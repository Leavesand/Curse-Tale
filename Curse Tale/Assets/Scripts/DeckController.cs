using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour
{
    public List<GameObject> deck;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject card in deck)
        {
            Instantiate(card, this.transform).SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
