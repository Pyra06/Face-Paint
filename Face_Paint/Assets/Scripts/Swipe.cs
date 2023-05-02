using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class Swipe : MonoBehaviour
{
    public Button[] btn;
    public RectTransform panel; //scrollpanel
    public RectTransform center; //center object
    private float[] distance; //btn dist from center
    private bool dragging = false; 
    private int btnDistance; //dist between btns
    public static int minBtnNum; //no. of button 

    void Start()
    {
        int btnLength = btn.Length;
        distance = new float[btnLength];

        //get btn dist
        btnDistance = (int)Mathf.Abs(btn[1].GetComponent<RectTransform>().anchoredPosition.x - btn[0].GetComponent<RectTransform>().anchoredPosition.x);
        minBtnNum = 0;
        GameObject childObj = btn[minBtnNum].transform.GetChild(0).gameObject;
        btn[minBtnNum].GetComponent<RectTransform>().sizeDelta = new Vector2(250, 250);
        childObj.GetComponent<RectTransform>().sizeDelta = new Vector2(250, 250);
        childObj.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < btn.Length; i++)
        {
            distance[i] = Mathf.Abs(center.transform.position.x - btn[i].transform.position.x);
        }

        float minDist = Mathf.Min(distance); //get min dist

        for (int a = 0; a < btn.Length; a++)
        {
            if (minDist == distance[a])
            {
                minBtnNum = a;
            }
        }

        if (!dragging)
        {
            LerpToBtn(minBtnNum * -btnDistance);
        }
    }

    void LerpToBtn(int position)
    {
        float newX = Mathf.Lerp(panel.anchoredPosition.x, position, Time.deltaTime * 10f);
        Vector3 newPosition = new Vector3(newX, panel.anchoredPosition.y);

        panel.anchoredPosition = newPosition;

        //panel.GetChild
    }

    public void StartDrag()
    {
        dragging = true;
        for (int i = 0; i < 7; i++)
        {
            GameObject childObj = btn[i].transform.GetChild(0).gameObject;
            btn[i].GetComponent<RectTransform>().sizeDelta = new Vector2(200, 200);
            childObj.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 200);
            childObj.SetActive(false);
        }
    }

    public void EndDrag()
    {
        dragging = false;
        GameObject childObj = btn[minBtnNum].transform.GetChild(0).gameObject;
        btn[minBtnNum].GetComponent<RectTransform>().sizeDelta = new Vector2(250, 250);
        childObj.GetComponent<RectTransform>().sizeDelta = new Vector2(250, 250);
        childObj.SetActive(true);
    }

    public void test()
    {
        Debug.Log("See");
    }
}