using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    private PlayerMotor motor;

    private PlayerCamera look;

    private PlayerInteract interact;

    [SerializeField] 
    CoreBoolean core;
    [SerializeField] 
    PauseMenu pause;
    [SerializeField] 
    CinemachineVirtualCamera playerCam;
    [SerializeField] 
    CinemachineVirtualCamera playerFrozenCam;
    [SerializeField] 
    CinemachineVirtualCamera tableCam;
    [SerializeField] 
    CinemachineVirtualCamera monitorCam;
    [SerializeField] 
    CinemachineVirtualCamera patientCam;

    [SerializeField]
    Transform lookAt;
    [SerializeField]
    Transform playerHand;
    [SerializeField] 
    PickupObject picker;




    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerCamera>();
        interact = GetComponent<PlayerInteract>();
        onFoot.Jump.performed += ctx => motor.Jump();
        onFoot.Crouch.performed += ctx => motor.Crouch();
        onFoot.Interact.performed += ctx => interact.ProcessInteract();
        onFoot.MouseToggle.performed += ctx => MouseLock.ToggleMouse();
        onFoot.PutGloves.performed += ctx => core.ProcessGloves();
        onFoot.Esc.performed += ctx => pause.EscapeMenu();
        //onFoot.PickUp.performed += ctx => picker.ProcessPick();
        //onFoot.SwitchCams.performed += ctx => CinemachineSwitch.SwapCamera(playerCam);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(CinemachineSwitch.activeCam == playerCam)
        {
            motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
        }
       
    }

    void Update()
    {
        if(onFoot.SwitchCams.triggered)
        {
            SwapPlayerCameras();
        }
        if (!Cursor.visible)
       {
            Vector3 temp = new Vector3(lookAt.position.x, playerHand.position.y, lookAt.position.z);
            lookAt.position = temp;
            lookAt.rotation = playerHand.rotation;
            look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
           
       }
       
        SwapPlayerCameras();
    }

    private void SwapPlayerCameras()
    {
        if(CinemachineSwitch.activeCam == null  && Cursor.visible || CinemachineSwitch.activeCam == playerCam && Cursor.visible )
        {
            CinemachineSwitch.SwapCamera(playerFrozenCam);
        }
        else if(CinemachineSwitch.activeCam == null  && !Cursor.visible || CinemachineSwitch.activeCam == playerFrozenCam && !Cursor.visible )
        {
            CinemachineSwitch.SwapCamera(playerCam);
        }
       
    }

    private void OnEnable()
    {
        //CinemachineVirtualCamera[] allCameras = GameObject.FindObjectsOfType<CinemachineVirtualCamera>();
        onFoot.Enable();
        CinemachineSwitch.Register(playerCam);
        CinemachineSwitch.Register(tableCam);
        CinemachineSwitch.Register(monitorCam);
        CinemachineSwitch.Register(patientCam);
    }
    private void OnDisable()
    {
        onFoot.Disable();
        CinemachineSwitch.UnRegister(playerCam);
        CinemachineSwitch.UnRegister(tableCam);
        CinemachineSwitch.UnRegister(monitorCam);
        CinemachineSwitch.UnRegister(patientCam);
    }
}
