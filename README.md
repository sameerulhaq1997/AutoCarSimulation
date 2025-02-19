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
