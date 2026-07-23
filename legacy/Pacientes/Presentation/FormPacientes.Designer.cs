namespace Pacientes.Presentation
{
    partial class FormPacientes
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
            this.comboBoxTipoBusqueda = new System.Windows.Forms.ComboBox();
            this.textBoxPaciente = new System.Windows.Forms.TextBox();
            this.labelNomUser = new System.Windows.Forms.Label();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonModificar = new System.Windows.Forms.Button();
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonHistorial = new System.Windows.Forms.Button();
            this.buttonConsulta = new System.Windows.Forms.Button();
            this.dataGridViewVerPacientes = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabelCerrarSesion = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCrecimiento = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVerPacientes)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxTipoBusqueda
            // 
            this.comboBoxTipoBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTipoBusqueda.FormattingEnabled = true;
            this.comboBoxTipoBusqueda.Items.AddRange(new object[] {
            "Nombre",
            "Madre",
            "Padre",
            "Tipo de Sangre",
            "Edad",
            "Sexo"});
            this.comboBoxTipoBusqueda.Location = new System.Drawing.Point(504, 48);
            this.comboBoxTipoBusqueda.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxTipoBusqueda.Name = "comboBoxTipoBusqueda";
            this.comboBoxTipoBusqueda.Size = new System.Drawing.Size(160, 32);
            this.comboBoxTipoBusqueda.TabIndex = 77;
            this.comboBoxTipoBusqueda.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoBusqueda_SelectedIndexChanged);
            // 
            // textBoxPaciente
            // 
            this.textBoxPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPaciente.Location = new System.Drawing.Point(143, 49);
            this.textBoxPaciente.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPaciente.Name = "textBoxPaciente";
            this.textBoxPaciente.Size = new System.Drawing.Size(263, 29);
            this.textBoxPaciente.TabIndex = 76;
            // 
            // labelNomUser
            // 
            this.labelNomUser.AutoSize = true;
            this.labelNomUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomUser.Location = new System.Drawing.Point(4, 0);
            this.labelNomUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNomUser.Name = "labelNomUser";
            this.labelNomUser.Size = new System.Drawing.Size(158, 29);
            this.labelNomUser.TabIndex = 75;
            this.labelNomUser.Text = "Bienvenido: ";
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBuscar.Location = new System.Drawing.Point(705, 33);
            this.buttonBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(125, 46);
            this.buttonBuscar.TabIndex = 19;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonBuscar_MouseClick);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonEliminar.Enabled = false;
            this.buttonEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEliminar.Location = new System.Drawing.Point(263, 542);
            this.buttonEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(107, 36);
            this.buttonEliminar.TabIndex = 18;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            this.buttonEliminar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonEliminar_MouseClick);
            // 
            // buttonModificar
            // 
            this.buttonModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonModificar.Enabled = false;
            this.buttonModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModificar.Location = new System.Drawing.Point(150, 542);
            this.buttonModificar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonModificar.Name = "buttonModificar";
            this.buttonModificar.Size = new System.Drawing.Size(107, 36);
            this.buttonModificar.TabIndex = 17;
            this.buttonModificar.Text = "Modificar";
            this.buttonModificar.UseVisualStyleBackColor = true;
            this.buttonModificar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonModificar_MouseClick);
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAgregar.Location = new System.Drawing.Point(35, 542);
            this.buttonAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(107, 36);
            this.buttonAgregar.TabIndex = 16;
            this.buttonAgregar.Text = "Agregar";
            this.buttonAgregar.UseVisualStyleBackColor = true;
            this.buttonAgregar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonAgregar_MouseClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.buttonCrecimiento);
            this.panel1.Controls.Add(this.buttonHistorial);
            this.panel1.Controls.Add(this.buttonConsulta);
            this.panel1.Controls.Add(this.comboBoxTipoBusqueda);
            this.panel1.Controls.Add(this.textBoxPaciente);
            this.panel1.Controls.Add(this.labelNomUser);
            this.panel1.Controls.Add(this.buttonBuscar);
            this.panel1.Controls.Add(this.buttonEliminar);
            this.panel1.Controls.Add(this.buttonModificar);
            this.panel1.Controls.Add(this.buttonAgregar);
            this.panel1.Controls.Add(this.dataGridViewVerPacientes);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.linkLabelCerrarSesion);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(16, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(997, 606);
            this.panel1.TabIndex = 4;
            // 
            // buttonHistorial
            // 
            this.buttonHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonHistorial.Enabled = false;
            this.buttonHistorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHistorial.Location = new System.Drawing.Point(405, 533);
            this.buttonHistorial.Margin = new System.Windows.Forms.Padding(4);
            this.buttonHistorial.Name = "buttonHistorial";
            this.buttonHistorial.Size = new System.Drawing.Size(137, 54);
            this.buttonHistorial.TabIndex = 79;
            this.buttonHistorial.Text = "Ver Historial";
            this.buttonHistorial.UseVisualStyleBackColor = true;
            this.buttonHistorial.Click += new System.EventHandler(this.buttonHistorial_Click);
            // 
            // buttonConsulta
            // 
            this.buttonConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonConsulta.Enabled = false;
            this.buttonConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConsulta.Location = new System.Drawing.Point(550, 533);
            this.buttonConsulta.Margin = new System.Windows.Forms.Padding(4);
            this.buttonConsulta.Name = "buttonConsulta";
            this.buttonConsulta.Size = new System.Drawing.Size(137, 54);
            this.buttonConsulta.TabIndex = 78;
            this.buttonConsulta.Text = "Generar Consulta";
            this.buttonConsulta.UseVisualStyleBackColor = true;
            this.buttonConsulta.Click += new System.EventHandler(this.buttonConsulta_Click);
            this.buttonConsulta.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonConsulta_MouseClick);
            // 
            // dataGridViewVerPacientes
            // 
            this.dataGridViewVerPacientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewVerPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVerPacientes.Location = new System.Drawing.Point(35, 86);
            this.dataGridViewVerPacientes.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewVerPacientes.Name = "dataGridViewVerPacientes";
            this.dataGridViewVerPacientes.ReadOnly = true;
            this.dataGridViewVerPacientes.RowHeadersWidth = 51;
            this.dataGridViewVerPacientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewVerPacientes.Size = new System.Drawing.Size(921, 438);
            this.dataGridViewVerPacientes.TabIndex = 15;
            this.dataGridViewVerPacientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPacientes_CellClick);
            this.dataGridViewVerPacientes.DoubleClick += new System.EventHandler(this.dataGridViewPacientes_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(435, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 24);
            this.label2.TabIndex = 13;
            this.label2.Text = "Tipo:";
            // 
            // linkLabelCerrarSesion
            // 
            this.linkLabelCerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelCerrarSesion.AutoSize = true;
            this.linkLabelCerrarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelCerrarSesion.Location = new System.Drawing.Point(843, 574);
            this.linkLabelCerrarSesion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelCerrarSesion.Name = "linkLabelCerrarSesion";
            this.linkLabelCerrarSesion.Size = new System.Drawing.Size(138, 24);
            this.linkLabelCerrarSesion.TabIndex = 12;
            this.linkLabelCerrarSesion.TabStop = true;
            this.linkLabelCerrarSesion.Text = "Cerrar Sesion";
            this.linkLabelCerrarSesion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCerrarSesion_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "Paciente:";
            // 
            // buttonCrecimiento
            // 
            this.buttonCrecimiento.Enabled = false;
            this.buttonCrecimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCrecimiento.Location = new System.Drawing.Point(694, 533);
            this.buttonCrecimiento.Name = "buttonCrecimiento";
            this.buttonCrecimiento.Size = new System.Drawing.Size(137, 54);
            this.buttonCrecimiento.TabIndex = 80;
            this.buttonCrecimiento.Text = "Crecimiento";
            this.buttonCrecimiento.UseVisualStyleBackColor = true;
            this.buttonCrecimiento.Click += new System.EventHandler(this.buttonCrecimiento_Click);
            // 
            // FormPacientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 631);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormPacientes";
            this.Text = "Pacientes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormPacientes_FormClosed);
            this.Load += new System.EventHandler(this.FormPacientes_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVerPacientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxTipoBusqueda;
        private System.Windows.Forms.TextBox textBoxPaciente;
        private System.Windows.Forms.Label labelNomUser;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonModificar;
        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewVerPacientes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabelCerrarSesion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonConsulta;
        private System.Windows.Forms.Button buttonHistorial;
        private System.Windows.Forms.Button buttonCrecimiento;
    }
}