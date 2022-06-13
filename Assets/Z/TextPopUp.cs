using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPopUp : MonoBehaviour
{
    public GameObject TextWarnungGebäude;
    public GameObject ImageWarnungDreieck;
    public GameObject ImageWarnungHintergrund;
    public GameObject TextDetails;
    public GameObject HintergrundDetails;
    public GameObject TextWarnungAufplop;

    private bool enter = true;
    private bool details = true;

    void Start()
    {
        TextWarnungGebäude.SetActive(false);
        ImageWarnungHintergrund.SetActive(false);
        ImageWarnungDreieck.SetActive(false);
        TextDetails.SetActive(false);
        HintergrundDetails.SetActive(false);
        TextWarnungAufplop.SetActive(false);
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
        yield return new WaitForSeconds(5f);
        HintergrundDetails.SetActive(false);
        TextDetails.SetActive(false);
    }

    IEnumerator nochmalGucken()
    {
        TextWarnungGebäude.SetActive(true);
        ImageWarnungHintergrund.SetActive(true);
        yield return new WaitForSeconds(5f);
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
        yield return new WaitForSeconds(10f);
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
