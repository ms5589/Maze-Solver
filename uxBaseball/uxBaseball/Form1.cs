/*Form1.cs
* Author: Sagar Mehta
* Stores main dictionary, HashSet and will handle the event handlers
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace uxBaseball
{
    public partial class Form1 : Form
    {
        string s1;
        /// <summary>
        /// Store the information on each team from the csv file
        /// </summary>
        private Dictionary<string, TeamData> _teamInfo = new Dictionary<string, TeamData>();

        /// <summary>
        /// Store the abbreviation of each team that has been added to the combobox
        /// </summary>
        private HashSet<string> _teamAbbrevs = new HashSet<string>();
        
        /// <summary>
        /// Store the information on each game from the game logs that have been read
        /// </summary>
        private Dictionary<TeamAndDate, List<GameData>> _gameLog = new Dictionary<TeamAndDate, List<GameData>>();

        public Form1()
        {
            try
            {
                using (var rd = new StreamReader("TEAMABR.csv"))
                {
                    while (!rd.EndOfStream)
                    {
                        string[] splits = rd.ReadLine().Split(',');
                        s1 = splits[0]; //teamAbbrev
                        _teamInfo.Add(s1, new TeamData(splits));

                    } //  _teamAbbrevs.Add(s1);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            InitializeComponent();
        }

        private void uxOpen_Click(object sender, EventArgs e)
        {
            if (uxOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using(StreamReader input= new StreamReader(uxOpenFileDialog.FileName))
                    {
                        while (input.EndOfStream == false)
                        {
                            //comboBox1.Text = "";
                            string[] line = input.ReadLine().Split(',');
                            string[] temp = new string[101];
                            Array.Copy(line, temp,temp.Length);
                            for (int a = 0; a < temp.Length; a++)
                            {
                                StringBuilder sb = new StringBuilder();
                                for (int b = 0; b < temp[a].Length; b++)
                                {
                                    if (temp[a][b] != '\"')
                                    {
                                        sb.Append(temp[a][b]);
                                    }
                                } //end for1
                                temp[a] = sb.ToString();
                            } //end for 2 

                            TeamAndDate tad1 = new TeamAndDate(temp[3],temp[0]);
                            TeamAndDate tad2 = new TeamAndDate(temp[6],temp[0]);
                            GameData gd = new GameData(temp, _teamInfo);
                            if (!HashKey(tad1)) _gameLog[tad1] = new List<GameData>();
                            _gameLog[tad1].Add(gd);
                            if (!HashKey(tad2)) _gameLog[tad2] = new List<GameData>();
                            _gameLog[tad2].Add(gd);
                            if (!_teamAbbrevs.Contains(_teamInfo[gd.visitAbr].ToString()))
                            {
                                _teamAbbrevs.Add(_teamInfo[gd.visitAbr].ToString());
                            }
                            if (!_teamAbbrevs.Contains(_teamInfo[gd.homeAbr].ToString()))
                            {
                                _teamAbbrevs.Add(_teamInfo[gd.homeAbr].ToString());
                            }
                        }//end while
                        comboBox1.Items.Clear();
                            
                        foreach (string a in _teamAbbrevs)
                        {
                            comboBox1.Items.Add(a.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The following error occured:\n"+ex.ToString());
                }
            } 
        }// end event handler
        private bool HashKey(TeamAndDate t)
        {
            foreach (TeamAndDate i in _gameLog.Keys)
            {
                if(i == t) return true;
            } 
            return false;
        }

        private void uxResult_Click(object sender, EventArgs e)
        {
            string nameOfTeam="";
            foreach(string x in _teamInfo.Keys)
            {
                if (_teamInfo[x].ToString().Equals(comboBox1.Text))
                    nameOfTeam = x;
            }
            string dateOfGame = uxDateTimePicker.Value.Year.ToString() + uxDateTimePicker.Value.Month.ToString().PadLeft(2, '0') + uxDateTimePicker.Value.Day.ToString().PadLeft(2, '0');
            TeamAndDate hold = new TeamAndDate(nameOfTeam, dateOfGame);
            if (_gameLog.ContainsKey(hold))
            {
                foreach (GameData a in _gameLog[hold])
                {
                    GameInformationcs game = new GameInformationcs();
                    game.Show();
                    game.Text = a.gameData.ToShortDateString();
                    game.uxHome.Text = a.homeTeam;
                    game.uxVisitor.Text = a.visitingTeam;
                    game.uxWin.Text = a.winningPitcher;
                    game.uxLose.Text = a.losingPitcher;
                    game.uxSave.Text = a.save;
                    game.uxMvp.Text = a.mvp;
                    game.uxVisitScore.Text = a.visitScore.ToString();
                    game.uxHomeScore.Text = a.homeScore.ToString();
                }
            }
                else
                {
                    MessageBox.Show("No results for that team on that date");
                }
            }
        }
    }

