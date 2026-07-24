using Estadisticas.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Estadisticas.BusinessLogic
{
    public class LogicaPercentiles
    {
        public static int edadMesesMaxima = 60;
        private static double[] valoresZPercentiles = { -1.8808, -1.0364, 0.0, 1.0364, 1.8808 };
        private static string[] nombresPercentiles = { "P3", "P15", "P50", "P85", "P97" };
        private static double AjusteLongitudEstatura = 0.7; // cm de diferencia entre longitud (acostado) y estatura (de pie), por convención OMS

        public static Paciente obtenerPacientePorId(int idPaciente)
        {
            return EstadisticaDatos.obtenerDatosDePaciente(idPaciente);
        }

        public static List<ParametrosLMS> obtenerParametrosLMS(string parametro, int meses, string sexo)
        {
            return CrecimientoDatos.obtenerParametrosLMS(parametro, meses, sexo);
        }

        public static int calcularEdadMeses(DateTime fechaNacimiento, DateTime fechaConsulta)
        {
            int meses = (fechaConsulta.Year - fechaNacimiento.Year) * 12 + (fechaConsulta.Month - fechaNacimiento.Month);

            if (fechaConsulta.Day < fechaNacimiento.Day)
            {
                meses--;
            }

            return meses;
        }

        public static double calcularZ(double valor, ParametrosLMS lms)
        {
            if (lms.L == 0)
            {
                return Math.Log(valor / lms.M) / lms.S;
            }
            else
            {
                return (Math.Pow((valor / lms.M), lms.L) - 1) / (lms.L * lms.S);
            }
        }

        public static double calcularPercentil(double z)
        {
            double t = 1 / (1 + 0.2316419 * Math.Abs(z));
            double phiZ = (1 / Math.Sqrt(2 * Math.PI)) * Math.Exp(-z * z / 2.0);
            double b1 = 0.319381530;
            double b2 = -0.356563782;
            double b3 = 1.781477937;
            double b4 = -1.821255978;
            double b5 = 1.330274429;

            double fz = 1 - phiZ * (b1 * t + b2 * Math.Pow(t, 2) + b3 * Math.Pow(t, 3) + b4 * Math.Pow(t, 4) + b5 * Math.Pow(t, 5));

            if (z >= 0)
            {
                return fz * 100;

            }
            else
            {
                return (1 - fz) * 100;
            }
        }

        public static double obtenerValorEsperado(double z, ParametrosLMS lms)
        {
            if (lms.L == 0)
            {
                return lms.M * Math.Exp(lms.S * z);
            }
            else
            {
                return lms.M * Math.Pow((1 + lms.L * lms.S * z), (1 / lms.L));
            }
        }

        // Dado el mes y la lista completa, devuelve el ParametrosLMS correcto,
        // resolviendo el traslape Acostado/De_pie del mes 24 para Talla.
        public static ParametrosLMS seleccionarParametroPorMes(List<ParametrosLMS> lista, string indicador, int mes)
        {
            string medicionEsperada = obtenerMedicionEsperada(indicador, mes);

            foreach (ParametrosLMS p in lista)
            {
                if (p.MesEdad == mes && p.Medicion == medicionEsperada)
                {
                    return p;
                }
            }

            return null;
        }

        // Determina qué técnica de medición corresponde según la edad (corte OMS: 24 meses).
        public static string obtenerMedicionEsperada(string indicador, int mesEdad)
        {
            if (indicador != "Talla")
            {
                return "Unica";
            }

            return mesEdad < 24 ? "Acostado" : "De_pie";
        }

        // Convierte una longitud (acostado) a su equivalente en estatura (de pie).
        public static double convertirLongitudAEstatura(double longitud)
        {
            return longitud - AjusteLongitudEstatura;
        }

        // Convierte una estatura (de pie) a su equivalente en longitud (acostado).
        public static double convertirEstaturaALongitud(double estatura)
        {
            return estatura + AjusteLongitudEstatura;
        }

        public static List<CurvaPercentil> generarCurvasReferencia(Paciente paciente, string indicador)
        {
            List<CurvaPercentil> curvas = new List<CurvaPercentil>();
            int edadMeses = calcularEdadMeses(paciente.FechaNacimiento, DateTime.Now);

            if (edadMeses > edadMesesMaxima)
            {
                edadMeses = edadMesesMaxima;
            }

            List<ParametrosLMS> parametrosLMS = obtenerParametrosLMS(indicador, edadMeses, paciente.Sexo);
            List<PuntoCrecimiento> crecimiento = LogicaEstadisticas.obtenerCurvaCrecimiento(paciente.IdPaciente);

            if (crecimiento.Count > 0)
            {

                for (int i = 0; i <= 4; i++)
                {
                    double z = valoresZPercentiles[i];
                    string nombre = nombresPercentiles[i];
                    CurvaPercentil curva = new CurvaPercentil();
                    curva.EsPaciente = false;
                    curva.Nombre = nombre;
                    curva.Puntos = new List<PuntoReferencia>();

                    for (int mes = 0; mes <= edadMeses; mes++)
                    {
                        PuntoReferencia puntoReferencia = new PuntoReferencia();
                        ParametrosLMS lms = seleccionarParametroPorMes(parametrosLMS, indicador, mes);
                        double valor = obtenerValorEsperado(z, lms);

                        puntoReferencia.MesEdad = mes;
                        puntoReferencia.Valor = valor;
                        curva.Puntos.Add(puntoReferencia);
                    }

                    curvas.Add(curva);
                }

                CurvaPercentil curvaCrecimiento = new CurvaPercentil();
                curvaCrecimiento.EsPaciente = true;
                curvaCrecimiento.Nombre = paciente.NombrePaciente;
                curvaCrecimiento.Puntos = new List<PuntoReferencia>();

                foreach (PuntoCrecimiento punto in crecimiento)
                {
                    PuntoReferencia puntoReferencia = new PuntoReferencia();
                    puntoReferencia.MesEdad = punto.EdadMeses;
                    switch(indicador)
                    {
                        case "Peso":
                            puntoReferencia.Valor = punto.Peso;
                            break;

                        case "Talla":
                            puntoReferencia.Valor = punto.Talla;
                            break;
                    }
                    
                    curvaCrecimiento.Puntos.Add(puntoReferencia);
                }

                curvas.Add(curvaCrecimiento);
            }

            return curvas;
        }
    }
}
