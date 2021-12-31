using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInOut : MonoBehaviour
{
    public static FadeInOut instance;
    Animator anim;

    public string laterLoadScene;

    private void Awake()
    {
        instance = this;;
        anim = GetComponent<Animator>();
    }

    public void ToScene()
    {
        SceneManager.LoadScene(laterLoadScene);
    }

    public void FadeIn(string sceneName)
    {
        laterLoadScene = sceneName;
        anim.SetTrigger("fadeIn");
    }
}
