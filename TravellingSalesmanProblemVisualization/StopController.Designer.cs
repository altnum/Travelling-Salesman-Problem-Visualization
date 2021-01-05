
namespace TravellingSalesmanProblemVisualization
{
    partial class StopController
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
            this.components = new System.ComponentModel.Container();
            this.StopButton = new System.Windows.Forms.Button();
            this.ContinueButton = new System.Windows.Forms.Button();
            this.BreakButton = new System.Windows.Forms.Button();
            this.Worktime = new System.Windows.Forms.Label();
            this.TimeHolder = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(12, 12);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 28);
            this.StopButton.TabIndex = 0;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // ContinueButton
            // 
            this.ContinueButton.Location = new System.Drawing.Point(12, 12);
            this.ContinueButton.Name = "ContinueButton";
            this.ContinueButton.Size = new System.Drawing.Size(75, 28);
            this.ContinueButton.TabIndex = 1;
            this.ContinueButton.Text = "Continue";
            this.ContinueButton.UseVisualStyleBackColor = true;
            this.ContinueButton.Visible = false;
            this.ContinueButton.Click += new System.EventHandler(this.ContinueButton_Click);
            // 
            // BreakButton
            // 
            this.BreakButton.Location = new System.Drawing.Point(103, 12);
            this.BreakButton.Name = "BreakButton";
            this.BreakButton.Size = new System.Drawing.Size(75, 28);
            this.BreakButton.TabIndex = 2;
            this.BreakButton.Text = "Break";
            this.BreakButton.UseVisualStyleBackColor = true;
            this.BreakButton.Click += new System.EventHandler(this.BreakButton_Click);
            // 
            // Worktime
            // 
            this.Worktime.AutoSize = true;
            this.Worktime.Location = new System.Drawing.Point(12, 56);
            this.Worktime.Name = "Worktime";
            this.Worktime.Size = new System.Drawing.Size(98, 17);
            this.Worktime.TabIndex = 3;
            this.Worktime.Text = "Working time: ";
            // 
            // TimeHolder
            // 
            this.TimeHolder.AutoSize = true;
            this.TimeHolder.Location = new System.Drawing.Point(116, 56);
            this.TimeHolder.Name = "TimeHolder";
            this.TimeHolder.Size = new System.Drawing.Size(16, 17);
            this.TimeHolder.TabIndex = 4;
            this.TimeHolder.Text = "0";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // StopController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 93);
            this.ControlBox = false;
            this.Controls.Add(this.TimeHolder);
            this.Controls.Add(this.Worktime);
            this.Controls.Add(this.BreakButton);
            this.Controls.Add(this.ContinueButton);
            this.Controls.Add(this.StopButton);
            this.Name = "StopController";
            this.Text = "Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StopController_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StopController_FormClosed);
            this.Load += new System.EventHandler(this.StopController_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button ContinueButton;
        private System.Windows.Forms.Button BreakButton;
        private System.Windows.Forms.Label Worktime;
        private System.Windows.Forms.Label TimeHolder;
        public System.Windows.Forms.Timer timer1;
    }
}