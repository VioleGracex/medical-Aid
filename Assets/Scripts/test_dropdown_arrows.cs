using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.UI;

public class test_dropdown_arrows : MonoBehaviour
{
    public Dropdown dropdown;
    [SerializeField] RectTransform rectTransform;

    //bool isFocused = false;



    // Start is called before the first frame update
    void Start()
    {
       dropdown = this.GetComponent<Dropdown>();
    }

    // Update is called once per frame
    void Update()
    { 
        if(gameObject == EventSystem.current.currentSelectedGameObject) 
        {
            Debug.Log(" we're selected! " );
        }
        else
        { 
            
        }
       
    }
}
