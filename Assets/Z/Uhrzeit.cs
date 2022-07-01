using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Uhrzeit : MonoBehaviour
{
    public Text datetext;
    public Text zeittext;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DateTime date = DateTime.Now;
        datetext.text = date.ToShortDateString();
        zeittext.text = date.ToLongTimeString();


    }
}
