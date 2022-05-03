using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public GameObject gameoverScreen;
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        gameoverScreen.SetActive(false);
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {

            if (GameController.instance.IsFailure)
            {
                isGameOver = true;
                Invoke(nameof(SetGameOverScreen), 0.5f);
            }
        }
    }

    private void SetGameOverScreen()
    {
        gameoverScreen.SetActive(true);
    }
}
