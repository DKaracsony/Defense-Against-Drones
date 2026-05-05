using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResultManager : MonoBehaviour
{
    [Header("Scene Names")]
    public string resultSceneName = "ResultScene";

    private bool gameEnded = false;

    public void WinGame(int reachedWave)
    {
        if (gameEnded) return;

        gameEnded = true;

        GameResultData.playerWon = true;
        GameResultData.reachedWave = reachedWave;

        SceneManager.LoadScene(resultSceneName);
    }

    public void LoseGame(int reachedWave)
    {
        if (gameEnded) return;

        gameEnded = true;

        GameResultData.playerWon = false;
        GameResultData.reachedWave = reachedWave;

        SceneManager.LoadScene(resultSceneName);
    }
}