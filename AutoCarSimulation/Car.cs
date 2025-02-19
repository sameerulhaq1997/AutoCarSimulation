namespace AutoCarSimulation
{
    public class Car
    {
        public string Name { get; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public DirectionEnum Facing { get; private set; }
        public Queue<char> Commands { get; }
        public bool Stopped { get; private set; }

        public Car(string name, int x, int y, char direction, string commands)
        {
            Name = name;
            X = x;
            Y = y;
            Enum.TryParse<DirectionEnum>(direction.ToString(), out DirectionEnum facing);
            Facing = facing;
            Commands = new Queue<char>(commands);
            Stopped = false;
        }

        public void ExecuteCommand(int width, int height, HashSet<(int, int)> occupiedPositions)
        {
            if (Stopped || Commands.Count == 0) return;
            char command = Commands.Dequeue();

            int newX = X, newY = Y;
            switch (command)
            {
                case 'L': Facing = (DirectionEnum)(((int)Facing + 3) % 4); break;
                case 'R': Facing = (DirectionEnum)(((int)Facing + 1) % 4); break;
                case 'F':
                    (newX, newY) = MoveForward();
                    if (newX >= 0 && newX < width && newY >= 0 && newY < height && !occupiedPositions.Contains((newX, newY)))
                    {
                        occupiedPositions.Remove((X, Y));
                        X = newX;
                        Y = newY;
                        occupiedPositions.Add((X, Y));
                    }
                    break;
            }
        }

        private (int, int) MoveForward()
        {
            return Facing switch
            {
                DirectionEnum.N => (X, Y + 1),
                DirectionEnum.E => (X + 1, Y),
                DirectionEnum.S => (X, Y - 1),
                DirectionEnum.W => (X - 1, Y),
                _ => (X, Y)
            };
        }

        public override string ToString() => $"{Name}, ({X},{Y}) {Facing}";
    }

}
