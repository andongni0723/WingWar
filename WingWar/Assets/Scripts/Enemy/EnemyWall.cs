using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWall : MonoBehaviour
{
    public float speed = 50;

    void Update()
    {
        if (!GameManager.instance.isPlayerDead)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);

            if (transform.position.x >= 59)
                Destroy(gameObject);
        }
    }
}
