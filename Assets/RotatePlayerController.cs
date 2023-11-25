using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayerController : MonoBehaviour
{

    public Transform player_cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relative = transform.InverseTransformPoint(player_cam.position);

        Debug.Log(relative);

        transform.Rotate(Vector3.up * -relative.x, Space.World);
    }
}
