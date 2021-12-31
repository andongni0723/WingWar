using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float score = 0;
    public bool isBossDead = true;
    public bool isPlayerDead;

    [Header("UI GameObject")]
    public GameObject gameOver_OBJ;
    public Text score_T;

    [Header("Boss UI")]
    public GameObject bossUI_OBJ;

    public Text bossHP_T;
    public Slider bossHP_SL;
    public Image bossHPFill_I;

    private void Awake()
    {
        Time.timeScale = 1;
        instance = this;
        if (instance == null)
            Destroy(this);
    }

    void Start()
    {

    }

    void Update()
    {
        if(!isPlayerDead)
            score += Time.deltaTime; // score add from play time

        // var show on UI
        score_T.text = score.ToString("0");

        //if (isBossDead)
        //    bossUI_OBJ.SetActive(true);
        //else
        //    bossUI_OBJ.SetActive(false);

    }

    public void GetPoint(float point)
    {
        score += point;
    }

    public void PlayerDead()
    {
        gameOver_OBJ.SetActive(true);
        isPlayerDead = true;
    }

    public void BossrDead(GameObject boss)
    {
        Destroy(boss);
    }

    public void ToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
