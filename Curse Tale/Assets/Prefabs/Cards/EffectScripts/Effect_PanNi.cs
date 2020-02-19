using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Effect_PanNi : MonoBehaviour
{
    // 祝符效果：叛逆
    
    public GameObject floatingWindow;
    public GameObject floatingDescription;

    // Start is called before the first frame update
    void Start()
    {

        floatingDescription.GetComponent<Text>().text = "拒绝。";
    }

    // Update is called once per frame
    void Update()
    {

        if (this.gameObject.GetComponent<CardLoad>().should_LaunchEffect)
        {
            // 卡牌发动效果

            this.gameObject.GetComponent<CardLoad>().EffectEnd();
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
