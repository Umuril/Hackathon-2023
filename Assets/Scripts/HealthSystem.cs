using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float health = 100f;
    void Start()
    {

    }

    public void addHealthPoint(float points)
    {
        health += points;
        if (health > 100)
            health = 100;
        GameObject.FindGameObjectWithTag("myHealth").GetComponentInChildren<HealthManagerScript>().Heal(points);
    }

    public void removeHealthPoint(float points)
    {
        if (health - points <= 0)
            Destroy(gameObject);

        health -= points;
        GameObject.FindGameObjectWithTag("myHealth").GetComponentInChildren<HealthManagerScript>().TakeDamage(points);
        //Debug.Log("Outch! " + health);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // every delta time remove health
        removeHealthPoint(Time.deltaTime);
    }
}
