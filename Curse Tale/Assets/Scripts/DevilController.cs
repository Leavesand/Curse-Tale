using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DevilController : MonoBehaviour
{
    public GameObject redLeftSlot;
    public GameObject redMidSlot;
    public GameObject redRightSlot;
    public GameObject blueLeftSlot;
    public GameObject blueMidSlot;
    public GameObject blueRightSlot;

    GameObject bloodBar;
    GameObject resistanceBar;
    Transform buffSlot;
    Transform intentionSlot;

    public int curBlood { get; private set; }
    public int initBlood = 10;
    int curBlood_CubeCount;

    public int curResistance { get; private set; }
    public int maxResistance { get; private set; }
    int curResistance_CubeCount;

    List<GameObject> blood_CubeList = new List<GameObject>();
    List<GameObject> resistance_CubeList = new List<GameObject>();
    //List<GameObject> buffList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        ActorInit();


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ActorInit()
    {
        curBlood = initBlood;
        bloodBar = this.transform.Find("Devil_StatusBar").Find("BloodBar").gameObject;
        InitBloodBar();
        UpdateBloodBar();

        curResistance = 0;
        maxResistance = 10;
        resistanceBar = this.transform.Find("Devil_StatusBar").Find("ResistanceBar").gameObject;
        InitResistanceBar();
        UpdateResistanceBar();

        buffSlot = this.transform.Find("Devil_StatusBar").Find("BuffSlot");
        intentionSlot = this.transform.Find("Devil_StatusBar").Find("IntentionSlot");
    }

    public GameObject GetIntention()
    {
        if (intentionSlot.childCount > 0)
        {
            return intentionSlot.GetChild(0).gameObject;
        }
        else
        {
            return null;
        }
    }

    public void SetIntention(GameObject intention)
    {
        while (GetIntention() != null)
        {
            Destroy(GetIntention());
        }
        GameObject.Instantiate(intention, intentionSlot);
    }

    //public List<GameObject> GetBuffs()
    //{
    //    return buffList;
    //}

    public void AddBuff(GameObject buff)
    {
        foreach (Transform curBuff in buffSlot)
        {
            if (buff.name + "(Clone)" == curBuff.name && buff.GetComponent<Buff_Controller>().value == curBuff.GetComponent<Buff_Controller>().value)
            {
                // 相同buff 持续时间叠加
                curBuff.GetComponent<Buff_Controller>().IncreaseDuration(buff.GetComponent<Buff_Controller>().duration);
                return;
            }
        }
        GameObject insBuff = Instantiate(buff, buffSlot, false);
        Vector3 newPosition = insBuff.transform.localPosition;
        newPosition.x += buffSlot.childCount * 0.5f;
        insBuff.transform.localPosition = newPosition;
    }

    public void ReduceBlood(int value)
    {
        curBlood -= value;
        curBlood = curBlood < 0 ? 0 : curBlood; // 死亡判定
        UpdateBloodBar();
    }

    public void IncreaseBlood(int value)
    {
        curBlood += value;
        UpdateBloodBar();
    }

    private void InitBloodBar()
    {
        curBlood_CubeCount = Mathf.CeilToInt((float)curBlood / 2);
        Vector3 position = Vector3.zero;
        GameObject curSlot;
        for (int i = 0; i < curBlood_CubeCount; i++)
        {
            position.x = i;
            if (i == 0)
            {
                curSlot = Instantiate(redLeftSlot, bloodBar.transform, false);
                curSlot.transform.localPosition = position;
            }
            else if (i < curBlood_CubeCount - 1)
            {
                curSlot = Instantiate(redMidSlot, bloodBar.transform, false);
                curSlot.transform.localPosition = position;
            }
            else
            {
                curSlot = Instantiate(redRightSlot, bloodBar.transform, false);
                curSlot.transform.localPosition = position;
            }
            blood_CubeList.Add(curSlot);
        }
    }

    private void UpdateBloodBar()
    {
        foreach (GameObject curCube in blood_CubeList)
        {
            Destroy(curCube);
        }
        blood_CubeList.Clear();
        int curBlood_CubeCount = Mathf.CeilToInt((float)curBlood / 2);
        Vector3 position = Vector3.zero;
        GameObject curSlot;
        for (int i = 0; i < curBlood_CubeCount; i++)
        {
            position.x = i;
            if (i == 0)
            {
                curSlot = Instantiate(redLeftSlot, bloodBar.transform, false);
                curSlot.transform.localPosition = position;
            }
            else if (i < curBlood_CubeCount - 1)
            {
                curSlot = Instantiate(redMidSlot, bloodBar.transform, false);
                curSlot.transform.localPosition = position;
            }
            else
            {
                curSlot = Instantiate(redRightSlot, bloodBar.transform, false);
                curSlot.transform.localPosition = position;
            }
            blood_CubeList.Add(curSlot);
        }
    }

    public void ReduceResistance(int value)
    {
        curResistance -= value;
        curResistance = curResistance < 0 ? 0 : curResistance;
        UpdateResistanceBar();
    }

    public void IncreaseResistance(int value)
    {
        curResistance += value;
        curResistance = curResistance < maxResistance ? curResistance : maxResistance;
        UpdateResistanceBar();
    }

    private void InitResistanceBar()
    {
        curResistance_CubeCount = curResistance;
        Vector3 position = Vector3.zero;
        GameObject curSlot;
        for (int i = 0; i < curResistance_CubeCount; i++)
        {
            position.x = i;
            if (i == 0)
            {
                curSlot = Instantiate(blueLeftSlot, resistanceBar.transform, false);
                curSlot.transform.localPosition = position;
            }
            else if (i < curResistance_CubeCount - 1)
            {
                curSlot = Instantiate(blueMidSlot, resistanceBar.transform, false);
                curSlot.transform.localPosition = position;
            }
            else
            {
                curSlot = Instantiate(blueRightSlot, resistanceBar.transform, false);
                curSlot.transform.localPosition = position;
            }
            resistance_CubeList.Add(curSlot);
        }
    }

    private void UpdateResistanceBar()
    {
        foreach (GameObject curCube in resistance_CubeList)
        {
            Destroy(curCube);
        }
        resistance_CubeList.Clear();
        int curResistance_CubeCount = curResistance;
        Vector3 position = Vector3.zero;
        GameObject curSlot;
        for (int i = 0; i < curResistance_CubeCount; i++)
        {
            position.x = i;
            if (i == 0)
            {
                curSlot = Instantiate(blueLeftSlot, resistanceBar.transform, false);
                curSlot.transform.localPosition = position;
            }
            else if (i < curBlood_CubeCount - 1)
            {
                curSlot = Instantiate(blueMidSlot, resistanceBar.transform, false);
                curSlot.transform.localPosition = position;
            }
            else
            {
                curSlot = Instantiate(blueRightSlot, resistanceBar.transform, false);
                curSlot.transform.localPosition = position;
            }
            resistance_CubeList.Add(curSlot);
        }
    }

    public int Resist(int value)
    {
        return (int)(value * (1 - (float)curResistance * 0.1)); // 百分比减伤
        //return value - curResistance; // 直接减伤
    }
}
