using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YiXuanZhuFuController : MonoBehaviour
{
    Text description;
    int childCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        description = this.transform.Find("FloatingCanvas").Find("Description").GetComponent<Text>();
        description.text = childCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (childCount != transform.childCount - 1)
        {
            childCount = transform.childCount - 1;
            description.text = childCount.ToString();
        }
    }

    private void OnMouseUpAsButton()
    {
        if (childCount > 0)
        {
            Destroy(transform.GetChild(1).gameObject);
        }
    }
}
