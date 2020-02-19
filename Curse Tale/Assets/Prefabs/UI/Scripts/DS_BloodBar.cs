using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DS_BloodBar : MonoBehaviour
{
    GameObject theDevil;
    DevilController theDevil_Controller;
    GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        theDevil = GameObject.FindGameObjectWithTag("Devil");
        theDevil_Controller = theDevil.GetComponent<DevilController>();
        text = this.transform.Find("Text").gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseEnter()
    {
        text.GetComponent<Text>().text = "生命：" + theDevil_Controller.curBlood;
        text.SetActive(true);
    }

    private void OnMouseExit()
    {
        text.SetActive(false);
    }
}
