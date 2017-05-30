namespace WoWVoiceControl
{
    partial class BaseAbilityForm
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
            this.dgvAbilities = new System.Windows.Forms.DataGridView();
            this.abilityNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keybindColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bAccept = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbilities)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAbilities
            // 
            this.dgvAbilities.AllowUserToAddRows = false;
            this.dgvAbilities.AllowUserToDeleteRows = false;
            this.dgvAbilities.AllowUserToResizeColumns = false;
            this.dgvAbilities.AllowUserToResizeRows = false;
            this.dgvAbilities.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAbilities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAbilities.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.abilityNameColumn,
            this.keybindColumn});
            this.dgvAbilities.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvAbilities.Location = new System.Drawing.Point(14, 58);
            this.dgvAbilities.Name = "dgvAbilities";
            this.dgvAbilities.RowHeadersVisible = false;
            this.dgvAbilities.Size = new System.Drawing.Size(363, 327);
            this.dgvAbilities.TabIndex = 18;
            // 
            // abilityNameColumn
            // 
            this.abilityNameColumn.HeaderText = "Ability Name";
            this.abilityNameColumn.Name = "abilityNameColumn";
            this.abilityNameColumn.ReadOnly = true;
            // 
            // keybindColumn
            // 
            this.keybindColumn.HeaderText = "Keybind";
            this.keybindColumn.Name = "keybindColumn";
            this.keybindColumn.ReadOnly = true;
            // 
            // bAccept
            // 
            this.bAccept.Location = new System.Drawing.Point(158, 395);
            this.bAccept.Name = "bAccept";
            this.bAccept.Size = new System.Drawing.Size(75, 23);
            this.bAccept.TabIndex = 19;
            this.bAccept.Text = "Accept";
            this.bAccept.UseVisualStyleBackColor = true;
            this.bAccept.Click += new System.EventHandler(this.bAccept_Click);
            // 
            // BaseAbilityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 428);
            this.Controls.Add(this.bAccept);
            this.Controls.Add(this.dgvAbilities);
            this.Name = "BaseAbilityForm";
            this.Text = "AbilityForm";
            this.Load += new System.EventHandler(this.AbilityForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbilities)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAbilities;
        private System.Windows.Forms.DataGridViewTextBoxColumn abilityNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keybindColumn;
        private System.Windows.Forms.Button bAccept;
    }
}