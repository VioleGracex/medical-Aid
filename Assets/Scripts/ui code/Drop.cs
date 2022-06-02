using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour
{
     [SerializeField]
    List<GameObject> slots;
    Vector3 org_pos;

    public bool placed = false;
    public void DropHandler(BaseEventData data)
    {
        Debug.Log("first placed "+placed);
        foreach (GameObject s in slots) 
        {
             if(Mathf.Abs(this.transform.localPosition.x - s.transform.localPosition.x)<=0.5f &&
             Mathf.Abs(this.transform.localPosition.y - s.transform.localPosition.y)<=0.5f)
             {
                this.transform.localPosition = new Vector3(s.transform.localPosition.x, s.transform.localPosition.y, s.transform.localPosition.z);
                placed = true;
                break;
             }
        }
        if( placed == false)
        {
            this.transform.position = org_pos;
        }
       Debug.Log("2nd placed "+placed);
    }

    public void DisablePlaced()
    {
        placed=false;
    }
    // Start is called before the first frame update
    void Start()
    {
        org_pos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
