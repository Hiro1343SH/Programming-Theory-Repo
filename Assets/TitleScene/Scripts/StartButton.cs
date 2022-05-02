using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    private bool isClick;

    public void OnClick()
    {
        if (isClick) return;

        GameController.instance.LoadScene(1);
        isClick = true;
    }

}
