namespace lab9
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            inputReset = new Button();
            output = new Label();
            inputRadius = new NumericUpDown();
            infoBox = new Label();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem1 = new ToolStripMenuItem();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)inputRadius).BeginInit();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // inputReset
            // 
            inputReset.Location = new Point(352, 276);
            inputReset.Name = "inputReset";
            inputReset.Size = new Size(94, 29);
            inputReset.TabIndex = 0;
            inputReset.Text = "Reset";
            inputReset.UseVisualStyleBackColor = true;
            inputReset.Click += inputReset_Click;
            // 
            // output
            // 
            output.BackColor = SystemColors.ButtonHighlight;
            output.Location = new Point(298, 110);
            output.Name = "output";
            output.Size = new Size(204, 35);
            output.TabIndex = 1;
            output.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // inputRadius
            // 
            inputRadius.Location = new Point(298, 216);
            inputRadius.Name = "inputRadius";
            inputRadius.Size = new Size(204, 31);
            inputRadius.TabIndex = 2;
            inputRadius.ValueChanged += inputRadius_ValueChanged;
            // 
            // infoBox
            // 
            infoBox.Location = new Point(298, 168);
            infoBox.Name = "infoBox";
            infoBox.Size = new Size(204, 31);
            infoBox.TabIndex = 3;
            infoBox.Text = "Enter the Radius";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, aboutToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(803, 33);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(52, 29);
            fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(125, 30);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem1 });
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(58, 29);
            aboutToolStripMenuItem.Text = "Info";
            // 
            // aboutToolStripMenuItem1
            // 
            aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            aboutToolStripMenuItem1.Size = new Size(148, 30);
            aboutToolStripMenuItem1.Text = "About";
            aboutToolStripMenuItem1.Click += aboutToolStripMenuItem1_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(output);
            panel1.Controls.Add(infoBox);
            panel1.Controls.Add(inputReset);
            panel1.Controls.Add(inputRadius);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 33);
            panel1.Name = "panel1";
            panel1.Size = new Size(803, 416);
            panel1.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(803, 449);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)inputRadius).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button inputReset;
        private Label output;
        private NumericUpDown inputRadius;
        private Label infoBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem1;
        private Panel panel1;
    }
}
