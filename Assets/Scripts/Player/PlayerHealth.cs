using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] Slider healthBar;
    [SerializeField] GameManager gameManager;
    [SerializeField] PlayerController playerController;

    private float playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = playerHealth;

        if(playerHealth <= 0)
        {
            gameManager.GameOver();
        }
    }

    public void IncreaseHealth()
    {
        if(playerHealth < maxHealth)
        {
            playerHealth++;
        }
    }

    public void DecreaseHealth(float damage)
    {
        playerHealth = playerHealth - damage;
    }
}
