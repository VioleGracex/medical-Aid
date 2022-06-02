using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using RPG.Dialogue;
using TMPro;

namespace RPG.UI
{
    public class DialogueUI : MonoBehaviour
    {
        [SerializeField]
        PlayerConversant DialogueHolder;
        [SerializeField]
        GameObject chatboxHolder;
        [SerializeField]
        TextMeshProUGUI taskBox;
        [SerializeField]
        public TextMeshProUGUI chatbox;
      
        [SerializeField]
        Transform choiceRoot;
        [SerializeField]
        GameObject choicePrefab;
        [SerializeField]
        Rt other;
        [SerializeField]
        GameObject chatLogPrefab;
        [SerializeField]
        GameObject logPage;


        void Start()
        {
            UpdateUI();
        }

        void Update()
        {
      
        }

        public void Next(string enabledBool)
        {
            if(enabledBool == DialogueHolder.GetBoolName())
            {
                if (other.Cr())
                {
                    other.RevealAll();
                }
                else
                {
                    DialogueHolder.Next();
                    UpdateUI();
                }      
            }
            else
            {
                Debug.Log("not my bool");
            }
        }

        public void UpdateUI()
        {

            //sepreate choice and updating texts don't update them if you chooosing they stay the same
            //nextButton.gameObject.SetActive(DialogueHolder.HasNext());
           // choiceRoot.gameObject.SetActive(DialogueHolder.ISChoosing());

           taskBox.text=DialogueHolder.GetTaskName();
           chatbox.text =DialogueHolder.GetText();

            if (DialogueHolder.ISChoosing())
            {
                BuildChoiceList();
            }
            else
            {
                if (DialogueHolder.GetText() != "")
                {
                    chatboxHolder.gameObject.SetActive(true);
                    chatbox.text = DialogueHolder.GetText();
                }
            
                DialogueHolder.PlayVoiceLine();
                
            }
        }

        private void BuildChoiceList()
        {
            foreach (Transform item in choiceRoot)
            {
                Destroy(item.gameObject);
            }
            foreach (DialogueNode choice in DialogueHolder.GetChoices())
            {
                GameObject choiceInstance = GameObject.Instantiate(choicePrefab, choiceRoot);
                choiceInstance.GetComponentInChildren<TextMeshProUGUI>().text = choice.GetText();
                Button button = choiceInstance.GetComponentInChildren<Button>();
                button.onClick.AddListener(() =>
                {
                    DialogueHolder.SelectChoice(choice);
                    UpdateUI();
                });
            }
        }

        void PutLogs(string s, string t)
        {
            GameObject temp = Instantiate(chatLogPrefab, transform.position, transform.rotation);
            temp.transform.SetParent(logPage.transform);
            GameObject Speaker = temp.transform.GetChild(0).gameObject;
            Speaker.GetComponent<TextMeshProUGUI>().text = s;
            GameObject chatText = temp.transform.GetChild(1).gameObject;
            chatText.GetComponent<TextMeshProUGUI>().text = t;
        }
    }
}
