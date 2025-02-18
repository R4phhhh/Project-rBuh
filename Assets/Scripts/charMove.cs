using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charMove : MonoBehaviour
{
    Rigidbody2D body;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float cSpeed = 5.0f;
    

    void Start ()
    {
        body = GetComponent<Rigidbody2D>(); 
    }

    void Update ()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical"); 
    }

    private void FixedUpdate()
    {  
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        if(body.position.x <= 12 && body.position.x >= -12 && body.position.y <= 7 && body.position.y >= -7) {
            body.velocity = new Vector2(horizontal*cSpeed, vertical*cSpeed);
        } else {
            body.velocity = new Vector2(horizontal*-cSpeed, vertical*-cSpeed);
        }
    }
}