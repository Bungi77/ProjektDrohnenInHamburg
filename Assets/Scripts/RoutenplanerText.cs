using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class RoutenplanerText : MonoBehaviour
{
    public static RoutenplanerText routenplanerText;
    public TMP_InputField inputFieldRoute;
    public TMP_InputField inputFieldStart;

    public string routenName;
    public string routenStart;

    private void Awake()
    {
        if(routenplanerText == null)
        {
            routenplanerText = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetRoutenName()
    {
        routenName = inputFieldRoute.text;
        routenStart = inputFieldStart.text;

        SceneManager.LoadSceneAsync("MainSceneDroneFlight");
    }

}
