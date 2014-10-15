/* UserInterface.cs
 * Author: Rod Howell
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
using Ksu.Cis300.MazeLibrary;

namespace Ksu.Cis300.MazeSolver
{
    /// <summary>
    /// A user interface for a maze solver.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles a New event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxNew_Click(object sender, EventArgs e)
        {
            uxMaze.Generate();
        }
        private bool DrawReal(Cell cell, bool[,] avoid)
        {
            if (!(uxMaze.IsInMaze(cell))) return true;
            Cell[] childcells = new Cell[4];
            avoid[cell.Row, cell.Column] = true;
            int count = 0;
            for (Direction d = Direction.North; d <= Direction.West; d++)
            {

                if (uxMaze.IsClear(cell, d) && (!uxMaze.IsInMaze(uxMaze.Step(cell, d)) || !avoid[uxMaze.Step(cell, d).Row, uxMaze.Step(cell, d).Column]))
                {
                    childcells[count] = uxMaze.Step(cell, d);
                    uxMaze.DrawPath(cell, d);
                    bool result = DrawReal(childcells[count], avoid);

                    if (result) return true;
                }
                uxMaze.ErasePath(childcells[count], d);
                uxMaze.Invalidate();
            }

            return false;
            /*if (flag == 1)
            {
                DrawReal(childcells[0], avoid);
                DrawReal(childcells[1], avoid);
                DrawReal(childcells[2], avoid);
                DrawReal(childcells[3], avoid);
            }
        */


        }


        /// <summary>
        /// Handes a MouseClick event on the maze.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxMaze_MouseClick(object sender, MouseEventArgs e)
        {
            Cell cell = uxMaze.GetCellFromPixel(e.Location);
            if (uxMaze.IsInMaze(cell))
            {
                //MessageBox.Show("starting point is " + cell.Row + " " + cell.Column);
                //MessageBox.Show(uxMaze.Height+" "+uxMaze.Width);
                uxMaze.EraseAllPaths();
                bool[,] avoid = new bool[uxMaze.MazeHeight, uxMaze.MazeWidth];
                bool result = DrawReal(cell, avoid);
                if (result == false)
                    MessageBox.Show("No path found");
                //DrawPath(cell)
                uxMaze.Invalidate();
            }
            /*   Cell cell = uxMaze.GetCellFromPixel(e.Location);
            if (uxMaze.IsInMaze(cell))
            {
                uxMaze.EraseAllPaths();
                //DrawPath(cell);
                uxMaze.Invalidate();
            } */
        }

        /// <summary>
        /// Draws a path from the given cell to an exit.
        /// If there is no path to an exit, displays a message to that effect.
        /// </summary>
        /// <param name="cell">The start of the path.</param>
        /*  private void DrawPath(Cell cell)
          {
              Stack<Direction> s = new Stack<Direction>();
              bool[,] visited = new bool[uxMaze.MazeHeight, uxMaze.MazeWidth];
              visited[cell.Row, cell.Column] = true;
              Direction dir = Direction.North;
              while (uxMaze.IsInMaze(cell))
              {
                  if (dir <= Direction.West)
                  {
                      Cell nextCell = uxMaze.Step(cell, dir);
                      if (uxMaze.IsClear(cell, dir) && (!uxMaze.IsInMaze(nextCell) || !visited[nextCell.Row, nextCell.Column]))
                      {
                          uxMaze.DrawPath(cell, dir);
                          cell = nextCell;
                          s.Push(dir);
                          dir = Direction.North;
                          if (uxMaze.IsInMaze(cell))
                          {
                              visited[cell.Row, cell.Column] = true;
                          }
                      }
                      else
                      {
                          dir++;
                      }
                  }
                  else if (s.Count > 0)
                  {
                      dir = s.Pop();
                      cell = uxMaze.ReverseStep(cell, dir);
                      uxMaze.ErasePath(cell, dir);
                      dir++;
                  }
                  else
                  {
                      MessageBox.Show("There is no path from this cell.");
                      return;
                  }
              }
          } */
    }
}