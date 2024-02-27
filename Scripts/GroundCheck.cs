using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    HitboxSc hbsc;
    // Start is called before the first frame update
    void Start()
    {
        hbsc = GameObject.FindGameObjectWithTag("Hitbox").GetComponent<HitboxSc>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
            hbsc.destroy(collision.gameObject, true);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
            hbsc.destroy(collision.gameObject, false);
        if(collision.gameObject.tag == "Hole")
        {
            Destroy(gameObject);
        }
    }


}
