namespace CbOAlgorithms
{
    partial class SaveChangesForm
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
            System.Windows.Forms.Label label1;
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.latticeCheckBox = new System.Windows.Forms.CheckBox();
            this.pngCheckBox = new System.Windows.Forms.CheckBox();
            this.dotCheckBox = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(17, 16);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(127, 16);
            label1.TabIndex = 2;
            label1.Text = "Chose data for save";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(251, 151);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 28);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(143, 151);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 28);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // latticeCheckBox
            // 
            this.latticeCheckBox.AutoSize = true;
            this.latticeCheckBox.Location = new System.Drawing.Point(21, 50);
            this.latticeCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.latticeCheckBox.Name = "latticeCheckBox";
            this.latticeCheckBox.Size = new System.Drawing.Size(128, 20);
            this.latticeCheckBox.TabIndex = 3;
            this.latticeCheckBox.Text = "Concept grid (txt)";
            this.latticeCheckBox.UseVisualStyleBackColor = true;
            this.latticeCheckBox.CheckedChanged += new System.EventHandler(this.onCheckedChanged);
            // 
            // pngCheckBox
            // 
            this.pngCheckBox.AutoSize = true;
            this.pngCheckBox.Location = new System.Drawing.Point(21, 80);
            this.pngCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pngCheckBox.Name = "pngCheckBox";
            this.pngCheckBox.Size = new System.Drawing.Size(179, 20);
            this.pngCheckBox.TabIndex = 4;
            this.pngCheckBox.Text = "Visualisation of grid (png)";
            this.pngCheckBox.UseVisualStyleBackColor = true;
            this.pngCheckBox.CheckedChanged += new System.EventHandler(this.onCheckedChanged);
            // 
            // dotCheckBox
            // 
            this.dotCheckBox.AutoSize = true;
            this.dotCheckBox.Location = new System.Drawing.Point(21, 110);
            this.dotCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dotCheckBox.Name = "dotCheckBox";
            this.dotCheckBox.Size = new System.Drawing.Size(175, 20);
            this.dotCheckBox.TabIndex = 5;
            this.dotCheckBox.Text = "Visualisation of grid (dot)";
            this.dotCheckBox.UseVisualStyleBackColor = true;
            this.dotCheckBox.CheckedChanged += new System.EventHandler(this.onCheckedChanged);
            // 
            // SaveChangesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(364, 185);
            this.Controls.Add(this.dotCheckBox);
            this.Controls.Add(this.pngCheckBox);
            this.Controls.Add(this.latticeCheckBox);
            this.Controls.Add(label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(382, 232);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(382, 232);
            this.Name = "SaveChangesForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Save";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox latticeCheckBox;
        private System.Windows.Forms.CheckBox pngCheckBox;
        private System.Windows.Forms.CheckBox dotCheckBox;
    }
}