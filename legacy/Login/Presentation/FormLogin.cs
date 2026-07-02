using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Citas.Presentation;
using Usuarios.Presentation;

namespace Login.Presentation
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (textBoxNombreUsuario.Text == "")
            {
                MessageBox.Show("El nombre no puede estar vacío.");
            }
            else if (textBoxContrasena.Text == "")
            {
                MessageBox.Show("La contraseña no puede estar vacía.");
            }
            else
            {
                Usuario objUsuario = new Usuario();

                objUsuario.Nombre = textBoxNombreUsuario.Text;
                objUsuario.Contrasena = textBoxContrasena.Text;

                Boolean status = LogicaUsuario.validarInicioDeSesion(objUsuario);

                if (status == true)
                {
                    //Obtener usuario y abrir diferentes ventanas

                    objUsuario = LogicaUsuario.obtenerUsuario(objUsuario);

                    //Tipo de Usuario = 0; Administrador
                    if (objUsuario.TipoUsuario == 0)
                    {
                        FormAdministracion frmAdministracion = new FormAdministracion(objUsuario.Nombre);
                        this.Hide();
                        frmAdministracion.ShowDialog();
                        this.Show();
                    }

                    //Tipo de Usuario = 1; Medico
                    if (objUsuario.TipoUsuario == 1)
                    {
                        MessageBox.Show("Bienvenido Médico no. " + objUsuario.Cedula);
                    }

                    //Tipo de Usuario = 2; Empleado
                    if (objUsuario.TipoUsuario == 2)
                    {
                        FormCitas frmCitas = new FormCitas();
                        this.Hide();
                        frmCitas.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Inicio inválido. Intente de nuevo.");
                }
            }
        }

        private void linkLabelRecuperarContrasena_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRecuperacion formRecuperacion = new FormRecuperacion();
            this.Hide();
            formRecuperacion.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
