
namespace TravellingSalesmanProblemVisualization
{
    partial class TravellingSalesman
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
            this.AddTowns = new System.Windows.Forms.RadioButton();
            this.RemoveTowns = new System.Windows.Forms.RadioButton();
            this.RemoveAllTowns = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Start = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.distanceStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddTowns
            // 
            this.AddTowns.AutoSize = true;
            this.AddTowns.Checked = true;
            this.AddTowns.Location = new System.Drawing.Point(17, 11);
            this.AddTowns.Name = "AddTowns";
            this.AddTowns.Size = new System.Drawing.Size(94, 21);
            this.AddTowns.TabIndex = 0;
            this.AddTowns.TabStop = true;
            this.AddTowns.Text = "Add towns";
            this.AddTowns.UseVisualStyleBackColor = false;
            // 
            // RemoveTowns
            // 
            this.RemoveTowns.AutoSize = true;
            this.RemoveTowns.Location = new System.Drawing.Point(17, 38);
            this.RemoveTowns.Name = "RemoveTowns";
            this.RemoveTowns.Size = new System.Drawing.Size(121, 21);
            this.RemoveTowns.TabIndex = 1;
            this.RemoveTowns.Text = "Remove towns";
            this.RemoveTowns.UseVisualStyleBackColor = true;
            // 
            // RemoveAllTowns
            // 
            this.RemoveAllTowns.Location = new System.Drawing.Point(8, 65);
            this.RemoveAllTowns.Name = "RemoveAllTowns";
            this.RemoveAllTowns.Size = new System.Drawing.Size(130, 35);
            this.RemoveAllTowns.TabIndex = 0;
            this.RemoveAllTowns.Text = "Remove All";
            this.RemoveAllTowns.UseVisualStyleBackColor = true;
            this.RemoveAllTowns.Click += new System.EventHandler(this.RemoveAllTowns_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.Start);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.AddTowns);
            this.panel1.Controls.Add(this.RemoveAllTowns);
            this.panel1.Controls.Add(this.RemoveTowns);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(173, 852);
            this.panel1.TabIndex = 2;
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(8, 209);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(130, 29);
            this.Start.TabIndex = 5;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "DynamicProgramming",
            "Branch&Bound",
            "Backtracking"});
            this.comboBox1.Location = new System.Drawing.Point(8, 162);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(130, 24);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Text = "Select algorithm";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.distanceStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 827);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1402, 26);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // distanceStatus
            // 
            this.distanceStatus.Name = "distanceStatus";
            this.distanceStatus.Size = new System.Drawing.Size(73, 20);
            this.distanceStatus.Text = "Distance: ";
            // 
            // TravellingSalesman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1402, 853);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TravellingSalesman";
            this.Text = "TravellingSalesman";
            this.Load += new System.EventHandler(this.TravellingSalesman_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TravellingSalesman_MouseUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton AddTowns;
        private System.Windows.Forms.RadioButton RemoveTowns;
        private System.Windows.Forms.Button RemoveAllTowns;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel distanceStatus;
    }
}

