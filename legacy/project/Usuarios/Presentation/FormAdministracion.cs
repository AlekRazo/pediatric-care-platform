using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Usuarios.BusinessLogic;

namespace Usuarios.Presentation
{
    public partial class FormAdministracion : Form
    {
        Usuario objUsuario;

        public FormAdministracion(string nombreUsuario)
        {
            InitializeComponent();
            labelNomUser.Text = labelNomUser.Text + " " + nombreUsuario;
        }

        public FormAdministracion()
        {
            InitializeComponent();
        }

        private void FormAdministracion_Load(object sender, EventArgs e)
        {
            actualizarTablaUsuarios();
        }

        private void linkLabelCerrarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Restart();
        }

        private void FormAdministracion_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormNuevoUsuario nuevoUsuario = new FormNuevoUsuario();
            nuevoUsuario.ShowDialog();
            actualizarTablaUsuarios();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridViewVerUsuarios.RowCount > 0)
            {
                if (objUsuario.IdUsuario > 0)
                {
                    FormModificarUsuario modificarUsuario = new FormModificarUsuario(objUsuario);
                    modificarUsuario.ShowDialog();
                    actualizarTablaUsuarios();
                }
                else
                {
                    MessageBox.Show("Seleccione usuario");
                }
            }
            else
            {
                MessageBox.Show("La tabla debe contener datos para modificar");
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewVerUsuarios.RowCount > 0)
            {
                if (objUsuario.IdUsuario > 0)
                {
                    DialogResult result1 = MessageBox.Show("¿Seguro que quiere eliminar este usuario?", "Eliminar usuario", MessageBoxButtons.YesNo);

                    if (result1 == DialogResult.Yes)
                    {
                        int result = LogicaUsuario.eliminarUsuario(objUsuario.IdUsuario);

                        if (result > 0)
                        {
                            MessageBox.Show("Usuario removido");
                        }

                        actualizarTablaUsuarios();
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione usuario");
                }
            }
            else
            {
                MessageBox.Show("La tabla debe contener datos para modificar");
            }
        }

        private void actualizarTablaUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            listaUsuarios = LogicaUsuario.obtenerUsuarios();
            dataGridViewVerUsuarios.DataSource = listaUsuarios;
        }

        private void dataGridViewVerUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            objUsuario = new Usuario();

            objUsuario.IdUsuario = Int32.Parse(dataGridViewVerUsuarios.SelectedCells[0].Value.ToString());
            objUsuario.Nombre = dataGridViewVerUsuarios.SelectedCells[1].Value.ToString();
            objUsuario.Contrasena = dataGridViewVerUsuarios.SelectedCells[2].Value.ToString();
            objUsuario.FechaNacimiento = DateTime.Parse(dataGridViewVerUsuarios.SelectedCells[3].Value.ToString());
            objUsuario.FechaRegistro = DateTime.Parse(dataGridViewVerUsuarios.SelectedCells[4].Value.ToString());
            objUsuario.Sexo = dataGridViewVerUsuarios.SelectedCells[5].Value.ToString();
            objUsuario.TipoUsuario = Int32.Parse(dataGridViewVerUsuarios.SelectedCells[6].Value.ToString());
            objUsuario.Cedula = dataGridViewVerUsuarios.SelectedCells[7].Value.ToString();
            objUsuario.Correo = dataGridViewVerUsuarios.SelectedCells[8].Value.ToString();

            buttonModificar.Enabled = true;
            buttonEliminar.Enabled = true;
        }

        private void comboBoxTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            listaUsuarios = LogicaUsuario.obtenerUsuariosPorTipo(comboBoxTipoUsuario.SelectedIndex);
            dataGridViewVerUsuarios.DataSource = listaUsuarios;
        }

        private void buttonBuscarPorNombre_Click(object sender, EventArgs e)
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            listaUsuarios = LogicaUsuario.obtenerUsuariosPorNombre(textBoxUsuario.Text);
            dataGridViewVerUsuarios.DataSource = listaUsuarios;
        }

        private void dataGridViewVerUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewVerUsuarios.RowCount > 0)
            {
                objUsuario = new Usuario();

                objUsuario.IdUsuario = Int32.Parse(dataGridViewVerUsuarios.SelectedCells[0].Value.ToString());
                objUsuario.Nombre = dataGridViewVerUsuarios.SelectedCells[1].Value.ToString();
                objUsuario.Contrasena = dataGridViewVerUsuarios.SelectedCells[2].Value.ToString();
                objUsuario.FechaNacimiento = DateTime.Parse(dataGridViewVerUsuarios.SelectedCells[3].Value.ToString());
                objUsuario.FechaRegistro = DateTime.Parse(dataGridViewVerUsuarios.SelectedCells[4].Value.ToString());
                objUsuario.Sexo = dataGridViewVerUsuarios.SelectedCells[5].Value.ToString();
                objUsuario.TipoUsuario = Int32.Parse(dataGridViewVerUsuarios.SelectedCells[6].Value.ToString());
                objUsuario.Cedula = dataGridViewVerUsuarios.SelectedCells[7].Value.ToString();
                objUsuario.Correo = dataGridViewVerUsuarios.SelectedCells[8].Value.ToString();

                FormModificarUsuario modificarUsuario = new FormModificarUsuario(objUsuario);
                modificarUsuario.ShowDialog();
                actualizarTablaUsuarios();
            }
            else
            {
                MessageBox.Show("La tabla debe contener datos para modificar");
            }
        }
    }
}
