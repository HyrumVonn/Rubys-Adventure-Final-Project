using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NonPlayerCharacter : MonoBehaviour
{
    public float displayTime = 4.0f;
    public GameObject dialogBox;
    public TMP_Text dialogText;
    float timerDisplay;
    public bool sendToNextLevel = true;
    [SerializeField] string text0 = "Oi! Looks like dese Robuts bin messed up, you gon' fix'em, yeh?";
    [SerializeField] string text1 = "Whacha talkin' ta me for? You still got yaself 3 more Robuts";
    [SerializeField] string text2 = "Prett gud, bucha still got 2 lef'";
    [SerializeField] string text3 = "Ya almost gottem all, but I still hearin' one, yeh?";
    [SerializeField] string text4 = "Oo-oo-wee! You done fix'em'd all good";
    [SerializeField] string textDefault = "Ah, talkin' like dis hurts me mouf brova";

    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false);
        timerDisplay = -1.0f;
    }

    public void DisplayDialog(int numRobotsFixed)
    {
        switch(numRobotsFixed)
        {
            case 0 : dialogText.SetText(text0);
            break;
            case 1 : dialogText.SetText(text1);
            break;
            case 2 : dialogText.SetText(text2);
            break;
            case 3 : dialogText.SetText(text3);
            break;
            case 4 : dialogText.SetText(text4);
            break;
            default : dialogText.SetText(textDefault);
            break;
        }
        dialogBox.SetActive(true);
        timerDisplay = displayTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if(timerDisplay < 0)
            {
                dialogBox.SetActive(false);
            }
        }
    }
}
