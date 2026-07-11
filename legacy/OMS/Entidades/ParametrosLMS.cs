using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Entidades
{
    public class ParametrosLMS
    {
        public int EdadMeses { get; set; }

        public decimal L { get; set; }

        public decimal M { get; set; }

        public decimal S { get; set; }

        public ParametrosLMS()
        {

        }

        public ParametrosLMS(
            int edadMeses,
            decimal l,
            decimal m,
            decimal s)
        {
            EdadMeses = edadMeses;
            L = l;
            M = m;
            S = s;
        }
    }
}
