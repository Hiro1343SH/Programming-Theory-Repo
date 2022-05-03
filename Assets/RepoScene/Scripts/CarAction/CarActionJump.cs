using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE, POLYMORPHISM
public class CarActionJump : CarActionBase
{
    private Rigidbody rb;

    public override void OnStart(CarManager car)
    {
        rb = car.GetComponent<Rigidbody>();
    }

    public override void OnEnter(CarManager car)
    {
        rb.AddForce(Vector3.up * car.jumpForce, ForceMode.Impulse);
        GameController.instance.ResetIsGround();

        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    public override void OnUpdate(CarManager car)
    {
        if (GameController.instance.IsGround)
        {
            car.ExitAction();
        }
    }

    public override void OnExit(CarManager car)
    {
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezePositionX;
    }

    public override CarActionType GetActionType()
    {
        return CarActionType.Jump;
    }

}
