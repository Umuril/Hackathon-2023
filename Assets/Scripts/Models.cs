using System;
using UnityEngine;

public static class Models
{

    #region - Player -
    [Serializable]
    public class PlayerSettingsModel{

        [Header("Camera Settings")]
        public float SensitivityX;
        public bool InvertedX;

        public float SensitivityY;
        public bool InvertedY;
        
        public float YClampMin = -40f;
        public float YClampMax = 40f; 

    }

    #endregion

}
