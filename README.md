Elevator Control System

This repository contains an Elevator Control System implemented in C#. It simulates the behavior of multiple elevators in a building, where elevators respond to requests from various floors, handle passenger loading and unloading, and move between floors.

Features
Elevator Class: Represents individual elevators with properties like Id, CurrentFloor, Capacity, and CurrentPassengerCount. It can move between floors and load/unload passengers.

ElevatorController Class: Manages multiple elevators, receives requests, and assigns the closest elevator to fulfill requests. It handles multiple elevators working in parallel.

ElevatorRequest Class: Represents a request for an elevator, including the start floor, destination floor, and the number of passengers.

Test Suite: Contains unit tests using XUnit to ensure that the elevator system works as expected.


How It Works

Add Elevators:
The elevator system can have multiple elevators, each with a unique Id and a maximum passenger capacity.

Request an Elevator:
Users can request an elevator by specifying the start floor, destination floor, and number of passengers. The system will assign the closest available elevator to the request.

Handle Requests:
The elevator system processes requests sequentially and moves elevators accordingly. If an elevator is full, extra elevators are allocated to accommodate passengers.

Test Scenarios:
The program includes a built-in test scenario that automatically runs predefined elevator requests and checks the behavior of the elevator system.

