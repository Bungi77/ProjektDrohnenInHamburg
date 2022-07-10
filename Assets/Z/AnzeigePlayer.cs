using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AnzeigePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ImageBatHigh; //neu
    public GameObject ImageBatMiddle; //neu
    public GameObject ImageBatLow; //neu
    public GameObject ImageBatEmpty; //neu
    public GameObject TextInfo; //neu
    public GameObject dron_2_body_root;
    public GameObject HintergrundLimit;
    public GameObject TextLimit;
    public GameObject HoehenLimit;
    public GameObject TextHoehenLimit;
    public FileWriter dokument;
    string datum = "Datum: " + System.DateTime.Now + "\n";

void Start() //neu Methode
{               
    dron_2_body_root = GameObject.Find("dron_2_body_root");
    ImageBatHigh.SetActive(true);
    ImageBatMiddle.SetActive(false);
    ImageBatLow.SetActive(false);
    ImageBatEmpty.SetActive(false);
    TextInfo.SetActive(true);
    HintergrundLimit.SetActive(false);
    TextLimit.SetActive(false);
    HoehenLimit.SetActive(false);
    TextHoehenLimit.SetActive(false);
    dokument = GetComponent<FileWriter>();
    StartCoroutine (onSight());
}
void Update()
{
    if(dron_2_body_root.transform.position.y <= 65f)
    {
        if(!TextLimit.active)
        {
            dokument.writeText(datum + "Im Path " + "wurde das Höhenlimit unterschritten." + "\n\n");
        }
        HintergrundLimit.SetActive(true);
        TextLimit.SetActive(true);
    }
    else
    {
        HintergrundLimit.SetActive(false);
        TextLimit.SetActive(false);
    }
    
    if(dron_2_body_root.transform.position.y > 300f)
    {
        if(!TextHoehenLimit.active)
        {
            dokument.writeText(datum + "Im Path " + "wurde das Höhenlimit überschritten." + "\n\n");
        }        
        HoehenLimit.SetActive(true);
        TextHoehenLimit.SetActive(true);
    }
    else
    {
        HoehenLimit.SetActive(false);
        TextHoehenLimit.SetActive(false);
    }
}
IEnumerator onSight() //neue Methode
{
    yield return new WaitForSeconds(20f);
    ImageBatHigh.SetActive(false);
    TextInfo.SetActive(false);
    yield return new WaitForSeconds(1f);
    ImageBatMiddle.SetActive(true);
    yield return new WaitForSeconds(20f);
    ImageBatMiddle.SetActive(false);
    yield return new WaitForSeconds(1f);
    ImageBatLow.SetActive(true);
    yield return new WaitForSeconds(20f);
    ImageBatLow.SetActive(false);
    yield return new WaitForSeconds(1f);
    ImageBatEmpty.SetActive(true);
    yield return new WaitForSeconds(0.5f);
    ImageBatEmpty.SetActive(false);
    yield return new WaitForSeconds(0.5f);
    ImageBatEmpty.SetActive(true);
    yield return new WaitForSeconds(0.5f);
    ImageBatEmpty.SetActive(false);
    yield return new WaitForSeconds(0.5f);
    ImageBatEmpty.SetActive(true);
    yield return new WaitForSeconds(20f);
    ImageBatEmpty.SetActive(false);
    }
}
