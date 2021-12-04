using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWinText : MonoBehaviour
{
    public static UIWinText instance { get; private set; }

    Text visibleText;

    void Awake()
    {
        instance = this;
        visibleText = GetComponent<Text>();
        SetText("");
    }

    public void SetText(string words)
    {
        visibleText.text = words;
    }
}