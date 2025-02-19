using AutoCarSimulation;

Console.WriteLine("Welcome to Auto Driving Car Simulation!");
Console.Write("Please enter the width and height of the simulation field (x y): ");
var dimensions = (Console.ReadLine() ?? "").Split();
int.TryParse(dimensions[0], out int width);
int.TryParse(dimensions[1], out int height);

CarSimulation simulation = new CarSimulation(width, height);

while (true)
{
    try
    {
        Console.WriteLine("\nOptions:");
        Console.WriteLine("1. Add a car to field");
        Console.WriteLine("2. Run simulation");
        Console.WriteLine("3. Exit");
        Console.Write("Choose an option: ");
        string? choice = Console.ReadLine();

        if (choice == "1")
        {
            Console.Write("Enter car name: ");
            string? name = Console.ReadLine();
            Console.Write("Enter initial position and direction (x y D): ");
            var data = (Console.ReadLine() ?? "").Split();

            int.TryParse(data[0], out int x);
            int.TryParse(data[1], out int y);
            char.TryParse(data[2].ToUpper(), out char direction);
            Console.Write("Enter movement commands: ");
            string commands = (Console.ReadLine() ?? "").ToUpper();

            simulation.AddCar(name ?? "", x, y, direction, commands);
        }
        else if (choice == "2")
        {
            Console.WriteLine("Running simulation...");
            simulation.RunSimulation();
        }
        else if (choice == "3")
        {
            Console.WriteLine("Thank you for running the simulation. Goodbye!");
            break;
        }
        else
        {
            Console.WriteLine("Invalid option, please try again.");
        }
    }
    catch(Exception)
    {
        Console.WriteLine("Some error accured try to repeat th process!");
    }
}