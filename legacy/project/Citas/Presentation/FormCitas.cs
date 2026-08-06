using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Citas.BusinessLogic;
using Estadisticas.Presentation;

namespace Citas.Presentation
{
    public partial class FormCitas : Form
    {
        Cita objCita;

        public FormCitas(string nombreUsuario)
        {
            InitializeComponent();
            labelNomUser.Text = labelNomUser.Text + " " + nombreUsuario;
        }

        private void FormCitas_Load(object sender, EventArgs e)
        {
            actualizarLista();
            labelDiaCita.Text = DateTime.Today.ToShortDateString();
        }

        private void actualizarLista()
        {
            List<Cita> listaCitas = LogicaCitas.obtenerCitas();
            dataGridViewVerCitas.DataSource = listaCitas;
        }

        private void dateTimePickerDiaCita_ValueChanged(object sender, EventArgs e)
        {
            List<Cita> listaCitas = LogicaCitas.obtenerCitasPorFecha(dateTimePickerDiaCita.Value.Date);
            dataGridViewVerCitas.DataSource = listaCitas;
        }

        private void buttonAgregarCita_Click(object sender, EventArgs e)
        {
            FormAgendarCita frmAgendarCita = new FormAgendarCita();
            frmAgendarCita.ShowDialog();
            actualizarLista();
        }

        private void FormCitas_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabelCerrarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Restart();
        }

        private void dataGridViewVerCitas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            objCita = new Cita();

            objCita.IdCita = Convert.ToInt32(dataGridViewVerCitas.SelectedCells[0].Value);
            objCita.NombrePaciente = dataGridViewVerCitas.SelectedCells[1].Value.ToString();
            objCita.FechaCita = DateTime.Parse(dataGridViewVerCitas.SelectedCells[2].Value.ToString());
            objCita.HoraCita = TimeSpan.Parse(dataGridViewVerCitas.SelectedCells[3].Value.ToString());
            objCita.PrimeraVez = Boolean.Parse(dataGridViewVerCitas.SelectedCells[4].Value.ToString());
            objCita.Telefono = dataGridViewVerCitas.SelectedCells[5].Value.ToString();
            objCita.Afiliacion = dataGridViewVerCitas.SelectedCells[6].Value.ToString();

            buttonModificarCita.Enabled = true;
            buttonEliminarCita.Enabled = true;
        }

        private void dataGridViewVerCitas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewVerCitas.RowCount > 0)
            {
                objCita = new Cita();

                objCita.IdCita = Convert.ToInt32(dataGridViewVerCitas.SelectedCells[0].Value);
                objCita.NombrePaciente = dataGridViewVerCitas.SelectedCells[1].Value.ToString();
                objCita.FechaCita = DateTime.Parse(dataGridViewVerCitas.SelectedCells[2].Value.ToString());
                objCita.HoraCita = TimeSpan.Parse(dataGridViewVerCitas.SelectedCells[3].Value.ToString());
                objCita.PrimeraVez = Boolean.Parse(dataGridViewVerCitas.SelectedCells[4].Value.ToString());
                objCita.Telefono = dataGridViewVerCitas.SelectedCells[5].Value.ToString();
                objCita.Afiliacion = dataGridViewVerCitas.SelectedCells[6].Value.ToString();

                FormAgendarCita modificarUsuario = new FormAgendarCita(objCita, true);
                modificarUsuario.ShowDialog();
                actualizarLista();
            }
        }

        private void buttonEliminarCita_Click(object sender, EventArgs e)
        {
            if (dataGridViewVerCitas.RowCount > 0)
            {
                if (objCita.IdCita > 0)
                {
                    DialogResult result1 = MessageBox.Show("¿Seguro que quiere eliminar esta cita?", "Eliminar cita", MessageBoxButtons.YesNo);

                    if (result1 == DialogResult.Yes)
                    {
                        int result = LogicaCitas.eliminarCita(objCita.IdCita);

                        if (result > 0)
                        {
                            MessageBox.Show("Cita eliminada");
                        }

                        actualizarLista();
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione cita");
                }
            }
            else
            {
                MessageBox.Show("La tabla debe contener datos para modificar");
            }
        }

        private void buttonModificarCita_Click(object sender, EventArgs e)
        {
            if (dataGridViewVerCitas.RowCount > 0)
            {
                if (objCita.IdCita > 0)
                {
                    FormAgendarCita frmModificar = new FormAgendarCita(objCita, true);
                    frmModificar.ShowDialog();
                    actualizarLista();
                }
                else
                {
                    MessageBox.Show("Seleccione cita");
                }
            }
            else
            {
                MessageBox.Show("La tabla debe contener datos para modificar");
            }
        }

        private void buttonDiasNoHabiles_Click(object sender, EventArgs e)
        {
            FormDiasNoHabiles frmDias = new FormDiasNoHabiles();
            frmDias.ShowDialog();
        }

        private void buttonVerEstadisticas_Click(object sender, EventArgs e)
        {
            FormEstadisticas frmEstadisticas = new FormEstadisticas();
            frmEstadisticas.ShowDialog();
        }
    }
}
