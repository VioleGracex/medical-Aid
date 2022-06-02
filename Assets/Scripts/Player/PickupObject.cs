using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupObject : MonoBehaviour
{
    public float pickupRange = 2f;
    public float moveForce = 250f;
    public Transform holdParent;

    [SerializeField] 
    LayerMask picukableLayer;

    [SerializeField] 
    float obj_drag = 8f;

    [SerializeField] 
    GameObject crosshair;
    private GameObject heldObj;

    private GameObject lastSeenObj;
    // Start is called before the first frame update
    void Start()
    {
        holdParent = GameObject.FindGameObjectWithTag("PlayerHand").transform;
        crosshair = GameObject.FindGameObjectWithTag("Crosshair");
        Debug.Log(holdParent.name);
    }

    // Update is called once per frame
    void Update()
    {
         
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.green);
          
        if (heldObj != null)
        {
            MoveObject();
        }
        else
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 100f,picukableLayer))
            {
                crosshair.GetComponent<Image>().color = Color.blue;
                lastSeenObj =hit.transform.gameObject;
            }
            
        }

    }

    public void ProcessPick()
    {
        if (heldObj == null)
        {
            if(lastSeenObj!=null)
            {
                crosshair.GetComponent<Image>().color = Color.green;
                Pickup_object(lastSeenObj);
            }
        }
        else
        {
            DropObject();
            crosshair.GetComponent<Image>().color = Color.white;
        }
    }

    void MoveObject()
    {
        if(Vector3.Distance(heldObj.transform.position,holdParent.position)>0.1f)
        {
            Vector3 moveDirection = (holdParent.position - heldObj.transform.position);
            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }

    void Pickup_object(GameObject pickObj)
    {
        if(pickObj)
        {
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            objRig.drag = obj_drag;
            
            //objRig.transform.parent = holdParent;
            heldObj = pickObj;

        }
    }
    
    void DropObject()
    {   
       
            Rigidbody objRig = heldObj.GetComponent<Rigidbody>();
            objRig.useGravity = true;
            objRig.drag = 1;
            
            //objRig.transform.parent = null;
            heldObj = null;

    }
}
