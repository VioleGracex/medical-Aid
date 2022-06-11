using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SlotTracker : MonoBehaviour
{
    public CoreBoolean core;
    public List<bool> slotsTaken = new List<bool> (6);
    
    public List<GameObject> elipses;

    [SerializeField]
    public List<GameObject> slots;

    Dictionary<string,string> match_elipses = new Dictionary<string, string>();

    [SerializeField]
    TextMeshProUGUI  result_list;
    [SerializeField]
    string  result;

    public void ResetElipses()
    {
        foreach (GameObject e in elipses) 
        {
            e.transform.position = e.GetComponent<Drag>().org_pos;
        }
       for ( int i = 0 ; i <slotsTaken.Count;i++)
        {
            slotsTaken[i]=false;
        }
    }

    public void Check_Reservations()
    {
      for(int i = 0 ; i<slots.Count;i++)
      {
        for(int j = 0 ; j < elipses.Count;j++)
        {
            if(slots[i].transform.position.x == elipses[j].transform.position.x 
             && slots[i].transform.position.y == elipses[j].transform.position.y  )
             {
                slotsTaken[i]=true;
                break;
             }
             else
             {
                slotsTaken[i]=false;
             }
        }
      }
    }

    public void Apply_Reservations()
    {
        /* Debug.Log(slots.Count);
        Debug.Log(elipses.Count); */
       /*  for(int i = 0 ; i<5;i++)
        {
            Debug.Log("i = "+i);
            Debug.Log(elipses[i].name);
            Debug.Log(slots[i].name);

        } */
      for(int i = 0 ; i<6;i++)
      {
        for(int j = 0 ; j < 6;j++)
        {
            Debug.Log("here");
             if(slots[i].transform.position.x==elipses[j].transform.position.x 
             && slots[i].transform.position.y==elipses[j].transform.position.y  )
             {
                Debug.Log(elipses[j].name);
                Debug.Log(slots[i].name);
                /* if(!match_elipses.ContainsKey(elipses[j].name))
                {
                    match_elipses.Add(elipses[j].name,slots[i].name);
                } */
                match_elipses.Add(elipses[j].name,slots[i].name);
                Debug.Log("pls no");
                break;
             }
        }
      }

    //Debug.Log("LISTSTSTSATAS");
      foreach (var item in match_elipses)
      {
          //Debug.Log("REEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
        
        result_list.text += item.ToString()+ "\n";
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

    public void CheckECGResult()
    {
      string temp =  @"Result[red, slot 1]
[green, slot 2]
[black, slot 3]
[grinch, slot 4]
[blue, slot 5]
[purple, slot 6]
";
      result= result_list.text;
      if(result_list.text == temp)
      {
        core.IncreaseScore(10);
        
      }

    }
}
