using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCombatButtonController : MonoBehaviour
{
    public GameObject prepareRoom;
    public GameObject combatRoom;
    public Transform YiXuanZhuFu;
    public Transform Deck;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(StartCombatButton_OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartCombatButton_OnClick()
    {
        foreach (Transform child in YiXuanZhuFu)
        {
            List<Transform> cardList = new List<Transform>();
            foreach (Transform card in child)
            {
                if (card.name != "FloatingCanvas")
                {
                    cardList.Add(card);
                }
            }
            foreach (Transform card in cardList)
            {
                card.SetParent(Deck);
            }
        }
        prepareRoom.SetActive(false);
        combatRoom.SetActive(true);
    }
}
