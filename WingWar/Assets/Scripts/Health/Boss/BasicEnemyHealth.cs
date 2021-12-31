using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyHealth : Health
{
    public static BasicEnemyHealth instance;

    public GameObject UI_OBJ;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        // dead
        if (HP <= 0)
        {
            HP = 0;
            GameManager.instance.GetPoint(10);
            Destroy(gameObject);
        }
    }

    public override void Hurt(float damage)
    {
        HP -= damage;
        HP_SL.value = HP / HP_MAX;  // Updata new HP value to UI Slider
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet"))
        {
            Destroy(other.gameObject);
            UI_OBJ.SetActive(true);
            Hurt(20);
        }
    }
}
