using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenManager : MonoBehaviour
{
    public static OpenManager instance;

    public float volume;
    public bool isAuto;

    [Header("UI Component")]
    public Slider bgmVolume_S;
    public Text volume_T;
    public Toggle joystickModeLeftIsOn_T;
    public List<Toggle> platform_TS = new List<Toggle>();
    public Text platform_T;
    

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // Load UI value
        joystickModeLeftIsOn_T.isOn = PlayerPrefs.HasKey("joystickMode") ? JoystickToggleIsOn_IntToBool() : true;
        bgmVolume_S.value = PlayerPrefs.HasKey("bgmVolume") ? PlayerPrefs.GetFloat("bgmVolume") : 1;
        PlatformToggleInOut(1);
    }

    private void Update()
    {
        // Setting UI show on screen
        volume_T.text = (bgmVolume_S.value * 100).ToString("0");

        // Setting vaule To Save
        PlayerPrefs.SetFloat("bgmVolume", bgmVolume_S.value);              // bgm volume
        PlayerPrefs.SetInt("joystickMode",JoystickToggleIsOn_BoolToInt()); // joystick mode
        PlatformToggleInOut(0);                                            // platform setting
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

    public void PlatformToggleInOut(int index)
    {
        switch (index)
        {
            case 0: // INPUT: the toggle to PP 
                isAuto = false;

                if (platform_TS[0].isOn)
                    CheckAuto();
                else if (platform_TS[1].isOn)
                    PlayerPrefs.SetString("platform", "mobile");

                else if (platform_TS[2].isOn)
                    PlayerPrefs.SetString("platform", "PC");

                if(isAuto)
                    platform_T.text = "Platform: Auto(" + PlayerPrefs.GetString("platform") + ")";
                else
                    platform_T.text = "Platform: " + PlayerPrefs.GetString("platform");

                break;

            case 1: // OUTPUT: the PP value to the toggle on

                if (PlayerPrefs.HasKey("platform"))
                {
                    switch (PlayerPrefs.GetString("platform"))
                    {
                        case "mobile":
                            platform_TS[1].isOn = true;
                            break;
                        case "PC":
                            platform_TS[2].isOn = true;
                            break;
                    }
                }
                break;
        }
    }

    public void CheckAuto()
    {
#if UNITY_ANDROID
        PlayerPrefs.SetString("platform", "mobile");                          
#elif UNITY_STANDALONE_WIN
        PlayerPrefs.SetString("platform", "PC");
#endif
        isAuto = true;
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
