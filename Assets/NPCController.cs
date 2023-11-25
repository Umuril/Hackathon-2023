using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public float speed = 1.0f;
    public bool isRunning = false;
    public bool isAttacking = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // get player position
        GameObject player = GameObject.Find("Player");
        Vector3 playerPosition = player.transform.position;
        // go towards player
        Vector3 direction = playerPosition - transform.position;
        // ignore y direction
        direction.y = 0;
        // normalize direction
        direction.Normalize();

        // check if player is in range
        float distanceToPlayer = Vector3.Distance(playerPosition, transform.position);
        if (distanceToPlayer < 2.0f)
        {
            isRunning = false;
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
            isRunning = true;
            // move towards player
            transform.position += direction * speed * Time.deltaTime;

            // rotate towards player
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);

            //// change animation to run if moving
            //Animator animator = GetComponent<Animator>();
            //if (direction.magnitude > 0.1f)
            //{
            //    animator.SetBool("isRunning", true);
            //}
            //else
            //{
            //    animator.SetBool("isRunning", false);
            //}

        }


        
        //// check if character is moving and change animation
        //if (direction.magnitude > 0.1f)
        //{
        //    isRunning = true;
        //}


    }
}
