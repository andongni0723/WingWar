using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject shootPoint;
    public GameObject bullet;
    public VariableJoystick variableJoystick;
    Rigidbody rb;
    public float speed;  

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        variableJoystick = GameObject.FindGameObjectWithTag("joystick").GetComponent<VariableJoystick>();   
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        // Joystick move on mobile and PC
        Vector3 direction = Vector3.up * variableJoystick.Vertical + Vector3.forward * variableJoystick.Horizontal;
        rb.velocity = direction * speed * Time.fixedDeltaTime;

        // WASD move on PC
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector3 directionPC = Vector3.up * moveY + Vector3.forward * moveX;
        rb.velocity = directionPC * speed * 0.4f * Time.fixedDeltaTime;
    }

    public void Shoot()
    {
        Instantiate(bullet, shootPoint.transform.position, Quaternion.Euler(0, 0, 180));
    }



    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Wall":
                PlayerHealth.instance.Hurt(1);
                break;
            case "enemyBullet":
                PlayerHealth.instance.Hurt(5);
                Destroy(other.gameObject);
                break;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        switch (other.tag)
        {
            case "Laser":
                PlayerHealth.instance.Hurt(1);
                break;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "enemyWall":
                PlayerHealth.instance.Hurt(25);
            break;
            case "Wall":
                PlayerHealth.instance.Hurt(1);
                break;
        }
    }

}
