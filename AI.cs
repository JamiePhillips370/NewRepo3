using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public Transform puck;
    public float moveSpeed = 7f;
    public float maxDistanceToPuck = 1.5f;
    public GameObject ownGoal;
    public GameObject opponentGoal;
    public Vector2 movement;

    private bool isMovingBackwards;

    private Rigidbody2D rb;
    private Collider2D aiCollider;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        aiCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 directionToPuck = puck.position - transform.position;

        if (directionToPuck.magnitude <= maxDistanceToPuck)
        {
            rb.velocity = Vector2.zero;
            maxDistanceToPuck = 0f;
        }
        else
        {
            rb.velocity = directionToPuck.normalized * moveSpeed;
            maxDistanceToPuck = 2f;
        }

        // Limit movement to within the air hockey table
        Vector2 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -7.8f, 0f);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -3.7f, 3.7f);
        transform.position = clampedPosition;
    }

    private void FixedUpdate()
    {
        Vector2 moveBackwards = new Vector2(-7f, this.transform.position.y);


        if (ownGoal != null && puck.position.x < ownGoal.transform.position.x)
        {
            movement = Vector2.zero;
        }
        if (puck.position.x < -6f)
        {
            movement = moveBackwards;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Puck"))
        {
            // Add force to the puck to simulate a hit
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(rb.velocity * 10f, ForceMode2D.Impulse);
        }
    }
}
