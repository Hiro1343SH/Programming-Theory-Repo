using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToTitle : MonoBehaviour
{
    private bool isClick;

    public void OnClick()
    {
        if (!isClick)
        {
            GameController.instance.LoadScene(0);
            isClick = true;
        }
    }

}
