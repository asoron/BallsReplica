using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerBall : MonoBehaviour
{
    PlayeMove pm;
    public void Start()
    {
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayeMove>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name != "Hitbox")
        {

            switch (collision.gameObject.name)
            {
                case "HotFloor":
                    break;
                case "Hole(Clone)":
                    break;
                case "Square(Clone)":
                    break;

                default:
                    if (collision.gameObject.tag != "EditorOnly")
                    {
                        Destroy(collision.gameObject);
                        pm.score.increase(50);
                        pm.AirTimer.Change(10);
                    }
                    break;
                    
            }
        }
    }
}
