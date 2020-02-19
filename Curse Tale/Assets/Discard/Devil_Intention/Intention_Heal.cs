using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intention_Heal : MonoBehaviour
{
    public int HealValue;

    GameObject theDevil;

    // Start is called before the first frame update
    void Start()
    {
        theDevil = GameObject.FindGameObjectWithTag("Devil");

    }

    // Update is called once per frame
    void Update()
    {
        if (CombatStage.curCombatStage == CombatStage.combatStage.devil_Move)
        {
            theDevil.GetComponent<DevilController>().IncreaseBlood(HealValue);
            Destroy(this.gameObject);
        }

    }
}
