using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth = 100;
    public int currentHealth;

    [Header("Result")]
    public GameResultManager gameResultManager;
    public DroneSpawner droneSpawner;

    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
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