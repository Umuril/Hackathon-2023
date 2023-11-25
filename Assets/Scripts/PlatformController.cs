using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    float y_level_limit = 25;
    float blocking_time = 5;

    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y >= y_level_limit)
        {
            transform.position += Vector3.down * Time.deltaTime;
        } else if (blocking_time > 0){
            blocking_time -= Time.deltaTime;
        } else {
            y_level_limit -= 9;
            blocking_time = 5;
        }
    }
}
