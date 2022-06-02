using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_function : Interactable
{
    [SerializeField]
    string myObj;

    [SerializeField]
    CoreBoolean handler;
     void Start()
    {
        handler = GameObject.FindGameObjectWithTag("Core").GetComponent<CoreBoolean>();
    }
    protected override void Interact()
    {
       handler.EnableThisBool(myObj,null);
    }
}
