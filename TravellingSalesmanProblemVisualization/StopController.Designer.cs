
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
            this.Worktime = new System.Windows.Forms.Label();
            this.TimeHolder = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BreakButton = new System.Windows.Forms.Button();
            this.ContinueButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Worktime
            // 
            this.Worktime.AutoSize = true;
            this.Worktime.Location = new System.Drawing.Point(12, 65);
            this.Worktime.Name = "Worktime";
            this.Worktime.Size = new System.Drawing.Size(98, 17);
            this.Worktime.TabIndex = 3;
            this.Worktime.Text = "Working time: ";
            // 
            // TimeHolder
            // 
            this.TimeHolder.AutoSize = true;
            this.TimeHolder.Location = new System.Drawing.Point(116, 65);
            this.TimeHolder.Name = "TimeHolder";
            this.TimeHolder.Size = new System.Drawing.Size(16, 17);
            this.TimeHolder.TabIndex = 4;
            this.TimeHolder.Text = "0";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BreakButton
            // 
            this.BreakButton.Image = global::TravellingSalesmanProblemVisualization.Properties.Resources.break7;
            this.BreakButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BreakButton.Location = new System.Drawing.Point(177, 55);
            this.BreakButton.Name = "BreakButton";
            this.BreakButton.Size = new System.Drawing.Size(129, 36);
            this.BreakButton.TabIndex = 2;
            this.BreakButton.Text = "Break";
            this.BreakButton.UseVisualStyleBackColor = true;
            this.BreakButton.Visible = false;
            this.BreakButton.Click += new System.EventHandler(this.BreakButton_Click);
            // 
            // ContinueButton
            // 
            this.ContinueButton.Image = global::TravellingSalesmanProblemVisualization.Properties.Resources.Continue;
            this.ContinueButton.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.ContinueButton.Location = new System.Drawing.Point(12, 5);
            this.ContinueButton.Name = "ContinueButton";
            this.ContinueButton.Size = new System.Drawing.Size(294, 44);
            this.ContinueButton.TabIndex = 1;
            this.ContinueButton.Text = "Continue";
            this.ContinueButton.UseVisualStyleBackColor = true;
            this.ContinueButton.Visible = false;
            this.ContinueButton.Click += new System.EventHandler(this.ContinueButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Image = global::TravellingSalesmanProblemVisualization.Properties.Resources.Stop1;
            this.StopButton.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.StopButton.Location = new System.Drawing.Point(12, 5);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(258, 35);
            this.StopButton.TabIndex = 0;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // StopController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 145);
            this.ControlBox = false;
            this.Controls.Add(this.TimeHolder);
            this.Controls.Add(this.Worktime);
            this.Controls.Add(this.BreakButton);
            this.Controls.Add(this.ContinueButton);
            this.Controls.Add(this.StopButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
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