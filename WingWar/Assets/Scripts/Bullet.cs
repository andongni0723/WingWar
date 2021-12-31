using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    Rigidbody rb;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(TimeToDestroy());
    }

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("enemyWall"))
        {
            Destroy(gameObject);
        }

        if(other.CompareTag("enemy") && CompareTag("bullet"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator TimeToDestroy()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);

            Destroy(gameObject);
        }
        
    }
}
