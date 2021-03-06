using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using RPG.Dialogue;

public class CoreBoolean : MonoBehaviour
{
    public Dictionary<string,bool> dependantBools = new Dictionary<string, bool> {{"HasGlovesOn",false},{"HasGloves",false},{"HasAmbubag",false}};
    public Dictionary<string,bool> currentTasks = new Dictionary<string, bool> {{"CheckedConsciousness",false},{"CheckedCavity",false},{"CheckedHeartRate",false},{"CheckedAirway",false}};
    //fill it with nodes

    [SerializeField] 
    List<GameObject> status;
    
    [SerializeField] 
    Sprite glovesONIMG;

    [SerializeField] 
    TextMeshProUGUI inventoryList;

    [SerializeField] 
    RPG.UI.DialogueUI uiHandler;
    
    [SerializeField] 
    float score = 0;
    [SerializeField] 
    float questionsCount = 0;

    [SerializeField] 
    SlotTracker tracker;

    [SerializeField]
    TextMeshProUGUI  end_result;
    private Dictionary<string,int> inventory =new Dictionary<string, int>();

    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(score);
    }

    private void RefreshInvText()
    {
        inventoryList.text="";
        foreach (var item in inventory)
        {
            inventoryList.text += item.ToString()+ "\n";
        }
    }

    public void ProcessGloves()
    {
        if( dependantBools["HasGloves"] == true)
        {
            EnableThisBool("glovesOn","");
            
            if(status[0].GetComponent<Image>().sprite != glovesONIMG )
            {
                status[0].GetComponent<Image>().sprite= glovesONIMG;
                IncreaseScore(10);
            }
        }
      
    }

    public void EnableThisBool(string enabledBool,string itemName)
    {
        dependantBools[enabledBool] = true;
        uiHandler.Next(enabledBool);
        
        
        if(itemName != string.Empty)
        {
            if(inventory.ContainsKey(itemName))
            {
                inventory[itemName]+=1;
            }
            else
            {
                inventory.Add(itemName,1);
            }
            RefreshInvText();
        }

    }
    public void EnableThisBoolonly(string enabledBool)
    {
        dependantBools[enabledBool] = true;
        uiHandler.Next(enabledBool);

    }
    public void DisableThisBool(string disabledBool)
    {
        dependantBools[disabledBool]=false;
        //check for failure
    }
    public bool ValueThisBool(string name)
    {
        return dependantBools[name];
    }

    public void AddToInventory(string itemName)
    {
        if(inventory.ContainsKey(itemName))
        {
           inventory[itemName]+=1;
        }
        else
        {
            inventory.Add(itemName,1);
        }
        RefreshInvText();
    }

    public void RemoveToInventory(string itemName)
    {
        if( inventory[itemName] > 1)
        {
            inventory[itemName] -= 1;
        }
        else
        {
            inventory.Remove(itemName);
        }
    
        RefreshInvText();
    }

    public void IncreaseScore(float points)
    {
        Debug.Log(score);
        score+=points;
        //questionsCount+=1;
    }

    public void EndExam()
    {
        //Debug.Log(score);
        float endScore=Mathf.CeilToInt((score/15)*10);
        end_result.text = string.Format("???????????? {0} %, ", endScore);
        //end_result.text = string.Format("\n questionscount {0} \n, ",(questionsCount));
        Time.timeScale=0f;
    }
    public void IsTaskFinished()
    {
       
    }

}