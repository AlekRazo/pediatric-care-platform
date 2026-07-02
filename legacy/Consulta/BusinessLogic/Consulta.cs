using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consultas.BusinessLogic
{
    class Consulta
    {
        int idConsulta;
        int idPaciente;
        DateTime fechaConsulta;
        string motivo;
        string responsabilidad;
        int frecuenciaCardiaca;
        int frecuenciaRespiratoria;
        string tensionArterial;
        double temperatura;
        double peso;
        double talla;
        string diagnostico;

        public Consulta()
        {
        }

        public int IdConsulta
        {
            get
            {
                return idConsulta;
            }
            set
            {
                idConsulta = value;
            }
        }

        public int IdPaciente
        {
            get
            {
                return idPaciente;
            }
            set
            {
                idPaciente = value;
            }
        }

        public DateTime FechaConsulta
        {
            get
            {
                return fechaConsulta;
            }
            set
            {
                fechaConsulta = value;
            }
        }

        public string Motivo
        {
            get
            {
                return motivo;
            }
            set
            {
                motivo = value;
            }
        }

        public string Responsabilidad
        {
            get
            {
                return responsabilidad;
            }
            set
            {
                responsabilidad = value;
            }
        }

        public int FrecuenciaCardiaca
        {
            get
            {
                return frecuenciaCardiaca;
            }
            set
            {
                frecuenciaCardiaca = value;
            }
        }

        public int FrecuenciaRespiratoria
        {
            get
            {
                return frecuenciaRespiratoria;
            }
            set
            {
                frecuenciaRespiratoria = value;
            }
        }

        public string TensionArterial
        {
            get
            {
                return tensionArterial;
            }
            set
            {
                tensionArterial = value;
            }
        }

        public double Temperatura
        {
            get
            {
                return temperatura;
            }
            set
            {
                temperatura = value;
            }
        }

        public double Peso
        {
            get
            {
                return peso;
            }
            set
            {
                peso = value;
            }
        }

        public double Talla
        {
            get
            {
                return talla;
            }
            set
            {
                talla = value;
            }
        }

        public string Diagnostico
        {
            get
            {
                return diagnostico;
            }
            set
            {
                diagnostico = value;
            }
        }
    }
}
