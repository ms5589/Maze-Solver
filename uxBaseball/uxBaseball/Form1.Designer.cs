namespace uxBaseball
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uxDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.uxResult = new System.Windows.Forms.Button();
            this.uxOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.uxOpen = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // uxDateTimePicker
            // 
            this.uxDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.uxDateTimePicker.Location = new System.Drawing.Point(12, 112);
            this.uxDateTimePicker.MaxDate = new System.DateTime(2013, 12, 31, 0, 0, 0, 0);
            this.uxDateTimePicker.MinDate = new System.DateTime(1871, 1, 1, 0, 0, 0, 0);
            this.uxDateTimePicker.Name = "uxDateTimePicker";
            this.uxDateTimePicker.Size = new System.Drawing.Size(197, 20);
            this.uxDateTimePicker.TabIndex = 0;
            this.uxDateTimePicker.Value = new System.DateTime(2013, 12, 31, 0, 0, 0, 0);
            // 
            // uxResult
            // 
            this.uxResult.Location = new System.Drawing.Point(253, 103);
            this.uxResult.Name = "uxResult";
            this.uxResult.Size = new System.Drawing.Size(133, 42);
            this.uxResult.TabIndex = 1;
            this.uxResult.Text = "Get Game Result";
            this.uxResult.UseVisualStyleBackColor = true;
            this.uxResult.Click += new System.EventHandler(this.uxResult_Click);
            // 
            // uxOpenFileDialog
            // 
            this.uxOpenFileDialog.FileName = "openFileDialog1";
            // 
            // uxOpen
            // 
            this.uxOpen.Location = new System.Drawing.Point(12, 13);
            this.uxOpen.Name = "uxOpen";
            this.uxOpen.Size = new System.Drawing.Size(374, 36);
            this.uxOpen.TabIndex = 2;
            this.uxOpen.Text = "Add Data File";
            this.uxOpen.UseVisualStyleBackColor = true;
            this.uxOpen.Click += new System.EventHandler(this.uxOpen_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 66);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(374, 21);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 154);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.uxOpen);
            this.Controls.Add(this.uxResult);
            this.Controls.Add(this.uxDateTimePicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Baseball Scores";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker uxDateTimePicker;
        private System.Windows.Forms.Button uxResult;
        private System.Windows.Forms.OpenFileDialog uxOpenFileDialog;
        private System.Windows.Forms.Button uxOpen;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

