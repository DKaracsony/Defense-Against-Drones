using System.Collections;
using UnityEngine;

public class DroneSpawner : MonoBehaviour
{
    [Header("References")]
    public GameObject dronePrefab;
    public Transform[] spawnPoints;
    public Transform[] waypoints;
    public Transform playerTarget;

    [Header("Wave Settings")]
    public int startDroneCount = 3;
    public int dronesIncreasePerWave = 2;
    public float timeBetweenSpawns = 2f;
    public float timeBetweenWaves = 5f;

    private int currentWave = 0;
    private int aliveDrones = 0;
    private bool isSpawning = false;

    void Start()
    {
        StartCoroutine(StartNextWave());
    }

    IEnumerator StartNextWave()
    {
        isSpawning = true;

        currentWave++;

        int dronesToSpawn = startDroneCount + (currentWave - 1) * dronesIncreasePerWave;

        for (int i = 0; i < dronesToSpawn; i++)
        {
            SpawnDrone();
            yield return new WaitForSeconds(timeBetweenSpawns);
        }

        isSpawning = false;
    }

    void Update()
    {
        if (!isSpawning && aliveDrones <= 0)
        {
            StartCoroutine(WaitAndStartNextWave());
        }
    }

    IEnumerator WaitAndStartNextWave()
    {
        isSpawning = true;

        yield return new WaitForSeconds(timeBetweenWaves);

        StartCoroutine(StartNextWave());
    }

    void SpawnDrone()
    {
        if (dronePrefab == null || spawnPoints.Length == 0) return;

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        GameObject newDrone = Instantiate(
            dronePrefab,
            spawnPoint.position,
            spawnPoint.rotation
        );

        DronePathShooter droneScript = newDrone.GetComponent<DronePathShooter>();

        if (droneScript != null)
        {
            droneScript.waypoints = waypoints;
            droneScript.playerTarget = playerTarget;
        }

        DroneHealth health = newDrone.GetComponent<DroneHealth>();

        if (health != null)
        {
            health.spawner = this;
        }

        aliveDrones++;
    }

    public void DroneDestroyed()
    {
        aliveDrones--;
    }
}