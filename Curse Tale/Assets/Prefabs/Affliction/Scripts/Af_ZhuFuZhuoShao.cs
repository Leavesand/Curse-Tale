using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Af_ZhuFuZhuoShao : MonoBehaviour
{
    //public GameObject PB_IncreaseBlessing;

    GameObject thePatient;
    PatientController thePatient_Controller;

    GameObject floatingWindow;
    Text description;

    int level;
    //int increasedBlessing;

    bool afflictionExecuted = false;

    // Start is called before the first frame update
    void Start()
    {
        thePatient = GameObject.FindGameObjectWithTag("Patient");
        thePatient_Controller = thePatient.GetComponent<PatientController>();
        level = this.GetComponent<Affliction_Controller>().level;

        floatingWindow = this.transform.Find("FloatingWindow").gameObject;
        description = floatingWindow.transform.Find("TextBackground").Find("Description").GetComponent<Text>();

        // 添加折磨时触发效果
        thePatient_Controller.IncreaseBlessing(1);
        //increasedBlessing = level;
    }


    // Update is called once per frame
    void Update()
    {
        if (CombatStage.curCombatStage == CombatStage.combatStage.patient_Settlement)
        {
            if (!afflictionExecuted)
            {
                // 每回合开始时触发效果
                level = this.GetComponent<Affliction_Controller>().level;
                thePatient_Controller.ReduceBlood(level);
                thePatient_Controller.ReduceSanity(level);
                //thePatient_Controller.ReduceBlessing(increasedBlessing);

                GetComponent<Affliction_Controller>().ReduceLevel(1);

                //thePatient_Controller.IncreaseBlessing(level);
                //increasedBlessing = level;

                afflictionExecuted = true;
            }
        }
        else if (afflictionExecuted)
        {
            afflictionExecuted = false;
        }
    }

    private void OnDestroy()
    {
        // buff结束时触发效果
        thePatient_Controller.ReduceBlessing(1);
    }
    
    private void OnMouseEnter()
    {
        level = this.GetComponent<Affliction_Controller>().level;
        description.text = "祝福灼烧" + level + "：\n 炎属性折磨，提升祝福等级1，下回合 生命-" + level + " 精神-" + level + "。";
        floatingWindow.SetActive(true);
    }

    private void OnMouseExit()
    {
        floatingWindow.SetActive(false);
    }
}
