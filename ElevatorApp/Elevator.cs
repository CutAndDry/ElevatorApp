using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorApp
{

    public class Elevator
    {
        public int Id { get; set; }
        public int CurrentFloor { get; set; }
        public int Capacity { get; set; }
        public bool IsMoving { get; set; }
        public int CurrentPassengerCount { get; set; }

        public Elevator(int id, int capacity)
        {
            Id = id;
            Capacity = capacity;
            CurrentFloor = 1; 
            IsMoving = false;
            CurrentPassengerCount = 0;
        }

    }
}
