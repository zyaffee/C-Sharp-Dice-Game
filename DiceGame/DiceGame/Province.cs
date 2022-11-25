using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    class Province
    {
        public string Name { get; set; }

        public string Aligned { get; set; }

        public List<Unit> Units;

        private int Wealth;

        public int Abundance;

        private Player OccupyingPlayer;

        private List<Province> AdjacentProvinces;

        
    }
}
