using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DI_YunYu : MonoBehaviour
{
    // 邪灵意图：孕育

    GameObject theDevil;
    GameObject thePatient;
    DevilController theDevil_Controller;
    PatientController thePatient_Controller;

    public GameObject DB_FuHua;
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
                devilSpawn_Controller.ChangeBlood((int)(devilSpawn_Controller.initBlood * 0.6f));
                if (devilSpawn_Controller.ptBlood == 0)
                {
                    Transform buffSlot = theDevil.transform.Find("Devil_StatusBar").Find("BuffSlot");
                    foreach (Transform curBuff in buffSlot)
                    {
                        if (curBuff.name == "DB_FuHua(Clone)")
                        {
                            Destroy(curBuff.gameObject);
                            break;
                        }
                    }
                    theDevil_Controller.AddBuff(DB_ChengShu);
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
