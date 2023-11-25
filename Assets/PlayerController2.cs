using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.UpArrow)))
        {
            rb.velocity = new Vector3(0, 0, speed * Time.deltaTime);
        }
        if ((Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.DownArrow)))
        {
            //rb.AddForce(0, 0, -speed * Time.deltaTime);
            rb.velocity = new Vector3(0, 0, -speed * Time.deltaTime);
        }
        if ((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            //rb.AddForce(-speed * Time.deltaTime, 0, 0);
            rb.velocity = new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        if ((Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.RightArrow)))
        {
            //rb.AddForce(speed * Time.deltaTime, 0, 0);
            rb.velocity = new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }
}
