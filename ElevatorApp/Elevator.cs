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

        public async Task MoveToFloorAsync(int floor)
        {
            if (floor != CurrentFloor)
            {
                IsMoving = true;
                Console.WriteLine($"Elevator {Id} is on floor {CurrentFloor} moving to floor {floor} with {CurrentPassengerCount} passengers.");

                // Simulate time taken to move 
                await Task.Delay(Math.Abs(CurrentFloor - floor) * 10);
                CurrentFloor = floor;


                Console.WriteLine($"Elevator {Id} arrived at floor {floor}.");
                UnloadPassengers();
            }
        }
        public void LoadPassengers(int passengerCount)
        {
            if (CurrentPassengerCount + passengerCount <= Capacity)
            {
                CurrentPassengerCount += passengerCount;
                Console.WriteLine($"Elevator {Id} loaded {passengerCount} passengers.");
            }
            else
            {
                Console.WriteLine($"Elevator {Id} cannot carry more passengers. It's already full.");
            }
        }
        public void UnloadPassengers()
        {

            CurrentPassengerCount = 0;
        }

    }
}
