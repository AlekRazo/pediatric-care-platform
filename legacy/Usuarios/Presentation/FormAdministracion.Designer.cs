namespace Usuarios.Presentation
{
    partial class FormAdministracion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.linkLabelCerrarSesion = new System.Windows.Forms.LinkLabel();
            this.textBoxUsuario = new System.Windows.Forms.TextBox();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.buttonBuscarPorNombre = new System.Windows.Forms.Button();
            this.dataGridViewVerUsuarios = new System.Windows.Forms.DataGridView();
            this.comboBoxTipoUsuario = new System.Windows.Forms.ComboBox();
            this.labelTipoUsuario = new System.Windows.Forms.Label();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonModificar = new System.Windows.Forms.Button();
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelNomUser = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVerUsuarios)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // linkLabelCerrarSesion
            // 
            this.linkLabelCerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelCerrarSesion.AutoSize = true;
            this.linkLabelCerrarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelCerrarSesion.Location = new System.Drawing.Point(615, 400);
            this.linkLabelCerrarSesion.Name = "linkLabelCerrarSesion";
            this.linkLabelCerrarSesion.Size = new System.Drawing.Size(113, 18);
            this.linkLabelCerrarSesion.TabIndex = 2;
            this.linkLabelCerrarSesion.TabStop = true;
            this.linkLabelCerrarSesion.Text = "Cerrar Sesion";
            this.linkLabelCerrarSesion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCerrarSesion_LinkClicked);
            // 
            // textBoxUsuario
            // 
            this.textBoxUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUsuario.Location = new System.Drawing.Point(164, 48);
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.Size = new System.Drawing.Size(177, 24);
            this.textBoxUsuario.TabIndex = 65;
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsuario.Location = new System.Drawing.Point(3, 51);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(155, 18);
            this.labelUsuario.TabIndex = 66;
            this.labelUsuario.Text = "Nombre de Usuario";
            // 
            // buttonBuscarPorNombre
            // 
            this.buttonBuscarPorNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBuscarPorNombre.Location = new System.Drawing.Point(347, 44);
            this.buttonBuscarPorNombre.Name = "buttonBuscarPorNombre";
            this.buttonBuscarPorNombre.Size = new System.Drawing.Size(89, 33);
            this.buttonBuscarPorNombre.TabIndex = 67;
            this.buttonBuscarPorNombre.Text = "Buscar";
            this.buttonBuscarPorNombre.UseVisualStyleBackColor = true;
            this.buttonBuscarPorNombre.Click += new System.EventHandler(this.buttonBuscarPorNombre_Click);
            // 
            // dataGridViewVerUsuarios
            // 
            this.dataGridViewVerUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewVerUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewVerUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewVerUsuarios.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewVerUsuarios.Location = new System.Drawing.Point(4, 97);
            this.dataGridViewVerUsuarios.Name = "dataGridViewVerUsuarios";
            this.dataGridViewVerUsuarios.ReadOnly = true;
            this.dataGridViewVerUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewVerUsuarios.Size = new System.Drawing.Size(724, 259);
            this.dataGridViewVerUsuarios.TabIndex = 68;
            this.dataGridViewVerUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewVerUsuarios_CellClick);
            this.dataGridViewVerUsuarios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewVerUsuarios_CellDoubleClick);
            // 
            // comboBoxTipoUsuario
            // 
            this.comboBoxTipoUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTipoUsuario.FormattingEnabled = true;
            this.comboBoxTipoUsuario.Items.AddRange(new object[] {
            "Administrador",
            "Doctor",
            "Recepcion"});
            this.comboBoxTipoUsuario.Location = new System.Drawing.Point(607, 48);
            this.comboBoxTipoUsuario.Name = "comboBoxTipoUsuario";
            this.comboBoxTipoUsuario.Size = new System.Drawing.Size(121, 26);
            this.comboBoxTipoUsuario.TabIndex = 69;
            this.comboBoxTipoUsuario.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoUsuario_SelectedIndexChanged);
            // 
            // labelTipoUsuario
            // 
            this.labelTipoUsuario.AutoSize = true;
            this.labelTipoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTipoUsuario.Location = new System.Drawing.Point(468, 51);
            this.labelTipoUsuario.Name = "labelTipoUsuario";
            this.labelTipoUsuario.Size = new System.Drawing.Size(133, 18);
            this.labelTipoUsuario.TabIndex = 70;
            this.labelTipoUsuario.Text = "Tipo de Usuario:";
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonEliminar.Enabled = false;
            this.buttonEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEliminar.Location = new System.Drawing.Point(196, 385);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(89, 33);
            this.buttonEliminar.TabIndex = 71;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonModificar
            // 
            this.buttonModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonModificar.Enabled = false;
            this.buttonModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModificar.Location = new System.Drawing.Point(101, 385);
            this.buttonModificar.Name = "buttonModificar";
            this.buttonModificar.Size = new System.Drawing.Size(89, 33);
            this.buttonModificar.TabIndex = 72;
            this.buttonModificar.Text = "Modificar";
            this.buttonModificar.UseVisualStyleBackColor = true;
            this.buttonModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAgregar.Location = new System.Drawing.Point(6, 385);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(89, 33);
            this.buttonAgregar.TabIndex = 73;
            this.buttonAgregar.Text = "Agregar";
            this.buttonAgregar.UseVisualStyleBackColor = true;
            this.buttonAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.labelNomUser);
            this.panel1.Controls.Add(this.buttonAgregar);
            this.panel1.Controls.Add(this.buttonModificar);
            this.panel1.Controls.Add(this.buttonEliminar);
            this.panel1.Controls.Add(this.labelTipoUsuario);
            this.panel1.Controls.Add(this.comboBoxTipoUsuario);
            this.panel1.Controls.Add(this.dataGridViewVerUsuarios);
            this.panel1.Controls.Add(this.buttonBuscarPorNombre);
            this.panel1.Controls.Add(this.labelUsuario);
            this.panel1.Controls.Add(this.textBoxUsuario);
            this.panel1.Controls.Add(this.linkLabelCerrarSesion);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(736, 425);
            this.panel1.TabIndex = 3;
            // 
            // labelNomUser
            // 
            this.labelNomUser.AutoSize = true;
            this.labelNomUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomUser.Location = new System.Drawing.Point(3, 0);
            this.labelNomUser.Name = "labelNomUser";
            this.labelNomUser.Size = new System.Drawing.Size(204, 24);
            this.labelNomUser.TabIndex = 74;
            this.labelNomUser.Text = "Bienvenido Usuario: ";
            // 
            // FormAdministracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 449);
            this.Controls.Add(this.panel1);
            this.Name = "FormAdministracion";
            this.Text = "Administrador";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAdministracion_FormClosed);
            this.Load += new System.EventHandler(this.FormAdministracion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVerUsuarios)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabelCerrarSesion;
        private System.Windows.Forms.TextBox textBoxUsuario;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.Button buttonBuscarPorNombre;
        private System.Windows.Forms.DataGridView dataGridViewVerUsuarios;
        private System.Windows.Forms.ComboBox comboBoxTipoUsuario;
        private System.Windows.Forms.Label labelTipoUsuario;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonModificar;
        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelNomUser;


    }
}