using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intention_Attack : MonoBehaviour
{
    public int attackDamageValue;

    GameObject thePatient;
    PatientController thePatient_Controller;
    // Start is called before the first frame update
    void Start()
    {
        thePatient = GameObject.FindGameObjectWithTag("Patient");
        thePatient_Controller = thePatient.GetComponent<PatientController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CombatStage.curCombatStage == CombatStage.combatStage.devil_Move)
        {
            thePatient_Controller.ReduceBlood( thePatient_Controller.BlessingResist(attackDamageValue) );
            Destroy(this.gameObject);
        }
        
    }
    
}
