using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirTimer : MonoBehaviour
{
    public GameObject bar;
    public float damage = 0;
    public Vector3 final;
    public bool lerping = false;
    public PlayeMove PlayerMove;
    public float min = 25;
    public float maxMana = 50;
    public float reviveMana = 0;
    public bool hasRevive = true;
    public void Update()
    {

        if (lerping)
        {
            final = new Vector3(final.x, 1, 1);
            bar.transform.localScale = Vector3.Lerp(bar.transform.localScale, final, .05f);
            if((bar.transform.localScale.x <= final.x && final.x < bar.transform.localScale.x) || (bar.transform.localScale.x >= final.x && final.x > bar.transform.localScale.x))
            {
                lerping = false;
            }
        }
    }
    private void Start()
    {
        PlayerMove = GetComponent<PlayeMove>();
    }

    public void Change(float dmg)
    {
        if (dmg != 666)
        {
            damage = dmg / maxMana;
            final = bar.transform.localScale + (Vector3.right * damage);
            if (PlayerMove.staminaOut && dmg > 0)
            {
                PlayerMove.staminaOut = false;
            }
        }
        else
        {
            hasRevive = true;
            PlayerMove.staminaOut = false;
            if ((1 - bar.transform.localScale.x) * 15 < min)
            {
                damage = min;
            }
            else
                damage = (1 - bar.transform.localScale.x) * 15;
        }
        final = bar.transform.localScale + (Vector3.right * damage);
        lerping = true;
        if (bar.transform.localScale.x + damage <= 0)
        {
            final = bar.transform.localScale + (Vector3.left * bar.transform.localScale.x);
            PlayerMove.staminaOut = true;
            if (hasRevive && reviveMana !=0) {
                final -= (Vector3.left * (reviveMana / maxMana));
                
                hasRevive = false;
                PlayerMove.staminaOut = false;

            }
        }

        if (bar.transform.localScale.x + damage >= 1)
        {
            final = Vector3.one;
        }

    }

    public void Res()
    {
        lerping = false;
        bar.transform.localScale = new Vector3(0,1,1);
        PlayerMove.staminaOut = true;
        if (reviveMana != 0 && hasRevive)
        {
            bar.transform.localScale -= (Vector3.left * (reviveMana / maxMana));
            PlayerMove.staminaOut = false;
            hasRevive = false;
        }

    }



}
