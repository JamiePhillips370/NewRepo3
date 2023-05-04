using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public GameObject goalPost1;
    public GameObject goalPost2;
    public TextMeshProUGUI scoreText1;
    public TextMeshProUGUI scoreText2;
    public float score1;
    public float score2;
    float point = 1f;
    float max = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Puck"))
        {
            if (collision.gameObject.transform.position.x < goalPost1.transform.position.x)
            {
                score2 += point;
                scoreText2.text = score2.ToString();
            }
            else if (collision.gameObject.transform.position.x > goalPost2.transform.position.x)
            {
                score1 += point;
                scoreText1.text = score1.ToString();
            }
        }
        if (score1 == 5f)
        {
            Application.Quit();
        }
        if (score2 == 5f)
        {
            Application.Quit();
        }
    }
}
