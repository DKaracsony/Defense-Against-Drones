using System.Collections;
using TMPro;
using UnityEngine;

public class WaveUI : MonoBehaviour
{
    public TextMeshProUGUI waveText;
    public float displayTime = 2f;

    void Start()
    {
        SetAlpha(0f); // induláskor láthatatlan
    }

    public void ShowWave(int waveNumber)
    {
        StopAllCoroutines();
        StartCoroutine(ShowWaveRoutine(waveNumber));
    }

    IEnumerator ShowWaveRoutine(int waveNumber)
    {
        waveText.text = "WAVE " + waveNumber;

        SetAlpha(1f); // megjelenik

        yield return new WaitForSeconds(displayTime);

        SetAlpha(0f); // eltűnik
    }

    void SetAlpha(float a)
    {
        Color c = waveText.color;
        c.a = a;
        waveText.color = c;
    }
}