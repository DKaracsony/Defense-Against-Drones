using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public float bulletLifetime = 5f; // seconds before bullet is destroyed

    public AudioClip clip;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();

        if (source == null)
        {
            source = gameObject.AddComponent<AudioSource>();
        }
    }

    public void FireBullet()
    {
	GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	Rigidbody rb = bullet.GetComponent<Rigidbody>();

	source.PlayOneShot(clip);

	if (rb != null)
	{
	     rb.linearVelocity = firePoint.forward * bulletSpeed;
	}

        // Destroy bullet after time
        Destroy(bullet, bulletLifetime);
    }
}