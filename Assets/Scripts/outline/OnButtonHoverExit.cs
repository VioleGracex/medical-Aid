using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class OnButtonHoverExit : MonoBehaviour, IPointerExitHandler // required interface when using the OnPointerExit method.
{
	Image buttonimg;

	bool toggle;
	//Do this when the cursor exits the rect area of this selectable UI object.
	public void OnPointerExit (PointerEventData eventData) 
	{
		Debug.Log(EventSystem.current.name);
	    if(EventSystem.current != this.gameObject)
        {
            //EventSystem.current.SetSelectedGameObject(null);
            buttonimg =this.GetComponent<Image>();
            buttonimg.color = new Color(0,0,0,0);
            Debug.Log("exit");
        }
	}
}