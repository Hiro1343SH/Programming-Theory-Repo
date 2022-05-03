using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParticle : MonoBehaviour
{
    public GameObject particlePrefab;

    private bool isExist = false;

    // Update is called once per frame
    void Update()
    {
        if (isExist) return;

        if (GameController.instance.IsFailure)
        {
            Vector3 hitoPos = GameController.instance.HitoPos;

            Instantiate(particlePrefab,hitoPos,particlePrefab.transform.rotation);
            isExist = true;
        }
    }
}
