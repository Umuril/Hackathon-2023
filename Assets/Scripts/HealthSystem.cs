using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HealthSystem : MonoBehaviour
{
    public Text[] disableOnDie;

    public GameObject panel;
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
        {
            foreach (var dis in disableOnDie)
            {
                dis.enabled = false;
            }
            panel.SetActive(true);
            Time.timeScale = 0f;
            //Destroy(gameObject);
        }

        health -= points;
        GameObject.FindGameObjectWithTag("myHealth").GetComponentInChildren<HealthManagerScript>().TakeDamage(points);
        //Debug.Log("Outch! " + health);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // every delta time remove health
        removeHealthPoint(Time.deltaTime);
        if (GameObject.FindGameObjectWithTag("Player").transform.position.y < -2)
        {
            removeHealthPoint(100);
            //Time.timeScale = 0f;
        }
    }
}
