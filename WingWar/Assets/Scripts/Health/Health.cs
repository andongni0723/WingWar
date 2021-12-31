using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]protected float HP_MAX = 100;
    protected float HP;
    [Header("UI GameObject")]
    [SerializeField] protected Text HP_T;
    [SerializeField] protected Slider HP_SL;
    [SerializeField] protected Image HPFill_I;


    void Start()
    {
        HP = HP_MAX;
    }

    public virtual void Hurt(float damage)
    {
        HP -= damage;
        HP_T.text = HP.ToString(); // Updata new HP to UI Text
        HP_SL.value = HP / HP_MAX;  // Updata new HP value to UI Slider
    }
}
