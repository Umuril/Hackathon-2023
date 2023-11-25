using System;
using UnityEngine;

public static class Models
{

    #region - Camera -
    [Serializable]
    public class CameraSettingsModel{

        [Header("Camera Settings")]
        public float SensitivityX;
        public bool InvertedX;

        public float SensitivityY;
        public bool InvertedY;
        
        public float YClampMin = -40f;
        public float YClampMax = 40f; 

        [Header("Character")]
        public float CharacterRotationSmoothdamp = 1f;

    }

    #endregion

        #region - Player -
    [Serializable]
    public class PlayerSettingsModel{

        public float ForwardSpeed = 1;
        public float CharacterRotationSmoothdamp = 0.6f;

    }

    #endregion

}
