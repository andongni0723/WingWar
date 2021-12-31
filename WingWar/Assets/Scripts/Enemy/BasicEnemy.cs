using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{
    private void OnEnable()
    {
        StartCoroutine(RamdomMove());
        StartCoroutine(RamdomShoot());
        StartCoroutine(ShootCold());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
