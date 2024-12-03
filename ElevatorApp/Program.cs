


using ElevatorApp;



ElevatorController elevatorSystem = new ElevatorController();

// Add elevator
elevatorSystem.AddElevator(new Elevator(1, 5));
elevatorSystem.AddElevator(new Elevator(2, 5));

elevatorSystem.RequestElevator(1, 5, 7);
elevatorSystem.RequestElevator(2, 3, 8);

elevatorSystem.HandleRequestsAsync();

await Task.Delay(10000);


//foreach (var elevator in elevatorSystem.elevators)
//{
//    Console.WriteLine($"elevator ID {elevator.Id}");
//}
//Console.WriteLine();

//foreach (var floor in elevatorSystem.floorRequests)
//{
// Console.WriteLine($"Request ID  {floor.Key}:");
//}


