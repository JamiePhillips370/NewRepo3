using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class transferBall : MonoBehaviour
{
    public GameObject goalPost1;
    //public GameObject goalPost2;
    //public TextMeshProUGUI scoreText1;
    public TextMeshProUGUI scoreText2;
    //public float score1;
    public float score2;
    float point = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Puck"))
        {
            if (collision.gameObject.transform.position.x < goalPost1.transform.position.x)
            {
                score2 += point;
                scoreText2.text = score2.ToString();
            }

            if (score2 == 5f )
            {
                Application.Quit();
            }
        }
    }
}
