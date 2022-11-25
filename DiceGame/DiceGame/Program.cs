using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// League Points: - Mo: 5; Nick: 2; Dave: 0.5; Kiran: 3.5 Brandi: 1


namespace DiceGame
{    
    class Program
    {
        static void Main(string[] args)
        {
            /*
            
            // Our Custom Dice, sum of faces = 21
            ZachDie zachDie = new ZachDie();
            //DaveDie daveDie = new DaveDie();
            NickDie nickDie = new NickDie();
            KiranDie kiranDie = new KiranDie();
            //BrettDie brettDie = new BrettDie();
            //ChrisDie chrisDie = new ChrisDie();
            MoDie moDie = new MoDie();
            JohnDie johnDie = new JohnDie();
            BrandiDie brandiDie = new BrandiDie();
            ElijahDie elijahDie = new ElijahDie();
            AshleyDie ashleyDie = new AshleyDie();

            // Dice Fields

            List<Dice> LeagueEntrants = new List<Dice> { brandiDie, ashleyDie, moDie, kiranDie, nickDie, johnDie };

            */
            //-------------------------------------------[PROGRAM]-----------------------------------------------------|


            var player1 = new Player();

            player1.
            





















            //-------------------------------------------[/PROGRAM]----------------------------------------------------|
            Console.ReadLine();
        }






        //-----------------------------------------------[METHODS]-----------------------------------------------------|

        // DiceTest compares two dice head to head in any number of trials
        public static void DiceTest(Dice a, Dice b, int trials)
        {
            double wins = 0;
            double losses = 0;
            double ties = 0;
            Random random = new Random();
            for (int i = 0; i < trials; i++)
            {
                double aResult = a.Faces[random.Next(0, a.Faces.Length)];
                double bResult = b.Faces[random.Next(0, b.Faces.Length)];
                if (aResult > bResult)
                {
                    wins++;
                }
                else if (aResult == bResult)
                {
                    ties++;
                }
                else
                {
                    losses++;
                }
            }
            Console.WriteLine("{0} won {1}%, lost {2}%, and tied {3}% against {4}",
                a.ToString(), (wins/trials)*100, (losses/trials)*100, (ties/trials)*100, b.ToString());
        }
        
        // FieldTest compares one die against a list of dice in any number of trials
        public static void FieldTest(Dice candidate, List<Dice> diceField, int trials)
        {
            Console.WriteLine("Testing {0} {1}", candidate.ToString(), FaceStringGenerator(candidate));
            double finalResultPercent = 0;
            int skips = 0;
            Random random = new Random();
            foreach (Dice opponent in diceField)
            {
                if (candidate != opponent)
                {
                    double score = 0;
                    double wins = 0;
                    double losses = 0;
                    double ties = 0;
                    for (int i = 0; i < trials; i++)
                    {
                        double aResult = candidate.Faces[random.Next(0, candidate.Faces.Length)];
                        double bResult = opponent.Faces[random.Next(0, opponent.Faces.Length)];                        
                        if (aResult > bResult)
                        {
                            score++;
                            wins++;
                        }
                        else if (aResult == bResult)
                        {
                            score += .5;
                            ties++;
                        }
                        else
                        {
                            losses++;
                        }
                    }
                    finalResultPercent += score;
                    double resultPercent = (score / trials) * 100;
                    Console.WriteLine("VS {0} || W: {1}% | L: {2}% | D: {3}% | Score: {4}%", opponent, (wins / trials) * 100, (losses / trials) * 100, (ties / trials) * 100, resultPercent);
                }
                else
                {
                    skips++;
                }
            }
            finalResultPercent = (finalResultPercent / (trials * (diceField.Count - skips))) * 100;
            Console.WriteLine("---\nResult: {0} is {1}% against this field in {2} trials.\n---\n", candidate.ToString(), finalResultPercent, trials);
        }

        // SuperFieldTest compares every die in a list against each other in any number of trials
        public static void SuperFieldTest(List<Dice> diceField, int trials)
        {
            Random random = new Random();
            string mark = "";
            foreach (Dice candidate in diceField)
            {
                Console.WriteLine("Testing {0} {1} : {2} Rolls", candidate.ToString(), FaceStringGenerator(candidate), trials);
                double finalResultPercent = 0;
                int skips = 0;
                double matchupWins = 0;
                double matchupLosses = 0;
                double matchupDraws = 0;
                foreach (Dice opponent in diceField)
                {
                    if (candidate != opponent)
                    {
                        double score = 0;
                        double wins = 0;
                        double losses = 0;
                        double ties = 0;
                        
                        for (int i = 0; i < trials; i++)
                        {
                            double aResult = candidate.Faces[random.Next(0, candidate.Faces.Length)];
                            double bResult = opponent.Faces[random.Next(0, opponent.Faces.Length)];
                            if (aResult > bResult) {
                                score++; wins++;
                            } else if (aResult == bResult) {
                                score += .5; ties++;
                            } else {
                                losses++;
                            }
                        }
                        finalResultPercent += score;
                        double resultPercent = Math.Round((score / trials) * 100);

                        if (resultPercent > 50) {
                            mark = "Winning";
                            matchupWins++;
                        } else if(resultPercent == 50) {
                            mark = "Drawn";
                            matchupDraws++;
                        } else {
                            mark = "Losing";
                            matchupLosses++;
                        }

                        Console.WriteLine("VS {0} || W: {1}% | L: {2}% | D: {3}% | Matchup : {4}",
                            opponent, Math.Round(((wins / trials) * 100), 1), Math.Round(((losses / trials) * 100), 1), Math.Round(((ties / trials) * 100), 1), mark);
                    } else { skips++; }
                }
                finalResultPercent = (finalResultPercent / (trials * (diceField.Count - skips))) * 100;
                candidate.matchupScore[0] = 100 * (matchupWins + (.5 * matchupDraws)) / (diceField.Count - 1);
                candidate.matchupScore[1] = finalResultPercent;
                Console.WriteLine("---\nResults: Overall Winrate: {0}% | Matchup Score: {1}\nWinning Matchups: {2} | Losing Matchups: {3} | Drawn Matchups: {4}\n---\n",
                    finalResultPercent, Math.Round(candidate.matchupScore[0]), matchupWins, matchupLosses, matchupDraws);
            }
            // Final Result Printout
            double topScore = 0;
            List<Dice> winners = new List<Dice>();
            for (int i = 0; i < diceField.Count; i++)
            {
                if (diceField[i].matchupScore[0] > topScore)
                {
                    topScore = diceField[i].matchupScore[0];
                    winners.Clear();
                    winners.Add(diceField[i]);
                }
                else if (diceField[i].RoundRobinScore == topScore)
                {
                    winners.Add(diceField[i]);
                }
            }
            if (winners.Count > 1)
            {
                topScore = 0;
                List<Dice> tieBreakers = winners;
                winners.Clear();
                for (int i = 0; i < tieBreakers.Count; i++)
                {
                    if (tieBreakers[i].matchupScore[1] > topScore)
                    {
                        topScore = tieBreakers[i].matchupScore[0];
                        winners.Add(tieBreakers[i]);
                    }
                    else if (diceField[i].RoundRobinScore == topScore)
                    {
                        winners.Add(tieBreakers[i]);
                    }
                }
            }
            Console.WriteLine("\nThe winner of today's number crunch is...\n");
            for (int i = 0; i < winners.Count; i++)
            {
                Console.WriteLine("{0} {1}\nOverall Matchup Score: {2} | Overall Winrate: {3}",
                    winners[i].ToString(), FaceStringGenerator(winners[i]), winners[i].matchupScore[0], winners[i].matchupScore[1]);
            }
        }

        // FaceStringGenerator makes a string from the die's faces
        public static string FaceStringGenerator(Dice die)
        {
            string faceString = "(";
            for (int i = 0; i < die.Faces.Length; i++)
            {
                faceString += die.Faces[i].ToString();
                if (i+1 != die.Faces.Length)
                {
                    faceString += ", ";
                }
            }
            faceString += ")";
            return faceString;
        }

        // Round Robin Tournament

        public static void RoundRobinTournament(List<Dice> entries, int bestOf)
        {
            Console.WriteLine("Welcome to the round robin portion of today's CBD League!\n\n" +
                              "Today's contestants are:\n");
            foreach (Dice e in entries)
            {
                e.RoundRobinScore = 0;
                e.RoundRobinFlag.Clear();
                Console.ReadLine();
                Console.WriteLine("{0} {1}", e.ToString(), FaceStringGenerator(e));
            }
            int round = 0;
            /*
            int entrants = entries.Count;
            int matches = ((entrants * (entrants - 1)) / 2);
            Dice[,] matchupChart = new Dice[matches, matches];
            for (int i = 0; i > entrants; i++)
            {
                matchupChart[i, i] = null;
            }
            */

            List<double> scoreReports = new List<double>();

            System.Threading.Thread.Sleep(500);
            Console.WriteLine("\n_Ready?");
            Console.ReadLine();
            Random random = new Random();
            foreach (Dice a in entries)
            {
                foreach (Dice b in entries)
                {
                    if (!a.RoundRobinFlag.Contains(b) && a != b)
                    {
                        
                        a.RoundRobinFlag.Add(b);
                        b.RoundRobinFlag.Add(a);
                        
                        Console.Clear();
                        int scoreA = 0;
                        int scoreB = 0;
                        int draws = 0;
                        Console.WriteLine("ROUND {0}", ++round);
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        for (int i = 0; i < 4; i++)
                        {                            
                            Console.WriteLine("{0} {1} VS  {2} {3}", a.ToString(), FaceStringGenerator(a), b.ToString(), FaceStringGenerator(b));
                            System.Threading.Thread.Sleep(25);
                            Console.Clear();
                            System.Threading.Thread.Sleep(5);
                        }
                        Console.WriteLine("{0} {1} VS  {2} {3}", a.ToString(), FaceStringGenerator(a), b.ToString(), FaceStringGenerator(b));
                        System.Threading.Thread.Sleep(700);

                        for (int i = 0; i < bestOf; i++)
                        {
                            
                            Console.Clear();
                            Console.Write("3");
                            System.Threading.Thread.Sleep(300);
                            Console.Clear();
                            Console.Write("2");
                            System.Threading.Thread.Sleep(300);
                            Console.Clear();
                            Console.Write("1");
                            System.Threading.Thread.Sleep(300);
                            Console.Clear();
                            Console.WriteLine("ROLL!!!\n");
                            System.Threading.Thread.Sleep(400);
                            
                            double aResult = a.Faces[random.Next(0, a.Faces.Length)];
                            Console.WriteLine("{0} rolls a {1}...", a.ToString(), aResult);
                            System.Threading.Thread.Sleep(200);
                            double bResult = b.Faces[random.Next(0, b.Faces.Length)];
                            Console.WriteLine("{0} rolls a {1}!\n", b.ToString(), bResult);
                            System.Threading.Thread.Sleep(200);
                            /*
                            Console.WriteLine("\n" +
                                              "\n" +
                                              "\n" +
                                              "\n" +
                                              "\n" +
                                              "\n" +
                                              "\n" +
                                              "\n" +
                                              "\n" +
                                              "\n" +
                                              "\n" +
                                              "\n" +
                                              "\n" +
                                              "");
                            System.Threading.Thread.Sleep(500);
                            */
                            if (aResult > bResult)
                            {
                                scoreA++;
                                if (aResult - bResult > 5)
                                {
                                    Console.WriteLine("{0} HUMILIATES {1}", a.ToString(), b.ToString());
                                }
                                else if (aResult - bResult == 1)
                                {
                                    Console.WriteLine("BY THE SKIN OF THEIR TEETH IT'S {0}!!!", a.ToString());
                                }
                                else
                                {
                                    Console.WriteLine("{0} beats {1}!", a.ToString(), b.ToString());
                                }
                            }
                            else if (aResult < bResult)
                            {
                                scoreB++;
                                if (bResult - aResult > 5)
                                {
                                    Console.WriteLine("{0} HUMILIATES {1}", b.ToString(), a.ToString());
                                }
                                else if (bResult - aResult == 1)
                                {
                                    Console.WriteLine("BY THE SKIN OF THEIR TEETH IT'S {0}!!!", b.ToString());
                                }
                                else
                                {
                                    Console.WriteLine("{0} beats {1}!", b.ToString(), a.ToString());
                                }
                            }
                            else
                            {
                                draws++;
                                Console.WriteLine("DRAW");
                            }
                            System.Threading.Thread.Sleep(500);
                            Console.WriteLine("\nCurrent Scores - {0}: {1} - {2}: {3} - Draws: {4}", a.ToString(), scoreA, b.ToString(), scoreB, draws);
                            Console.ReadLine();
                        }

                        if (scoreA > scoreB)
                        {
                            Console.Clear();
                            a.RoundRobinScore += 1;
                            Console.WriteLine("{0} DEFEATS {1} {2} to {3}", a.ToString(), b.ToString(), scoreA, scoreB);

                        }
                        else if (scoreB > scoreA)
                        {
                            Console.Clear();
                            b.RoundRobinScore += 1;
                            Console.WriteLine("{0} DEFEATS {1} {2} to {3}", b.ToString(), a.ToString(), scoreB, scoreA);
                        }
                        else
                        {
                            Console.Clear();
                            a.RoundRobinScore += .5;
                            b.RoundRobinScore += .5;
                            Console.WriteLine("Improbably, the match is a draw. Both players receive half a point.\n");
                        }

                        scoreReports.Add(scoreA);
                        scoreReports.Add(scoreB);

                        Console.WriteLine("\n___Standings\n");

                        foreach (Dice RRScore in entries)
                        {
                            Console.WriteLine("{0} : {1} match pts.", RRScore.ToString(), RRScore.RoundRobinScore);
                        }
                        // Wait for input
                        Console.ReadLine();
                        
                    }
                }
            }

            double topScore = 0;
            List<String> winners = new List<string>();
            for (int i = 0; i < entries.Count; i++)
            {
                if (entries[i].RoundRobinScore > topScore)
                {
                    topScore = entries[i].RoundRobinScore;
                    winners.Clear();
                    winners.Add(entries[i].ToString());
                }
                else if (entries[i].RoundRobinScore == topScore)
                {
                    winners.Add(entries[i].ToString());
                }
            }

            if (winners.Count > 1)
            {
                Console.WriteLine("The winner of today's CBD League Round Robin Tournament is...");
                Console.ReadLine();
                Console.WriteLine("It's a {0}-way tie between...\n", winners.Count);
                foreach(string winner in winners)
                {
                    Console.WriteLine(winner);
                }
            }
            else
            {
                Console.WriteLine("The winner of today's CBD League Round Robin Tournament is...");
                Console.ReadLine();
                Console.WriteLine("{0}!!!\n", winners[0]);
            }

            
            Console.WriteLine("\n   |   |   |   |   |   |\n" +
                                $" \\ | {scoreReports[0]} | {scoreReports[2]} | {scoreReports[4]} | {scoreReports[6]} | {scoreReports[8]} | {FaceStringGenerator(entries[0])} {entries[0].ToString()}\n" +
                                  "___|___|___|___|___|___|__\n" +
                                  "   |   |   |   |   |   |\n" +
                                $" {scoreReports[1]} | \\ | {scoreReports[10]} | {scoreReports[12]} | {scoreReports[14]} | {scoreReports[16]} | {FaceStringGenerator(entries[1])} {entries[1].ToString()}\n" +
                                  "___|___|___|___|___|___|__\n" +
                                  "   |   |   |   |   |   |\n" +
                                $" {scoreReports[3]} | {scoreReports[11]} | \\ | {scoreReports[18]} | {scoreReports[20]} | {scoreReports[22]} | {FaceStringGenerator(entries[2])} {entries[2].ToString()}\n" +
                                  "___|___|___|___|___|___|__\n" +
                                  "   |   |   |   |   |   |\n" +
                                $" {scoreReports[5]} | {scoreReports[13]} | {scoreReports[19]} | \\ | {scoreReports[24]} | {scoreReports[26]} | {FaceStringGenerator(entries[3])} {entries[3].ToString()}\n" +
                                  "___|___|___|___|___|___|__\n" +
                                  "   |   |   |   |   |   |\n" +
                                $" {scoreReports[7]} | {scoreReports[15]} | {scoreReports[21]} | {scoreReports[25]} | \\ | {scoreReports[28]} | {FaceStringGenerator(entries[4])} {entries[4].ToString()}\n" +
                                  "___|___|___|___|___|___|__\n" +
                                  "   |   |   |   |   |   |\n" +
                                $" {scoreReports[9]} | {scoreReports[17]} | {scoreReports[23]} | {scoreReports[27]} | {scoreReports[29]} | \\ | {FaceStringGenerator(entries[5])} {entries[5].ToString()}\n" +
                                  "   |   |   |   |   |   |\n");
            /*
            Console.WriteLine("\n   |   |   |   |   |   |\n" +
                                $" \\ | {scoreReports[0]} | {scoreReports[2]} | {scoreReports[4]} | {scoreReports[6]} | {scoreReports[8]} | {FaceStringGenerator(entries[0])} {entries[0].ToString()}\n" +
                                  "___|___|___|___|___|___|__\n" +
                                  "   |   |   |   |   |   |\n" +
                                $" {scoreReports[1]} | \\ | {scoreReports[10]} | {scoreReports[12]} | {scoreReports[14]} | {scoreReports[16]} | {FaceStringGenerator(entries[1])} {entries[1].ToString()}\n" +
                                  "___|___|___|___|___|___|__\n" +
                                  "   |   |   |   |   |   |\n" +
                                $" {scoreReports[3]} | {scoreReports[11]} | \\ | {scoreReports[18]} | {scoreReports[20]} | {scoreReports[22]} | {FaceStringGenerator(entries[2])} {entries[2].ToString()}\n" +
                                  "___|___|___|___|___|___|__\n" +
                                  "   |   |   |   |   |   |\n" +
                                $" {scoreReports[5]} | {scoreReports[13]} | {scoreReports[19]} | \\ | {scoreReports[24]} | {scoreReports[26]} | {FaceStringGenerator(entries[3])} {entries[3].ToString()}\n" +
                                  "___|___|___|___|___|___|__\n" +
                                  "   |   |   |   |   |   |\n" +
                                $" {scoreReports[7]} | {scoreReports[15]} | {scoreReports[21]} | {scoreReports[25]} | \\ | {scoreReports[28]} | {FaceStringGenerator(entries[4])} {entries[4].ToString()}\n" +
                                  "___|___|___|___|___|___|__\n" +
                                  "   |   |   |   |   |   |\n" +
                                $" {scoreReports[9]} | {scoreReports[17]} | {scoreReports[23]} | {scoreReports[27]} | {scoreReports[29]} | \\ | {FaceStringGenerator(entries[5])} {entries[5].ToString()}\n" +
                                  "   |   |   |   |   |   |\n");
            */
        }
    }
}
