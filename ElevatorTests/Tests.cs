

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ElevatorApp;

 
namespace ElevatorTests
{
    public class Tests
    {
        [Fact]
        public void AddElevator_ShouldAddElevatorToSystem()
        {
          
            var elevatorController = new ElevatorController();
            var elevator = new Elevator(1, 5);

           
            elevatorController.AddElevator(elevator);

         
            Assert.Single(elevatorController.elevators); // Verify only 1 elevator is added
            Assert.Contains(elevatorController.elevators, e => e.Id == 1); // Verify elevator with Id 1 is present
        }

        [Fact]
        public void RequestElevator_ShouldQueueRequest()
        {
         
            var elevatorController = new ElevatorController();
            var elevator = new Elevator(1, 5);
            elevatorController.AddElevator(elevator);

            
            elevatorController.RequestElevator(1, 5, 3);

         
            Assert.Single(elevatorController.floorRequests[1]); // Verify that request is added for floor 1
            var request = elevatorController.floorRequests[1].Dequeue();
            Assert.Equal(5, request.EndFloor); // Verify destination floor
            Assert.Equal(3, request.PassengerCount); // Verify the number of passengers
        }

        [Fact]
        public async Task HandleRequestsAsync_ShouldHandleElevatorRequest()
        {
           
            var elevatorController = new ElevatorController();
            var elevator = new Elevator(1, 5);
            elevatorController.AddElevator(elevator);

            elevatorController.RequestElevator(1, 5, 3);

         
            await elevatorController.HandleRequestsAsync();

            
            Assert.Equal(5, elevator.CurrentFloor); // Verify that elevator has moved to floor 5
            Assert.Equal(5, elevator.CurrentPassengerCount); // Verify the elevator has Passengers
        }

        [Fact]
        public async Task HandleMultipleRequests_ShouldDistributePassengersCorrectly()
        {
          
            var elevatorController = new ElevatorController();
            var elevator1 = new Elevator(1, 5);
            var elevator2 = new Elevator(2, 5);
            elevatorController.AddElevator(elevator1);
            elevatorController.AddElevator(elevator2);

            elevatorController.RequestElevator(1, 5, 7);
            elevatorController.RequestElevator(2, 6, 5);

           
            await elevatorController.HandleRequestsAsync();

         
           
            Assert.Equal(5, elevator1.CurrentFloor); // Elevator 1 should be at floor 5
            Assert.Equal(2, elevator2.CurrentFloor); // Elevator 2 should be at floor 2 (it picked the remaining passengers)
            Assert.Equal(5, elevator1.CurrentPassengerCount); // Elevator 1 should be full
            Assert.Equal(2, elevator2.CurrentPassengerCount); // Elevator 2 should have the remaining passengers
        }

        [Fact]
        public async Task HandleRequestWithOverCapacity_ShouldAllocateExtraElevators()
        {
           
            var elevatorController = new ElevatorController();
            var elevator1 = new Elevator(1, 5);
            var elevator2 = new Elevator(2, 5);
            elevatorController.AddElevator(elevator1);
            elevatorController.AddElevator(elevator2);

            elevatorController.RequestElevator(1, 5, 12); 

        
            await elevatorController.HandleRequestsAsync();

          
            Assert.Equal(5, elevator1.CurrentPassengerCount); // Elevator 1 should be full
            Assert.Equal(5, elevator2.CurrentPassengerCount); // Elevator 2 should have Passengers
        }
    }
}
