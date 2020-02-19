using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffect : MonoBehaviour
{
    public List<GameObject> effects;
    public List<GameObject> buffs;

    GameObject patient;

    // Start is called before the first frame update
    void Start()
    {
        patient = GameObject.FindGameObjectWithTag("Patient");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EffectLaunch()
    {
        //foreach (GameObject effect in effects)
        //{
        //    if (effect != null)
        //    {
        //        Instantiate(effect);
        //    }
        //}
        //foreach (GameObject buff in buffs)
        //{
        //    if (buff != null)
        //    {
        //        patient.GetComponent<PatientController>().AddBuff(buff);
        //    }
        //}
    }
}
