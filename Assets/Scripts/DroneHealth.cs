using UnityEngine;

public class DroneHealth : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth = 100;

    [Header("Effects")]
    public GameObject explosionEffect;

    [Header("UI")]
    public HealthBar healthBar;

    [HideInInspector]
    public DroneSpawner spawner;

    private int currentHealth;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;

        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(currentHealth, maxHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(currentHealth, maxHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return;

        isDead = true;

        // Wave rendszer értesítése
        if (spawner != null)
        {
            spawner.DroneDestroyed();
        }

        // Robbanás effekt
        if (explosionEffect != null)
        {
            GameObject explosion = Instantiate(
                explosionEffect,
                transform.position + Vector3.up * 1f,
                Quaternion.identity
            );

            ParticleSystem ps = explosion.GetComponent<ParticleSystem>();

            if (ps != null)
            {
                ps.Play();
            }

            Destroy(explosion, 3f);
        }

        // Drone törlése
        Destroy(gameObject);
    }
}