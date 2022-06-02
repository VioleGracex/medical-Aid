using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class HighLightButton : MonoBehaviour ,IPointerEnterHandler,IPointerExitHandler
{
    // Start is called before the first frame update
    private bool click;
    public void OnPointerEnter(PointerEventData eventData)
     { 
        this.gameObject.GetComponent<Image>().color = Color.blue;
     }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(!click)
        {   
            this.gameObject.GetComponent<Image>().color = Color.white;
            var col = Color.white;
            col.a = 0f;
            this.gameObject.GetComponent<Image>().color=col;
        }   
    }


    public void ClickedTheButton()
    { 
        click=true;
        this.gameObject.GetComponent<Image>().color = Color.black;
    }
    // Start is called before the first frame update
    void Update()
    {
        
    }
}
