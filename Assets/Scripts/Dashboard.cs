using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dashboard : MonoBehaviour
{
   public void LogoutButton()
   {
       Application.Quit();
       Debug.Log("Abgemeldet"); 
   }
   
   public void RoutenPlaner()
   {
       SceneManager.LoadScene("MainSceneDroneFlight");
   }

}
