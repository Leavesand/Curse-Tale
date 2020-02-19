using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientController : MonoBehaviour
{
    public GameObject redLeftSlot;
    public GameObject redMidSlot;
    public GameObject redRightSlot;
    public GameObject greedLeftSlot;
    public GameObject greedMidSlot;
    public GameObject greedRightSlot;
    public GameObject blueLeftSlot;
    public GameObject blueMidSlot;
    public GameObject blueRightSlot;
    Transform buffSlot;
    Transform afflictionSlot;

    GameObject bloodBar;
    GameObject sanityBar;
    GameObject blessingBar;

    public int curBlood { get; private set; }
    public int maxBlood { get; private set; }
    public int curSanity { get; private set; }
    public int maxSanity { get; private set; }
    public int curBlessing { get; private set; }
    public int maxBlessing { get; private set; }

    public int initCurBlood = 18;
    public int initMaxBlood = 20;
    public int initCurSanity = 16;
    public int initMaxSanity = 20;
    public int initCurBlessing = 3;
    public int initMaxBlessing = 10;

    int maxBlood_CubeCount;
    int maxSanity_CubeCount;
    int maxBlessing_CubeCount = 10;

    List<GameObject> blood_CubeList = new List<GameObject>();
    List<GameObject> sanity_CubeList = new List<GameObject>();
    List<GameObject> blessing_CubeList = new List<GameObject>();
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
        curBlood = initCurBlood;
        maxBlood = initMaxBlood;
        bloodBar = this.transform.Find("Patient_StatusBar").Find("BloodBar").gameObject;
        InitBloodBar();
        UpdateBloodBar();

        curSanity = initCurSanity;
        maxSanity = initMaxSanity;
        sanityBar = this.transform.Find("Patient_StatusBar").Find("SanityBar").gameObject;
        InitSanityBar();
        UpdateSanityBar();

        curBlessing = initCurBlessing;
        maxBlessing = initMaxBlessing;
        blessingBar = this.transform.Find("Patient_StatusBar").Find("BlessingBar").gameObject;
        InitBlessingBar();
        UpdateBlessingBar();
        
        buffSlot = this.transform.Find("Patient_StatusBar").Find("BuffSlot");
        afflictionSlot = this.transform.Find("AfflictionSlot");
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
                // buff 持续时间叠加
                curBuff.GetComponent<Buff_Controller>().IncreaseDuration(buff.GetComponent<Buff_Controller>().duration);
                return;
            }
        }
        GameObject insBuff = Instantiate(buff, buffSlot, false);
        Vector3 newPosition = insBuff.transform.localPosition;
        newPosition.x += buffSlot.childCount * 0.5f;
        insBuff.transform.localPosition = newPosition;
    }

    public void AddAffliction(GameObject affliction)
    {
        foreach (Transform curAffliction in afflictionSlot)
        {
            if (affliction.name + "(Clone)" == curAffliction.name)
            {
                curAffliction.GetComponent<Affliction_Controller>().IncreaseLevel(affliction.GetComponent<Affliction_Controller>().level);
                return;
            }
        }
        GameObject insAffliction = Instantiate(affliction, afflictionSlot, false);
    }

    public void ReduceBlood(int value)
    {
        curBlood -= value;
        curBlood = curBlood < 0 ? 0 : curBlood;
        UpdateBloodBar();
    }

    public void IncreaseBlood(int value)
    {
        curBlood += value;
        curBlood = curBlood > maxBlood ? maxBlood : curBlood;
        UpdateBloodBar();
    }

    private void InitBloodBar()
    {
        maxBlood_CubeCount = Mathf.CeilToInt((float)maxBlood / 2);
        Vector3 position = Vector3.zero;
        GameObject curSlot;
        for (int i = 0; i < maxBlood_CubeCount; i++)
        {
            position.x = i;
            if (i == 0)
            {
                curSlot = Instantiate(redLeftSlot, bloodBar.transform, false);
                curSlot.transform.localPosition = position;
            }
            else if (i < maxBlood_CubeCount - 1)
            {
                curSlot = Instantiate(redMidSlot, bloodBar.transform, false);
                curSlot.transform.localPosition = position;
            }
            else
            {
                curSlot = Instantiate(redRightSlot, bloodBar.transform, false);
                curSlot.transform.localPosition = position;
            }
            blood_CubeList.Add(curSlot.transform.Find("RedCube").gameObject);
        }
    }

    private void UpdateBloodBar()
    {
        int curBlood_CubeCount = Mathf.CeilToInt((float)curBlood / 2);
        for (int i = 0; i < curBlood_CubeCount; i++)
        {
            if (!blood_CubeList[i].activeSelf)
            {
                blood_CubeList[i].SetActive(true);
            }
        }
        for (int i = curBlood_CubeCount; i < maxBlood_CubeCount; i++)
        {
            if (blood_CubeList[i].activeSelf)
            {
                blood_CubeList[i].SetActive(false);
            }
        }        
    }

    public void ReduceSanity(int value)
    {
        curSanity -= value;
        curSanity = curSanity < 0 ? 0 : curSanity;
        UpdateSanityBar();
    }

    public void IncreaseSanity(int value)
    {
        curSanity += value;
        curSanity = curSanity > maxSanity ? maxSanity : curSanity;
        UpdateSanityBar();
    }

    private void InitSanityBar()
    {
        maxSanity_CubeCount = Mathf.CeilToInt((float)maxSanity / 2);
        Vector3 position = Vector3.zero;
        GameObject curSlot;
        for (int i = 0; i < maxSanity_CubeCount; i++)
        {
            position.x = i;
            if (i == 0)
            {
                curSlot = Instantiate(greedLeftSlot, sanityBar.transform, false);
                curSlot.transform.localPosition = position;
            }
            else if (i < maxSanity_CubeCount - 1)
            {
                curSlot = Instantiate(greedMidSlot, sanityBar.transform, false);
                curSlot.transform.localPosition = position;
            }
            else
            {
                curSlot = Instantiate(greedRightSlot, sanityBar.transform, false);
                curSlot.transform.localPosition = position;
            }
            sanity_CubeList.Add(curSlot.transform.Find("GreenCube").gameObject);
        }
    }

    private void UpdateSanityBar()
    {
        int curSanity_CubeCount = Mathf.CeilToInt((float)curSanity / 2);
        for (int i = 0; i < curSanity_CubeCount; i++)
        {
            if (!sanity_CubeList[i].activeSelf)
            {
                sanity_CubeList[i].SetActive(true);
            }
        }
        for (int i = curSanity_CubeCount; i < maxSanity_CubeCount; i++)
        {
            if (sanity_CubeList[i].activeSelf)
            {
                sanity_CubeList[i].SetActive(false);
            }
        }
    }

    public void ReduceBlessing(int value)
    {
        curBlessing -= value;
        curBlessing = curBlessing < 0 ? 0 : curBlessing;
        UpdateBlessingBar();
    }

    public void IncreaseBlessing(int value)
    {
        curBlessing += value;
        curBlessing = curBlessing > maxBlessing ? maxBlessing : curBlessing;
        UpdateBlessingBar();
    }

    private void InitBlessingBar()
    {
        maxBlessing_CubeCount = maxBlessing;
        Vector3 position = Vector3.zero;
        GameObject curSlot;
        for (int i = 0; i < maxBlessing_CubeCount; i++)
        {
            position.x = i;
            if (i == 0)
            {
                curSlot = Instantiate(blueLeftSlot, blessingBar.transform, false);
                curSlot.transform.localPosition = position;
            }
            else if (i < maxBlessing_CubeCount - 1)
            {
                curSlot = Instantiate(blueMidSlot, blessingBar.transform, false);
                curSlot.transform.localPosition = position;
            }
            else
            {
                curSlot = Instantiate(blueRightSlot, blessingBar.transform, false);
                curSlot.transform.localPosition = position;
            }
            blessing_CubeList.Add(curSlot.transform.Find("BlueCube").gameObject);
        }
    }

    private void UpdateBlessingBar()
    {
        int curBlessing_CubeCount = curBlessing;
        for (int i = 0; i < curBlessing_CubeCount; i++)
        {
            if (!blessing_CubeList[i].activeSelf)
            {
                blessing_CubeList[i].SetActive(true);
            }
        }
        for (int i = curBlessing_CubeCount; i < maxBlessing_CubeCount; i++)
        {
            if (blessing_CubeList[i].activeSelf)
            {
                blessing_CubeList[i].SetActive(false);
            }
        }
    }

    public int BlessingResist(int value)
    {
        return  (int)(value * (1 - (float)curBlessing * 0.1)); // 百分比减伤
        //return value - curBlessing; // 直接减伤
    }

}
