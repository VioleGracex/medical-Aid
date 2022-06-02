using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskTracker : MonoBehaviour
{
    [SerializeField]
    CoreBoolean handler;

    public void FinishedATask(string taskName)
    {
        handler.EnableThisBool(taskName, "");
    }
    public void FailedATask(string taskName)
    {
        handler.DisableThisBool(taskName);
    }
    // Start is called before the first frame update
    void Start()
    {
        handler = GameObject.FindGameObjectWithTag("Core").GetComponent<CoreBoolean>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
