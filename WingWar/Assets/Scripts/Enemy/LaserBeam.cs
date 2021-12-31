using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    public GameObject accumulate;
    public GameObject glow;
    public GameObject laserBeam;
    public GameObject freed;

    private void OnEnable()
    {
        StartCoroutine(Laser());
    }

    private void OnDisable()
    {
        transform.GetComponentInParent<EaglePlane>().laserStep = 2;
        transform.GetComponentInParent<EaglePlane>().moveSpeed = 2;
        StopAllCoroutines();
    }

    IEnumerator Laser()
    {
        accumulate.SetActive(true);
        glow.SetActive(true);

        yield return new WaitForSeconds(2);

        accumulate.SetActive(false);
        glow.SetActive(false);

        laserBeam.SetActive(true);
        freed.SetActive(true);

        yield return new WaitForSeconds(5);

        laserBeam.SetActive(false);
        freed.SetActive(false);

        gameObject.SetActive(false);
    }
}
