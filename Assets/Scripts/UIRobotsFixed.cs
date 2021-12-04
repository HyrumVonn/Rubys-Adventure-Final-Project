using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRobotsFixed : MonoBehaviour
{
    public static UIRobotsFixed instance { get; private set; }

    Text visibleText;

    void Awake()
    {
        instance = this;
        visibleText = GetComponent<Text>();
        SetValue(0);

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetValue(int numberFixed)
    {
        visibleText.text = "Robots Fixed: " + numberFixed.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
