using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutlineOnHover : MonoBehaviour
{
   
    Dictionary<string,GameObject> bodyparts = new Dictionary<string, GameObject>() ;
    [SerializeField]
    GameObject bodyList;

    GameObject activePart;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in bodyList.transform)
        {
            bodyparts.Add(child.name,child.gameObject);
        }  
    }

    // Update is called once per frame
    void Update()
    {
        
  
    }

    public void OutlineBodyPart(string partName)
    {
        
        GameObject temp = bodyparts[partName];

        if(activePart !=null)
        {
            activePart.GetComponent<Outline>().OutlineWidth=0f;
        }

        activePart = temp;

        if(temp.GetComponent<Outline>() !=null)
        {
            temp.GetComponent<Outline>().OutlineWidth=2f;
        }
        else
        {
            temp.AddComponent<Outline>();
            temp.GetComponent<Outline>().OutlineWidth=2f;
        }
        
    }

}
