using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool canExclude;

    private readonly float yEnd;

    private Rigidbody rb;
    public Vector3 addForce;
    public Vector3 addTorque;
    public Vector3 addVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.IsFailure) return;

        transform.Translate(GameController.instance.ScrollSpeed * Time.deltaTime * Vector3.left);

        Vector3 currentPos=transform.position;
        if(currentPos.y < yEnd)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(GameController.groundTag)) return;

        if (collision.gameObject.CompareTag(GameController.attackTag) && canExclude)
        {
            rb.AddForce(addForce, ForceMode.Impulse);
            rb.AddTorque(addTorque, ForceMode.Force);
            rb.velocity = addVelocity;
        }
        else if (collision.gameObject.CompareTag(GameController.normalTag) || !canExclude)
        {
            GameController.instance.SetIsFailure();
            GameController.instance.SetHitPos(collision.contacts[0].point);
        }

    }

}
