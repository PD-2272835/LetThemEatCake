using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;
    public TMP_Text healthText;
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.Return)) // Down arrow to take damage
        //{
        //    TakeDamage(20);
        //}
        //if (Input.GetKeyDown(KeyCode.Space)) // Space key to heal
        //{
        //    Heal(20);
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
        healthText.text = "Health: " + healthAmount.ToString("F0"); // Update health text
        if (healthAmount <= 0)
        {
            GameOver(); // Call GameOver method to show the Game Over panel
        }
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100f;
        healthText.text = "Health: " + healthAmount.ToString("F0"); // Update health text
    }
    
    public void GameOver()
    {
        EventManager.GameOver(); // Trigger the Game Over event
    }
}
