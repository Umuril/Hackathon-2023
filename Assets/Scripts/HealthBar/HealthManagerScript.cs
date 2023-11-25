using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManagerScript : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (healthAmount <= 0)
        {
            // Application.LoadLevel(Application.loadedLevel);
            // SceneManager.LoadScene("OtherSceneName", LoadSceneMode.Additive);
        }

        /*if (Input.GetKeyDown(KeyCode.Return))
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Heal(5);
        }*/
    }

    public void TakeDamage(float damage)
    {
        //Debug.Log("TakeDamage");
        //Debug.Log(healthBar.fillAmount);
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }

    public void Heal(float healingAmount)
    {
        //Debug.Log("Heal");
        //Debug.Log(healthBar.fillAmount);
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        healthBar.fillAmount = healthAmount / 100f;

    }
}