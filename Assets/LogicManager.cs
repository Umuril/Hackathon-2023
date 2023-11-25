using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicManager : MonoBehaviour
{
    public HealthSystem healthSystem;

    public void takeDamage(float damage)
    {
        healthSystem.removeHealthPoint(damage);
    }
}
