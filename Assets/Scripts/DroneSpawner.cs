using System.Collections;
using UnityEngine;

public class DroneSpawner : MonoBehaviour
{
    [Header("References")]
    public GameObject dronePrefab;
    public Transform[] spawnPoints;
    public Transform[] waypoints;
    public Transform playerTarget;
    public WaveUI waveUI;
    public GameResultManager gameResultManager;

    [Header("Wave Settings")]
    public int startDroneCount = 3;
    public int dronesIncreasePerWave = 2;
    public float timeBetweenSpawns = 2f;
    public float timeBetweenWaves = 5f;
    public int maxWaves = 5;

    [Header("Spawn Offset")]
    public float spawnOffsetX = 4f;
    public float spawnOffsetY = 1.5f;
    public float spawnOffsetZ = 4f;

    private int currentWave = 0;
    private int aliveDrones = 0;
    private bool isSpawning = false;
    private bool waitingForNextWave = false;
    private bool gameStarted = false;

    void Start()
    {
        // Waves are now started manually by GameStartManager.
    }

    void Update()
    {
        if (!gameStarted) return;

        if (!isSpawning && !waitingForNextWave && aliveDrones <= 0)
        {
            if (currentWave >= maxWaves)
            {
                if (gameResultManager != null)
                {
                    gameResultManager.WinGame(currentWave);
                }

                return;
            }

            StartCoroutine(WaitAndStartNextWave());
        }
    }

    public void StartSpawning()
    {
        if (gameStarted) return;

        gameStarted = true;
        StartCoroutine(StartNextWave());
    }

    IEnumerator StartNextWave()
    {
        isSpawning = true;
        waitingForNextWave = false;

        currentWave++;

        if (waveUI != null)
        {
            waveUI.ShowWave(currentWave);
        }

        int dronesToSpawn = startDroneCount + (currentWave - 1) * dronesIncreasePerWave;

        for (int i = 0; i < dronesToSpawn; i++)
        {
            SpawnDrone();
            yield return new WaitForSeconds(timeBetweenSpawns);
        }

        isSpawning = false;
    }

    IEnumerator WaitAndStartNextWave()
    {
        waitingForNextWave = true;

        yield return new WaitForSeconds(timeBetweenWaves);

        StartCoroutine(StartNextWave());
    }

    void SpawnDrone()
    {
        if (dronePrefab == null || spawnPoints == null || spawnPoints.Length == 0)
        {
            return;
        }

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        GameObject newDrone = Instantiate(
            dronePrefab,
            spawnPoint.position + GetSpawnOffset(),
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

        if (aliveDrones < 0)
        {
            aliveDrones = 0;
        }
    }

    public int GetCurrentWave()
    {
        return currentWave;
    }

    Vector3 GetSpawnOffset()
    {
        return new Vector3(
            Random.Range(-spawnOffsetX, spawnOffsetX),
            Random.Range(-spawnOffsetY, spawnOffsetY),
            Random.Range(-spawnOffsetZ, spawnOffsetZ)
        );
    }
}