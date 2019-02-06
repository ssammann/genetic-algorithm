using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hosh_genetic
{
    class Gen
    {
        private string[] genv = new string[12];

        private double fitness;
        private Boolean isway = false;
        public string[] Genv
        {
            set
            {
                genv = value;
            }
            get
            {
                return genv;
            }
        }
        public double Fitness
        {
            set
            {
                fitness = value;
            }
            get
            {
                return fitness;
            }
        }
        public Boolean Isway
        {
            set
            {
                isway = value;
            }
            get
            {
                return isway;
            }
        }
    }
    
}
