using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

namespace RPG.Dialogue
{
    public class DialogueNode : ScriptableObject
    {
        #region 
        [SerializeField]
        private bool isPlayerSpeaking = false;
        [SerializeField]
        private bool isRootNode = false;
        [SerializeField]
        private string parentID;
        [SerializeField] 
        private string taskName;
        [SerializeField] 
        private string text;
        [SerializeField] 
        private AudioClip voiceLine;
        [SerializeField] 
        private AudioClip musicAudio;
        [SerializeField] 
        private List<string> children = new List<string>();
        [SerializeField] 
        private Rect pos = new Rect (0, 0, 200, 200);
        [SerializeField]
        private int nodeNumber;
        [SerializeField]
        private string dependantBool;

        [SerializeField]
        private int nodeIndexPosition = 0;
        [SerializeField]
        private bool taskCheck = false;

        
    #endregion


        public Rect GetPos()
        {
            return pos;
        }

        public string GetText()
        {
            return text;
        }

        public string GetParentName()
        {
            return parentID;
        }

        public string GetName()
        {
            return name;
        }

        public string GetTaskName()
        {
            return taskName;
        }

        public List<string> GetChildren()
        {
            return children;
        }

        //changed that into string
        public AudioClip GetVLName()
        {
            return voiceLine;
        }
        public AudioClip GetMusicName()
        {
            return voiceLine;
        }

        public bool IsPlayerSpeaking()
        {
            return isPlayerSpeaking;
        }

        public bool IsRootNode()
        {
            return isRootNode;
        }
    
        public int GetNodeNumber()
        {
            return nodeNumber;
        }
        public int GetIndexPosition()
        {
            return nodeIndexPosition;
        }
        public bool GetBool()
        {
            return taskCheck;
        }
        public string GetDependantBooleanName()
        {
            return dependantBool;
        }


        
#if UNITY_EDITOR
        public void SetPos(Vector2 newPosition)
        {
            Undo.RecordObject(this ,"Move Dialogue");
            pos.position = newPosition;
            EditorUtility.SetDirty(this);
        }

        public void SetParentName(string newParentID)
        {          
            Undo.RecordObject(this ,"Set Parent Name");
            parentID = newParentID;        
            EditorUtility.SetDirty(this);
        }


        public void SetTaskName(string newSpeaker)
        {
            if(newSpeaker != taskName)
            {
                Undo.RecordObject(this ,"Set taskName");
                taskName = newSpeaker;
                EditorUtility.SetDirty(this);
            }               
        }

        public void SetText(string newText)
        {
            if(newText != text)
            {
                Undo.RecordObject(this, "Update Dialogue Text");
                text = newText;
                EditorUtility.SetDirty(this);
            }         
        }


        public void AddChild(string childID)
        {
            Undo.RecordObject(this, "Add Dialogue Link");
            children.Add(childID);
            EditorUtility.SetDirty(this);
        }

        public void RemoveChild(string childID)
        {
            Undo.RecordObject(this, "Remove Dialogue Link");
            children.Remove(childID);
            EditorUtility.SetDirty(this);
        }

         public void SetRootNode(bool rootvalue)
        {
            isRootNode = rootvalue;
            EditorUtility.SetDirty(this);   
        }
        public void SetNodeNumber(int prevNum)
        {
            nodeNumber = prevNum;
            EditorUtility.SetDirty(this);
        }
        public void SetIndexPosition(int newIndex)
        {
                Undo.RecordObject(this, "Update index pos");
                nodeIndexPosition = newIndex;
                EditorUtility.SetDirty(this);        
        }
        
        public void SetDependantBoolName(string name)
        {
            dependantBool = name;
        }

        public void SetDependantBoolValue(bool v)
        {
            taskCheck=v;
        }
        

       
#endif

    }
}
