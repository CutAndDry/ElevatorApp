using ElevatorApp;

Console.WriteLine("Elevator control system");
Console.WriteLine("1: Run test scenario");
Console.WriteLine("2: Run user input");

bool exitVar = true;
int selection;

while (exitVar)
{
    string input = Console.ReadLine();
    if (int.TryParse(input, out selection))
    {
        switch (selection)
        {
            case 1:
                testScenarioAsync();
                break;
            case 2:
                userInputAsync();
                break;
            case 3:
                Console.WriteLine("Exiting app");
                break;
            default:
                Console.WriteLine("Invalid input");
                break;
        }
    }
    else
    {
        Console.WriteLine("Invalid input");
    }
}

async Task userInputAsync()
{
    bool exit = true;
    ElevatorController elevatorSystem = new ElevatorController();

    while (exit)
    {
        Console.WriteLine("Pick a command");
        Console.WriteLine("1: Add elevator");
        Console.WriteLine("2: Request elevator");
        Console.WriteLine("3: Handle requests");
        Console.WriteLine("4: Exit");

        string input = Console.ReadLine();
        int selection;
        int elevatorId = 1;
        if (int.TryParse(input, out selection))
        {
            if (selection == 4)
            {
                exit = false;
                continue;
            }

            if (selection == 1)
            {
                Console.WriteLine("Pick Max Passengers for elevator");
                string maxPassengers = Console.ReadLine();
                int maxPassengersNum;
                if (int.TryParse(maxPassengers, out maxPassengersNum))
                {
                    elevatorId++;
                    elevatorSystem.AddElevator(new Elevator(elevatorId, maxPassengersNum));
                    Console.WriteLine($"Elevator {elevatorId} added with max capacity of {maxPassengersNum} passengers.");

                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
            else if (selection == 2)
            {
                Console.WriteLine("Pick Start Floor, End Floor, Amount of Passengers");
                Console.WriteLine("e.g., 1 4 5");

                string request = Console.ReadLine();
                var parts = request.Split(' ');

                elevatorSystem.RequestElevator(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
                Console.WriteLine($"Elevator requested from floor {int.Parse(parts[0])} to {int.Parse(parts[1])}.");
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
                Console.Clear();
            }
            else if (selection == 3)
            {
                await elevatorSystem.HandleRequestsAsync();
                await Task.Delay(10000);
                Console.WriteLine("Requests are being handled.");
                Console.WriteLine();
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Unknown command.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input");
        }
    }
}

async Task testScenarioAsync()
{
    ElevatorController elevatorSystem = new ElevatorController();

    // Add elevator
    elevatorSystem.AddElevator(new Elevator(1, 5));
    elevatorSystem.AddElevator(new Elevator(2, 5));

    elevatorSystem.RequestElevator(1, 5, 7);
    elevatorSystem.RequestElevator(5, 2, 8);

    elevatorSystem.HandleRequestsAsync();

    await Task.Delay(10000);
}

//foreach (var elevator in elevatorSystem.elevators)
//{
//    Console.WriteLine($"Elevator ID {elevator.Id}");
//}
//Console.WriteLine();

//foreach (var floor in elevatorSystem.floorRequests)
//{
//    Console.WriteLine($"Request ID {floor.Key}:");
//}
