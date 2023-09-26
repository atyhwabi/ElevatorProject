
using System;
using System.Collections.Generic;
using System.Linq;

class Elevator
{
    private int currentFloor;
    private ElevatorDirection direction;
    private List<int> destinationFloors;
    private List<Person> people;

    public Elevator()
    {
        currentFloor = 0;
        direction = ElevatorDirection.Stopped;
        destinationFloors = new List<int>();
        people = new List<Person>();

    }

    public void RequestFloor(int floor, string weight)
    {
        if (floor >= 1 && floor <= 10) // Assuming a 10-floor building
        {
            destinationFloors.Add(floor);
            if (direction == ElevatorDirection.Stopped)
            {
                Move(weight);
            }
        }
        else
        {
            Console.WriteLine("Invalid floor request.");
        }
    }

    private void Move(string weight)
    {
        if (destinationFloors.Count == 0)
        {
            direction = ElevatorDirection.Stopped;
            Console.WriteLine($"Elevator is now stopped at floor {currentFloor} and the weight in the elevator is currently : " + weight + "Kg");
            return;
        }

        int nextFloor = destinationFloors[0];
        if (nextFloor > currentFloor)
        {
            direction = ElevatorDirection.Up;
            Console.WriteLine($"Elevator is moving up to floor {nextFloor} and the weight in the elevator is currently : " + weight + "Kg");
        }
        else if (nextFloor < currentFloor)
        {
            direction = ElevatorDirection.Down;
            Console.WriteLine($"Elevator is moving down to floor {nextFloor} and the weight in the elevator is currently : " + weight + "Kg");
        }
        else
        {
            direction = ElevatorDirection.Stopped;
            Console.WriteLine($"Elevator has reached floor {nextFloor} and the weight in the elevator is currently : " + weight + "Kg");
            destinationFloors.RemoveAt(0);
        }

        // Simulate elevator movement (pause for a moment)
        System.Threading.Thread.Sleep(1000);
        currentFloor = nextFloor;
        Move("");
    }
}

enum ElevatorDirection
{
    Up,
    Down,
    Stopped
}

public class Person
{
    public string Name { get; set; }
    public int RequestFloor { get; set; }
    public string RequestDirection { get; set; }

    public double Mass { get; set; }

    public void PressRequestButton(string direction)
    {

    }
}
class Program
{
    static void Main(string[] args)
    {
        Elevator elevator = new Elevator();

        var People = new List<Person>();
  

        People.Add(new Person { Name = "Person 1", RequestFloor = 3, RequestDirection = "up" , Mass = 108.4});
        People.Add(new Person { Name = "Person 2", RequestFloor = 4, RequestDirection = "up", Mass = 128.4 });
        People.Add(new Person { Name = "Person 3", RequestFloor = 6, RequestDirection = "up", Mass = 148.4 });
        People.Add(new Person { Name = "Person 4", RequestFloor = 9, RequestDirection = "up", Mass = 118.4 });
        People.Add(new Person { Name = "Person 5", RequestFloor = 1, RequestDirection = "up", Mass = 105.4 });

        double weightElevator = People.Sum(x => Convert.ToInt32(x.Mass));
        Console.WriteLine("The elevator has" + People.Count() + " passegers and the weight is : " + weightElevator + "kg");

        foreach (var person in People)
        {
            weightElevator = weightElevator - person.Mass;
            elevator.RequestFloor(person.RequestFloor, weightElevator.ToString());
        }

        People.Add(new Person { Name = "Person 1", RequestFloor = 3, RequestDirection = "down" , Mass = 108.4});
        People.Add(new Person { Name = "Person 2", RequestFloor = 4, RequestDirection = "down", Mass = 128.4 });
        People.Add(new Person { Name = "Person 3", RequestFloor = 6, RequestDirection = "down", Mass = 148.4 });
        People.Add(new Person { Name = "Person 4", RequestFloor = 9, RequestDirection = "down", Mass = 118.4 });
        People.Add(new Person { Name = "Person 5", RequestFloor = 1, RequestDirection = "down", Mass = 105.4 });

        Console.WriteLine("===================================================================================");

        foreach (var person in People)
        {
            weightElevator = weightElevator +  person.Mass;
            elevator.RequestFloor(person.RequestFloor, weightElevator.ToString());
        }

    }
}
