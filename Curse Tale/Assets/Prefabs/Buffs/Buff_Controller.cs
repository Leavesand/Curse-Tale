using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff_Controller : MonoBehaviour
{
    public int duration;
    public int value;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CalDuration()
    {
        if (duration > 0)
        {
            duration--;
        }
        if (duration == 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void IncreaseDuration(int value)
    {
        duration += value;
    }

    public void ReduceDuration(int value)
    {
        duration -= value;
        if (duration <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
