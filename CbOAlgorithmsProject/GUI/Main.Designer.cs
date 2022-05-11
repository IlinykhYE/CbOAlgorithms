namespace CbOAlgorithms.GUI
{
    partial class Main
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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьКонтекстToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemContext = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьКонтекстВручнуюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportContextFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateRandomContextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.latticeTextBox = new System.Windows.Forms.TextBox();
            this.toolsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.LCM = new System.Windows.Forms.Button();
            this.buildConceptButton = new System.Windows.Forms.Button();
            this.CbOV1 = new System.Windows.Forms.Button();
            this.editModelCheckBox = new System.Windows.Forms.CheckBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.importContextBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.createLatticeBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.createLatticeCbOV1BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.createLatticeLCMBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            label1 = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.toolsTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 263);
            label1.Margin = new System.Windows.Forms.Padding(13, 12, 13, 6);
            label1.MinimumSize = new System.Drawing.Size(0, 18);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(107, 18);
            label1.TabIndex = 2;
            label1.Text = "Conceptual grid";
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.progressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 674);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(1116, 26);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(57, 20);
            this.toolStripStatusLabel.Text = "Готово";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(133, 18);
            this.progressBar.Visible = false;
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.toolStripMenuItemContext});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1116, 28);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.закрытьКонтекстToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.файлToolStripMenuItem.Text = "File";
            // 
            // закрытьКонтекстToolStripMenuItem
            // 
            this.закрытьКонтекстToolStripMenuItem.Name = "закрытьКонтекстToolStripMenuItem";
            this.закрытьКонтекстToolStripMenuItem.Size = new System.Drawing.Size(126, 26);
            this.закрытьКонтекстToolStripMenuItem.Text = "Clear";
            this.закрытьКонтекстToolStripMenuItem.Click += new System.EventHandler(this.OnClickCloseContext);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(126, 26);
            this.выходToolStripMenuItem.Text = "Exit";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.OnClickExit);
            // 
            // toolStripMenuItemContext
            // 
            this.toolStripMenuItemContext.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьКонтекстВручнуюToolStripMenuItem,
            this.ImportContextFromFileToolStripMenuItem,
            this.CreateRandomContextToolStripMenuItem});
            this.toolStripMenuItemContext.Name = "toolStripMenuItemContext";
            this.toolStripMenuItemContext.Size = new System.Drawing.Size(74, 24);
            this.toolStripMenuItemContext.Text = "Context";
            // 
            // создатьКонтекстВручнуюToolStripMenuItem
            // 
            this.создатьКонтекстВручнуюToolStripMenuItem.Name = "создатьКонтекстВручнуюToolStripMenuItem";
            this.создатьКонтекстВручнуюToolStripMenuItem.Size = new System.Drawing.Size(290, 26);
            this.создатьКонтекстВручнуюToolStripMenuItem.Text = "Создать контекст вручную";
            this.создатьКонтекстВручнуюToolStripMenuItem.Click += new System.EventHandler(this.CreateContextHandlyToolStripMenuItem_Click);
            // 
            // ImportContextFromFileToolStripMenuItem
            // 
            this.ImportContextFromFileToolStripMenuItem.Name = "ImportContextFromFileToolStripMenuItem";
            this.ImportContextFromFileToolStripMenuItem.Size = new System.Drawing.Size(290, 26);
            this.ImportContextFromFileToolStripMenuItem.Text = "Импорт контекста из файла";
            this.ImportContextFromFileToolStripMenuItem.Click += new System.EventHandler(this.ImportContextFromFileToolStripMenuItem_Click);
            // 
            // CreateRandomContextToolStripMenuItem
            // 
            this.CreateRandomContextToolStripMenuItem.Name = "CreateRandomContextToolStripMenuItem";
            this.CreateRandomContextToolStripMenuItem.Size = new System.Drawing.Size(290, 26);
            this.CreateRandomContextToolStripMenuItem.Text = "Создать случайный контекст";
            this.CreateRandomContextToolStripMenuItem.Click += new System.EventHandler(this.CreateRandomContextToolStripMenuItem_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 267F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1116, 646);
            this.tableLayoutPanel.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.latticeTextBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.toolsTableLayoutPanel, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.14286F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.85714F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 162F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1108, 638);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.ColumnHeadersVisible = false;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.Location = new System.Drawing.Point(4, 4);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.MinimumSize = new System.Drawing.Size(533, 246);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView.Size = new System.Drawing.Size(1100, 246);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.EditModeChanged += new System.EventHandler(this.EditModeChanged);
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellDoubleClick);
            this.dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellEndEdit);
            this.dataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.CellMouseClick);
            /*this.dataGridView.SelectionChanged += new System.EventHandler(this.CellSelectionChanged)*/;
            this.dataGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPressWithSelectedCell);
            // 
            // latticeTextBox
            // 
            this.latticeTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.latticeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.latticeTextBox.Location = new System.Drawing.Point(4, 291);
            this.latticeTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.latticeTextBox.Multiline = true;
            this.latticeTextBox.Name = "latticeTextBox";
            this.latticeTextBox.ReadOnly = true;
            this.latticeTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.latticeTextBox.Size = new System.Drawing.Size(1100, 180);
            this.latticeTextBox.TabIndex = 3;
            // 
            // toolsTableLayoutPanel
            // 
            this.toolsTableLayoutPanel.ColumnCount = 3;
            this.toolsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.toolsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 301F));
            this.toolsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 411F));
            this.toolsTableLayoutPanel.Controls.Add(this.LCM, 2, 0);
            this.toolsTableLayoutPanel.Controls.Add(this.buildConceptButton, 1, 4);
            this.toolsTableLayoutPanel.Controls.Add(this.CbOV1, 1, 0);
            this.toolsTableLayoutPanel.Controls.Add(this.editModelCheckBox, 0, 0);
            this.toolsTableLayoutPanel.Location = new System.Drawing.Point(4, 479);
            this.toolsTableLayoutPanel.Margin = new System.Windows.Forms.Padding(4);
            this.toolsTableLayoutPanel.Name = "toolsTableLayoutPanel";
            this.toolsTableLayoutPanel.RowCount = 8;
            this.toolsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.toolsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.toolsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.toolsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.toolsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.toolsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.toolsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.toolsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.toolsTableLayoutPanel.Size = new System.Drawing.Size(1100, 134);
            this.toolsTableLayoutPanel.TabIndex = 1;
            // 
            // LCM
            // 
            this.LCM.Location = new System.Drawing.Point(702, 12);
            this.LCM.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.LCM.Name = "LCM";
            this.LCM.Size = new System.Drawing.Size(236, 42);
            this.LCM.TabIndex = 9;
            this.LCM.Text = "LCM";
            this.LCM.UseVisualStyleBackColor = true;
            this.LCM.Click += new System.EventHandler(this.LCM_Click);
            // 
            // buildConceptButton
            // 
            this.buildConceptButton.Enabled = false;
            this.buildConceptButton.Location = new System.Drawing.Point(401, 78);
            this.buildConceptButton.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.buildConceptButton.Name = "buildConceptButton";
            this.buildConceptButton.Size = new System.Drawing.Size(240, 42);
            this.buildConceptButton.TabIndex = 6;
            this.buildConceptButton.Text = "CbO v2";
            this.buildConceptButton.UseVisualStyleBackColor = true;
            this.buildConceptButton.Click += new System.EventHandler(this.OnClickBuildConceptButton);
            // 
            // CbOV1
            // 
            this.CbOV1.Location = new System.Drawing.Point(401, 12);
            this.CbOV1.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.CbOV1.Name = "CbOV1";
            this.CbOV1.Size = new System.Drawing.Size(240, 42);
            this.CbOV1.TabIndex = 8;
            this.CbOV1.Text = "CbO v1";
            this.CbOV1.UseVisualStyleBackColor = true;
            this.CbOV1.Click += new System.EventHandler(this.button1_Click);
            // 
            // editModelCheckBox
            // 
            this.editModelCheckBox.AutoSize = true;
            this.editModelCheckBox.Enabled = false;
            this.editModelCheckBox.Location = new System.Drawing.Point(13, 12);
            this.editModelCheckBox.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.editModelCheckBox.Name = "editModelCheckBox";
            this.editModelCheckBox.Size = new System.Drawing.Size(54, 21);
            this.editModelCheckBox.TabIndex = 2;
            this.editModelCheckBox.Text = "Edit";
            this.editModelCheckBox.UseVisualStyleBackColor = true;
            this.editModelCheckBox.CheckedChanged += new System.EventHandler(this.EditModeChanged);
            // 
            // importContextBackgroundWorker
            // 
            this.importContextBackgroundWorker.WorkerReportsProgress = true;
            this.importContextBackgroundWorker.WorkerSupportsCancellation = true;
            this.importContextBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork_importContext);
            this.importContextBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Bw_ProgressChanged_importContext);
            this.importContextBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted_importContext);
            // 
            // createLatticeBackgroundWorker
            // 
            this.createLatticeBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.createLatticeBackgroundWorker_DoWork);
            this.createLatticeBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.createLatticeBackgroundWorker_RunWorkerCompleted);
            // 
            // createLatticeCbOV1BackgroundWorker
            // 
            this.createLatticeCbOV1BackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.createLatticeCbOV1BackgroundWorker_DoWork);
            this.createLatticeCbOV1BackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.createLatticeBackgroundWorker_RunWorkerCompleted);
            // 
            // createLatticeLCMBackgroundWorker
            // 
            this.createLatticeLCMBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.createLatticeLCMWithoutPruningBackgroundWorker_DoWork);
            this.createLatticeLCMBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.createLatticeBackgroundWorker_RunWorkerCompleted);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1116, 700);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1101, 678);
            this.Name = "Main";
            this.Text = "CbO algorithms";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnCloseMainForm);
            this.Load += new System.EventHandler(this.Main_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.toolsTableLayoutPanel.ResumeLayout(false);
            this.toolsTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьКонтекстToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.ComponentModel.BackgroundWorker importContextBackgroundWorker;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox latticeTextBox;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.ComponentModel.BackgroundWorker createLatticeBackgroundWorker;
        private System.ComponentModel.BackgroundWorker createLatticeCbOV1BackgroundWorker;
        private System.ComponentModel.BackgroundWorker createLatticeLCMBackgroundWorker;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemContext;
        private System.Windows.Forms.ToolStripMenuItem создатьКонтекстВручнуюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImportContextFromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateRandomContextToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel toolsTableLayoutPanel;
        private System.Windows.Forms.CheckBox editModelCheckBox;
        private System.Windows.Forms.Button buildConceptButton;
        private System.Windows.Forms.Button CbOV1;
        private System.Windows.Forms.Button LCM;
    }
}

