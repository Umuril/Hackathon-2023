using System.Collections;
using System.Collections.Generic;
using static Models;
using UnityEngine;
using System;
using UnityEditor;

public class CameraController2 : MonoBehaviour
{
    public PlayerController playerController;

    public CameraSettingsModel settings;

    private Vector3 targetRotation;

    public GameObject yGimbal;
    private Vector3 yGimbalRotation;


    public void Update(){
        FollowPlayerCameraTarget();
        CameraRotation();

    }

    private void CameraRotation(){
        var viewInput = playerController.input_View;

        targetRotation.y += -(settings.InvertedX ? -(viewInput.x * settings.SensitivityX) : (viewInput.x * settings.SensitivityX)) * Time.deltaTime;
        transform.rotation = Quaternion.Euler(targetRotation);

        yGimbalRotation.x += (settings.InvertedY ? (viewInput.y * settings.SensitivityY) : -(viewInput.y * settings.SensitivityY)) * Time.deltaTime;
        yGimbalRotation.x = Mathf.Clamp(yGimbalRotation.x, settings.YClampMin, settings.YClampMax);

        yGimbal.transform.localRotation =  Quaternion.Euler(yGimbalRotation);


        if (playerController.isTargetMode){
            var currentRotation = playerController.transform.rotation;

            var newRotation = currentRotation.eulerAngles;
            newRotation.y = targetRotation.y;

            currentRotation = Quaternion.Lerp(currentRotation, Quaternion.Euler(newRotation), settings.CharacterRotationSmoothdamp);

            playerController.transform.rotation = currentRotation;

        }

    }

    private void FollowPlayerCameraTarget(){
        transform.position = playerController.cameraTarget.position;

    }

}
