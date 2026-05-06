using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth = 100;
    public int currentHealth;

    [Header("UI")]
    public TextMeshProUGUI healthText;

    [Header("Result")]
    public GameResultManager gameResultManager;
    public DroneSpawner droneSpawner;

    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthText();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "HP: " + currentHealth;
        }
    }

    void Die()
    {
        if (isDead) return;

        isDead = true;

        int reachedWave = 1;

        if (droneSpawner != null)
        {
            reachedWave = droneSpawner.GetCurrentWave();
        }

        if (gameResultManager != null)
        {
            gameResultManager.LoseGame(reachedWave);
        }
    }
}