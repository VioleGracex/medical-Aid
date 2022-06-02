using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    CinemachineVirtualCamera playerCamera;
    [SerializeField] 
    private float distance = 3f;
    [SerializeField] 
    LayerMask mask;
    [SerializeField] 
    GameObject crosshair;

    private PlayerInput playerInput;

    private GameObject lastOutlined;

    //Interactable interactable;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(CinemachineSwitch.activeCam == playerCamera )
        {
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);
            Debug.DrawRay(ray.origin,ray.direction * distance);
            RaycastHit hitInfo;
            if(Physics.Raycast(ray, out hitInfo,distance,mask))
            {
                crosshair.GetComponent<Image>().color = Color.red;
                if(hitInfo.collider.GetComponent<Interactable>() != null)
                {
                    if(lastOutlined!=null)
                    {
                        //lastOutlined.GetComponent<Outline>().OutlineMode = Outline.Mode.SilhouetteOnly;
                        lastOutlined.GetComponent<Outline>().OutlineWidth = 0f;
                    }
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                if(interactable.GetComponent<Outline>())
                {
                    interactable.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineAll;
                    interactable.GetComponent<Outline>().OutlineWidth = 2f;
                    lastOutlined=interactable.gameObject;
                }
                //Debug.Log(interactable.promptMessage);
                }
            }
            else
            {
                crosshair.GetComponent<Image>().color = Color.white;
                if(lastOutlined!=null)
                {
                    lastOutlined.GetComponent<Outline>().OutlineWidth = 0f;
                }
                
            }
        }
        else
        {
            crosshair.GetComponent<Image>().color = Color.white;
            if(lastOutlined!=null)
            {
                lastOutlined.GetComponent<Outline>().OutlineWidth = 0f;
            }
            
        }
       

    }

    public void ProcessInteract()
    {
         Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin,ray.direction * distance);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo,distance,mask))
        {
            crosshair.GetComponent<Image>().color = Color.red;
            if(hitInfo.collider.GetComponent<Interactable>() != null)
            {
               Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
               //lastOutlined.GetComponent<Outline>().OutlineMode = Outline.Mode.SilhouetteOnly;
               lastOutlined.GetComponent<Outline>().OutlineWidth = 0f;
               interactable.BaseInteract();
            }
        }
        
    }
}
