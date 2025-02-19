# Auto Driving Car Simulation

## Overview
This project is a command-line simulation of an autonomous driving car, developed using **.NET Core 8.0**. The simulation allows users to define a grid, add multiple cars with unique names and movement commands, and execute a step-by-step movement simulation.

## Design & Assumptions
- The simulation is **grid-based**.
- Cars **rotate (L, R) and move forward (F)**.
- Cars **do not move beyond the grid boundaries**.
- Cars **move sequentially**, executing one command at a time.
- **Collisions are detected**, and a car stops if it collides with another.
- **HashSet** is used to track occupied positions efficiently.


## Data Structures Used & Why

### **Queue<char> (Commands Queue)**
- **Purpose**: Stores movement commands (`F, L, R`) for each car.
- **Why?** A queue ensures that commands are executed in the order they are received (FIFO - First In, First Out).

### **Enum Direction**
- **Purpose**: Represents the four possible directions (`N, E, S, W`).
- **Why?** Enums provide a **strongly typed, readable representation** of car directions.

### **HashSet<(int, int)> (Occupied Positions Set)**
- **Purpose**: Keeps track of occupied positions on the grid.
- **Why?** HashSet offers **O(1) lookup time**, which efficiently prevents cars from moving into occupied spaces.

### **List<Car> (Car List)**
- **Purpose**: Stores all cars added to the simulation.
- **Why?** A list allows **dynamic storage** of cars with **easy iteration** during the simulation.


## System Requirements
- **OS**: Windows/Linux/macOS
- **.NET SDK**: .NET Core 8.0 or later
- **Dependencies**: NUnit (if running tests)

## Installation & Setup
1. **Install .NET Core 8.0 SDK** (Download from [dotnet.microsoft.com](https://dotnet.microsoft.com/))
2. **Clone the repository**:
   ```sh
   git clone <your-github-repo-url>
   cd AutoCarSimulation
   ```
3. **Build the project**:
   ```sh
   dotnet build
   ```
4. **Run the application**:
   ```sh
   dotnet run
   ```

## Running Unit Tests
To run NUnit tests:
```sh
dotnet test
```
