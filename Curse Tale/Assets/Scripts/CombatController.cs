using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatController : MonoBehaviour
{
    public static CombatStage.combatStage combatStage;

    public GameObject devil_01;
    public GameObject patient_01;
    public GameObject devil_intention_01;
    public GameObject devil_intention_02;
    public GameObject deck;
    public GameObject graveyard;
    public Transform handPosition_01;
    public Transform handPosition_02;
    public Transform handPosition_03;
    public Transform cardSlot_01;
    public Transform cardSlot_02;
    public Transform cardSlot_03;
    public Transform cardSlot_04;
    public Button button_Replace;
    public Button button_Launch;

    public static List<GameObject> deckCards;
    public static List<GameObject> handCards;

    private DevilController devilCon;
    private PatientController patientCon;
    private GameObject handCard_01;
    private GameObject handCard_02;
    private GameObject handCard_03;

    public GameObject card_PanNi;
    public GameObject card_ShenZhu;


    void Start()
    {
        devilCon = GameObject.FindGameObjectWithTag("Devil").GetComponent<DevilController>();
        patientCon = GameObject.FindGameObjectWithTag("Patient").GetComponent<PatientController>();

        StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
        {
            CombatInit();
        }, 1f));

        Debug.Log("Combat Start!");
    }
    
    void Update()
    {

        if (cardSlot_01.childCount > 0 || cardSlot_02.childCount > 0 || cardSlot_03.childCount > 0 || cardSlot_04.childCount > 0 || deck.transform.childCount + graveyard.transform.childCount == 0)
        {
            button_Launch.interactable = true;
        }
        else
        {
            button_Launch.interactable = false;
        }
    }

    void CombatInit()
    {
        // 初始化
        deckCards = new List<GameObject>();
        handCards = new List<GameObject>();
        foreach(Transform child in deck.transform)
        {
            deckCards.Add(child.gameObject);
        }

        button_Replace.onClick.AddListener(ButtonReplaceOnClick);
        button_Launch.onClick.AddListener(ButtonLaunchOnClick);

        Devil_Intention();
    }

    // 战斗回合循环
    // - 邪灵准备意图阶段 - 患者状态结算阶段 - 祭司行动阶段 - 祝符效果结算阶段 - 邪灵状态结算阶段 - 邪灵行动阶段 -

    // 邪灵准备意图    
    void Devil_Intention()
    {
        CombatStage.curCombatStage = CombatStage.combatStage.devil_Intention;

        //int i = Random.Range(0, 2);
        //if (i == 0)
        //{
        //    devilCon.SetIntention(devil_intention_01);
        //}
        //else
        //{
        //    devilCon.SetIntention(devil_intention_02);
        //}

        StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
        {
            Patient_Settlement();
        }, 0.5f));
    }

    // 患者状态结算
    void Patient_Settlement()
    {
        CombatStage.curCombatStage = CombatStage.combatStage.patient_Settlement;

        if (patientCon.curSanity < 10)
        {
            Instantiate(card_PanNi, cardSlot_01, false);
        }

        if (patientCon.curBlessing > 4)
        {
            cardSlot_04.gameObject.SetActive(true);
            Instantiate(card_ShenZhu, cardSlot_04, false);
        }

        //List<GameObject> buffs = patientCon.buffs;
        //foreach(GameObject buff in buffs)
        //{
        //    if (buff != null)
        //    {
        //        buff.GetComponent<Buff_Duration>().ReduceDuration();
        //    }
        //}

        StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
        {
            Priest_Move();
        }, 0.5f));
    }

    // 祭司行动
    void Priest_Move()
    {
        CombatStage.curCombatStage = CombatStage.combatStage.priest_Move;

        Debug.Log("Priest Move!");

        // 洗牌                 /// 不明bug：无法完全洗牌
        if (deckCards.Count < 3)
        {
            foreach (Transform child in graveyard.transform)
            {
                deckCards.Add(child.gameObject);
                child.SetParent(deck.transform);
            }
            Debug.Log("shuffle!");
        }

        // 抽卡
        if (deckCards.Count > 0)
        {
            handCard_01 = deckCards[Random.Range(0, deckCards.Count)];
            deckCards.Remove(handCard_01);
            handCards.Add(handCard_01);
            handCard_01.transform.SetParent(handPosition_01, false);
            handCard_01.SetActive(true);
            handCard_01.transform.localPosition = Vector3.zero;
        }
        if (deckCards.Count > 0)
        {
            handCard_02 = deckCards[Random.Range(0, deckCards.Count)];
            deckCards.Remove(handCard_02);
            handCards.Add(handCard_02);
            handCard_02.transform.SetParent(handPosition_02, false);
            handCard_02.SetActive(true);
            handCard_02.transform.localPosition = Vector3.zero;
        }
        if (deckCards.Count > 0)
        {
            handCard_03 = deckCards[Random.Range(0, deckCards.Count)];
            deckCards.Remove(handCard_03);
            handCards.Add(handCard_03);
            handCard_03.transform.SetParent(handPosition_03, false);
            handCard_03.SetActive(true);
            handCard_03.transform.localPosition = Vector3.zero;
        }
        

        // 换卡按钮可用
        button_Replace.interactable = true;        
    }

    // 祝符效果结算
    void Card_Settlement()
    {
        CombatStage.curCombatStage = CombatStage.combatStage.card_Settlement;
        
        StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
        {
            LaunchCard_01();
        }, 0.5f));
    }
    void LaunchCard_01()
    {
        if (cardSlot_01.childCount > 0)
        {
            GameObject card = cardSlot_01.GetChild(0).gameObject;
            card.GetComponent<CardLoad>().EffectLaunch();
            //card.transform.SetParent(graveyard.transform, false);
        }
        StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
        {
            LaunchCard_02();
        }, 0.5f));
    }
    void LaunchCard_02()
    {
        if (cardSlot_02.childCount > 0)
        {
            GameObject card = cardSlot_02.GetChild(0).gameObject;
            card.GetComponent<CardLoad>().EffectLaunch();
            //card.transform.SetParent(graveyard.transform, false);
        }
        StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
        {
            LaunchCard_03();
        }, 0.5f));
    }
    void LaunchCard_03()
    {
        if (cardSlot_03.childCount > 0)
        {
            GameObject card = cardSlot_03.GetChild(0).gameObject;
            card.GetComponent<CardLoad>().EffectLaunch();
            //card.transform.SetParent(graveyard.transform, false);
        }
        if (cardSlot_04.gameObject.activeSelf)
        {
            StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
            {
                LaunchCard_04();
            }, 0.5f));
        }
        else
        {
            StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
            {
                Devil_Settlement();
            }, 0.5f));
        }
    }
    void LaunchCard_04()
    {
        if (cardSlot_04.childCount > 0)
        {
            GameObject card = cardSlot_04.GetChild(0).gameObject;
            card.GetComponent<CardLoad>().EffectLaunch();
        }
        StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
        {
            Devil_Settlement();
        }, 0.5f));
    }

    // 邪灵状态结算
    void Devil_Settlement()
    {
        CombatStage.curCombatStage = CombatStage.combatStage.devil_Settlement;
        
        StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
        {
            Devil_Move();
        }, 0.5f));
    }

    // 邪灵行动
    void Devil_Move()
    {
        CombatStage.curCombatStage = CombatStage.combatStage.devil_Move;

        StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
        {
            Devil_Intention();
        }, 1f));
    }

    void ButtonReplaceOnClick()
    {
        // 弃牌
        foreach(GameObject card in handCards)
        {
            card.transform.SetParent(graveyard.transform, false);
            card.SetActive(false);
        }
        handCards.Clear();
        // 洗牌
        if (deckCards.Count < 3)
        {
            foreach (Transform child in graveyard.transform)
            {
                deckCards.Add(child.gameObject);
                child.SetParent(deck.transform, false);
            }
            Debug.Log("shuffle!");
        }
        // 抽牌
        if (deckCards.Count > 0)
        {
            handCard_01 = deckCards[Random.Range(0, deckCards.Count)];
            deckCards.Remove(handCard_01);
            handCards.Add(handCard_01);
            handCard_01.transform.SetParent(handPosition_01, false);
            handCard_01.SetActive(true);
            handCard_01.transform.localPosition = Vector3.zero;
        }
        if (deckCards.Count > 0)
        {
            handCard_02 = deckCards[Random.Range(0, deckCards.Count)];
            deckCards.Remove(handCard_02);
            handCards.Add(handCard_02);
            handCard_02.transform.SetParent(handPosition_02, false);
            handCard_02.SetActive(true);
            handCard_02.transform.localPosition = Vector3.zero;
        }
        if (deckCards.Count > 0)
        {
            handCard_03 = deckCards[Random.Range(0, deckCards.Count)];
            deckCards.Remove(handCard_03);
            handCards.Add(handCard_03);
            handCard_03.transform.SetParent(handPosition_03, false);
            handCard_03.SetActive(true);
            handCard_03.transform.localPosition = Vector3.zero;
        }
        if (Random.Range(0, 2) == 0)
        {
            Debug.Log("增加抗性");
            devilCon.IncreaseResistance(1);
        }
    }

    void ButtonLaunchOnClick()
    {
        Debug.Log("Launch!");
        button_Replace.interactable = false;
        button_Launch.interactable = false;

        StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
        {
            Card_Settlement();
        }, 0.1f));

        foreach (GameObject card in handCards)
        {
            card.transform.SetParent(graveyard.transform, false);
            card.SetActive(false);
        }
        handCards.Clear();
    }

}
