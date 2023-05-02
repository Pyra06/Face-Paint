using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Paint_Changer : MonoBehaviour
{
    private ARFaceManager faceManager;
    private ARFace face;
    public List<Material> faceMaterials;
    public int btn_no;
   /* private int faceMaterialIndex = 0;*/

    void Start()
    {
        faceManager = GetComponent<ARFaceManager>();
    }
    public void SwitchFace()
    {
        btn_no = Swipe.minBtnNum;
        Debug.Log(btn_no);
        foreach (ARFace face in faceManager.trackables)
        {
            
            face.GetComponent<Renderer>().material = faceMaterials[btn_no];
        }
/*        faceMaterialIndex++;

        if (faceMaterialIndex == faceMaterials.Count)
        {
            faceMaterialIndex = 0;
        }*/
    }
}