using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillImage;

    public void SetHealth(float current, float max)
    {
        float ratio = current / max;

        fillImage.fillAmount = ratio;

        fillImage.color = Color.Lerp(Color.red, Color.green, ratio);
    }

    void Update()
    {
        // mindig a kamera felé néz
        if (Camera.main != null)
        {
            transform.LookAt(Camera.main.transform);
        }
    }
}