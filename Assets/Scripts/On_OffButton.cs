using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On_OffButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ONOFF()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }
}
