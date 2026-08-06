using Helpers.Helpers;
using System;
using System.Windows.Forms;
using Usuarios.BusinessLogic;

namespace Usuarios.Presentation
{
    public partial class FormRecuperacion : Form
    {
        public FormRecuperacion()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string nombre = textBoxNombreUsuario.Text;

            if (Validaciones.esCorreoElectronico(textBoxCorreo.Text))
            {
                string correo = textBoxCorreo.Text;

                if (LogicaUsuario.enviarCorreo(nombre, correo))
                {
                    MessageBox.Show("Correo Enviado");
                }
                else
                {
                    MessageBox.Show("No se Pudo Enviar el Correo");
                }
            }
            else
            {
                MessageBox.Show("Escriba el correo correctamente.");
            }
        }

        private void FormRecuperacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Restart();
        }
    }
}
