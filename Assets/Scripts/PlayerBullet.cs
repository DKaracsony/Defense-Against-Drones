using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int damage = 25;

    private void OnTriggerEnter(Collider other)
    {
        DroneHealth droneHealth = other.GetComponentInParent<DroneHealth>();

        if (droneHealth != null)
        {
            droneHealth.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}