using NUnit.Framework;
namespace AutoCarSimulation
{
    [TestFixture]
    public class CarSimulationTests
    {
        [Test]
        public void TestCarInitialization()
        {
            var car = new Car("A", 1, 2, 'N', "FFR");
            Assert.That(car.X, Is.EqualTo(1));
            Assert.That(car.Y, Is.EqualTo(2));
            Assert.That(car.Facing, Is.EqualTo(DirectionEnum.N));
            Assert.That(car.Commands.Count, Is.EqualTo(3));
        }

        [Test]
        public void TestCarRotation()
        {
            var car = new Car("A", 0, 0, 'N', "LR");
            car.ExecuteCommand(10, 10, new HashSet<(int, int)>());
            Assert.That(car.Facing, Is.EqualTo(DirectionEnum.W));
            car.ExecuteCommand(10, 10, new HashSet<(int, int)>());
            Assert.That(car.Facing, Is.EqualTo(DirectionEnum.N));
        }

        [Test]
        public void TestCarMovement()
        {
            var occupiedPositions = new HashSet<(int, int)>();
            var car = new Car("A", 1, 1, 'N', "F");
            occupiedPositions.Add((1, 1));
            car.ExecuteCommand(10, 10, occupiedPositions);
            Assert.That(car.X, Is.EqualTo(1));
            Assert.That(car.Y, Is.EqualTo(2));
            Assert.That(occupiedPositions.Contains((1, 1)), Is.False);
        }

        [Test]
        public void TestMultipleCarsSimulation()
        {
            CarSimulation simulation = new CarSimulation(10, 10);

            simulation.AddCar("A", 2, 2, 'E', "FF");
            simulation.AddCar("B", 4, 3, 'W', "F");

            simulation.RunSimulation();

            Assert.That(simulation.GetCar("A")?.X, Is.EqualTo(3));
            Assert.That(simulation.GetCar("A")?.Y, Is.EqualTo(3));
            Assert.That(simulation.GetCar("B")?.X, Is.EqualTo(3));
            Assert.That(simulation.GetCar("B")?.Y, Is.EqualTo(3));

            Assert.That(simulation.GetCar("A")?.Stopped, Is.True);
            Assert.That(simulation.GetCar("B")?.Stopped, Is.True);
        }
    }
}
