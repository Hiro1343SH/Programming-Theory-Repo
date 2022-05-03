using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    int framCount = 0;

    private Vector3 initialPos;

    //INHERITANCE, POLYMORPHISM and ABSTRACTION: Car Action
    private static readonly CarActionMove actionMove = new CarActionMove();
    private static readonly CarActionJump actionJump = new CarActionJump();
    private static readonly CarActionAttack actionAttack = new CarActionAttack();

    private CarActionBase carAction = actionMove;

    //Action Parameter
    [Header("For Move")]
    public float speed;
    public float turnSpeed;
    public float straightBackSpeed;

    [Header("For Attack")]
    public float attackForce;
    public float attackRotateSpeed;
    public float vibrationSpeed;
    public AnimationCurve attackCurve;

    [Header("For Jump")]
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        actionAttack.OnStart(this);
        actionJump.OnStart(this);
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (framCount < 5)
        {
            framCount++;
            return;
        }

        if (GameController.instance.IsFailure) return;

        if (carAction.GetActionType() == CarActionType.Move)
        {
            if (GetActionKey()) return;
        }
        carAction.OnUpdate(this);

    }

    private bool GetActionKey()
    {
        if (Input.GetButtonDown("Jump"))
        {
            carAction = actionJump;
            carAction.OnEnter(this);
            return true;
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            carAction = actionAttack;
            carAction.OnEnter(this);
            return true;
        }
        return false;
    }

    public void SetNormalTag()
    {
        tag = GameController.normalTag;
    }

    public void SetAttackTag()
    {
        tag = GameController.attackTag;
    }

    public Vector3 GetInitialPos() { return initialPos; }

    public void ExitAction()
    {
        carAction.OnExit(this);
        carAction = actionMove;
    }
}
