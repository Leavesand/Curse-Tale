using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PB_BlessingIncrease : MonoBehaviour
{
    GameObject thePatient;

    int duration;
    int value;

    bool buffExecuted = false;

    GameObject floatingWindow;
    Text description;

    // Start is called before the first frame update
    void Start()
    {
        thePatient = GameObject.FindGameObjectWithTag("Patient");
        duration = this.GetComponent<Buff_Controller>().duration;
        value = this.GetComponent<Buff_Controller>().value;

        floatingWindow = this.transform.Find("FloatingWindow").gameObject;
        description = floatingWindow.transform.Find("TextBackground").Find("Description").GetComponent<Text>();

        // 添加buff时触发效果
        thePatient.GetComponent<PatientController>().IncreaseBlessing(value);
    }

    // Update is called once per frame
    void Update()
    {
        if (CombatStage.curCombatStage == CombatStage.combatStage.patient_Settlement)
        {
            if (!buffExecuted)
            {
                // 每回合开始时触发效果

                GetComponent<Buff_Controller>().CalDuration();
                buffExecuted = true;
            }
        }
        else if (buffExecuted)
        {
            buffExecuted = false;
        }
    }

    private void OnDestroy()
    {
        // buff结束时触发效果

        thePatient.GetComponent<PatientController>().ReduceBlessing(value);

    }

    private void OnMouseEnter()
    {
        description.text = "提升" + this.GetComponent<Buff_Controller>().value + "祝福等级，持续" + this.GetComponent<Buff_Controller>().duration + "回合。";
        floatingWindow.SetActive(true);
    }

    private void OnMouseExit()
    {
        floatingWindow.SetActive(false);
    }
}
