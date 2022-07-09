using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class RoutenplanerText : MonoBehaviour
{
    public static RoutenplanerText routenplanerText;
    public TMP_InputField inputField;

    public string routenName;

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
        routenName = inputField.text;

        print("Hallo");
        SceneManager.LoadSceneAsync("MainSceneDroneFlight");
    }

}
