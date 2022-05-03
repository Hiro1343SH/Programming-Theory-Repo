using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    private bool isClicked = false;

    public void OnClick()
    {
        if (!isClicked)
        {
            isClicked = true;
            GameController.instance.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
