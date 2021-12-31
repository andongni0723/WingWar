using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallFade : MonoBehaviour
{
    public void CallFadeIn(string sceneName)
    {
        FadeInOut.instance.FadeIn(sceneName);
    }
}
