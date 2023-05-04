using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class Goal : MonoBehaviour
{
    [SerializeField]
    private float teleportTime = 1f;
    [SerializeField]
    private Transform portalLocation;


    //public float score = 0f;

    public GameObject ball;

    private float teleportTimer;
    public bool teleporting;
    

   

    private void Start()
    {
        teleportTimer = teleportTime;
    }

    private void Update()
    {
        if (ball && teleporting)
        {
            if (teleportTimer > 0f)
            {
                teleportTimer -= Time.deltaTime;

            }
            else
            {
                Teleport();
            }
        }
    }
    private void Teleport()
    {
        ball.transform.position = portalLocation.position;
        teleportTimer = teleportTime;
        teleporting = false;
        ball = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Puck"))
        {
            teleporting = true;
            ball = collision.gameObject;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Puck"))
        {
            teleporting = false;
            ball = null;
            teleportTimer = teleportTime;

            // Stop the puck's movement
            Rigidbody2D puckRb = collision.GetComponent<Rigidbody2D>();
            puckRb.velocity = UnityEngine.Vector2.zero;
        }
    }
}
