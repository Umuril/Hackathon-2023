using System.Collections;
using System.Collections.Generic;
using static Models;
using UnityEngine;
using System;

public class NewBehaviourScript : MonoBehaviour
{
    public PlayerController playerController;

    public PlayerSettingsModel settings;

    private Vector3 targetRotation;

    public void Update(){
        FollowPlayerCameraTarget();
        CameraRotation();

    }

    private void CameraRotation(){
        var viewInput = playerController.input_View;

        targetRotation.x += (settings.InvertedY ? (viewInput.y * settings.SensitivityY) : -(viewInput.y * settings.SensitivityY)) * Time.deltaTime;
        targetRotation.y += -(settings.InvertedX ? -(viewInput.x * settings.SensitivityX) : (viewInput.x * settings.SensitivityX)) * Time.deltaTime;

        targetRotation.x = Mathf.Clamp(targetRotation.x, settings.YClampMin, settings.YClampMax);

        transform.rotation = Quaternion.Euler(targetRotation);

    }

    private void FollowPlayerCameraTarget(){
        transform.position = playerController.cameraTarget.position;
        
    }

}
