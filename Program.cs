using System;
using System.Collections.Generic;
using PlantGrower.Models;
using System.Timers;
// using System.Threading;

namespace PlantGrower
{
    public class Program
    {
        private static System.Timers.Timer timer;
        // private static Thread inputThread;
        // private static AutoResetEvent getInput, gotInput;
        // private static string input;
        public static void Main()
        {
            int inputInt;
            // getInput = new AutoResetEvent(false);
            // gotInput = new AutoResetEvent(false);
            Console.WriteLine("Welcome to the Plant Grower!");
            Console.WriteLine("Name your plant: ");
            string name = Console.ReadLine();
            Plant myPlant = new Plant(name, 5);
            timer = new System.Timers.Timer(5000);
            timer.Elapsed += (sender, e) => BadStuff(sender, e, myPlant);
            timer.Start();

            while(myPlant.PlantHealth > 0)
            {
                Console.WriteLine("{0}'s health is {1}", myPlant.PlantName, myPlant.PlantHealth);
                Console.WriteLine("What action would you like to take?");
                Console.WriteLine("1: Water {0}", myPlant.PlantName);
                Console.WriteLine("2: Feed {0}", myPlant.PlantName);
                Console.WriteLine("3: Give sunshine to {0}", myPlant.PlantName);
                Console.WriteLine("4: Do nothing");
                Console.WriteLine("5: Exit program");

                // bool success = TryReadLine(out name, 3000);
                // Console.WriteLine(success);
                // if  (success) {
                    inputInt = int.Parse(Console.ReadLine());
                    TakeAction(myPlant, inputInt);
                // }
                if (myPlant.PlantHealth <= 0) {
                    Console.WriteLine("The plant {0} is dead!", myPlant.PlantName);
                    break;
                }
                
            }
            timer.Stop();
            Console.WriteLine("Thanks for visiting the Plant Grower!");
        }

        private static void TakeAction(Plant plant, int input)
        {
            switch(input)
            {
                case 1:
                    plant.Water();
                    break;
                case 2:
                    plant.Feed();
                    break;
                case 3:
                    plant.Sunshine();
                    break;
                case 4:
                    break;
                case 5:
                    plant.PlantHealth = 0;
                    break;
                default:
                    Console.WriteLine("Please enter a valid input.");
                    break;
            }
        }

        private static void BadStuff(Object source, ElapsedEventArgs e, Plant plant)
        {
            var rnd = new Random();
            int chance = rnd.Next(1,4);
            switch(chance)
            {
                case 1:
                    plant.Windstorm();
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("A windstorm occured, {0} lost 1 health. Leaving them at {1} health.", plant.PlantName, plant.PlantHealth);
                    break;
                case 2:
                    plant.AphidAttack();
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Aphids attacked {0}, they lost 3 health. Leaving them at {1} health.", plant.PlantName, plant.PlantHealth);
                    break;
                case 3:
                    plant.SlugBite();
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("A slug bit {0}, they lost 2 health. Leaving them at {1} health.", plant.PlantName, plant.PlantHealth);
                    break;
                default:
                    break;
            }

            if(plant.PlantHealth <= 0) {
                timer.Stop();
            }
        }

        // private static bool TryReadLine(out string line, int timeOutMillisecs = Timeout.Infinite) {
        //     getInput.Set();
        //     Console.WriteLine(input);
        //     bool success = gotInput.WaitOne(timeOutMillisecs);
        //     if (success) {
        //         line = input;
        //     } else {
        //         line = null;
        //     }
        //     return success;
        // }
    }
}