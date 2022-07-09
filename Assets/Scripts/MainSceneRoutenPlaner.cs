using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainSceneRoutenPlaner : MonoBehaviour
{
    //private static RoutenplanerText routenplanerText;
    public TextMeshProUGUI displayRoutenName;
    public TextMeshProUGUI displayRoutenStart;

    public void Awake()
    {
        displayRoutenName.text = RoutenplanerText.routenplanerText.routenName;
        displayRoutenStart.text = RoutenplanerText.routenplanerText.routenStart;
    }

}
