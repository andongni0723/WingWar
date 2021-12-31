using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPoint;
    public GameObject enemyWallPoint;
    public List<GameObject> walls = new List<GameObject>();
    public List<GameObject> enemys = new List<GameObject>();

    float timer = 0;
    float step;
    public float mix = 2.5f;
    public float max = 5;
    public float bossTargetPoint = 50;
    public float enemyTargetPoint = 0;
    

    private void Start()
    {
        SetTimerStep();
    }

    void Update()
    {
        CreateEnemy();
        CreateBoss();

        timer += Time.deltaTime;
        if(timer >= step)
        {
            CreateWall();
            SetTimerStep();
        }
    }

    public void SetTimerStep()
    {
        step = Random.Range(mix, max);
        timer = 0;
    }

    public void CreateWall()
    {
        Instantiate(walls[Random.Range(0, walls.Count)], enemyWallPoint.transform.position, Quaternion.Euler(90, 0, 0));
    }

    public void CreateBoss()
    {
        if(GameManager.instance.score > bossTargetPoint)
        {
            // if Boss dead
            if (GameManager.instance.isBossDead) 
                Instantiate(enemys[0], enemyPoint.transform.position, Quaternion.Euler(0, 180, 0));
            
            bossTargetPoint += 150;
        }
    }

    public void CreateEnemy()
    {
        if (GameManager.instance.score > enemyTargetPoint )
        {
            // if Boss dead
            if (GameManager.instance.isBossDead)
            {
                for (int i = 0; i < Random.Range(2,4); i++) //instantiate 2~4 enemys
                {
                    Instantiate(enemys[1], enemyPoint.transform.position, Quaternion.identity);
                }           
            }
            
            enemyTargetPoint += 30;
        }
    }
}
