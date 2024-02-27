using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    public int dotCount=10;
    public GameObject dot;
    GameObject[] dots;
    float timeScale = 0.002f;
    public void Start()
    {
        float scale = 0.75f;
        dots = new GameObject[dotCount];
        for (int a = 0; a < dotCount; a++)
        {
            dots.SetValue(Instantiate(dot, transform.position, Quaternion.identity), a);
            dots[a].transform.parent = transform;
            dots[a].transform.localScale = Vector3.one * scale;
            scale -= 0.05f;

        }
        transform.gameObject.SetActive(false);
    }

    public void create()
    {

        
    }

    public void trajectail(Vector3 v)
    {

        for (int a = 0; a < dotCount; a++)
        {
            dots[a].transform.position = new Vector3(transform.position.x + (v.x * timeScale), transform.position.y + (v.y * timeScale)+((Physics2D.gravity.y * timeScale * timeScale*3500)/2), transform.position.z);

            timeScale += 0.002f;
        }
        timeScale = 0;

    }

}
