using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public class Program
    {      
        static void Main(string[] args)
        {
            RunVotingErrorSimulation();

            
            Console.ReadKey();
        }

        static Random randomGen = new Random();


        private static void RunVotingErrorSimulation()
        {
            Console.Write("Enter number of voters: ");
            int numVoters = ReadInt();
            Console.WriteLine();

            Console.Write("Enter percentage spread between candidates: ");
            double percentageSpread = ReadDouble();
            Console.WriteLine();

            Console.Write("Enter voting error percentage: ");
            double errorPercentage = ReadDouble();
            Console.WriteLine();

            int leaderVotes = getLeadingVotes(numVoters, percentageSpread);
            int losingVotes = getLosingVotes(numVoters, percentageSpread);

            int invalidTrials = 0;
            int NUM_OF_TRIALS = 500;

            for (int i = 0; i < NUM_OF_TRIALS; i++)
            {
                int recordedLeadVotes = 0;
                int recordedLosingVotes = 0;

                for (int v = 0; v < leaderVotes; v++)
                {
                    if (isInverted(errorPercentage))
                    {
                        recordedLosingVotes++;
                    }
                    else
                    {
                        recordedLeadVotes++;
                    }
                }

                for (int v = 0; v < losingVotes; v++)
                {
                    if (!isInverted(errorPercentage))
                    {
                        recordedLosingVotes++;
                    }
                    else
                    {
                        recordedLeadVotes++;
                    }
                }

                if (recordedLeadVotes <= recordedLosingVotes)
                {
                    invalidTrials++;
                }
            }

            double invalidChance = Convert.ToDouble(invalidTrials) / Convert.ToDouble(NUM_OF_TRIALS);

            Console.WriteLine("Last Trial Stats: ");
            Console.WriteLine("The leader had {0} votes: ", leaderVotes);
            Console.WriteLine("The loser had {0} votes: ", losingVotes);

            Console.WriteLine("There were {0} invalid trials", invalidTrials);
            Console.WriteLine("Chance of an invalid election result after 500 trials = {0}%", invalidChance * 100);
        }

        static int getLeadingVotes(int totalVotes, double percentSpread)
        {
            double halfSpread = percentSpread/2;
            double factor = .5 + halfSpread;
            double result = totalVotes * factor;
            return Convert.ToInt32(result);
        }
        
        static int getLosingVotes(int totalVotes, double percentSpread)
        {
            double halfSpread = percentSpread / 2;
            double factor = .5 - halfSpread;
            double result = totalVotes * factor;
            return Convert.ToInt32(result);
        }

        static bool isInverted(double errorPercent)
        {
            int rollOutcome = randomGen.Next(1, 100);
            double percent = Convert.ToDouble(rollOutcome) / 100.00;            
            if (percent <= errorPercent)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static int ReadInt()
        {
           
            string inputString = Console.ReadLine();
            int result = Convert.ToInt32(inputString);
            return result;
        }

        private static double ReadDouble()
        {

            string inputString = Console.ReadLine();
            double result = Convert.ToDouble(inputString);
            return result;
        }

        private static void GetPerfectNumbers()
        {
            List<int> perfectNumbers = new List<int>();

            for (int i = 1; i < 10001; i++)
            {
                if (IsPerfect(i) == true)
                {
                    perfectNumbers.Add(i);
                }
            }

            foreach (var num in perfectNumbers)
            {
                Console.WriteLine(num);
            }
        }

        static public bool IsPerfect(int number)
        {
            int myInt = number;
            int ans;
            List<int> divisors = new List<int>();

            for (int i = 1; i < number; i++)
            {
                // add divisors to list
                Math.DivRem(myInt, i, out ans);
                if (ans == 0)
                {
                    divisors.Add(i);
                }
            }

            if (divisors.Sum() == myInt)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        private static void TestDivisorFunction()
        {
            int ans;
            Math.DivRem(6, 3, out ans);
            Console.WriteLine("{0}", ans);
            Console.ReadKey();
        }
    }
}
