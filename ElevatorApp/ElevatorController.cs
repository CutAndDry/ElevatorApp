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

        public void AddElevator(Elevator elevator)
        {
        
        }
        public void RequestElevator(int floor, int destination, int passengerCount)
        {

        }

        public async Task HandleRequestsAsync()
        {
        }

    }
}
