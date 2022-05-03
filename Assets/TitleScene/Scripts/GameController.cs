using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public static readonly string groundTag = "Ground";

    //ENCASULATION
    private bool isFailure = false;
    public bool IsFailure { get { return isFailure; } }

    private bool isGround = false;
    public bool IsGround { get { return isGround; } }

    private readonly float maxScrollSpeed = 12f;
    private readonly float initialScrollSpeed = 5f;
    private float scrollSpeed;
    public float ScrollSpeed
    {
        get
        {
            if (scrollSpeed > maxScrollSpeed)
            {
                return maxScrollSpeed;
            }
            else
            {
                return scrollSpeed;
            }
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        InitialSetting();
    }

    private void InitialSetting()
    {
        isFailure = false;
        isGround = false;
        scrollSpeed = initialScrollSpeed;
    }
    public void LoadScene(int sceneIndex)
    {
        InitialSetting();
        SceneManager.LoadScene(sceneIndex);
    }

    public void SetIsGround()
    {
        isGround = true;
    }

    public void ResetIsGround()
    {
        isGround = false;
    }

    public void ScrollSpeedUp(float rize)
    {
        scrollSpeed += rize;
    }
}


public enum CarActionType
{
    Move = 0,
    Attack = 1,
    Jump = 2
}
