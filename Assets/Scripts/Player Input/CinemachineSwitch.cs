using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public static class CinemachineSwitch 
{
    static List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();

    public static CinemachineVirtualCamera activeCam = null;

    public static bool isActiveCamera(CinemachineVirtualCamera camera)
    {
        return camera==activeCam;
    }

    public static void SwapCamera(CinemachineVirtualCamera camera)
    {
        camera.Priority=10;
        activeCam = camera;

        foreach(CinemachineVirtualCamera c in cameras)
        {
            if( c != camera && c.Priority != 0)
            {
                c.Priority=0;
            }
        }
    }

    public static void Register(CinemachineVirtualCamera camera)
    {
        cameras.Add(camera);  
        //Debug.Log("added",camera);
    }

    public static void UnRegister(CinemachineVirtualCamera camera)
    {
        cameras.Remove(camera);
        //Debug.Log("removed",camera);
    }

}
