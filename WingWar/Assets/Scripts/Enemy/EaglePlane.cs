using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EaglePlane : Enemy
{
    public int laserStep = 0; // 0 is can use; 1 is using; 2 is cannot use;
    public float moveSpeed = 2; // by second
    public GameObject planeFan;
    public GameObject shootPointLeft;
    public GameObject shootPointRight;
    public GameObject laserBeam;

    [Header("Overlap Box")]
    [SerializeField] public Transform boxPos;
    [SerializeField] public Vector3 boxSize;
    [SerializeField] public LayerMask playerLayer;

    void OnEnable()
    {
        StartCoroutine(RamdomMove());
        StartCoroutine(RamdomShoot());
        StartCoroutine(ShootCold());
        StartCoroutine(LaserCold());
    }

    private void OnDisable()
    {
        StopAllCoroutines();   
    }

    private void Update()
    {
        GunToPlayer();
        FanRotate();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxPos.position, boxSize);
    }
    public void GunToPlayer()
    {
        Vector2 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void FanRotate()
    {
        planeFan.transform.RotateAround(planeFan.transform.position, Vector3.right, 720 * Time.deltaTime);
    }

    public void Laser()
    {
        laserStep = 1;
        moveSpeed = 1.5f;
        laserBeam.SetActive(true);
    }

    //public bool FireMode()
    //{
    //    // If player in the OverlapBox , return true
    //    return Physics.OverlapBox(boxPos.position, boxSize, Quaternion.identity, playerLayer).Length > 0;
    //}

    protected override IEnumerator RamdomShoot()
    {
        int shootTime = 0;
        //bool mode = FireMode();
        while (shootTime < bulletShootTime)
        {
            if (startDone)
            {           
                // If Boss is using the LaserBeam , it can't shoot bullet
                switch (laserStep)
                {
                    case 0:
                        Laser();
                        yield break;

                    case 2:
                        //shoot more
                        Instantiate(bulletPrefab, shootPointLeft.transform.position, Quaternion.Euler(0, -20, gun.transform.rotation.z));
                        Instantiate(bulletPrefab, shootPoint.transform.position, gun.transform.rotation);
                        Instantiate(bulletPrefab, shootPointRight.transform.position, Quaternion.Euler(0, 20, gun.transform.rotation.z));
                        shootTime++;
                        break;
                }
            }

            yield return new WaitForSeconds(0.3f);
        }

    }

    protected override IEnumerator RamdomMove()
    {
        targetPos = new Vector3(Random.Range(13, 20), Random.Range(5, 10.5f), Random.Range(63, 76));


        while (self.activeSelf)
        {
            if (Vector3.Distance(transform.position, targetPos) > 2)
            {
                transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, moveSpeed);
            }
            else
            {
                if(laserStep == 1)
                {
                    targetPos = new Vector3(Random.Range(13, 20), player.transform.position.y, player.transform.position.z);
                    startDone = true;
                }
                else
                {
                    targetPos = new Vector3(Random.Range(13, 20), Random.Range(5, 10.5f), Random.Range(63, 76));
                    startDone = true;
                }

            }
            yield return null;
        }
    }

    protected IEnumerator LaserCold()
    {
        while (self.activeSelf)
        {
            yield return new WaitForSeconds(17);
            laserStep = 0;
        }
    }
}
