using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen_Capture : MonoBehaviour
{
    public GameObject panel;
    public void Capture_Screen()
    {
        panel.SetActive(false);
        ScreenCapture.CaptureScreenshot(System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png");
        //Debug.Log(Application.persistentDataPath + "\\" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png");
    }
}