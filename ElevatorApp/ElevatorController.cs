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

            var elevatorRequest = new ElevatorRequest(destination, passengerCount);
            floorRequests[floor].Enqueue(elevatorRequest);

        }

        public async Task HandleRequestsAsync()
        {
        }

    }
}
