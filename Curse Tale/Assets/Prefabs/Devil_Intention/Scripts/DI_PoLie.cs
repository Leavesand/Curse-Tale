using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DI_PoLie : MonoBehaviour
{
    // 邪灵意图：破裂

    GameObject theDevil;
    GameObject thePatient;
    DevilController theDevil_Controller;
    PatientController thePatient_Controller;

    public GameObject DB_ChengShu;

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
            GameObject devilSpawn = theDevil.transform.Find("DevilSpawn(Clone)").gameObject;            
            if (devilSpawn)
            {
                DevilSpawnController devilSpawn_Controller = devilSpawn.GetComponent<DevilSpawnController>();
                theDevil_Controller.IncreaseBlood(devilSpawn_Controller.dvBlood);
                thePatient_Controller.IncreaseBlood(devilSpawn_Controller.ptBlood);
                Destroy(devilSpawn);
            }

            Transform buffSlot = theDevil.transform.Find("Devil_StatusBar").Find("BuffSlot");
            foreach (Transform curBuff in buffSlot)
            {
                if (curBuff.name == "DB_ChengShu(Clone)")
                {
                    Destroy(curBuff.gameObject);
                    break;
                }
            }

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
