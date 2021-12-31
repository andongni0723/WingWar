using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbarEffect : MonoBehaviour
{
    const float WaitTime_MAX = 0.5f;
    public Slider slider_S;
    public Image hpEffect_IMAGE;
    float waitTime = 0; 
    public float effectSpeed;

    private void Start()
    {
        hpEffect_IMAGE.fillAmount = slider_S.value;
    }

    private void Update()
    {
        if(slider_S.value < hpEffect_IMAGE.fillAmount)
        {
            waitTime += Time.deltaTime;
            if (waitTime > WaitTime_MAX)
            {
                hpEffect_IMAGE.fillAmount -= effectSpeed * Time.deltaTime;
            }
            //hpEffect_IMAGE.fillAmount -= effectSpeed * Time.deltaTime;
        }
        else
        {
            waitTime = 0;
            hpEffect_IMAGE.fillAmount = slider_S.value;
        }
    }

}
