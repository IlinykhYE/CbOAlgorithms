namespace CbOAlgorithms
{
    partial class ShowGraphWindow
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.savePngButton = new System.Windows.Forms.Button();
            this.saveDotFileButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.savePngFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.pictureBox, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(837, 104);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 566F));
            this.tableLayoutPanel1.Controls.Add(this.savePngButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.saveDotFileButton, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1192, 51);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // savePngButton
            // 
            this.savePngButton.Location = new System.Drawing.Point(13, 12);
            this.savePngButton.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.savePngButton.Name = "savePngButton";
            this.savePngButton.Size = new System.Drawing.Size(287, 28);
            this.savePngButton.TabIndex = 0;
            this.savePngButton.Text = "Save as png";
            this.savePngButton.UseVisualStyleBackColor = true;
            this.savePngButton.Click += new System.EventHandler(this.onClickSavePngButton);
            // 
            // saveDotFileButton
            // 
            this.saveDotFileButton.Location = new System.Drawing.Point(326, 12);
            this.saveDotFileButton.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.saveDotFileButton.Name = "saveDotFileButton";
            this.saveDotFileButton.Size = new System.Drawing.Size(287, 28);
            this.saveDotFileButton.TabIndex = 1;
            this.saveDotFileButton.Text = "Save as .dot";
            this.saveDotFileButton.UseVisualStyleBackColor = true;
            this.saveDotFileButton.Click += new System.EventHandler(this.onClickSaveDotFileButton);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Location = new System.Drawing.Point(4, 63);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox.MinimumSize = new System.Drawing.Size(427, 295);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1192, 295);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // ShowGraphWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(837, 104);
            this.Controls.Add(this.tableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ShowGraphWindow";
            this.ShowIcon = false;
            this.Text = "Conceptual grid";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.onCloseWindow);
            this.Load += new System.EventHandler(this.ShowGraphWindow_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button savePngButton;
        private System.Windows.Forms.Button saveDotFileButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.SaveFileDialog savePngFileDialog;
    }
}