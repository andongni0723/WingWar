using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_VFX : MonoBehaviour
{
    public ParticleSystem ps;
    public Color colorVFX;
    public float time;

    private void OnEnable()
    {
        Destroy(gameObject,1);
    }
    private void Update()
    {
        //var main = ps.main;
        //main.startColor = colorVFX;
    }
}
