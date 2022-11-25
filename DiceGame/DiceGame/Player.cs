using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    class Player
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Alliance { get; set; }

        public List<Cluster> Domain = new List<Cluster>();

    }
}
