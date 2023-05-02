using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ImageCapture : MonoBehaviour
{
    WebCamTexture webCamTexture;
    public RawImage display;
    public AspectRatioFitter fit;

    public void Start()
    {
/*        int index = -1;
        for (int i = 0; i < WebCamTexture.devices.Length; i++)
        {
            if (WebCamTexture.devices[i].name.ToLower().Contains("your webcam name"))
            {
                Debug.LogError("WebCam Name:" + WebCamTexture.devices[i].name + "   Webcam Index:" + i);
                index = i;
            }
        }*/

        WebCamDevice device = WebCamTexture.devices[1];
        webCamTexture = new WebCamTexture(device.name);
        webCamTexture.Play();
        display.texture = webCamTexture;
    }

    public void Update()
    {
        float ratio = (float)webCamTexture.width / (float)webCamTexture.height;
        fit.aspectRatio = ratio;

        float ScaleY = webCamTexture.videoVerticallyMirrored ? -1f : 1f;
        display.rectTransform.localScale = new Vector3(1f, ScaleY, 1f);

        int orient = -webCamTexture.videoRotationAngle;
        display.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
    }

    public void callTakePhoto()
    {
        StartCoroutine(TakePhoto());
    }

    IEnumerator TakePhoto()
    {
        yield return new WaitForEndOfFrame();
        Texture2D photo = new Texture2D(webCamTexture.width, webCamTexture.height);
        photo.SetPixels(webCamTexture.GetPixels());
        photo.Apply();

        byte[] bytes = photo.EncodeToPNG();

        File.WriteAllBytes(Application.dataPath + "\\" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") +".png", bytes);
        Debug.Log(Application.dataPath);
    }
}