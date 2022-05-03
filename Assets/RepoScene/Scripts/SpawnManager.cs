using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;

    //Place Point
    private readonly float pointX = 18;
    private readonly float pointY = 1;
    private readonly float[] pointZ = { 6f, 4f, 2f, 0, -2f, -4f, -6f };

    //Place Settings
    private readonly float longSize = 2f;
    private readonly int centerPositionIndex = 3;

    //Interval
    private readonly float spawnInterval = 2f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle),0.1f,spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.IsFailure)
        {
            CancelInvoke();
        }
    }

    private void SpawnObstacle()
    {
        int pointIndex=Random.Range(0, pointZ.Length);
        int obstacleIndex=Random.Range(0, obstaclePrefab.Length);

        if (obstaclePrefab[obstacleIndex].GetComponent<Transform>().localScale.z > longSize)
        {
            pointIndex = centerPositionIndex;
        }

        Instantiate(obstaclePrefab[obstacleIndex], 
                    new Vector3(pointX, pointY, pointZ[pointIndex]), 
                    obstaclePrefab[obstacleIndex].transform.rotation); ;
    }
}
