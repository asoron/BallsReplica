using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Transform player;
    public float speed = 0.1f;
    public GameObject explosion;
    void Start()
    {
        Invoke("dead", 2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.position,speed);
        transform.rotation = Quaternion.LerpUnclamped(transform.rotation, player.rotation,speed);
    }

    public void dead()
    {
        GameObject a = Instantiate(explosion,transform.position,Quaternion.identity);
        Destroy(a, 2);
        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dead();
        }
    }

}
