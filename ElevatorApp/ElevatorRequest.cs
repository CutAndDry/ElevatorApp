﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorApp
{
    public class ElevatorRequest
    {
        public int StartFloor { get; set; }
        public int EndFloor { get; set; }
        public int PassengerCount { get; set; }

        public ElevatorRequest(int startFloor, int destinationFloor, int passengerCount)
        {
            StartFloor = startFloor;
            EndFloor = destinationFloor;
            PassengerCount = passengerCount;
        }


    }
}
