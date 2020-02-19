using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Effect_ShenZhu : MonoBehaviour
{
    // 祝符效果：神助

    GameObject theDevil;
    GameObject thePatient;
    public GameObject floatingWindow;
    public GameObject floatingDescription;

    int damageValue;

    // Start is called before the first frame update
    void Start()
    {
        theDevil = GameObject.FindGameObjectWithTag("Devil");
        thePatient = GameObject.FindGameObjectWithTag("Patient");
        damageValue = thePatient.GetComponent<PatientController>().curBlessing;
        floatingDescription.GetComponent<Text>().text = "受祝福加持，对邪灵造成" + damageValue + "点伤害。";
    }

    // Update is called once per frame
    void Update()
    {

        if (this.gameObject.GetComponent<CardLoad>().should_LaunchEffect)
        {
            // 卡牌发动效果
            damageValue = thePatient.GetComponent<PatientController>().curBlessing;
            int realDamageValue = theDevil.GetComponent<DevilController>().Resist(damageValue);
            theDevil.GetComponent<DevilController>().ReduceBlood(realDamageValue);

            this.gameObject.GetComponent<CardLoad>().EffectEnd();
            this.transform.parent.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }

    private void OnMouseEnter()
    {
        floatingWindow.SetActive(true);
        damageValue = thePatient.GetComponent<PatientController>().curBlessing;
        floatingDescription.GetComponent<Text>().text = "受祝福加持，对邪灵造成" + damageValue + "点伤害。";
    }

    private void OnMouseExit()
    {
        floatingWindow.SetActive(false);
    }
}
