using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOtherLists : MonoBehaviour
{
    [SerializeField] Transform disabledLists;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.childCount>1)
        {
            this.transform.GetChild(0).SetParent(disabledLists);
        }
        
    }
}
