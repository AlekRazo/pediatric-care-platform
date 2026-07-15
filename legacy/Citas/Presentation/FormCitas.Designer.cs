namespace Citas.Presentation
{
    partial class FormCitas
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
            this.labelNomUser = new System.Windows.Forms.Label();
            this.buttonDiasNoHabiles = new System.Windows.Forms.Button();
            this.buttonEliminarCita = new System.Windows.Forms.Button();
            this.buttonModificarCita = new System.Windows.Forms.Button();
            this.buttonAgregarCita = new System.Windows.Forms.Button();
            this.dataGridViewVerCitas = new System.Windows.Forms.DataGridView();
            this.labelDiaCita = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabelCerrarSesion = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerDiaCita = new System.Windows.Forms.DateTimePicker();
            this.buttonVerEstadisticas = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVerCitas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.buttonVerEstadisticas);
            this.panel1.Controls.Add(this.labelNomUser);
            this.panel1.Controls.Add(this.buttonDiasNoHabiles);
            this.panel1.Controls.Add(this.buttonEliminarCita);
            this.panel1.Controls.Add(this.buttonModificarCita);
            this.panel1.Controls.Add(this.buttonAgregarCita);
            this.panel1.Controls.Add(this.dataGridViewVerCitas);
            this.panel1.Controls.Add(this.labelDiaCita);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.linkLabelCerrarSesion);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateTimePickerDiaCita);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 492);
            this.panel1.TabIndex = 1;
            // 
            // labelNomUser
            // 
            this.labelNomUser.AutoSize = true;
            this.labelNomUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomUser.Location = new System.Drawing.Point(3, 0);
            this.labelNomUser.Name = "labelNomUser";
            this.labelNomUser.Size = new System.Drawing.Size(204, 24);
            this.labelNomUser.TabIndex = 75;
            this.labelNomUser.Text = "Bienvenido Usuario: ";
            // 
            // buttonDiasNoHabiles
            // 
            this.buttonDiasNoHabiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDiasNoHabiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDiasNoHabiles.Location = new System.Drawing.Point(350, 432);
            this.buttonDiasNoHabiles.Name = "buttonDiasNoHabiles";
            this.buttonDiasNoHabiles.Size = new System.Drawing.Size(141, 44);
            this.buttonDiasNoHabiles.TabIndex = 19;
            this.buttonDiasNoHabiles.Text = "Agregar/Quitar Dias Habiles";
            this.buttonDiasNoHabiles.UseVisualStyleBackColor = true;
            this.buttonDiasNoHabiles.Click += new System.EventHandler(this.buttonDiasNoHabiles_Click);
            // 
            // buttonEliminarCita
            // 
            this.buttonEliminarCita.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonEliminarCita.Enabled = false;
            this.buttonEliminarCita.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEliminarCita.Location = new System.Drawing.Point(230, 440);
            this.buttonEliminarCita.Name = "buttonEliminarCita";
            this.buttonEliminarCita.Size = new System.Drawing.Size(96, 29);
            this.buttonEliminarCita.TabIndex = 18;
            this.buttonEliminarCita.Text = "Eliminar";
            this.buttonEliminarCita.UseVisualStyleBackColor = true;
            this.buttonEliminarCita.Click += new System.EventHandler(this.buttonEliminarCita_Click);
            // 
            // buttonModificarCita
            // 
            this.buttonModificarCita.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonModificarCita.Enabled = false;
            this.buttonModificarCita.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModificarCita.Location = new System.Drawing.Point(128, 440);
            this.buttonModificarCita.Name = "buttonModificarCita";
            this.buttonModificarCita.Size = new System.Drawing.Size(96, 29);
            this.buttonModificarCita.TabIndex = 17;
            this.buttonModificarCita.Text = "Modificar";
            this.buttonModificarCita.UseVisualStyleBackColor = true;
            this.buttonModificarCita.Click += new System.EventHandler(this.buttonModificarCita_Click);
            // 
            // buttonAgregarCita
            // 
            this.buttonAgregarCita.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAgregarCita.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAgregarCita.Location = new System.Drawing.Point(26, 440);
            this.buttonAgregarCita.Name = "buttonAgregarCita";
            this.buttonAgregarCita.Size = new System.Drawing.Size(96, 29);
            this.buttonAgregarCita.TabIndex = 16;
            this.buttonAgregarCita.Text = "Agregar";
            this.buttonAgregarCita.UseVisualStyleBackColor = true;
            this.buttonAgregarCita.Click += new System.EventHandler(this.buttonAgregarCita_Click);
            // 
            // dataGridViewVerCitas
            // 
            this.dataGridViewVerCitas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewVerCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVerCitas.Location = new System.Drawing.Point(26, 70);
            this.dataGridViewVerCitas.Name = "dataGridViewVerCitas";
            this.dataGridViewVerCitas.ReadOnly = true;
            this.dataGridViewVerCitas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewVerCitas.Size = new System.Drawing.Size(691, 356);
            this.dataGridViewVerCitas.TabIndex = 15;
            this.dataGridViewVerCitas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewVerCitas_CellClick);
            this.dataGridViewVerCitas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewVerCitas_CellDoubleClick);
            // 
            // labelDiaCita
            // 
            this.labelDiaCita.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDiaCita.AutoSize = true;
            this.labelDiaCita.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDiaCita.Location = new System.Drawing.Point(621, 30);
            this.labelDiaCita.Name = "labelDiaCita";
            this.labelDiaCita.Size = new System.Drawing.Size(95, 18);
            this.labelDiaCita.TabIndex = 14;
            this.labelDiaCita.Text = "Dia de la Cita";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(556, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "Fecha:";
            // 
            // linkLabelCerrarSesion
            // 
            this.linkLabelCerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelCerrarSesion.AutoSize = true;
            this.linkLabelCerrarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelCerrarSesion.Location = new System.Drawing.Point(632, 466);
            this.linkLabelCerrarSesion.Name = "linkLabelCerrarSesion";
            this.linkLabelCerrarSesion.Size = new System.Drawing.Size(113, 18);
            this.linkLabelCerrarSesion.TabIndex = 12;
            this.linkLabelCerrarSesion.TabStop = true;
            this.linkLabelCerrarSesion.Text = "Cerrar Sesion";
            this.linkLabelCerrarSesion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCerrarSesion_LinkClicked);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(253, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Fecha:";
            // 
            // dateTimePickerDiaCita
            // 
            this.dateTimePickerDiaCita.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerDiaCita.Location = new System.Drawing.Point(318, 30);
            this.dateTimePickerDiaCita.Name = "dateTimePickerDiaCita";
            this.dateTimePickerDiaCita.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDiaCita.TabIndex = 10;
            this.dateTimePickerDiaCita.ValueChanged += new System.EventHandler(this.dateTimePickerDiaCita_ValueChanged);
            // 
            // buttonVerEstadisticas
            // 
            this.buttonVerEstadisticas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVerEstadisticas.Location = new System.Drawing.Point(499, 432);
            this.buttonVerEstadisticas.Name = "buttonVerEstadisticas";
            this.buttonVerEstadisticas.Size = new System.Drawing.Size(127, 44);
            this.buttonVerEstadisticas.TabIndex = 76;
            this.buttonVerEstadisticas.Text = "Ver Estadísticas";
            this.buttonVerEstadisticas.UseVisualStyleBackColor = true;
            this.buttonVerEstadisticas.Click += new System.EventHandler(this.buttonVerEstadisticas_Click);
            // 
            // FormCitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 516);
            this.Controls.Add(this.panel1);
            this.Name = "FormCitas";
            this.Text = "Citas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCitas_FormClosed);
            this.Load += new System.EventHandler(this.FormCitas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVerCitas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonDiasNoHabiles;
        private System.Windows.Forms.Button buttonEliminarCita;
        private System.Windows.Forms.Button buttonModificarCita;
        private System.Windows.Forms.Button buttonAgregarCita;
        private System.Windows.Forms.DataGridView dataGridViewVerCitas;
        private System.Windows.Forms.Label labelDiaCita;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabelCerrarSesion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerDiaCita;
        private System.Windows.Forms.Label labelNomUser;
        private System.Windows.Forms.Button buttonVerEstadisticas;
    }
}