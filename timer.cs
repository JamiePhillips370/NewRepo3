using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class timer : MonoBehaviour
{
    
    public TextMeshProUGUI numberToDisplay;
    public GameObject game;
    public float timeRemaining;
    public bool time = false;



    void Start()
    {
        
        game.SetActive(false);
        time = true;
    }
    void Update()
    {
        if (time)
        {
            if (timeRemaining > 0)
            {
                numberToDisplay.text = timeRemaining.ToString();
                timeRemaining -= Time.deltaTime;

                if (timeRemaining <= 0)
                {
                    Destroy(numberToDisplay);
                    game.SetActive(true);
                }
            }
            else
            {
                timeRemaining = 0;
                time = false;

            }
        }
    }
}
