using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Paint_Changer : MonoBehaviour
{
    private ARFaceManager faceManager;
    private ARFace face;
    public List<Material> faceMaterials;
    private int faceMaterialIndex = 0;

    void Start()
    {
        faceManager = GetComponent<ARFaceManager>();
    }

    public void SwitchFace()
    {
        foreach (ARFace face in faceManager.trackables)
        {
            face.GetComponent<Renderer>().material = faceMaterials[faceMaterialIndex];
        }
        faceMaterialIndex++;
    
        if (faceMaterialIndex == faceMaterials.Count)
        {
            faceMaterialIndex = 0;
        }
    }

    public void PutFacePaint(int btn_no)
    {
        foreach (ARFace face in faceManager.trackables)
        {
            face.GetComponent<Renderer>().material = faceMaterials[btn_no - 1];
        }
    }

    public void TestCase()
    {
        Debug.Log("Works");
    }
}
