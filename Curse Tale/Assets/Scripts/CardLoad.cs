using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLoad : MonoBehaviour
{
    private Transform cardSlot_01;
    private Transform cardSlot_02;
    private Transform cardSlot_03;

    public int cardLevel { get; set; }
    public bool should_LaunchEffect { get; private set; }
    public bool should_LoadCard { get; private set; }
    public bool isLoaded = false;
    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        cardSlot_01 = GameObject.Find("CardSlot_01").transform;
        cardSlot_02 = GameObject.Find("CardSlot_02").transform;
        cardSlot_03 = GameObject.Find("CardSlot_03").transform;

        cardLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (canMove && isLoaded)
        {
            this.GetComponent<SpriteRenderer>().sortingOrder += 10;
        }        
    }

    private void OnMouseDrag()
    {
        if (canMove && isLoaded)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition.z = 0;
            this.transform.position = newPosition;
        }
    }

    private void OnMouseUpAsButton()
    {
        if (!isLoaded)
        {
            if (cardSlot_01.childCount < 1)
            {
                transform.SetParent(cardSlot_01, false);
                CombatController.handCards.Remove(gameObject);
                if (!should_LoadCard)
                {
                    should_LoadCard = true;
                }
                UpdateLevel();
            }
            else if (cardSlot_02.childCount < 1)
            {
                transform.SetParent(cardSlot_02, false);
                CombatController.handCards.Remove(gameObject);
                if (!should_LoadCard)
                {
                    should_LoadCard = true;
                }
                UpdateLevel();
            }
            else if (cardSlot_03.childCount < 1)
            {
                transform.SetParent(cardSlot_03, false);
                CombatController.handCards.Remove(gameObject);
                if (!should_LoadCard)
                {
                    should_LoadCard = true;
                }
                UpdateLevel();
            }
            else
            {
                Debug.Log("Card Slot is Full!");
            }
        }
        else if (canMove)
        {
            if (Vector2.Distance(this.transform.position, cardSlot_01.position) < 2)
            {
                if (cardSlot_01.childCount > 0)
                {
                    Transform otherCard = cardSlot_01.GetChild(0);
                    otherCard.SetParent(this.transform.parent);
                    otherCard.localPosition = Vector3.zero;
                }
                this.transform.SetParent(cardSlot_01);
                UpdateLevel();
            }
            else if (Vector2.Distance(this.transform.position, cardSlot_02.position) < 2)
            {
                if (cardSlot_02.childCount > 0)
                {
                    Transform otherCard = cardSlot_02.GetChild(0);
                    otherCard.SetParent(this.transform.parent);
                    otherCard.localPosition = Vector3.zero;
                }
                this.transform.SetParent(cardSlot_02);
                UpdateLevel();
            }
            else if (Vector2.Distance(this.transform.position, cardSlot_03.position) < 2)
            {
                if (cardSlot_03.childCount > 0)
                {
                    Transform otherCard = cardSlot_03.GetChild(0);
                    otherCard.SetParent(this.transform.parent);
                    otherCard.localPosition = Vector3.zero;
                }
                this.transform.SetParent(cardSlot_03);
                UpdateLevel();
            }
            this.transform.localPosition = Vector3.zero;
            this.GetComponent<SpriteRenderer>().sortingOrder -= 10;
        }
    }

    public void EffectLaunch()
    {
        if (!should_LaunchEffect)
        {
            should_LaunchEffect = true;
        }
    }

    public void EffectEnd()
    {
        if (should_LaunchEffect)
        {
            should_LaunchEffect = false;
            //this.gameObject.SetActive(false);
        }
    }

    void UpdateLevel()
    {
        Transform card_01;
        Transform card_02;
        Transform card_03;
        CardLoad cardLoad_01;
        CardLoad cardLoad_02;
        CardLoad cardLoad_03;
        if (cardSlot_01.childCount > 0)
        {
            card_01 = cardSlot_01.GetChild(0);
            cardLoad_01 = card_01.GetComponent<CardLoad>();
            cardLoad_01.cardLevel = 1;
        }        
        if (cardSlot_02.childCount > 0)
        {
            card_02 = cardSlot_02.GetChild(0);
            if (cardSlot_01.childCount > 0)
            {
                card_01 = cardSlot_01.GetChild(0);
                cardLoad_02 = card_02.GetComponent<CardLoad>();
                cardLoad_02.cardLevel = 1;
                if (card_02.name == card_01.name)
                {
                    cardLoad_02.cardLevel++;
                }
            }
        }
        if (cardSlot_03.childCount > 0)
        {
            card_03 = cardSlot_03.GetChild(0);
            cardLoad_03 = card_03.GetComponent<CardLoad>();
            cardLoad_03.cardLevel = 1;
            if (cardSlot_02.childCount > 0)
            {
                card_02 = cardSlot_02.GetChild(0);
                if (card_03.name == card_02.name)
                {
                    cardLoad_03.cardLevel++;
                    if (cardSlot_01.childCount > 0)
                    {
                        card_01 = cardSlot_01.GetChild(0);
                        if (card_03.name == card_01.name)
                        {
                            cardLoad_03.cardLevel++;
                        }
                    }
                }
            }
        }        
    }
}
