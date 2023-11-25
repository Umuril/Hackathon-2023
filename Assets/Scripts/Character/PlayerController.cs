using UnityEngine;
using static Models;


public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    PlayerInputActions player_input_actions_instance;
    [HideInInspector]
    public Vector2 input_Movement;
    [HideInInspector ]
    public Vector2 input_View;

    Vector3 playerMovement;


    public PlayerSettingsModel settings;
    public bool isTargetMode;
    
    [Header("Camera")]
    public Transform cameraTarget;
    public CameraController cameraController;
    

    public void Awake(){
        characterController = GetComponent<CharacterController>();
        player_input_actions_instance = new PlayerInputActions();

        player_input_actions_instance.Movement.Movement.performed += x => input_Movement = x.ReadValue<Vector2>();
        player_input_actions_instance.Movement.View.performed += x => input_View = x.ReadValue<Vector2>();



        player_input_actions_instance.Actions.Jump.performed += x => Jump();
        player_input_actions_instance.Actions.SuperJump.performed += x => SuperJump();

    }

    private void Jump(){
        Debug.Log("I'm Jumping!");
    }

    private void SuperJump(){
        Debug.Log("I'm SuperJumping!");
    }

    private void Update(){
        Movement();
    }

    private void Movement(){
        Debug.Log(cameraController);

        playerMovement = cameraController.transform.forward * (settings.ForwardSpeed * input_Movement.y) * Time.deltaTime;
        playerMovement += cameraController.transform.right * (settings.ForwardSpeed * input_Movement.x) * Time.deltaTime;

        if (!isTargetMode){
            var originalRotation = transform.rotation;
            transform.LookAt(playerMovement + transform.position, Vector3.up);
            var newRotation = transform.rotation;

            transform.rotation = Quaternion.Lerp(originalRotation, newRotation, settings.CharacterRotationSmoothdamp); 
        }

        characterController.Move(playerMovement);
    }

    # region - Enable/Disable -
    public void OnEnable(){
        player_input_actions_instance.Enable();
    }

    public void OnDisable(){
        player_input_actions_instance.Disable();

    }

    #endregion
}
