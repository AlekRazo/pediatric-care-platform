using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pacientes.BusinessLogic;
using Consultas.Presentation;

namespace Pacientes.Presentation
{
    public partial class FormPacientes : Form
    {
        Paciente objPaciente;
        
        public FormPacientes(string nombreUsuario)
        {
            InitializeComponent();
            labelNomUser.Text = labelNomUser.Text + " " + nombreUsuario;
        }

        private void linkLabelCerrarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Restart();
        }

        private void buttonBuscar_MouseClick(object sender, MouseEventArgs e)
        {
            List<Paciente> listaPacientes = new List<Paciente>();
            //listaPacientes = LogicaBusquedas.obtenerTodosLosPacientes();
            //dataGridViewVerPacientes.DataSource = listaPacientes;

            if(comboBoxTipoBusqueda.SelectedIndex == 0){                             
                listaPacientes = LogicaBusquedas.obtenerPacientesPorNombre(textBoxPaciente.Text);
                dataGridViewVerPacientes.DataSource = listaPacientes;
            }
            else if (comboBoxTipoBusqueda.SelectedIndex == 1)
            {                
                listaPacientes = LogicaBusquedas.obtenerPacientesPorNombreMadre(textBoxPaciente.Text);
                dataGridViewVerPacientes.DataSource = listaPacientes;
            }
            else if (comboBoxTipoBusqueda.SelectedIndex == 2)
            {                
                listaPacientes = LogicaBusquedas.obtenerPacientesPorNombrePadre(textBoxPaciente.Text);
                dataGridViewVerPacientes.DataSource = listaPacientes;
            }
            else if (comboBoxTipoBusqueda.SelectedIndex == 3)
            {
                listaPacientes = LogicaBusquedas.obtenerPacientesPorTipoSangre(textBoxPaciente.Text);
                dataGridViewVerPacientes.DataSource = listaPacientes;
            }
            else if (comboBoxTipoBusqueda.SelectedIndex == 4)
            {
                //listaPacientes = LogicaBusquedas.obtenerPacientesPorEdad(textBoxNomPaciente.Text);
                dataGridViewVerPacientes.DataSource = listaPacientes;
            }
            else if (comboBoxTipoBusqueda.SelectedIndex == 5)
            {
                listaPacientes = LogicaBusquedas.obtenerPacientesPorSexo(textBoxPaciente.Text);
                dataGridViewVerPacientes.DataSource = listaPacientes;
            }
        }

        private void buttonConsulta_MouseClick(object sender, MouseEventArgs e)
        {
            FormConsulta consulta = new FormConsulta(objPaciente.IdPaciente, objPaciente.NombrePaciente);
            consulta.ShowDialog();

        }

        private void buttonAgregar_MouseClick(object sender, MouseEventArgs e)
        {
            FormAgregarPaciente agregarPaciente = new FormAgregarPaciente();
            agregarPaciente.ShowDialog();
            actualizarTablaPaciente();
        }

        private void actualizarTablaPaciente()
        {
            List<Paciente> listaPacientes = new List<Paciente>();
            listaPacientes = LogicaBusquedas.obtenerTodosLosPacientes();
            dataGridViewVerPacientes.DataSource = listaPacientes;
        }

        private void dataGridViewPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            objPaciente = new Paciente();

            objPaciente.IdPaciente = Int32.Parse(dataGridViewVerPacientes.SelectedCells[0].Value.ToString());
            objPaciente.NombrePaciente = dataGridViewVerPacientes.SelectedCells[1].Value.ToString();
            objPaciente.NombreMadre = dataGridViewVerPacientes.SelectedCells[2].Value.ToString();
            objPaciente.NombrePadre = dataGridViewVerPacientes.SelectedCells[3].Value.ToString();
            objPaciente.NombreTutor = dataGridViewVerPacientes.SelectedCells[4].Value.ToString();
            objPaciente.Afiliacion = dataGridViewVerPacientes.SelectedCells[5].Value.ToString();
            objPaciente.NumeroSeguro = dataGridViewVerPacientes.SelectedCells[6].Value.ToString();
            objPaciente.Domicilio = dataGridViewVerPacientes.SelectedCells[7].Value.ToString();
            objPaciente.CodigoPostal = dataGridViewVerPacientes.SelectedCells[8].Value.ToString();
            objPaciente.FechaNacimiento = DateTime.Parse(dataGridViewVerPacientes.SelectedCells[9].Value.ToString());
            objPaciente.LugarNacimiento = dataGridViewVerPacientes.SelectedCells[10].Value.ToString();
            objPaciente.TelefonoCasa = dataGridViewVerPacientes.SelectedCells[11].Value.ToString();
            objPaciente.TelefonoCelular = dataGridViewVerPacientes.SelectedCells[12].Value.ToString();
            objPaciente.Sexo = dataGridViewVerPacientes.SelectedCells[13].Value.ToString();
            objPaciente.TipoSangre = dataGridViewVerPacientes.SelectedCells[14].Value.ToString();
            objPaciente.Observaciones = dataGridViewVerPacientes.SelectedCells[15].Value.ToString();

            buttonConsulta.Enabled = true;
            buttonEliminar.Enabled = true;
            buttonModificar.Enabled = true;
        }

        private void dataGridViewPacientes_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridViewVerPacientes.RowCount > 0)
            {
                objPaciente = new Paciente();
                objPaciente.IdPaciente = Int32.Parse(dataGridViewVerPacientes.SelectedCells[0].Value.ToString());
                objPaciente.NombrePaciente = dataGridViewVerPacientes.SelectedCells[1].Value.ToString();
                objPaciente.NombreMadre = dataGridViewVerPacientes.SelectedCells[2].Value.ToString();
                objPaciente.NombrePadre = dataGridViewVerPacientes.SelectedCells[3].Value.ToString();
                objPaciente.NombreTutor = dataGridViewVerPacientes.SelectedCells[4].Value.ToString();
                objPaciente.Afiliacion = dataGridViewVerPacientes.SelectedCells[5].Value.ToString();
                objPaciente.NumeroSeguro = dataGridViewVerPacientes.SelectedCells[6].Value.ToString();
                objPaciente.Domicilio = dataGridViewVerPacientes.SelectedCells[7].Value.ToString();
                objPaciente.CodigoPostal = dataGridViewVerPacientes.SelectedCells[8].Value.ToString();
                objPaciente.FechaNacimiento = DateTime.Parse(dataGridViewVerPacientes.SelectedCells[9].Value.ToString());
                objPaciente.LugarNacimiento = dataGridViewVerPacientes.SelectedCells[10].Value.ToString();
                objPaciente.TelefonoCasa = dataGridViewVerPacientes.SelectedCells[11].Value.ToString();
                objPaciente.TelefonoCelular = dataGridViewVerPacientes.SelectedCells[12].Value.ToString();
                objPaciente.Sexo = dataGridViewVerPacientes.SelectedCells[13].Value.ToString();
                objPaciente.TipoSangre = dataGridViewVerPacientes.SelectedCells[14].Value.ToString();
                objPaciente.Observaciones = dataGridViewVerPacientes.SelectedCells[15].Value.ToString();
                
                FormAgregarPaciente modificarPaciente = new FormAgregarPaciente(true, objPaciente);
                modificarPaciente.ShowDialog();
                actualizarTablaPaciente();
            }
            else
            {
                MessageBox.Show("La tabla debe contener datos para modificar");
            }
        }

        private void buttonEliminar_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridViewVerPacientes.RowCount > 0)
            {
                if (objPaciente.IdPaciente > 0)
                {
                    DialogResult result1 = MessageBox.Show("¿Seguro que quiere eliminar este Paciente?", "Eliminar Paciente", MessageBoxButtons.YesNo);

                    if (result1 == DialogResult.Yes)
                    {
                        bool result = LogicaPaciente.eliminarPaciente(objPaciente.IdPaciente);

                        if (result == true)
                        {
                            MessageBox.Show("Paciente Removido");
                        }

                        actualizarTablaPaciente();
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione Paciente");
                }
            }
            else
            {
                MessageBox.Show("La tabla debe contener datos para modificar");
            }
        }

        private void buttonModificar_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridViewVerPacientes.RowCount > 0)
            {
                if (objPaciente.IdPaciente > 0)
                {
                    FormAgregarPaciente modificarPaciente = new FormAgregarPaciente(true, objPaciente);
                    modificarPaciente.ShowDialog();
                    actualizarTablaPaciente();
                }
                else
                {
                    MessageBox.Show("Seleccione Paciente");
                }
            }
            else
            {
                MessageBox.Show("La tabla debe contener datos para modificar");
            }
        }

        private void FormPacientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FormPacientes_Load(object sender, EventArgs e)
        {
            actualizarTablaPaciente();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxTipoBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
