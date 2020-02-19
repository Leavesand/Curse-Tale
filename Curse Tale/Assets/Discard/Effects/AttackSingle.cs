using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSingle : MonoBehaviour
{

    public int attackDamageValue;
    
    GameObject theDevil;

    // Start is called before the first frame update
    void Start()
    {

        theDevil = GameObject.FindGameObjectWithTag("Devil");
        theDevil.GetComponent<DevilController>().ReduceBlood(attackDamageValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
