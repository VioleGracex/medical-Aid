using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Dialogue;
using TMPro;


public class Player_InputName_Enable : MonoBehaviour
{
    [SerializeField] 
    PlayerConversant DialogueHolder;
    [SerializeField] 
    GameObject Diary;
    [SerializeField] 
    GameObject chatbox;
    [SerializeField] 
    TMP_InputField nameInputField;
    [SerializeField] 
    GameObject IncorrectInput;
    [SerializeField] 
    string inputNodeName;
    string playerNameInput;

    bool playerNameTaken = false;

    [SerializeField]
    Rt other;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerNameTaken)
        {
           EnableDiary();
        }
        
    }

    private void EnableDiary()
    {
        if (DialogueHolder.GetCurrentNodeName() == "6fab836d-244e-4f2d-a07a-1fc6347732c4")
        {
            playerNameTaken = true;
            Diary.SetActive(true);
            chatbox.SetActive(false);
            DialogueHolder.Next();
        }
    }
    public void TakenName()
    {  

        if(nameInputField.text.Length <= 8 )
        {
            playerNameInput = nameInputField.text;
            if (PlayerPrefs.GetInt("Isloading") == 1)
            {
                PlayerPrefs.SetString("PlayerName"+'1',playerNameInput);
            }
            else if (PlayerPrefs.GetInt("Isloading") == 2)
            {
                PlayerPrefs.SetString("PlayerName"+'2',playerNameInput);
            }
             else if (PlayerPrefs.GetInt("Isloading") == 3)
            {
              PlayerPrefs.SetString("PlayerName"+'3',playerNameInput);
            }
            else
            {
                PlayerPrefs.SetString("PlayerName",playerNameInput);
            }
            
            Diary.SetActive(false);
            chatbox.SetActive(true);
            other.RevealAll();    
        }
        else
        {
            IncorrectInput.SetActive(true);
        }
        
    }
}
