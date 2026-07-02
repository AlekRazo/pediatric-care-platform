namespace Citas.Presentation
{
    partial class FormDiasNoHabiles
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCerrar = new System.Windows.Forms.Button();
            this.buttonDeshabilitar = new System.Windows.Forms.Button();
            this.buttonHabilitar = new System.Windows.Forms.Button();
            this.dateTimePickerFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.labelFechaInicial = new System.Windows.Forms.Label();
            this.labelFechaFinal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxRango = new System.Windows.Forms.CheckBox();
            this.dataGridViewVerFechasNoHabiles = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVerFechasNoHabiles)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonCerrar);
            this.panel1.Controls.Add(this.buttonDeshabilitar);
            this.panel1.Controls.Add(this.buttonHabilitar);
            this.panel1.Controls.Add(this.dateTimePickerFechaFinal);
            this.panel1.Controls.Add(this.dateTimePickerFechaInicial);
            this.panel1.Controls.Add(this.labelFechaInicial);
            this.panel1.Controls.Add(this.labelFechaFinal);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.checkBoxRango);
            this.panel1.Controls.Add(this.dataGridViewVerFechasNoHabiles);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 408);
            this.panel1.TabIndex = 1;
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCerrar.Location = new System.Drawing.Point(427, 361);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(84, 32);
            this.buttonCerrar.TabIndex = 19;
            this.buttonCerrar.Text = "Cerrar";
            this.buttonCerrar.UseVisualStyleBackColor = true;
            this.buttonCerrar.Click += new System.EventHandler(this.buttonCerrar_Click);
            // 
            // buttonDeshabilitar
            // 
            this.buttonDeshabilitar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeshabilitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeshabilitar.Location = new System.Drawing.Point(298, 361);
            this.buttonDeshabilitar.Name = "buttonDeshabilitar";
            this.buttonDeshabilitar.Size = new System.Drawing.Size(123, 32);
            this.buttonDeshabilitar.TabIndex = 18;
            this.buttonDeshabilitar.Text = "Deshabilitar";
            this.buttonDeshabilitar.UseVisualStyleBackColor = true;
            this.buttonDeshabilitar.Click += new System.EventHandler(this.buttonDeshabilitar_Click);
            // 
            // buttonHabilitar
            // 
            this.buttonHabilitar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHabilitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHabilitar.Location = new System.Drawing.Point(170, 361);
            this.buttonHabilitar.Name = "buttonHabilitar";
            this.buttonHabilitar.Size = new System.Drawing.Size(122, 32);
            this.buttonHabilitar.TabIndex = 17;
            this.buttonHabilitar.Text = "Habilitar";
            this.buttonHabilitar.UseVisualStyleBackColor = true;
            this.buttonHabilitar.Click += new System.EventHandler(this.buttonHabilitar_Click);
            // 
            // dateTimePickerFechaFinal
            // 
            this.dateTimePickerFechaFinal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePickerFechaFinal.Location = new System.Drawing.Point(132, 296);
            this.dateTimePickerFechaFinal.Name = "dateTimePickerFechaFinal";
            this.dateTimePickerFechaFinal.Size = new System.Drawing.Size(204, 20);
            this.dateTimePickerFechaFinal.TabIndex = 16;
            this.dateTimePickerFechaFinal.Visible = false;
            // 
            // dateTimePickerFechaInicial
            // 
            this.dateTimePickerFechaInicial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePickerFechaInicial.Location = new System.Drawing.Point(132, 248);
            this.dateTimePickerFechaInicial.Name = "dateTimePickerFechaInicial";
            this.dateTimePickerFechaInicial.Size = new System.Drawing.Size(204, 20);
            this.dateTimePickerFechaInicial.TabIndex = 15;
            // 
            // labelFechaInicial
            // 
            this.labelFechaInicial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelFechaInicial.AutoSize = true;
            this.labelFechaInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFechaInicial.Location = new System.Drawing.Point(19, 248);
            this.labelFechaInicial.Name = "labelFechaInicial";
            this.labelFechaInicial.Size = new System.Drawing.Size(59, 18);
            this.labelFechaInicial.TabIndex = 14;
            this.labelFechaInicial.Text = "Fecha:";
            // 
            // labelFechaFinal
            // 
            this.labelFechaFinal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelFechaFinal.AutoSize = true;
            this.labelFechaFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFechaFinal.Location = new System.Drawing.Point(19, 296);
            this.labelFechaFinal.Name = "labelFechaFinal";
            this.labelFechaFinal.Size = new System.Drawing.Size(100, 18);
            this.labelFechaFinal.TabIndex = 13;
            this.labelFechaFinal.Text = "Fecha Final:";
            this.labelFechaFinal.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "Fecha con Rango:";
            // 
            // checkBoxRango
            // 
            this.checkBoxRango.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxRango.AutoSize = true;
            this.checkBoxRango.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxRango.Location = new System.Drawing.Point(171, 208);
            this.checkBoxRango.Name = "checkBoxRango";
            this.checkBoxRango.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxRango.Size = new System.Drawing.Size(15, 14);
            this.checkBoxRango.TabIndex = 11;
            this.checkBoxRango.UseVisualStyleBackColor = true;
            this.checkBoxRango.CheckedChanged += new System.EventHandler(this.checkBoxRango_CheckedChanged);
            // 
            // dataGridViewVerFechasNoHabiles
            // 
            this.dataGridViewVerFechasNoHabiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewVerFechasNoHabiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVerFechasNoHabiles.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewVerFechasNoHabiles.Name = "dataGridViewVerFechasNoHabiles";
            this.dataGridViewVerFechasNoHabiles.ReadOnly = true;
            this.dataGridViewVerFechasNoHabiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewVerFechasNoHabiles.Size = new System.Drawing.Size(522, 184);
            this.dataGridViewVerFechasNoHabiles.TabIndex = 10;
            this.dataGridViewVerFechasNoHabiles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewVerFechasNoHabiles_CellClick);
            // 
            // FormDiasNoHabiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 430);
            this.Controls.Add(this.panel1);
            this.Name = "FormDiasNoHabiles";
            this.Text = "Dias No Habiles";
            this.Load += new System.EventHandler(this.FormDiasNoHabiles_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVerFechasNoHabiles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonCerrar;
        private System.Windows.Forms.Button buttonDeshabilitar;
        private System.Windows.Forms.Button buttonHabilitar;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaFinal;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaInicial;
        private System.Windows.Forms.Label labelFechaInicial;
        private System.Windows.Forms.Label labelFechaFinal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxRango;
        private System.Windows.Forms.DataGridView dataGridViewVerFechasNoHabiles;
    }
}