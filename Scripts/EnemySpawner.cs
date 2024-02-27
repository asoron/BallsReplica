using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform player;

    public GameObject[] enemies;
    public HitboxSc Hitbox;
    public float maxradius = 30;
    public float minradius = 10;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        Hitbox = player.GetComponentInChildren<HitboxSc>();
        for (int i = 0; i < 60; i++)
        {
            int r = Random.Range(0, enemies.Length);
            Vector2 a =Random.insideUnitCircle * maxradius;
            if(Vector2.Distance(Vector3.zero,a) > minradius)
            {
                
                GameObject n = Instantiate(enemies[r], new Vector2(player.position.x,player.position.y) + a, Quaternion.identity) as GameObject;


            }
            else
            {
                i--;
            }
        }

    }
    /*IEnumerator delay()
    {
        if (Hitbox.enemies.Count < 40)
        {

            Vector2 a = Random.insideUnitCircle * maxradius;
            if (Vector2.Distance(Vector3.zero, a) > minradius)
            {

                Instantiate(enemies[Random.Range(0, enemies.Length)], new Vector2(player.position.x, player.position.y) + a, Quaternion.identity);
                yield return new WaitForSeconds(1.5f);

            }
            else
                StartCoroutine(delay());


        }
    }*/
    void Update()
    {

        if (Hitbox.enemies.Count < 40 && Time.timeScale != 0)
        {
            //StartCoroutine(delay());

                Vector2 a = Random.insideUnitCircle * maxradius;
                if (Vector2.Distance(Vector3.zero, a) > minradius)
                {

                    Instantiate(enemies[Random.Range(0, enemies.Length)], new Vector2(player.position.x, player.position.y) + a, Quaternion.identity);

                }


            
        }

    }
}
