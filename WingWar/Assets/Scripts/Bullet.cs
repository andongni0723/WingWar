using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{ 
    Rigidbody rb;
    public GameObject destroyVFX;
    public string name;
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

    private void OnDestroy()
    {
        GameObject vfx = Instantiate(destroyVFX, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        // A name a rule to collider
        switch (name){
            case "Enemy":
                if (other.gameObject.CompareTag("Player"))
                {
                    Debug.Log(other.gameObject + "enter all");
                    Destroy(gameObject);
                }
                return;

            case "Player":
                if (other.gameObject.CompareTag("enemy") || other.CompareTag("enemyWall"))
                {
                    Debug.Log(other.gameObject + "enter all");
                    Destroy(gameObject);
                }
                return;
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
