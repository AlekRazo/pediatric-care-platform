using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacientes.BusinessLogic
{
    class Vacunacion
    {
        int idVacunacion;
        int idPaciente;
        bool hepatitisA;
        bool hepatitisB;
        bool hib;
        bool meningococo;
        bool bpt;
        bool poliomielitis;
        bool rotavirus;
        bool neumococo;
        bool influenzaEstacionaria;
        bool mmr;
        bool varicela;
        bool hpv;
        bool tuberculosis;

        public Vacunacion()
        {
        }

        //Getters, Setters

        public int IdVacunacion
        {
            get
            {
                return idVacunacion;
            }
            set
            {
                idVacunacion = value;
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

        public bool HepatitisA
        {
            get
            {
                return hepatitisA;
            }
            set
            {
                hepatitisA = value;
            }
        }

        public bool HepatitisB
        {
            get
            {
                return hepatitisB;
            }
            set
            {
                hepatitisB = value;
            }
        }

        public bool HIB
        {
            get
            {
                return hib;
            }
            set
            {
                hib = value;
            }
        }

        public bool Meningococo
        {
            get
            {
                return meningococo;
            }
            set
            {
                meningococo = value;
            }
        }

        public bool BPT
        {
            get
            {
                return bpt;
            }
            set
            {
                bpt= value;
            }
        }

        public bool Poliomielitis
        {
            get
            {
                return poliomielitis;
            }
            set
            {
                poliomielitis = value;
            }
        }

        public bool Rotavirus
        {
            get
            {
                return rotavirus;
            }
            set
            {
                rotavirus = value;
            }
        }

        public bool Neumococo
        {
            get
            {
                return neumococo;
            }
            set
            {
                neumococo = value;
            }
        }

        public bool Influenza
        {
            get
            {
                return influenzaEstacionaria;
            }
            set
            {
                influenzaEstacionaria = value;
            }
        }

        public bool MMR
        {
            get
            {
                return mmr;
            }
            set
            {
                mmr = value;
            }
        }

        public bool Varicela
        {
            get
            {
                return varicela;
            }
            set
            {
                varicela = value;
            }
        }

        public bool HPV
        {
            get
            {
                return hpv;
            }
            set
            {
                hpv = value;
            }
        }

        public bool Tuberculosis
        {
            get
            {
                return tuberculosis;
            }
            set
            {
                tuberculosis = value;
            }
        }
    }
}
