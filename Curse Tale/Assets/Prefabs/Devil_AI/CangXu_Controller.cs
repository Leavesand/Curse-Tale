using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CangXu_Controller : MonoBehaviour
{
    GameObject theDevil;
    GameObject thePatient;
    DevilController theDevil_Controller;
    PatientController thePatient_Controller;

    public GameObject DI_ZhiRu;
    public GameObject DI_YunYu;
    public GameObject DI_PoLie;
    public GameObject DI_YinRan;

    public GameObject DB_FuHua;
    public GameObject DB_ChengShu;

    bool intentionChanged = false;

    // Start is called before the first frame update
    void Start()
    {
        theDevil = GameObject.FindGameObjectWithTag("Devil");
        theDevil_Controller = theDevil.GetComponent<DevilController>();
        thePatient = GameObject.FindGameObjectWithTag("Patient");
        thePatient_Controller = thePatient.GetComponent<PatientController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (CombatStage.curCombatStage == CombatStage.combatStage.devil_Intention)
        {
            if (!intentionChanged)
            {
                ChangeIntention();

                intentionChanged = true;
            }
        }
        else if (intentionChanged)
        {
            intentionChanged = false;
        }
    }

    private void ChangeIntention()
    {
        Transform buffSlot = theDevil.transform.Find("Devil_StatusBar").Find("BuffSlot");
        foreach (Transform curBuff in buffSlot)
        {
            if (curBuff.name == "DB_ChengShu(Clone)")
            {
                theDevil_Controller.SetIntention(DI_PoLie);
                return;
            }
            else if (curBuff.name == "DB_FuHua(Clone)")
            {
                if (theDevil_Controller.curBlood == 0)
                {
                    theDevil_Controller.SetIntention(DI_PoLie);
                    return;
                }
                theDevil_Controller.SetIntention(DI_YunYu);
                return;
            }
        }
        if (thePatient_Controller.curBlessing >= 5 && !thePatient.transform.Find("AfflictionSlot/Af_ZhuFuZhuoShao(Clone)"))
        {
            theDevil_Controller.SetIntention(DI_YinRan);
            return;
        }
        theDevil_Controller.SetIntention(DI_ZhiRu);
        return;
    }

}
