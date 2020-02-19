using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DI_YinRan : MonoBehaviour
{
    // 邪灵意图：引燃

    GameObject theDevil;
    GameObject thePatient;
    DevilController theDevil_Controller;
    PatientController thePatient_Controller;
    
    public GameObject Af_ZhuFuZhuoShao;

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
            Af_ZhuFuZhuoShao.GetComponent<Affliction_Controller>().level = thePatient_Controller.curBlessing;
            thePatient_Controller.AddAffliction(Af_ZhuFuZhuoShao);

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
