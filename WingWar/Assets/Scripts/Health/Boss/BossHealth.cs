using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : Health
{
    public static BossHealth instance;
    GameObject HPUI_OBJ;

    private void OnEnable()
    {
        HPUI_OBJ = GameManager.instance.bossUI_OBJ;
        HP_T = GameManager.instance.bossHP_T;
        HP_SL = GameManager.instance.bossHP_SL;
        HPFill_I = GameManager.instance.bossHPFill_I;

        HPUI_OBJ.SetActive(true);
        GameManager.instance.isBossDead = false;
        HP_SL.value = 1;
        HP_T.text = "100.00%";
    }
    private void OnDisable()
    {
        GameManager.instance.isBossDead = true;
        HPUI_OBJ.SetActive(false);
    }

    private void Awake()
    {
        instance = this;
    }


    void Update()
    {
        // Boss dead
        if (HP <= 0)
        {
            HP = 0;
            GameManager.instance.GetPoint(50);
            GameManager.instance.BossrDead(gameObject);
        }
    }

    public override void Hurt(float damage)
    {
        HP -= damage;      
        HP_SL.value = HP / HP_MAX;  // Updata new HP value to UI Slider
        HP_T.text = (HP_SL.value * 100).ToString("0.00") + "%"; // Updata new HP to UI Text
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet"))
        {
            Hurt(20);
        }
    }
}
