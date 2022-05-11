namespace CbOAlgorithms.GUI
{
    partial class StartContextWindow
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
            this.createContextHandlyButton = new System.Windows.Forms.Button();
            this.importContextButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createContextHandlyButton
            // 
            this.createContextHandlyButton.Location = new System.Drawing.Point(108, 163);
            this.createContextHandlyButton.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.createContextHandlyButton.Name = "createContextHandlyButton";
            this.createContextHandlyButton.Size = new System.Drawing.Size(229, 28);
            this.createContextHandlyButton.TabIndex = 10;
            this.createContextHandlyButton.Text = "Create context manually";
            this.createContextHandlyButton.UseVisualStyleBackColor = true;
            this.createContextHandlyButton.Click += new System.EventHandler(this.createContextHandlyButton_Click);
            // 
            // importContextButton
            // 
            this.importContextButton.Location = new System.Drawing.Point(108, 117);
            this.importContextButton.Margin = new System.Windows.Forms.Padding(13, 12, 13, 6);
            this.importContextButton.Name = "importContextButton";
            this.importContextButton.Size = new System.Drawing.Size(229, 28);
            this.importContextButton.TabIndex = 11;
            this.importContextButton.Text = "Import context from file";
            this.importContextButton.UseVisualStyleBackColor = true;
            this.importContextButton.Click += new System.EventHandler(this.importContextButton_Click);
            // 
            // StartContextWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 348);
            this.Controls.Add(this.createContextHandlyButton);
            this.Controls.Add(this.importContextButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StartContextWindow";
            this.Text = "StartContextWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button createContextHandlyButton;
        private System.Windows.Forms.Button importContextButton;
    }
}