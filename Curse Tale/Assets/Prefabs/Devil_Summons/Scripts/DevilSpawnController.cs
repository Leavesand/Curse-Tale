using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DevilSpawnController : MonoBehaviour
{
    public int initBlood { get; private set; }
    public int ptBlood { get; private set; }
    public int dvBlood { get; private set; }

    public Sprite orb1;
    public Sprite orb2;
    public Sprite orb3;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitBlood(int value)
    {
        initBlood = value;
        ptBlood = value;
        dvBlood = 0;

        UpdateText();
    }

    public void ChangeBlood(int value)
    {
        int realValue = value < ptBlood ? value : ptBlood;
        ptBlood -= realValue;
        dvBlood += realValue;

        if (dvBlood == 0)
        {
            this.GetComponent<SpriteRenderer>().sprite = orb1;
        }
        else if (ptBlood == 0)
        {
            this.GetComponent<SpriteRenderer>().sprite = orb3;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = orb2;
        }

        UpdateText();
    }

    private void UpdateText()
    {
        text.text = dvBlood + "/" + ptBlood;
    }

}
