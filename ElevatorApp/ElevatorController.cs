using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorApp
{
    public class ElevatorController
    {
        public List<Elevator> elevators;
        public Dictionary<int, Queue<ElevatorRequest>> floorRequests;

        public ElevatorController()
        {
            elevators = new List<Elevator>();
            floorRequests = new Dictionary<int, Queue<ElevatorRequest>>();
        }


        public void AddElevator(Elevator elevator)
        {
            elevators.Add(elevator);
            floorRequests[elevator.CurrentFloor] = new Queue<ElevatorRequest>();
        }


        public void RequestElevator(int floor, int destination, int passengerCount)
        {
            // Add request to the request queue
            if (!floorRequests.ContainsKey(floor))
            {
                floorRequests[floor] = new Queue<ElevatorRequest>();
            }

            var elevatorRequest = new ElevatorRequest(floor, destination, passengerCount);
            floorRequests[floor].Enqueue(elevatorRequest);

        }

        public async Task HandleRequestsAsync()
        {

            foreach (var floor in floorRequests.Keys)
            {
                while (floorRequests[floor].Count > 0)
                {
                    var elevatorRequest = floorRequests[floor].Dequeue();
                    var destination = elevatorRequest.EndFloor;
                    int passengerCount = elevatorRequest.PassengerCount;
                    var closestElevator = GetClosestElevator(floor);

                    Console.WriteLine($"Request from floor {floor} to {destination} with {passengerCount} passengers.");

                    if (passengerCount > closestElevator.Capacity)
                    {
                        // get elevators extra elevators 
                        int remainingPassengers = passengerCount;
                        while (remainingPassengers > 0)
                        {
                            int passengersForCurrentElevator = Math.Min(remainingPassengers, closestElevator.Capacity);
                            remainingPassengers -= passengersForCurrentElevator;


                            if (closestElevator.CurrentFloor != floor)
                            {
                                await closestElevator.MoveToFloorAsync(floor);
                            }

                            closestElevator.LoadPassengers(passengersForCurrentElevator);
                            await closestElevator.MoveToFloorAsync(destination);


                            if (remainingPassengers > 0)
                            {
                                closestElevator = GetClosestElevator(floor);
                            }
                            closestElevator.UnloadPassengers();
                        }
                    }
                    else
                    {
                        closestElevator.LoadPassengers(passengerCount);

                        if (closestElevator.CurrentFloor != floor)
                        {
                            await closestElevator.MoveToFloorAsync(floor);
                        }
                        await closestElevator.MoveToFloorAsync(destination);
                        closestElevator.UnloadPassengers();
                    }
                }
            }
        }
        public Elevator GetClosestElevator(int floor)
        {
            Elevator closestElevator = null;
            int closestDistance = int.MaxValue;

            foreach (var elevator in elevators)
            {
                int distance = Math.Abs(elevator.CurrentFloor - floor);
                if (distance < closestDistance)
                {
                    closestElevator = elevator;
                    closestDistance = distance;
                }
            }

            return closestElevator;
        }
    }
}
