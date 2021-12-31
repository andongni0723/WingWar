using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    public static PlayerHealth instance;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        // player dead
        if (HP <= 0)
        {
            HP = 0;
            GameManager.instance.PlayerDead();
        }
    }

    public override void Hurt(float damage)
    {
        base.Hurt(damage);

        if (HP >= 60) // change color of HP bar and text on slider value change
        {
            HPFill_I.color = Color.green;
            HP_T.color = Color.green;
        }
        else if (HP >= 30)
        {
            HPFill_I.color = Color.yellow;
            HP_T.color = Color.yellow;
        }
        else if (HP >= 0)
        {
            HPFill_I.color = Color.red;
            HP_T.color = Color.red;
        }
    }
}
