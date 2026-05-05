using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultSceneManager : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI resultTitleText;
    public TextMeshProUGUI resultInfoText;

    [Header("Scene Names")]
    public string gameSceneName = "GameScene";
    public string menuSceneName = "MenuScene";

    void Start()
    {
        ShowResult();
    }

    void ShowResult()
    {
        if (GameResultData.playerWon)
        {
            resultTitleText.text = "MISSION COMPLETE";
            resultInfoText.text = "You survived all drone waves.\nReached Wave: " + GameResultData.reachedWave;
        }
        else
        {
            resultTitleText.text = "MISSION FAILED";
            resultInfoText.text = "The drones overwhelmed you.\nReached Wave: " + GameResultData.reachedWave;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}