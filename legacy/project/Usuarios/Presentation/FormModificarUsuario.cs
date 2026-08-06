using Helpers.Helpers;
using System;
using System.Windows.Forms;
using Usuarios.BusinessLogic;

namespace Usuarios
{
    public partial class FormModificarUsuario : Form
    {
        Usuario objUsuario;

        public FormModificarUsuario()
        {
            InitializeComponent();
        }

        public FormModificarUsuario(Usuario objUsuario)
        {
            InitializeComponent();
            this.objUsuario = objUsuario;
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
                    string cedula = "";

                    if (comboBoxTipoUsuario.SelectedIndex == 1)
                    {
                        cedula = textBoxCedula.Text;
                    }

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
                                        objUsuario.Nombre = textBoxNombreUsuario.Text;
                                        objUsuario.Contrasena = textBoxContrasena.Text;
                                        objUsuario.FechaNacimiento = dateTimePickerFechaNacimiento.Value;
                                        objUsuario.FechaRegistro = dateTimePickerFechaRegistro.Value;
                                        objUsuario.Sexo = sexo;
                                        objUsuario.TipoUsuario = comboBoxTipoUsuario.SelectedIndex;
                                        objUsuario.Cedula = cedula;
                                        objUsuario.Correo = textBoxCorreo.Text;

                                        int resultado = LogicaUsuario.actualizarUsuario(objUsuario);

                                        if (resultado > 0)
                                        {
                                            MessageBox.Show("Usuario actualizado");
                                            Close();
                                        }
                                        else
                                        {
                                            MessageBox.Show("No se pudo actualizar usuario");
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

        private void FormModificarUsuario_Load(object sender, EventArgs e)
        {
            if (objUsuario.TipoUsuario == 1)
            {
                labelCedula.Visible = true;
                textBoxCedula.Visible = true;
                textBoxCedula.Text = objUsuario.Cedula;
            }

            textBoxNombreUsuario.Text = objUsuario.Nombre;
            textBoxContrasena.Text = objUsuario.Contrasena;
            textBoxConfirmarContrasena.Text = objUsuario.Contrasena;
            textBoxCorreo.Text = objUsuario.Correo;

            if (objUsuario.Sexo == "Femenino")
            {
                radioButtonFemenino.Checked = true;
            }
            if (objUsuario.Sexo == "Masculino")
            {
                radioButtonMasculino.Checked = true;
            }

            dateTimePickerFechaNacimiento.Value = objUsuario.FechaNacimiento;
            dateTimePickerFechaRegistro.Value = objUsuario.FechaRegistro;
            comboBoxTipoUsuario.SelectedIndex = objUsuario.TipoUsuario;
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
    }
}
