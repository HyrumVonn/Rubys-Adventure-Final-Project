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
            case 0 : dialogText.SetText("Oi! Looks like dese Robuts bin messed up, you gon' fix'em, yeh?");
            break;
            case 1 : dialogText.SetText("Whacha talkin' ta me for? You still got yaself 3 more Robuts");
            break;
            case 2 : dialogText.SetText("Prett gud, bucha still got 2 lef'");
            break;
            case 3 : dialogText.SetText("Ya almost gottem all, but I still hearin' one, yeh?");
            break;
            case 4 : dialogText.SetText("Oo-oo-wee! You done fix'em'd all good");
            break;
            default : dialogText.SetText("Ah, talkin' like dis hurts me mouf brova");
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
