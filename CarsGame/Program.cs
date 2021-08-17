using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsGame
{
    class Program
    {

        static void ShowOption()
        {
            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("\t1 - check player balance");
            Console.WriteLine("\t2 - create a car");
            Console.WriteLine("\t3 - exit");

            Console.Write("Your option? ");
        }
        static int GetOption()
        {
            int option = 0;
            int.TryParse(Console.ReadLine(), out option);
            return option;
        }

        static void ShowCarOption(Car car)
        {

            Console.WriteLine("Your car " + car.Number);

            Console.WriteLine("\t1 - add a car to the player");
            Console.WriteLine("\t2 - drive a car");
            Console.WriteLine("\t3 - check player balance ");

            Console.Write("Your option? ");

        }

        static void RepairDialg()
        {

            Console.WriteLine("\t2 - check player balance");
            Console.WriteLine("\t3 - repair a motor");
            Console.WriteLine("\t4 - repair an accumulator");
            Console.WriteLine("\t5 - repair a disc");
            Console.Write("Your option? ");
        }

        static void RepairCar(Car car)
        {
            switch (GetOption())
            {
                case 2:
                    Console.WriteLine($"Your balance {game.GetBalance()}");
                    break;
                case 3:
                    car.RepairEngine(game.GetPlayer());
                    break;
                case 4:
                    car.RepairAccumulator(game.GetPlayer());
                    break;
                case 5:
                    car.RepairDisc(game.GetPlayer());
                    break;
            }

        }



        static void ProcessingCar_(Car car)
        {
            switch (GetOption())
            {
                case 1:
                    game.AddCar(car);
                    Console.WriteLine(game.ShowCars());
                    break;
                case 2:
                    car.Drive(game.GetPlayer());
                    break;
                case 3:
                    Console.WriteLine($"Your balance {game.GetBalance()}");
                    break;
                default:
                    Console.WriteLine("Error! No such action...");
                    break;
            }

        }
        static void ProcessingCar()
        {
            Car car = MakeCar();
            while (!game.EndApp())
            {
                ShowCarOption(car);
                while (!car.NoRepair)
                {
                    ProcessingCar_(car);
                    if (car.IsBroken)
                    {
                        RepairDialg();
                        RepairCar(car);
                    }


                }
                FinishCheck();

            }

        
    }

        public static void FinishCheck()
        {
            Console.Write("Press 's' and Enter to close the app, or press any other key and Enter to continue: ");
            if (Console.ReadLine() == "s")
            {
                game.Finish();
            }

            Console.WriteLine("\n");

        }

        static Car MakeCar()
        {
            Engine engine = new Engine();
            Accumulator accumulator = new Accumulator();
            Disc disc = new Disc();
            return new Car(engine ,disc, accumulator);
        }

        static void DoStep()
        {
            ShowOption();
            switch (GetOption())
            {
                case 1:
                    Console.WriteLine($"Your balance {game.GetBalance()}");
                    break;
                case 2:
                    ProcessingCar();
                    break;
                case 3:
                    game.Done();
                    break;
                default:
                    Console.WriteLine("Error! No such action...");
                    break;
            }
        }
        static Game game = new Game();
        static void Main(string[] args)
        {

            if(!game.Init())
            {
                Console.WriteLine($"Welcome {game.PlayerName()}" );
                while(game.IsStop())
                {
                    DoStep();
                }
            }
        }

    }
}

