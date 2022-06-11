using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : Interactable
{
    [SerializeField]
    GameObject myObj;
    public CoreBoolean core;

    float extra_score = 10;

    // Start is called before the first frame update
    protected override void Interact()
    {
       myObj.SetActive(true);
       core.IncreaseScore(extra_score);
       extra_score = 0;
    }
}
