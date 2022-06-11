using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;

    List<GameObject> slots;
    public Vector3 org_pos;

    [SerializeField]
    SlotTracker slots_handler;
    bool placed = false;

    public void DragHandler(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;

        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform,
            pointerData.position,
            canvas.worldCamera,
            out position);
            transform.position = canvas.transform.TransformPoint(position);
            placed = false;
    }

    public void DropHandler(BaseEventData data)
    {
        Debug.Log("first placed "+placed);
        int counter = 0;
        foreach (GameObject s in slots) 
        {
            float distance = Vector3.Distance (this.transform.position, s.transform.position);
            Debug.Log(distance);
             if(distance<=0.006f && slots_handler.slotsTaken[counter] !=true )
             {
                   //Debug.Log("jajajajjaja");
                this.transform.position = new Vector3(s.transform.position.x, s.transform.position.y, s.transform.position.z);
               // slots_handler.slotsTaken[counter] = true;
                placed = true;
                //break;
             }
             counter++;
        }


        if( placed == false)
        {
            this.transform.position = org_pos;
        }
       Debug.Log("2nd placed "+placed);
       slots_handler.Check_Reservations();
    }
    // Start is called before the first frame update
    void Start()
    {
        org_pos = this.transform.position;
        slots = slots_handler.slots;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
