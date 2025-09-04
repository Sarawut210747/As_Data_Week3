using UnityEngine;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;

namespace Assignment.StudentSolution.LCT01
{
    public class Car
    {
        public string name;
        public string color;
        public float speed;

        public void Move()
        {
            Debug.Log("Car is moving");
        }

        public void Turn()
        {
            Debug.Log("Car is turning");
        }

        public void Honk()
        {
            Debug.Log("Car is honking");
        }

    }
    public class LCT01SyntaxClass
        {
            public void Start()
            {
                Car car = new Car();

                car.name = "Car1";
                car.color = "Red";
                car.speed = 100.0f;

                car.Move();
                car.Turn();
                car.Honk();
            }
        }
}
