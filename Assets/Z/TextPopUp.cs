using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class TextPopUp : MonoBehaviour
{
    public GameObject TextWarnungGebäude;
    public GameObject ImageWarnungDreieck;
    public GameObject ImageWarnungHintergrund;
    public GameObject TextDetails;
    public GameObject HintergrundDetails;
    public GameObject TextWarnungAufplop;
    public GameObject dron_2_body_root;
    public GameObject Canvas;
    public MainSceneRoutenPlaner scene;
    public FileWriter dokument;
    public string routenName;
    private bool enter = true;
    private bool details = true;
    string datum = "Datum: " + System.DateTime.Now + "\n";

    void Start()
    {
        dron_2_body_root = GameObject.Find("dron_2_body_root");
        Canvas = GameObject.Find("Canvas");
        TextWarnungGebäude.SetActive(false);
        ImageWarnungHintergrund.SetActive(false);
        ImageWarnungDreieck.SetActive(false);
        TextDetails.SetActive(false);
        HintergrundDetails.SetActive(false);
        TextWarnungAufplop.SetActive(false); 
        scene = Canvas.GetComponent<MainSceneRoutenPlaner>();
        routenName = scene.displayRoutenName.text;
        dokument = dron_2_body_root.GetComponent<FileWriter>();
    }
    void Update()
    {
        if (!enter)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                details = false;
                StartCoroutine(nochmalGucken());
            }
        }
        if (!details)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                StartCoroutine(detailsAnzeigen());
            }
        }
    }

    IEnumerator detailsAnzeigen()
    {
        HintergrundDetails.SetActive(true);
        TextDetails.SetActive(true);
        yield return new WaitForSeconds(20f);
        HintergrundDetails.SetActive(false);
        TextDetails.SetActive(false);
    }

    IEnumerator nochmalGucken()
    {
        TextWarnungGebäude.SetActive(true);
        ImageWarnungHintergrund.SetActive(true);
        yield return new WaitForSeconds(20f);
        TextWarnungGebäude.SetActive(false);
        ImageWarnungHintergrund.SetActive(false);
        details = true;
    }

    // Start is called before the first frame update
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            enter = false;
            details = false;
            print("Warnung: Flugverbotzone");
            if(!ImageWarnungDreieck.active)
            {
                dokument.writeText(datum + "Im Path " + routenName + " wurde ein Gebäude durchflogen." + "\n\n");
            }
            ImageWarnungDreieck.SetActive(true);
            TextWarnungAufplop.SetActive(true);
            TextWarnungGebäude.SetActive(true);
            ImageWarnungHintergrund.SetActive(true);
            StartCoroutine(TextWeg());
            if (!details)
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    StartCoroutine(detailsAnzeigen());
                }

            }
        }
    }

    IEnumerator TextWeg()
    {
        yield return new WaitForSeconds(20f);
        TextWarnungGebäude.SetActive(false);
        ImageWarnungHintergrund.SetActive(false);
        details = true;
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            enter = true;
            details = true;
            print("Flugverbotzone verlassen.");
            ImageWarnungDreieck.SetActive(false);
            TextWarnungAufplop.SetActive(false);
            TextWarnungGebäude.SetActive(false);
            ImageWarnungHintergrund.SetActive(false);
            TextDetails.SetActive(false);
            HintergrundDetails.SetActive(false);
        }
    }
}
