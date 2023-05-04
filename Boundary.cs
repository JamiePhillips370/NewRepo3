using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(0, 0);
    }
    

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= 0.9f)
        {
            transform.position = new Vector2(0.9f, transform.position.y);
        }
        else if (transform.position.x <= -7.241337)
        {
            transform.position = new Vector2(-7.241337f, transform.position.y);
        }
        
        transform.Translate (Vector2.right * Time.deltaTime * speed * Input.GetAxis("Horizontal"));
        transform.Translate(Vector2.up * Time.deltaTime * speed * Input.GetAxis("vertical"));
    }
}
