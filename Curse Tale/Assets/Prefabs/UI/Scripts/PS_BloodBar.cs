using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PS_BloodBar : MonoBehaviour
{
    GameObject thePatient;
    PatientController thePatient_Controller;
    GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        thePatient = GameObject.FindGameObjectWithTag("Patient");
        thePatient_Controller = thePatient.GetComponent<PatientController>();
        text = this.transform.Find("Text").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        text.GetComponent<Text>().text = "生命：" + thePatient_Controller.curBlood + "/" + thePatient_Controller.maxBlood;
        text.SetActive(true);
    }

    private void OnMouseExit()
    {
        text.SetActive(false);
    }

}
