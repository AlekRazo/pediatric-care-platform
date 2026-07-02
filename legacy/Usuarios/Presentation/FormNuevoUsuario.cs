using System;
using System.Windows.Forms;
using Usuarios.BusinessLogic;

namespace Usuarios.Presentation
{
    public partial class FormNuevoUsuario : Form
    {
        public FormNuevoUsuario()
        {
            InitializeComponent();
        }

        private void comboBoxTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipoUsuario.SelectedIndex == 1)
            {
                labelCedula.Visible = true;
                textBoxCedula.Visible = true;
            }
            else
            {
                labelCedula.Visible = false;
                textBoxCedula.Visible = false;
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (textBoxContrasena.Text != textBoxConfirmarContrasena.Text)
            {
                MessageBox.Show("Los campos de contraseña debe coincidir");
            }
            else
            {
                if (radioButtonFemenino.Checked == false && radioButtonMasculino.Checked == false)
                {
                    MessageBox.Show("Seleccione sexo");
                }
                else
                {
                    string sexo = "";

                    if (radioButtonFemenino.Checked == true)
                    {
                        sexo = "Femenino";
                    }

                    if (radioButtonMasculino.Checked == true)
                    {
                        sexo = "Masculino";
                    }

                    if (comboBoxTipoUsuario.SelectedIndex.Equals(-1))
                    {
                        MessageBox.Show("Seleccione tipo de usuario");
                    }
                    else
                    {
                        if (Validaciones.esCorreoElectronico(textBoxCorreo.Text))
                        {
                            if (textBoxNombreUsuario.Text.Length > 0)
                            {
                                if (Validaciones.esAlfanumerico(textBoxNombreUsuario.Text))
                                {
                                    if (textBoxContrasena.Text.Length > 0)
                                    {
                                        Usuario objUsuario = new Usuario();
                                        objUsuario.Nombre = textBoxNombreUsuario.Text;
                                        objUsuario.Contrasena = textBoxContrasena.Text;
                                        objUsuario.FechaNacimiento = dateTimePickerFechaNacimiento.Value;
                                        objUsuario.FechaRegistro = dateTimePickerFechaRegistro.Value;
                                        objUsuario.Sexo = sexo;
                                        objUsuario.TipoUsuario = comboBoxTipoUsuario.SelectedIndex;
                                        objUsuario.Cedula = textBoxCedula.Text;
                                        objUsuario.Correo = textBoxCorreo.Text;

                                        int resultado = LogicaUsuario.capturarUsuario(objUsuario);

                                        if (resultado > 0)
                                        {
                                            MessageBox.Show("Usuario registrado");
                                            Close();
                                        }
                                        else
                                        {
                                            MessageBox.Show("No se pudo registrar usuario");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("La contraseña no debe estar vacía");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("El nombre de usuario solo puede contener letras y números");
                                }
                            }
                            else
                            {
                                MessageBox.Show("El nombre de usuario no debe estar vacío.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Inserte un correo electrónico válido");
                        }
                    }
                }
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
