using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICogCount : MonoBehaviour
{
    public static UICogCount instance { get; private set; }

    Text visibleText;

    void Awake()
    {
        instance = this;
        visibleText = GetComponent<Text>();

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetValue(int numberFixed)
    {
        visibleText.text = "Cogs: " + numberFixed.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
