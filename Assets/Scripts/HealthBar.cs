using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    void Awake()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        float ratio = currentValue / maxValue;

        slider.value = ratio;

        // 🔥 SZÍN VÁLTÁS
        Color healthColor = Color.Lerp(Color.red, Color.green, ratio);

        // Slider fill színének beállítása
        Image fillImage = slider.fillRect.GetComponent<Image>();
        fillImage.color = healthColor;
    }

    void Update()
{
    float ratio = slider.value;

    Image fillImage = slider.fillRect.GetComponent<Image>();
    fillImage.color = Color.Lerp(Color.red, Color.green, ratio);

    if (mainCamera != null)
        transform.rotation = mainCamera.transform.rotation;

    if (target != null)
        transform.position = target.position + offset;
}
}