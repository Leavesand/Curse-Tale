using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Affliction_Controller : MonoBehaviour
{
    public bool Yan;
    public bool Shen;
    public bool Xue;
    public bool Qu;
    public int level;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseLevel(int value)
    {
        level += value;
    }

    public void ReduceLevel(int value)
    {
        level -= value;
        if (level <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
