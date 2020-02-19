using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Effect_TuiHuo : MonoBehaviour
{
    // 祝符效果：退火

    CardLoad thisCardLoad;
    GameObject theDevil;
    GameObject thePatient;
    public GameObject floatingCanvas;
    public GameObject description;
    public GameObject floatingWindow;
    public GameObject floatingDescription;

    public int value = 2;

    public Sprite symbolSprite;
    bool isLoaded = false;

    Vector3 originScale;

    // Start is called before the first frame update
    void Start()
    {
        thisCardLoad = this.GetComponent<CardLoad>();
        theDevil = GameObject.FindGameObjectWithTag("Devil");
        thePatient = GameObject.FindGameObjectWithTag("Patient");
        description.GetComponent<Text>().text = "消除" + value * thisCardLoad.cardLevel + "层炎、神属性的折磨。";
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
            foreach (Transform curAffliction in thePatient.transform.Find("AfflictionSlot"))
            {
                Affliction_Controller curAfCon = curAffliction.GetComponent<Affliction_Controller>();
                if (curAfCon)
                {
                    if (curAfCon.Yan || curAfCon.Shen)
                    {
                        curAfCon.ReduceLevel(value);
                    }
                }
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
            floatingDescription.GetComponent<Text>().text = "消除" + value + "层炎、神属性的折磨。";
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sortingOrder += 10;
            floatingCanvas.GetComponent<Canvas>().sortingOrder += 10;
            this.transform.localScale = originScale * 1.5f;
            description.GetComponent<Text>().text = "消除" + value + "层炎、神属性的折磨。";
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
