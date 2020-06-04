namespace saveBackupCreator
{
    partial class formSaveBackup
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
            this.comboBoxSaves = new System.Windows.Forms.ComboBox();
            this.labelSaves = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonRestore = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.labelFrequency = new System.Windows.Forms.Label();
            this.comboBoxFrequency = new System.Windows.Forms.ComboBox();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.buttonSaveSettings = new System.Windows.Forms.Button();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxSaves
            // 
            this.comboBoxSaves.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSaves.FormattingEnabled = true;
            this.comboBoxSaves.Location = new System.Drawing.Point(208, 41);
            this.comboBoxSaves.Name = "comboBoxSaves";
            this.comboBoxSaves.Size = new System.Drawing.Size(522, 24);
            this.comboBoxSaves.TabIndex = 3;
            this.comboBoxSaves.SelectionChangeCommitted += new System.EventHandler(this.comboBoxSaves_SelectionChangeCommitted);
            // 
            // labelSaves
            // 
            this.labelSaves.AutoSize = true;
            this.labelSaves.Location = new System.Drawing.Point(77, 44);
            this.labelSaves.Name = "labelSaves";
            this.labelSaves.Size = new System.Drawing.Size(45, 17);
            this.labelSaves.TabIndex = 4;
            this.labelSaves.Text = "saves";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(139, 157);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.Text = "delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonRestore
            // 
            this.buttonRestore.Location = new System.Drawing.Point(231, 157);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(75, 23);
            this.buttonRestore.TabIndex = 6;
            this.buttonRestore.Text = "restore";
            this.buttonRestore.UseVisualStyleBackColor = true;
            this.buttonRestore.Click += new System.EventHandler(this.buttonRestore_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(47, 157);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 7;
            this.buttonUpdate.Text = "update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // labelFrequency
            // 
            this.labelFrequency.AutoSize = true;
            this.labelFrequency.Location = new System.Drawing.Point(15, 93);
            this.labelFrequency.Name = "labelFrequency";
            this.labelFrequency.Size = new System.Drawing.Size(107, 17);
            this.labelFrequency.TabIndex = 8;
            this.labelFrequency.Text = "frequency (min)";
            // 
            // comboBoxFrequency
            // 
            this.comboBoxFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFrequency.FormattingEnabled = true;
            this.comboBoxFrequency.Location = new System.Drawing.Point(208, 90);
            this.comboBoxFrequency.Name = "comboBoxFrequency";
            this.comboBoxFrequency.Size = new System.Drawing.Size(121, 24);
            this.comboBoxFrequency.TabIndex = 9;
            // 
            // buttonSaveSettings
            // 
            this.buttonSaveSettings.Location = new System.Drawing.Point(321, 157);
            this.buttonSaveSettings.Name = "buttonSaveSettings";
            this.buttonSaveSettings.Size = new System.Drawing.Size(103, 23);
            this.buttonSaveSettings.TabIndex = 10;
            this.buttonSaveSettings.Text = "save settings";
            this.buttonSaveSettings.UseVisualStyleBackColor = true;
            this.buttonSaveSettings.Click += new System.EventHandler(this.buttonSaveSettings_Click);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Image = global::saveBackupCreator.Properties.Resources.folder1;
            this.buttonBrowse.Location = new System.Drawing.Point(181, 44);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(21, 18);
            this.buttonBrowse.TabIndex = 11;
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(444, 156);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(101, 23);
            this.buttonStart.TabIndex = 12;
            this.buttonStart.Text = "start backup";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(562, 157);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(106, 23);
            this.buttonStop.TabIndex = 13;
            this.buttonStop.Text = "stop backup";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // formSaveBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.buttonSaveSettings);
            this.Controls.Add(this.comboBoxFrequency);
            this.Controls.Add(this.labelFrequency);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonRestore);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.labelSaves);
            this.Controls.Add(this.comboBoxSaves);
            this.HelpButton = true;
            this.Name = "formSaveBackup";
            this.Text = "Save Backup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxSaves;
        private System.Windows.Forms.Label labelSaves;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonRestore;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Label labelFrequency;
        private System.Windows.Forms.ComboBox comboBoxFrequency;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Button buttonSaveSettings;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
    }
}

