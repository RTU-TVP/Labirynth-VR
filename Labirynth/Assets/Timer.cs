using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    float time;
    TMP_Text text;
    void Start()
    {
        time = 0;
        text = GetComponent<TMP_Text>();
    }

    void SetTime()
    {
        time += Time.deltaTime;
        text.text = "";
        string min = ((int)time / 60).ToString();
        string sec = ((int)time % 60).ToString();
        if (min.Length > 1) text.text += min;
        else text.text += "0" + min;
        text.text += ":";
        if (sec.Length > 1) text.text += sec;
        else text.text += "0" + sec;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetTime();
    }
}
