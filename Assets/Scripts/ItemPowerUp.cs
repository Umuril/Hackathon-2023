using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ItemPowerUp : MonoBehaviour
{
    public float HealthPoint = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Item taken!");
            collision.gameObject.GetComponent<HealthSystem>().addHealthPoint(HealthPoint);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
