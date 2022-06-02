using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;

namespace RPG.Dialogue
{
    [CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue", order = 0)]
    public class Dialogue : ScriptableObject,ISerializationCallbackReceiver
    {
        [SerializeField]
        List<DialogueNode> nodes = new List<DialogueNode>();
        [SerializeField]
        public int canvasHeight = 4000;
        [SerializeField]
        public int canvasWidth = 4000;

        [SerializeField]
        Vector2 newNodeOffset = new Vector2(250, 0);

        Dictionary<string, DialogueNode> nodeLookup = new Dictionary<string, DialogueNode>();

        private void OnValidate()
        {
            nodeLookup.Clear();
            foreach(DialogueNode node in GetAllNodes())
            {
                nodeLookup[node.name] = node;
            }
        }

        void Awake()
        {
            OnValidate();
        }

        public IEnumerable<DialogueNode> GetAllNodes()
        {
            return nodes;
        }

        public DialogueNode GetRootNode()
        {
            return nodes[0];
        }

        public DialogueNode GetSavedNode( string savedNodeName)
        {
            return  nodeLookup[savedNodeName] ;
        } 

        public IEnumerable<DialogueNode> GetAllChildren(DialogueNode parentNode)
        {
            foreach(string ChildID in parentNode.GetChildren())
            {
                if(nodeLookup.ContainsKey(ChildID))
                {
                  yield return(nodeLookup[ChildID]);
                }
                  
            }         
        }
#if UNITY_EDITOR
        public void CreateNode(DialogueNode parent)
        {
            DialogueNode newNode = MakeNode(parent);
            Undo.RegisterCreatedObjectUndo(newNode, "Created Dialogue Node");
            Undo.RecordObject(this, "Added Dialogue Node");
            AddNode(newNode);
        }

        public void DeleteNode(DialogueNode nodeToDelete)
        {
            Undo.RecordObject(this ,"Deleted Dialogue Node");
            nodes.Remove(nodeToDelete);          
            OnValidate();
            ClearConnectedChildren(nodeToDelete);
            if(nodeToDelete.IsRootNode())
                {
                    if(nodeToDelete.GetChildren().Count != 0 )
                    {
                        DialogueNode[] children = GetAllChildren(nodeToDelete).ToArray(); 
                        children[0].SetRootNode(true);
                        children[0].SetNodeNumber(children[0].GetNodeNumber()-1);       
                    }
                }
            foreach (DialogueNode node in GetAllNodes())
            {
                node.SetParentName(null);        
            }
            Undo.DestroyObjectImmediate(nodeToDelete);
        }

        private void ClearConnectedChildren(DialogueNode nodeToDelete)
        {
            foreach (DialogueNode node in GetAllNodes())
            {
                node.RemoveChild(nodeToDelete.name);
                nodeToDelete.SetParentName(null);
            }
        }

        private  DialogueNode MakeNode(DialogueNode parent )
        {
            DialogueNode newNode = CreateInstance<DialogueNode>();
            newNode.name = Guid.NewGuid().ToString();

            if (parent != null)
            {
                parent.AddChild(newNode.name);
                newNode.SetParentName(parent.name);
                newNode.SetPos(parent.GetPos().position + newNodeOffset);
                newNode.SetNodeNumber(parent.GetNodeNumber()+1);
            }

            return newNode;
        }

        private void AddNode(DialogueNode newNode)
        {
            nodes.Add(newNode);
            OnValidate();
        }

#endif
        public void OnBeforeSerialize()
        {
#if UNITY_EDITOR
             if(nodes.Count == 0)
            {
                DialogueNode newNode = MakeNode(null);
                newNode.SetNodeNumber(0);
                newNode.SetRootNode(true);
                AddNode(newNode);
            }
            if(AssetDatabase.GetAssetPath(this) != "")
            {
                foreach (DialogueNode node in GetAllNodes())
                {
                    if(AssetDatabase.GetAssetPath(node) == "")
                    {
                        AssetDatabase.AddObjectToAsset(node, this);   
                    }
                    
                }
            }
#endif
        }

        public void OnAfterDeserialize()
        {
        }
 }
}