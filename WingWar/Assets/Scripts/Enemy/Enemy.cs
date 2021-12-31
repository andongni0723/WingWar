using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected GameObject self;
    protected Rigidbody rb;
    protected Vector3 velocity = Vector3.zero;
    protected Vector3 beingTargetPos;
    protected bool startDone = false;
    protected GameObject player;

    [SerializeField] protected Vector3 targetPos;
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected GameObject gun;
    [SerializeField] protected GameObject shootPoint;
    [SerializeField] protected int bulletShootTime;

    //private void OnEnable()
    //{
    //    //transform.position = Vector3.SmoothDamp(transform.position, beingTargetPos, ref velocity, 5);
    //    StartCoroutine(RamdomMove());
    //}

    private void Awake()
    {
        self = gameObject;
        rb = self.GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        beingTargetPos = new Vector3(16, transform.position.y, transform.position.z);
        
    }

    protected virtual IEnumerator RamdomMove()
    {
        targetPos = new Vector3(Random.Range(13, 20), Random.Range(5, 10.5f), Random.Range(63, 76));
        

        while (self.activeSelf)
        {
            if(Vector3.Distance(transform.position, targetPos) > 2)
            {
                transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, 2);
            }
            else
            {
                targetPos = new Vector3(Random.Range(13, 20), Random.Range(5, 10.5f), Random.Range(63, 76));
                startDone = true;
            }
            yield return null;
        }
    }

    protected virtual IEnumerator RamdomShoot()
    {
        int shootTime = 0;
        while (shootTime < bulletShootTime)
        {
            if (startDone)
            {
                Instantiate(bulletPrefab, shootPoint.transform.position, Quaternion.Euler(0, 0, 0));
                shootTime++;
            }            
            yield return new WaitForSeconds(0.3f);
        }
    }

    protected IEnumerator ShootCold()
    {
        while (self.activeSelf)
        {
            yield return new WaitForSeconds(3);
            yield return StartCoroutine(RamdomShoot());
        }     
    }
}
