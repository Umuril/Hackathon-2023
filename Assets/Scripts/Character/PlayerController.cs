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
    public FuckCameraController fuckCameraController;
    
    public float movementSmoothdamp;
    public bool isWalking;
    public float verticalSpeed;
    private float targetVerticalSpeed;
    private float verticalSpeedVelocity;

    public float horizontalSpeed;
    private float targetHorizontalSpeed;
    private float horizontalSpeedVelocity;

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

       
        if (isTargetMode){

            if (input_Movement.y > 0){
                targetVerticalSpeed = (isWalking ? settings.WalkingSpeed : settings.RunningSpeed);
            } else {
                targetVerticalSpeed = (isWalking ? settings.WalkingBackwardSpeed : settings.RunningBackwardSpeed);
            }

            targetVerticalSpeed = targetVerticalSpeed * input_Movement.y * Time.deltaTime;
            targetHorizontalSpeed = (isWalking ? settings.WalkingSpeed : settings.RunningSpeed) * input_Movement.y * Time.deltaTime;

        } else {

            var originalRotation = transform.rotation;
            transform.LookAt(playerMovement + transform.position, Vector3.up);
            var newRotation = transform.rotation;

            transform.rotation = Quaternion.Lerp(originalRotation, newRotation, settings.CharacterRotationSmoothdamp); 

            targetVerticalSpeed = (isWalking ? settings.WalkingStrafingSpeed : settings.RunningStrafingSpeed) * input_Movement.y * Time.deltaTime;
            targetHorizontalSpeed = (isWalking ? settings.WalkingStrafingSpeed : settings.RunningStrafingSpeed) * input_Movement.y * Time.deltaTime;

        }

        verticalSpeed = Mathf.SmoothDamp(verticalSpeed, targetVerticalSpeed, ref verticalSpeedVelocity, movementSmoothdamp);
        horizontalSpeed = Mathf.SmoothDamp(horizontalSpeed, targetHorizontalSpeed, ref horizontalSpeedVelocity, movementSmoothdamp);

        playerMovement = fuckCameraController.transform.forward * verticalSpeed;
        playerMovement += fuckCameraController.transform.right * horizontalSpeed;


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
