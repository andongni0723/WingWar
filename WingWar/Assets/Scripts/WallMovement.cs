using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    public float speed = 50;
    public float x = -118;

    private void FixedUpdate()
    {
        if (!GameManager.instance.isPlayerDead)
        {
            transform.Translate(Vector3.right * Time.fixedDeltaTime * speed);

            if (transform.position.x >= 59)
                transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }
        
    }
}
