using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Citas.DataAccess;

namespace Citas.BusinessLogic
{
    class LogicaCitas
    {
        public static List<Cita> obtenerCitas()
        {
            return CitaDatos.obtenerDatosDeCitas();
        }
        public static List<Cita> obtenerCitasPorFecha(DateTime fechaBusqueda)
        {
            return CitaDatos.obtenerDatosDeCitasPorFecha(fechaBusqueda);
        }

        public static int capturarCita(Cita objCita)
        {
            if (objCita.FechaCita > DateTime.Today.Date)
            {
                DateTime limite = DateTime.Today.AddDays(60);

                if (objCita.FechaCita.Date <= limite.Date)
                {
                    if (objCita.FechaCita.DayOfWeek == DayOfWeek.Sunday)
                    {
                        //-3 es el número de error enviado para indicar que no se puede agendar una cita en domingo
                        return -3;
                    }
                    else
                    {
                        bool existe = LogicaFechas.existeFecha(objCita.FechaCita.Date);
                        if (!existe)
                        {
                            if (objCita.HoraCita.Minutes == 0 || objCita.HoraCita.Minutes == 20 || objCita.HoraCita.Minutes == 40)
                            {
                                if (objCita.HoraCita.Hours == 0 && objCita.HoraCita.Minutes == 0)
                                {
                                    // -6 es el número de error que indica que la hora es inválida
                                    return -6;
                                }

                                //Comprobar si existe otra cita
                                Cita apartado = CitaDatos.obtenerDatosDeCitasPorFechaYHora(objCita.FechaCita.Date, objCita.HoraCita);

                                if (apartado.FechaCita.Date == objCita.FechaCita.Date && apartado.HoraCita == objCita.HoraCita)
                                {
                                    //-7 es el número de error que aparece cuando ya existe otra cita agendada.
                                    return -7;
                                }
                                else
                                {
                                    return CitaDatos.registrarDatosDeCita(objCita);
                                }
                            }
                            else
                            {
                                //-5 es el numero de error que indica si la hora es múltiplo de 20 minutos.
                                return -5;
                            }
                        }
                        else
                        {
                            //-4 es el número de error enviado para indicar que la fecha está inhabilitada
                            return -4;
                        }
                    }
                }
                else
                {
                    // -1 es el número de error enviado para indicar que no se puede agendar en una fecha anterior a la actual
                    return -2;
                }
            }
            else
            {
                /*-2 es el número de error enviado para indicar que la fecha agendada excede el límite máximo de
                    * 60 días después de la fecha actual */ 
                return -1;
            }
        }

        public static int actualizarCita(Cita objCita)
        {
            if (objCita.FechaCita > DateTime.Today.Date)
            {
                DateTime limite = DateTime.Today.AddDays(60);

                if (objCita.FechaCita.Date <= limite.Date)
                {
                    if (objCita.FechaCita.DayOfWeek == DayOfWeek.Sunday)
                    {
                        //-3 es el número de error enviado para indicar que no se puede agendar una cita en domingo
                        return -3;
                    }
                    else
                    {
                        bool existe = LogicaFechas.existeFecha(objCita.FechaCita.Date);
                        if (!existe)
                        {
                            if (objCita.HoraCita.Minutes == 0 || objCita.HoraCita.Minutes == 20 || objCita.HoraCita.Minutes == 40)
                            {
                                if (objCita.HoraCita.Hours == 0 && objCita.HoraCita.Minutes == 0)
                                {
                                    // -6 es el número de error que indica que la hora es inválida
                                    return -6;
                                }

                                //Comprobar si existe otra cita
                                Cita apartado = CitaDatos.obtenerDatosDeCitasPorFechaYHora(objCita.FechaCita.Date, objCita.HoraCita);

                                if (apartado.FechaCita.Date == objCita.FechaCita.Date && apartado.HoraCita == objCita.HoraCita)
                                {
                                    //-7 es el número de error que aparece cuando ya existe otra cita agendada.
                                    return -7;
                                }
                                else
                                {
                                    return CitaDatos.modificarDatosDeCita(objCita);
                                }
                            }
                            else
                            {
                                //-5 es el numero de error que indica si la hora es múltiplo de 20 minutos.
                                return -5;
                            }
                        }
                        else
                        {
                            //-4 es el número de error enviado para indicar que la fecha está inhabilitada
                            return -4;
                        }
                    }
                }
                else
                {
                    /*-2 es el número de error enviado para indicar que la fecha agendada excede el límite máximo de
                    * 60 días después de la fecha actual */
                    return -2;
                }
            }
            else
            {
                // -1 es el número de error enviado para indicar que no se puede agendar en una fecha anterior a la actual
                return -1;
            }
        }

        public static int eliminarCita(int idCita)
        {
            return CitaDatos.eliminarDatosDeCita(idCita);
        }
    }
}
