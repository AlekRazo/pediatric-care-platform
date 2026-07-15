using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estadisticas.Presentation
{
    public partial class FormEstadisticasPaciente : Form
    {
        private int idPaciente;
        private string nombrePaciente;

        public FormEstadisticasPaciente(int idPaciente, string nombrePaciente)
        {
            InitializeComponent();

            this.idPaciente = idPaciente;
            this.nombrePaciente = nombrePaciente;
        }

        private void FormEstadisticasPaciente_Load(object sender, EventArgs e)
        {
            // Cargar estadisticas del paciente en el formulario.
            // Cargar el nombre del paciente en el formulario.
        }
    }
}
