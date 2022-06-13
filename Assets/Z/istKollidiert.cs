using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class istKollidiert : MonoBehaviour
{
  void OnTriggerEnter(Collider collider)
  {
    if(collider.gameObject.tag == "Player")
    {
        print ("geht");
    }
  }
}
