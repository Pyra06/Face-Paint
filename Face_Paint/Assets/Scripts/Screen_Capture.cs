using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Screen_Capture : MonoBehaviour
{
    public GameObject panel;
    public GameObject display;
    public void Capture_Screen()
    {
        panel.SetActive(false);
        ScreenCapture.CaptureScreenshot(System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png");

        StartCoroutine(bar(2, 1));
    }

    private IEnumerator bar(float duration1, float duration2)
    {
        yield return new WaitForSeconds(duration1);
        display.SetActive(true);
        panel.SetActive(true);
        yield return new WaitForSeconds(duration2);
        display.SetActive(false);

    }
}