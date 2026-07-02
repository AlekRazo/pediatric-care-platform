using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Citas.BusinessLogic
{
    class Fecha
    {
        DateTime fechaNoHabil;

        public Fecha()
        {
        }

        public Fecha(DateTime fecha)
        {
            this.fechaNoHabil = fecha;
        }

        public DateTime FechaNoHabil
        {
            get
            {
                return fechaNoHabil;
            }
            set
            {
                this.fechaNoHabil = value;
            }
        }
    }
}
