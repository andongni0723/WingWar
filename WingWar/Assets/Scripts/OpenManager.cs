using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenManager : MonoBehaviour
{
    public static OpenManager instance;

    public float volume;

    [Header("UI Component")]
    public Slider bgmVolume_S;
    public Text volume_T;
    public Toggle joystickModeLeftIsOn_T;
    

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // Load UI value
        joystickModeLeftIsOn_T.isOn = PlayerPrefs.HasKey("joystickMode") ? JoystickToggleIsOn_IntToBool() : true;
        bgmVolume_S.value = PlayerPrefs.HasKey("bgmVolume") ? PlayerPrefs.GetFloat("bgmVolume") : 1;
        var a = gameObject.activeSelf ? true : false;
    }

    private void Update()
    {
        // Setting UI show on screen
        volume_T.text = (bgmVolume_S.value * 100).ToString("0");

        // Setting vaule To Save
        PlayerPrefs.SetFloat("bgmVolume", bgmVolume_S.value);
        PlayerPrefs.SetInt("joystickMode",JoystickToggleIsOn_BoolToInt()); // Left
    }

    public int JoystickToggleIsOn_BoolToInt()
    {
        if (joystickModeLeftIsOn_T.isOn)
            return 0;
        else
            return 1;
    }

    public bool JoystickToggleIsOn_IntToBool()
    {
        if (PlayerPrefs.GetInt("joystickMode") == 0)
            return true;
        else
            return false;
    }

    public void ToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
