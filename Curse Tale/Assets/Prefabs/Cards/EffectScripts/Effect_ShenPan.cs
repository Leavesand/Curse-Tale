﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Effect_ShenPan : MonoBehaviour
{
    // 祝符效果：审判

    CardLoad thisCardLoad;
    GameObject theDevil;
    GameObject thePatient;
    public GameObject floatingCanvas;
    public GameObject description;
    public GameObject floatingWindow;
    public GameObject floatingDescription;

    public int damageValue = 3;

    public Sprite symbolSprite;
    bool isLoaded = false;

    Vector3 originScale;

    // Start is called before the first frame update
    void Start()
    {
        thisCardLoad = this.GetComponent<CardLoad>();
        theDevil = GameObject.FindGameObjectWithTag("Devil");
        thePatient = GameObject.FindGameObjectWithTag("Patient");
        description.GetComponent<Text>().text = "对病毒类邪灵造成" + damageValue + "伤害，小概率增加邪灵抗性。";
        originScale = this.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLoaded && this.gameObject.GetComponent<CardLoad>().should_LoadCard)
        {
            this.GetComponent<SpriteRenderer>().sprite = symbolSprite;
            description.SetActive(false);
            this.GetComponent<BoxCollider2D>().size = new Vector2(5.08f, 5.15f);
            isLoaded = true;
            this.GetComponent<CardLoad>().isLoaded = true;
        }
        if (this.gameObject.GetComponent<CardLoad>().should_LaunchEffect)
        {
            // 卡牌发动效果
            int realDamageValue = theDevil.GetComponent<DevilController>().Resist(damageValue);
            theDevil.GetComponent<DevilController>().ReduceBlood(realDamageValue);
            if (Random.Range(0, 4) == 0)
            {
                theDevil.GetComponent<DevilController>().IncreaseResistance(1);
            }

            this.gameObject.GetComponent<CardLoad>().EffectEnd();
            Destroy(this.gameObject);
        }
    }

    private void OnMouseEnter()
    {
        if (isLoaded)
        {
            floatingWindow.SetActive(true);
            floatingDescription.GetComponent<Text>().text = "对病毒类邪灵造成" + damageValue * thisCardLoad.cardLevel + "伤害，小概率增加邪灵抗性。";
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sortingOrder += 10;
            floatingCanvas.GetComponent<Canvas>().sortingOrder += 10;
            this.transform.localScale = originScale * 1.5f;
            description.GetComponent<Text>().text = "对病毒类邪灵造成" + damageValue + "伤害，小概率增加邪灵抗性。";
        }
    }

    private void OnMouseExit()
    {
        if (isLoaded)
        {
            floatingWindow.SetActive(false);
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sortingOrder -= 10;
            floatingCanvas.GetComponent<Canvas>().sortingOrder -= 10;
            this.transform.localScale = originScale;
        }
    }

}
