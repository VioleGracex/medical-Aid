using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class change_BG : MonoBehaviour
{
    public Sprite def_bg;
    public Sprite[] backgrounds;
    void ChangeBG(string bg)
    {
        foreach(Sprite i in backgrounds)
        {
            if (i.name == bg)
            {
                this.GetComponent<Image>().sprite = i;
            }
            else
            {
                this.GetComponent<Image>().sprite = def_bg;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
