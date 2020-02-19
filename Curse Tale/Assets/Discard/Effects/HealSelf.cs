using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSelf : MonoBehaviour
{
    public int healSelfValue;

    GameObject thePatient;

    // Start is called before the first frame update
    void Start()
    {
        thePatient = GameObject.FindGameObjectWithTag("Patient");
        thePatient.GetComponent<PatientController>().IncreaseBlood(healSelfValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
