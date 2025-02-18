using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    Rigidbody2D body;
    public GameObject player;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float damage = 7f;

    float cSpeed = 4.0f;
    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = UnityEngine.Vector2.MoveTowards(transform.position, player.transform.position, cSpeed*Time.deltaTime);
        transform.up = player.transform.position - transform.position;
    }
}
