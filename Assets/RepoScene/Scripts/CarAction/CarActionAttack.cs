using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE, POLYMORPHISM
public class CarActionAttack : CarActionBase
{
    private Vector3 attackStartPos;
    private Vector3 attackStartAng;
    private float vibrationAngle;

    private float timer;
    private readonly float attackTime = 2.0f;

    public override void OnEnter(CarManager car)
    {
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
    }

    public override CarActionType GetActionType()
    {
        return CarActionType.Attack;
    }
}
