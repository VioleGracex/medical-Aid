using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class SwitchCameras : MonoBehaviour
{
    Camera enabled_cam1;
    Camera disabled_cam2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SwapCamera()
    {
        enabled_cam1.enabled =! enabled_cam1.enabled;
        disabled_cam2.enabled =! disabled_cam2.enabled;
    }
}
