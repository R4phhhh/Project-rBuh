using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class enemyMove : MonoBehaviour
{
    Rigidbody2D body;
    public GameObject player;
    int hp;
    Text hpText;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float damage = 7f;

    float cSpeed = 4.0f;
    void Start ()
    {
        hp = 10;
        body = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        Transform hpCanvas = transform.Find("HPCanvas");
        if (hpCanvas != null)
        {
            // Reset Z position to ensure it's visible
            UnityEngine.Vector3 newPosition = hpCanvas.localPosition;
            newPosition.z = 0; // Adjust if needed
            hpCanvas.localPosition = newPosition;

            Debug.Log($"{gameObject.name}: Fixed HPCanvas Z position to {hpCanvas.localPosition.z}");
        }
        if (hpText == null)
        {
            hpText = GetComponentInChildren<Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = UnityEngine.Vector2.MoveTowards(transform.position, player.transform.position, cSpeed*Time.deltaTime);
        transform.up = player.transform.position - transform.position;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log(hp);
        hp = hp - damage;
        Debug.Log(hp);
        if (hpText != null)
        {
            hpText.text = hp.ToString();
        }

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
