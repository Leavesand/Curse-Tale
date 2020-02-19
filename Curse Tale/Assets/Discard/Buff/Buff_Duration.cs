using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff_Duration : MonoBehaviour
{
    public int duration { get; private set; }

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
        duration--;
        if (duration <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void IncreaseDuration(int value)
    {
        duration += value;
    }
}
