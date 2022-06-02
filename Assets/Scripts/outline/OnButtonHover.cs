using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnButtonHover : MonoBehaviour ,IPointerEnterHandler
{
    Image buttonimg;
    // Start is called before the first frame update
    public void OnPointerEnter(PointerEventData eventData)
    {
       //EventSystem.current.SetSelectedGameObject(this.gameObject);
       buttonimg =this.GetComponent<Image>();
       Debug.Log(buttonimg.color);
       buttonimg.color = new Color(0.274f,0.934f,0,0.3f);
    }
}
