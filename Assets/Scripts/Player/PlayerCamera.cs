using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] 
    CoreBoolean core;
    public Camera cam;
    private float xRotation = 0f;
    public float distance_rotated = 0f;
    float temp = 0f;

    public float xSens = 30f;
    public float ySens = 30f;

    [SerializeField]
    float rotationSpeed = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }
   public void ProcessLook(Vector2 input)
   {
       if(!Cursor.visible)
        {
            Quaternion targetRotation = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0);   
            if(Mathf.Abs(transform.rotation.y - targetRotation.y)>1f)
            {
                   distance_rotated+= targetRotation.y* rotationSpeed * Time.deltaTime*2;
            }
            if(distance_rotated>180)
            {
               core.EnableThisBool("lookedAround","");
            }
        
           
            transform.rotation = Quaternion.Lerp(transform.rotation,targetRotation, rotationSpeed * Time.deltaTime);
             Debug.Log("rotate"+transform.rotation.y);
            Debug.Log("distance_rotated"+targetRotation.y);
            Debug.Log(Mathf.Abs(transform.rotation.y - targetRotation.y));
            Debug.Log(distance_rotated);
        }
   }
}
