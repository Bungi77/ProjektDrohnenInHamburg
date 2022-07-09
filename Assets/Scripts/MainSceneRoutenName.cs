using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainSceneRoutenName : MonoBehaviour
{
    //private static RoutenplanerText routenplanerText;
    public TextMeshProUGUI displayRoutenName;

    public void Awake()
    {
        displayRoutenName.text = RoutenplanerText.routenplanerText.routenName;
    }

}
