using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiceGame
{
    /// <summary>
    /// Interaction logic for DiceGameInterface.xaml
    /// </summary>
    public partial class DiceGameInterface : UserControl
    {
        public DiceGameInterface()
        {
            // Standard 6-Sided Die
            Die123456 D6 = new Die123456();

            // Bradley Efron's Dice
            Die333333 allThrees = new Die333333();
            Die444400 foursAndZeros = new Die444400();
            Die555111 fivesAndOnes = new Die555111();
            Die662222 sixesAndTwos = new Die662222();

            // Equal Average Variant
            Die555555 allFives = new Die555555();
            Die777711 sevensAndOnes = new Die777711();
            Die888222 eightsAndTwos = new Die888222();
            Die993333 ninesAndThrees = new Die993333();

            // Our Custom Dice, sum of faces = 21
            ZachDie zachDie = new ZachDie();
            DaveDie daveDie = new DaveDie();
            NickDie nickDie = new NickDie();
            KiranDie kiranDie = new KiranDie();
            BrettDie brettDie = new BrettDie();
            ChrisDie chrisDie = new ChrisDie();

            // Dice Fields
            List<Dice> diceFieldEfron = new List<Dice> { allThrees, foursAndZeros, fivesAndOnes, sixesAndTwos };
            List<Dice> diceFieldEqAvg = new List<Dice> { allFives, sevensAndOnes, eightsAndTwos, ninesAndThrees };
            List<Dice> diceFieldShitGang = new List<Dice> { daveDie, nickDie, kiranDie, brettDie, chrisDie };

            InitializeComponent();
        }
    }
}
