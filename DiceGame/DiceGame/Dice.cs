using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    public class Dice
    {
        // Properties
        public string Name;
        public double[] Faces;
        public List<Dice> RoundRobinFlag = new List<Dice>();
        public double[] matchupScore = new double[2];
        public double RoundRobinScore = 0;

        // Constructors
        public Dice() { }

        public Dice(string name, double[] faces)
        {
            this.Name = name;
            this.Faces = faces;
        }

        // Methods
        
        public override string ToString()
        {
            return this.Name;
        }
    }

    // Regular 6-Sided Die
    //-------------------------------------------------------------
    class Die123456 : Dice
    {
        public Die123456()
        {
            this.Name = "D6";
            this.Faces = new double[] { 1, 2, 3, 4, 5, 6 };
        }
    }

    // Efron's Dice
    //-------------------------------------------------------------
    class Shieldwall : Dice
    {
        public Shieldwall()
        {
            this.Name = "Shieldwall Maneuvre";
            this.Faces = new double[] { 3, 3, 3, 3, 3, 3 };
        }
    }

    class Skirmish : Dice
    {
        public Skirmish()
        {
            this.Name = "Skirmish Maneuvre";
            this.Faces = new double[] { 4, 4, 4, 4, 0, 0 };
        }
    }

    class Phalanx : Dice
    {
        public Phalanx()
        {
            this.Name = "Phalanx Maneuvre";
            this.Faces = new double[] { 5, 5, 5, 1, 1, 1 };
        }
    }

    class Flanking : Dice
    {
        public Flanking()
        {
            this.Name = "Flanking Maneuvre";
            this.Faces = new double[] { 6, 6, 2, 2, 2, 2 };
        }
    }

    // Equal Averages Variant of Efron's Dice
    //-------------------------------------------------------------
    class Die777711 : Dice
    {
        public Die777711()
        {
            this.Name = "sevensAndOnes";
            this.Faces = new double[] { 7, 7, 7, 7, 1, 1 };
        }
    }

    class Die555555 : Dice
    {
        public Die555555()
        {
            this.Name = "allFives";
            this.Faces = new double[] { 5, 5, 5, 5, 5, 5 };
        }
    }

    class Die993333 : Dice
    {
        public Die993333()
        {
            this.Name = "ninesAndThrees";
            this.Faces = new double[] { 9, 9, 3, 3, 3, 3 };
        }
    }

    class Die888222 : Dice
    {
        public Die888222()
        {
            this.Name = "eightsAndTwos";
            this.Faces = new double[] { 8, 8, 8, 2, 2, 2 };
        }
    }

    // Custom Dice
    //-------------------------------------------------------------
    class ZachDie : Dice
    {
        public ZachDie()
        {
            this.Name = "Zach's Die";
            //this.Faces = new double[] { 7, 6, 5, 1, 1, 1 };
            this.Faces = new double[] { 6, 6, 4, 3, 1, 1 };
        }
    }

    class AshleyDie : Dice
    {
        public AshleyDie()
        {
            this.Name = "Phil Mcrevis";
            //this.Faces = new double[] { 7, 6, 4, 3, 1, 0 };
            this.Faces = new double[] { 8, 5, 4, 3, 1, 0 };
        }
    }

    class BrandiDie : Dice
    {
        public BrandiDie()
        {
            this.Name = "Slingshot";
            //this.Faces = new double[] { 8, 6, 4, 3, 0, 0 };
            //this.Faces = new double[] { 5, 5, 4, 4, 2, 1 };
            //this.Faces = new double[] { 7, 5, 5, 3, 1, 0 };
            //this.Faces = new double[] { 7, 5, 4, 3, 1, 1 };
            this.Faces = new double[] { 8, 5, 4, 2, 2, 0 };
        }
    }

    class BrettDie : Dice
    {
        public BrettDie()
        {
            this.Name = "Brett's Die";
            //this.Faces = new double[] { 10, 5, 2, 2, 1, 1 };
            //this.Faces = new double[] { 7, 6, 3, 3, 1, 1 };
            this.Faces = new double[] { 9, 5, 3, 2, 1, 1 };
        }
    }

    class ChrisDie : Dice
    {
        public ChrisDie()
        {
            this.Name = "Chris's Die";
            this.Faces = new double[] { 5, 5, 4, 4, 3, 0 };
        }
    }

    class DaveDie : Dice
    {
        public DaveDie()
        {
            this.Name = "Dave's Super Lame Really Dumb Die";
            this.Faces = new double[] { 1, 0, 0, 0, 0, 0 };
        }
    }

    class ElijahDie : Dice
    {
        public ElijahDie()
        {
            this.Name = "Three-Six-Nine";
            //this.Faces = new double[] { 9, 6, 3, 1, 1, 1 };
            this.Faces = new double[] { 9, 6, 3, 2, 1, 0 };
        }
    }

    class JohnDie : Dice
    {
        public JohnDie()
        {
            this.Name = "John's Die";
            //this.Faces = new double[] { 7, 7, 7, 0, 0, 0 };
            this.Faces = new double[] { 5, 5, 5, 3, 2, 1 };
        }
    }

    class KiranDie : Dice
    {
        public KiranDie()
        {
            this.Name = "Kiran's Die";
            //this.Faces = new double[] { 8, 7, 6, 0, 0, 0 };
            //this.Faces = new double[] { 5, 5, 4, 3, 2, 2 };
            //this.Faces = new double[] { 4, 4, 4, 4, 4, 1 };
            this.Faces = new double[] { 5, 5, 4, 4, 2, 1 };
        }
    }

    class MoDie : Dice
    {
        public MoDie()
        {
            this.Name = "Hertzmeister";
            //this.Faces = new double[] { 7, 6, 3, 2, 2, 1 };
            //this.Faces = new double[] { 6, 5, 4, 4, 1, 1 };
            this.Faces = new double[] { 5, 5, 4, 3, 3, 1 };
        }
    }

    class NickDie : Dice
    {
        public NickDie()
        {
            this.Name = "(Assorted Pig Noises)";
            //this.Faces = new double[] { 4, 4, 4, 4, 4, 1 };
            //this.Faces = new double[] { 4, 4, 4, 4, 3, 2 };
            //this.Faces = new double[] { 5, 5, 5, 2, 2, 2 };
            //this.Faces = new double[] { 6, 3, 3, 3, 3, 3 };
            //this.Faces = new double[] { 5, 5, 3, 3, 3, 2 };
            //this.Faces = new double[] { 7, 6, 2, 2, 2, 2 };
            this.Faces = new double[] { 6, 6, 6, 1, 1, 1 };
        }
    }    
}
