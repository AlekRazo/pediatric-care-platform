using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Citas.BusinessLogic;

namespace Citas.Presentation
{
    public partial class FormDiasNoHabiles : Form
    {
        DateTime fecha;

        public FormDiasNoHabiles()
        {
            InitializeComponent();
        }

        private void checkBoxRango_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxRango.Checked == true){
                //labelFechaInicial.Visible = true;
                labelFechaInicial.Text = "Fecha Inicial:";
                labelFechaFinal.Visible = true;
                //dateTimePickerFechaInicial.Visible = true;
                dateTimePickerFechaFinal.Visible = true;
                
            }
        }

        private void buttonHabilitar_Click(object sender, EventArgs e)
        {
            if (dataGridViewVerFechasNoHabiles.RowCount > 0)
            {
                DialogResult result1 = MessageBox.Show("¿Seguro que quiere habilitar esta fecha?", "Habilitar fecha", MessageBoxButtons.YesNo);

                if (result1 == DialogResult.Yes)
                {
                    int result = LogicaFechas.eliminarFechaNoHabil(fecha);

                    if (result > 0)
                    {
                        MessageBox.Show("Fecha habilitada");
                    }
                    else
                    {
                        MessageBox.Show("Seleccione fecha");
                    }

                    actualizarListaFechas();
                }
            }
        }

        private void FormDiasNoHabiles_Load(object sender, EventArgs e)
        {
            actualizarListaFechas();
        }

        private void actualizarListaFechas()
        {
            List<Fecha> listaFechas = LogicaFechas.obtenerFechasNoHabiles();
            dataGridViewVerFechasNoHabiles.DataSource = listaFechas;
        }

        private void buttonDeshabilitar_Click(object sender, EventArgs e)
        {
            int resultado;
            if (checkBoxRango.Checked == true)
            {
                resultado = LogicaFechas.agregarFechasPorRango(dateTimePickerFechaInicial.Value.Date, dateTimePickerFechaFinal.Value.Date);
            }
            else
            {
                resultado = LogicaFechas.agregarFechaNoHabil(dateTimePickerFechaInicial.Value.Date);
            }

            if (resultado > 0)
            {
                MessageBox.Show("Fecha insertada");
                actualizarListaFechas();
            }
            else
            {
                MessageBox.Show("Error al insertar fecha");
            }
        }

        private void dataGridViewVerFechasNoHabiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewVerFechasNoHabiles.RowCount > 0)
            {
                fecha = new DateTime();
                fecha = Convert.ToDateTime(dataGridViewVerFechasNoHabiles.SelectedCells[0].Value);
            }
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
