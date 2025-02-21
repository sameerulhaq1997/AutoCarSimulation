namespace AutoCarSimulation
{
    public class CarSimulation
    {
        private readonly int _width;
        private readonly int _height;
        private readonly List<Car> _cars;
        private readonly HashSet<(int, int)> _occupiedPositions;

        public CarSimulation(int width, int height)
        {
            _width = width;
            _height = height;
            _cars = new List<Car>();
            _occupiedPositions = new HashSet<(int, int)>();
        }

        public void AddCar(string name, int x, int y, char direction, string commands)
        {
            if (x < 0 || x >= _width || y < 0 || y >= _height)
            {
                Console.WriteLine("Invalid position. Car is outside the grid.");
                return;
            }
            if (_occupiedPositions.Contains((x, y)))
            {
                Console.WriteLine("Position already occupied by another car.");
                return;
            }
            Car car = new Car(name, x, y, direction, commands);
            _cars.Add(car);
            _occupiedPositions.Add((x, y));
        }

        public void RunSimulation()
        {
            bool commandsRemaining;
            do
            {
                commandsRemaining = false;
                foreach (var car in _cars)
                {
                    if (car.Commands.Count > 0)
                    {
                        _occupiedPositions.Remove((car.X, car.Y));
                        car.ExecuteCommand(_width, _height, _occupiedPositions);
                        if (_occupiedPositions.Contains((car.X, car.Y)))
                        {
                            Console.WriteLine($"Collision detected! {car.Name} has collided at ({car.X},{car.Y}).");
                            car.Stopped = true;
                        }
                        else
                        {
                            _occupiedPositions.Add((car.X, car.Y));
                            Console.WriteLine(car);
                        }
                        commandsRemaining = true;
                    }
                }
            } while (commandsRemaining);
        }

        public Car? GetCar(string name)
        {
            return _cars.FirstOrDefault(car => car.Name == name);
        }
    }

}
