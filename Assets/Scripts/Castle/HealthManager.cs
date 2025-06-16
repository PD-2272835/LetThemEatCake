using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
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

        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    TakeDamage(10);
        //}
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Heal(10);
        //}

    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
        if (healthAmount <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // reload current scene
        }
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100f;
    }
}
