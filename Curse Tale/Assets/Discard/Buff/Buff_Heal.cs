using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff_Heal : MonoBehaviour
{
    public int healValue;

    GameObject thePatient;
    
    bool buffExecuted = false;

    // Start is called before the first frame update
    void Start()
    {
        thePatient = GameObject.FindGameObjectWithTag("Patient");
    }

    // Update is called once per frame
    void Update()
    {
        if (CombatStage.curCombatStage == CombatStage.combatStage.patient_Settlement)
        {
            if (!buffExecuted)
            {
                thePatient.GetComponent<PatientController>().IncreaseBlood(healValue);
                GetComponent<Buff_Duration>().CalDuration();
                buffExecuted = true;
            }
        }
        else if (buffExecuted)
        {
            buffExecuted = false;
        }
        
    }
}
