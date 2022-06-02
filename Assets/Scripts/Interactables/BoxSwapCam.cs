using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;


public class BoxSwapCam : Interactable
{
    [SerializeField]
    CinemachineVirtualCamera playerCamera;
   
    [SerializeField]
    CinemachineVirtualCamera playerFrozenCamera;

    [SerializeField]
    CinemachineVirtualCamera newCamera;
    
    

    [SerializeField]
    Canvas canvas1;
    [SerializeField]
    Canvas canvas2;
  
   
    protected override void Interact()
    {
        if(CinemachineSwitch.activeCam != newCamera || CinemachineSwitch.activeCam == null)
        {
            CinemachineSwitch.SwapCamera(newCamera);
            canvas1.gameObject.SetActive(!canvas1.gameObject.activeSelf);
        }
        else if(Cursor.visible)
        {
            CinemachineSwitch.SwapCamera(playerFrozenCamera);
            canvas1.gameObject.SetActive(!canvas1.gameObject.activeSelf);
        }
        else
        {
            CinemachineSwitch.SwapCamera(playerCamera);
            canvas1.gameObject.SetActive(!canvas1.gameObject.activeSelf);
        } 
        
        canvas2.gameObject.SetActive(!canvas2.gameObject.activeSelf);
    }

    public void TurnCursor()
    {
        MouseLock.ToggleMouse();
    }
}
