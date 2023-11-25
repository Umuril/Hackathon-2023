using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformController : MonoBehaviour
{
    float y_level_limit = 25;

    int current_level = 23;

    float timer = 15;

    public Text platform_text;

    public Text timer_text;

    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (transform.position.y >= y_level_limit) {
            // Go down
            transform.position += Vector3.down * Time.deltaTime;
        } else if (timer <= 0){
            // Start again
            y_level_limit -= 9;
            timer = 15;
            current_level += 1;
        }

        platform_text.text = "Platform level: " + current_level;
        timer_text.text = Mathf.FloorToInt(timer).ToString();
    }
}
