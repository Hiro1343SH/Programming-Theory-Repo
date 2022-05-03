using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE, POLYMORPHISM
public class CarActionMove : CarActionBase
{
    private readonly float turnRange = 45;
    private readonly float zRange = 5.5f;

    public override void OnUpdate(CarManager car)
    {
        Vector3 currentAng = car.transform.localEulerAngles;
        Vector3 currentPos = car.transform.position;

        //Rotate
        car.transform.localEulerAngles = Rotating(currentAng, car);

        //Move: vertical direction
        currentPos.x=car.GetInitialPos().x;
        car.transform.position = VerticalMove(currentPos, currentAng, car);
    }

    //ABSTRACTION
    private Vector3 Rotating(Vector3 currentAng, CarManager car)
    {
        float turnInput = Input.GetAxis("Vertical");

        if (turnInput != 0)
        {
            //When input, rotate at turnspeed.
            currentAng.y = AngulerClamp(currentAng.y - turnInput * car.turnSpeed * Time.deltaTime);
        }
        else
        {
            //If not input, straight back with straightBackSpeed.
            float direction;
            if (currentAng.y > 180)
            {
                direction = 1f;
            }
            else
            {
                direction = -1f;
            }
            currentAng.y += direction * car.straightBackSpeed * Time.deltaTime;
        }
        return currentAng;
    }

    //ABSTRACTION
    private Vector3 VerticalMove(Vector3 currentPos, Vector3 currentAng, CarManager car)
    {
        float verticalSpeed;
        if (currentAng.y > 180)
        {
            verticalSpeed = Mathf.Sin((currentAng.y - 360) / 180) * car.speed;
        }
        else
        {
            verticalSpeed=Mathf.Sin(currentAng.y/180)*car.speed;
        }
        currentPos.z=Mathf.Clamp(currentPos.z-verticalSpeed*Time.deltaTime,-zRange,zRange);
        return currentPos;
    }

    private float AngulerClamp(float ang)
    {
        if (ang <= 180)
        {
            if (ang > turnRange)
            {
                return turnRange;
            }
        }
        else
        {
            if (ang < 360 - turnRange)
            {
                return 360 - turnRange;
            }
        }
        return ang;
    }
}
