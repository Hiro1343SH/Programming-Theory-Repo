using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    private float wallSize;

    //For scroll speed
    private float timer = 0;
    private readonly float interval = 5f;
    private readonly float rize = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject wallObject = gameObject.transform.Find("Wall").gameObject;
        wallSize = wallObject.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(GameController.instance.ScrollSpeed * Time.deltaTime * Vector3.left);

        Vector3 currentPos = transform.position;
        if (currentPos.x < -wallSize / 2)
        {
            transform.position = Vector3.zero;
        }

        ScrollSpeedUp();

    }

    private void ScrollSpeedUp()
    {
        timer+=Time.deltaTime;
        if(timer > interval)
        {
            GameController.instance.ScrollSpeedUp(rize);
            timer = 0;
        }
    }
}
