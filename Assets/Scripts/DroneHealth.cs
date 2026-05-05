using UnityEngine;

public class DroneHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public GameObject explosionEffect;
    public HealthBar healthBar;

    [HideInInspector] public DroneSpawner spawner;

    [Header("DEBUG")]
    [Range(0, 100)]
    public int debugHealth = 100;

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

    void OnValidate()
    {
        currentHealth = debugHealth;

        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(currentHealth, maxHealth);
        }

        if (currentHealth <= 0 && !isDead && Application.isPlaying)
        {
            Die();
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
        isDead = true;

        if (spawner != null)
        {
            spawner.DroneDestroyed();
        }

        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    // 🔥 Inspector teszt
    [ContextMenu("TEST DAMAGE")]
    void TestDamage()
    {
        TakeDamage(25);
    }

    [ContextMenu("TEST DIE")]
    void TestDie()
    {
        Die();
    }
}