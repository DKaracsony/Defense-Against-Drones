using UnityEngine;

public class GameStartManager : MonoBehaviour
{
    [Header("Mission UI")]
    public GameObject missionCanvas;

    [Header("Player Locomotion Objects")]
    public GameObject moveObject;
    public GameObject turnObject;
    public GameObject gravityObject;
    public GameObject jumpObject;
    public GameObject teleportationObject;

    [Header("Drone System")]
    public DroneSpawner droneSpawner;

    private bool missionStarted = false;

    void Start()
    {
        if (missionCanvas != null)
        {
            missionCanvas.SetActive(true);
        }

        SetPlayerMovement(false);
    }

    public void StartMission()
    {
        if (missionStarted) return;

        missionStarted = true;

        if (missionCanvas != null)
        {
            missionCanvas.SetActive(false);
        }

        SetPlayerMovement(true);

        if (droneSpawner != null)
        {
            droneSpawner.StartSpawning();
        }
    }

    private void SetPlayerMovement(bool enabled)
    {
        if (moveObject != null) moveObject.SetActive(enabled);
        if (turnObject != null) turnObject.SetActive(enabled);
        if (gravityObject != null) gravityObject.SetActive(enabled);
        if (jumpObject != null) jumpObject.SetActive(enabled);
        if (teleportationObject != null) teleportationObject.SetActive(enabled);
    }
}