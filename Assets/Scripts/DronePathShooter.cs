using UnityEngine;

public class DronePathShooter : MonoBehaviour
{
    [Header("Movement")]
    public Transform[] waypoints;
    public float speed = 4f;
    public float rotationSpeed = 5f;

    [Header("Shooting")]
    public Transform playerTarget;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float shootDistance = 25f;
    public float bulletSpeed = 15f;
    public float fireRate = 1.5f;

    private int currentWaypointIndex = 0;
    private float nextFireTime = 0f;

    void Update()
    {
        MoveOnPath();
        ShootAtPlayer();
    }

    void MoveOnPath()
    {
        if (waypoints == null || waypoints.Length == 0) return;

        Transform targetWaypoint = waypoints[currentWaypointIndex];

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetWaypoint.position,
            speed * Time.deltaTime
        );

        if (playerTarget != null)
        {
            Vector3 direction = new Vector3(
                playerTarget.position.x - transform.position.x,
                0,
                playerTarget.position.z - transform.position.z
            );
            if (direction.sqrMagnitude > 0.001f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    targetRotation,
                    rotationSpeed * Time.deltaTime
                );
            }
        }

        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.3f)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
    }

    void ShootAtPlayer()
    {
        if (playerTarget == null || firePoint == null || bulletPrefab == null) return;

        float distance = Vector3.Distance(transform.position, playerTarget.position);

        if (distance <= shootDistance && Time.time >= nextFireTime)
        {
            Vector3 direction = (playerTarget.position - firePoint.position).normalized;

            GameObject bullet = Instantiate(
                bulletPrefab,
                firePoint.position,
                Quaternion.LookRotation(direction)
            );

            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.linearVelocity = direction * bulletSpeed;
            }

            Destroy(bullet, 5f);

            nextFireTime = Time.time + fireRate;
        }
    }
}