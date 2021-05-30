using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;
    private GameObject MainObject;

    private void Start()
    {
        MainObject = GameObject.FindGameObjectWithTag("MainObject");
    }
    public void StartGame()
    {
        MainObject.GetComponent<BallMovement>().IsGameStarted = true;
        canvas.enabled = false;
    }
}
