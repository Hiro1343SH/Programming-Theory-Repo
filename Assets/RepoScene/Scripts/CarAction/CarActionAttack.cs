using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE, POLYMORPHISM
public class CarActionAttack : CarActionBase
{
    private Rigidbody rb;

    private Vector3 attackStartPos;
    private Vector3 attackStartAng;
    private float vibrationAngle;

    private float timer;
    private readonly float attackTime = 2.0f;

    public override void OnStart(CarManager car)
    {
        rb = car.GetComponent<Rigidbody>();
    }

    public override void OnEnter(CarManager car)
    {
        rb.constraints = RigidbodyConstraints.FreezePosition;

        attackStartPos = car.transform.position;
        attackStartAng = car.transform.localEulerAngles;
        vibrationAngle = 0;
        timer = 0;
    }

    public override void OnUpdate(CarManager car)
    {
        timer += Time.deltaTime;
        if (timer > attackTime)
        {
            car.ExitAction();
        }
        SetTag(car);

        Vector3 currentPos = car.transform.position;
        Vector3 currentAng = car.transform.localEulerAngles;

        vibrationAngle += car.vibrationSpeed * Time.deltaTime;
        currentPos.x += Mathf.Sin(vibrationAngle) * car.attackForce;

        currentAng.y += car.attackCurve.Evaluate(timer / attackTime) * car.attackRotateSpeed * Time.deltaTime;

        car.transform.position = currentPos;
        car.transform.localEulerAngles = currentAng;
    }

    public override void OnExit(CarManager car)
    {
        car.transform.position = attackStartPos;
        car.transform.localEulerAngles = attackStartAng;

        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezePositionX;
    }

    private void SetTag(CarManager car)
    {
        if (timer / attackTime > 0.9f)
        {
            car.SetNormalTag();
        }
        else if (timer / attackTime > 0.1f)
        {
            car.SetAttackTag();
        }
    }

    public override CarActionType GetActionType()
    {
        return CarActionType.Attack;
    }
}
