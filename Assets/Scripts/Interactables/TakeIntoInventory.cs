using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeIntoInventory : Interactable
{
    [SerializeField]
    string myObj;
    [SerializeField]
    string grabbedObj="";
    [SerializeField]
    CoreBoolean handler;
    // Start is called before the first frame update
     void Start()
    {
        handler = GameObject.FindGameObjectWithTag("Core").GetComponent<CoreBoolean>();
    }
    protected override void Interact()
    {
       handler.EnableThisBool(myObj,grabbedObj);
    }
}
