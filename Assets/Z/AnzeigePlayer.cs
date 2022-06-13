using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnzeigePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ImageBatHigh; //neu
    public GameObject ImageBatMiddle; //neu
    public GameObject ImageBatLow; //neu
    public GameObject ImageBatEmpty; //neu
    public GameObject TextInfo; //neu

void Start() //neu Methode
{               
    ImageBatHigh.SetActive(true);
    ImageBatMiddle.SetActive(false);
    ImageBatLow.SetActive(false);
    ImageBatEmpty.SetActive(false);
    TextInfo.SetActive(true);
    StartCoroutine (onSight());
}

IEnumerator onSight() //neue Methode
{
    yield return new WaitForSeconds(5f);
    ImageBatHigh.SetActive(false);
    TextInfo.SetActive(false);
    yield return new WaitForSeconds(5f);
    ImageBatMiddle.SetActive(true);
    yield return new WaitForSeconds(5f);
    ImageBatMiddle.SetActive(false);
    yield return new WaitForSeconds(5f);
    ImageBatLow.SetActive(true);
    yield return new WaitForSeconds(5f);
    ImageBatLow.SetActive(false);
    yield return new WaitForSeconds(5f);
    ImageBatEmpty.SetActive(true);
    yield return new WaitForSeconds(0.5f);
    ImageBatEmpty.SetActive(false);
    yield return new WaitForSeconds(0.5f);
    ImageBatEmpty.SetActive(true);
    yield return new WaitForSeconds(0.5f);
    ImageBatEmpty.SetActive(false);
    yield return new WaitForSeconds(0.5f);
    ImageBatEmpty.SetActive(true);
    yield return new WaitForSeconds(0.5f);
    ImageBatEmpty.SetActive(false);
    }
}
