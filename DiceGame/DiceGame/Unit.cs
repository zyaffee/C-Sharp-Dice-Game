using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    class Unit
    {
        public int Strength { get; set; }

        public int CostGold { get; set; }

        public int CostAbundance { get; set; }

        public int Upkeep { get; set; }

        public bool isAgent { get; set; }


    }
}
