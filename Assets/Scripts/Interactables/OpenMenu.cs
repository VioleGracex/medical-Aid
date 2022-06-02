using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : Interactable
{
    [SerializeField]
    GameObject myObj;

    // Start is called before the first frame update
    protected override void Interact()
    {
       myObj.SetActive(true);
    }
}
