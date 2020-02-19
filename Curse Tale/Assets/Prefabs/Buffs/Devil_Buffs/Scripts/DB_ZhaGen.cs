using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_ZhaGen : MonoBehaviour
{
    // buff：扎根

    GameObject theDevil;

    int duration;
    int value;

    bool buffExecuted = false;

    // Start is called before the first frame update
    void Start()
    {
        theDevil = GameObject.FindGameObjectWithTag("Devil");
        duration = this.GetComponent<Buff_Controller>().duration;
        value = this.GetComponent<Buff_Controller>().value;

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
}
