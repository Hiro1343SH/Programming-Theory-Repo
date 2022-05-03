using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public abstract class CarActionBase 
{
    public virtual void OnStart(CarManager car) { }

    public virtual void OnEnter(CarManager car) { }

    public virtual void OnUpdate(CarManager car) { }

    public virtual void OnExit(CarManager car) { }

    public virtual CarActionType GetActionType()
    {
        return CarActionType.Move;
    }
}
