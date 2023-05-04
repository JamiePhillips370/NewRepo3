using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class CountDown : MonoBehaviour
{
    public float timeRemaining;
    public bool timerOn = false;
    public TextMeshProUGUI numberToShow;
    public GameObject gameobject;
    public TextMeshProUGUI five;
    public TextMeshProUGUI four;
    public TextMeshProUGUI three;
    public TextMeshProUGUI two;
    public TextMeshProUGUI one;
    public TextMeshProUGUI start;


    void Start()
    {
        timerOn = true;
        gameobject.SetActive(false);

    }
    void Update()
    {
        if (timerOn)
        {
            if (timeRemaining > 0)
            {
                numberToShow.text = timeRemaining.ToString();
                timeRemaining -= Time.deltaTime;

                if (timeRemaining == 5f)
                {

                }

                if (timeRemaining <= 0)
                {
                    Destroy(numberToShow);
                    gameobject.SetActive(true);
                }
            }
            else
            {
                timeRemaining = 0;
                timerOn = false;

            }
        }
    }
}
