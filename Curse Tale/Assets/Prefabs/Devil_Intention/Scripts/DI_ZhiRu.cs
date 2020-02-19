using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DI_ZhiRu : MonoBehaviour
{
    // 邪灵意图：植入

    GameObject theDevil;
    GameObject thePatient;
    DevilController theDevil_Controller;
    PatientController thePatient_Controller;

    public GameObject devilSpawn;
    public GameObject DB_FuHua;

    GameObject floatingWindow;
    Text description;

    // Start is called before the first frame update
    void Start()
    {
        theDevil = GameObject.FindGameObjectWithTag("Devil");
        theDevil_Controller = theDevil.GetComponent<DevilController>();
        thePatient = GameObject.FindGameObjectWithTag("Patient");
        thePatient_Controller = thePatient.GetComponent<PatientController>();

        floatingWindow = this.transform.Find("FloatingWindow").gameObject;
        description = floatingWindow.transform.Find("TextBackground").Find("Description").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CombatStage.curCombatStage == CombatStage.combatStage.devil_Move)
        {
            // 意图发动效果
            int X = (int)(theDevil_Controller.curBlood * 0.5f);
            int X_resist = thePatient_Controller.BlessingResist(X);

            theDevil_Controller.ReduceBlood(X);
            thePatient_Controller.ReduceBlood(X_resist * 2);
            Instantiate(devilSpawn, theDevil.transform, false).GetComponent<DevilSpawnController>().InitBlood(X_resist * 2);
            theDevil_Controller.AddBuff(DB_FuHua);
            
            Destroy(this.gameObject);
        }
    }
    
    private void OnMouseEnter()
    {
        floatingWindow.SetActive(true);
    }

    private void OnMouseExit()
    {
        floatingWindow.SetActive(false);
    }
}
