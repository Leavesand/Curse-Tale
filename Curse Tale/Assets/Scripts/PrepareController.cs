using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareController : MonoBehaviour
{
    public Transform cardSlot;
    public GameObject card;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUpAsButton()
    {
        Instantiate(card, cardSlot, false).SetActive(false);
    }
}
