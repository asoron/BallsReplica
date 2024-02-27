using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSkill : MonoBehaviour
{
    public GameObject Ball;
    public Transform player;
    public GameObject[] balls;
    float t = 0;
    
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < 3; i++)
        {
            GameObject a = Instantiate(Ball, new Vector3(transform.position.x, transform.position.y, transform.position.y),Quaternion.identity);
            switch (i)
            {
                case 0:
                    a.transform.position = new Vector3(transform.position.x - 2, transform.position.y - 2, transform.position.y);
                    break;    
                case 1:
                    a.transform.position = new Vector3(transform.position.x + 2, transform.position.y - 2, transform.position.y);
                    break;    
                case 2:
                    a.transform.position = new Vector3(transform.position.x, transform.position.y +2, transform.position.y);
                    break;
            }
            a.transform.parent = transform;
            balls[i] = a;
        }
    }

    int b = 0;
    void Update()
    {
        transform.position = player.position;
        transform.RotateAround(Vector3.forward,3*Time.deltaTime);

        
    }

}
