using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerInputActions player_input_actions_instance;
    [HideInInspector]
    public Vector2 input_Movement;
    [HideInInspector ]
    public Vector2 input_View;

    public Transform cameraTarget;

    public void Awake(){
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
        // Debug.Log(input_Movement);
        // Debug.Log(input_View);
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
