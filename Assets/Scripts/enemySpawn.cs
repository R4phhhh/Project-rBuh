using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    float delay = 2f;
    float waveSize = 8f;
    float xPosition;
    float yPosition;
    public GameObject test;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        timer = delay;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0) {
            timer -= Time.deltaTime;
        } else if(timer <= 0) {
            float chooseCoords = Random.Range(1,3); //1 = x, 2 = y
            if(chooseCoords == 1) {
                float xEdge = Random.Range(1,3); //1 = dibawah 0, 2 = diatas 1
                if(xEdge == 1) {
                    xPosition = Random.Range(-1f, -0.1f);
                    yPosition = Random.Range(0f, 1f);
                } else if(xEdge == 2) {
                    xPosition = Random.Range(1.1f, 2f);
                    yPosition = Random.Range(0f, 1f);
                }
            } else if(chooseCoords == 2) {
                float yEdge = Random.Range(1,3); //1 = dibawah 0, 2 = diatas 1
                if(yEdge == 1) {
                    xPosition = Random.Range(-1f, -0.1f);
                    yPosition = Random.Range(0f, 1f);
                } else if(yEdge == 2) {
                    xPosition = Random.Range(1.1f, 2f);
                    yPosition = Random.Range(0f, 1f);
                }
            }
            Vector2 pos = Camera.main.ViewportToWorldPoint(new Vector2(xPosition, yPosition));
            Instantiate(test,pos,Quaternion.identity);
            timer = 2f;
        }
    }
}
