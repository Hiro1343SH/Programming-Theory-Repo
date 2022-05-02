using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    private float scrollSpeed = 5f;
    private float wallSize;

    // Start is called before the first frame update
    void Start()
    {
        GameObject wallObject = gameObject.transform.Find("Wall").gameObject;
        wallSize = wallObject.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(scrollSpeed * Time.deltaTime * Vector3.left);

        Vector3 currentPos = transform.position;
        if (currentPos.x < -wallSize / 2)
        {
            transform.position = Vector3.zero;
        }
    }
}
