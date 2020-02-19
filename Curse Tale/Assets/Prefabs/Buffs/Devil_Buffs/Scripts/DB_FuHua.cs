using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DB_FuHua : MonoBehaviour
{
    // buff：孵化

    GameObject theDevil;

    int duration;
    int value;

    bool buffExecuted = false;

    GameObject floatingWindow;
    Text description;

    // Start is called before the first frame update
    void Start()
    {
        theDevil = GameObject.FindGameObjectWithTag("Devil");
        duration = this.GetComponent<Buff_Controller>().duration;
        value = this.GetComponent<Buff_Controller>().value;
        
        floatingWindow = this.transform.Find("FloatingWindow").gameObject;
        description = floatingWindow.transform.Find("TextBackground").Find("Description").GetComponent<Text>();
        // 添加buff时触发效果

    }

    // Update is called once per frame
    void Update()
    {
        if (CombatStage.curCombatStage == CombatStage.combatStage.devil_Settlement)
        {
            if (!buffExecuted)
            {
                // 每回合开始时触发效果

                //GetComponent<Buff_Controller>().CalDuration();
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
