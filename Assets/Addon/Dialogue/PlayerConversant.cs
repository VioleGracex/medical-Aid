using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

namespace RPG.Dialogue
{
    public class PlayerConversant : MonoBehaviour
    {
        [SerializeField] public Dialogue currentDialogue;
        public DialogueNode currentNode = null;

        bool iSChoosing = false;

        [SerializeField]
        GameObject endMenu;

        [SerializeField]
        AudioSource BGMPlayer;
        [SerializeField] AudioSource VFXPlayer;
        [SerializeField] AudioMixerGroup voiceLinesMixer;

        [SerializeField]
        Animator transition;
        GameObject audioValues;
        //nova was here
        // [SerializeField] float soundPlayerVolume = 0.2f;

        public void Awake()
        {
            currentNode = currentDialogue.GetRootNode();
        }


        public void SaveNode()
        {
            PlayerPrefs.SetString("SavedPosition", currentNode.GetName());
            Scene activeScene = SceneManager.GetActiveScene();
            PlayerPrefs.SetInt("LevelNumber", activeScene.buildIndex);
            PlayerPrefs.SetInt("SaveSlot", 1);
            //PlayerPrefs.Save();
        }
        public void LoadSaveNode()
        {
            PlayerPrefs.SetInt("Isloading", 1);
            SceneManager.LoadScene(PlayerPrefs.GetInt("LevelNumber", 0));
            currentNode = currentDialogue.GetSavedNode(PlayerPrefs.GetString("SavedPosition", "none"));
        }

        public bool ISChoosing()
        {
            return iSChoosing;
        }

        public string GetText()
        {
            if (currentNode == null)
            {
                return "";
            }
            return currentNode.GetText();
        }
        public string GetCurrentNodeName()
        {
            return currentNode.GetName();
        }

        public string GetBoolName()
        {
            return currentNode.GetDependantBooleanName();
        }


        public void PlayVoiceLine()
        {
            if (currentNode.GetVLName() != null)
            {
                VFXPlayer.outputAudioMixerGroup = voiceLinesMixer;
                VFXPlayer.PlayOneShot(currentNode.GetVLName());
            }
        }

        public IEnumerable<DialogueNode> GetChoices()
        {
            //BGM.volume = 0.0f;
            //see conditional affinity here
            foreach (DialogueNode node in currentDialogue.GetAllChildren(currentNode))
            {
               yield return node;
            }
        }

        public void SelectChoice(DialogueNode chosenNode)
        {
            //here dont fix audio this is shit nova removed it
            //BGM.volume = PlayerPrefs.GetFloat("BGMVolume", 0.2f);
            currentNode = chosenNode;
            iSChoosing = false;
            Next();
        }

        public string GetTaskName()
        {
            if (currentDialogue == null)
            {
                return "";
            }
            return currentNode.GetTaskName();
        }


        public void SetTransitionOff()
        {
            transition.gameObject.SetActive(false);
        }

        public void Next()
        {
            if (this.HasNext())
            {
                DialogueNode[] children = currentDialogue.GetAllChildren(currentNode).ToArray();
                if (children.Count() > 1)
                {
                    iSChoosing = true;
                    return;
                }
                currentNode = children[0];
                VFXPlayer.Stop();
            }
            else
            {
                //chapter ends here
                //endMenu.SetActive(true);
                //loading screen
                //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

        public bool HasNext()
        {
            return currentDialogue.GetAllChildren(currentNode).Count() > 0;
        }

    }
}