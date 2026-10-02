using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VacuumHUD : MonoBehaviour
{
    [Header("Vacumm Reference")]
    [SerializeField] VacuumBagController vacuumController;
    [Header("Bag Capacity UI")]
    [SerializeField] Slider bagCapacitySlider;
    [SerializeField] TMP_Text bagCapacityText;

    [Header("Level Cleanliness UI")]
    [SerializeField] TMP_Text cleanlinessText;
    [SerializeField] TMP_Text scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (vacuumController == null)
        {
            vacuumController = FindFirstObjectByType<VacuumBagController>();
        }

        if (vacuumController != null && vacuumController.storage != null)
        {
            vacuumController.storage.onBagUpdated += UpdateBagUI;
        }

        if (CleanlinessManager.Instance != null)
        {
            CleanlinessManager.Instance.OnCleanlinessPercentageChanged += UpdateCleanlinessUI;
            CleanlinessManager.Instance.OnScoreChanged += UpdateScoreUI;
        }

        UpdateBagUI();
        UpdateCleanlinessUI(0f);
        UpdateScoreUI(0);
    }

    void OnDestroy()
    {
        if (vacuumController != null && vacuumController.storage != null)
        {
            vacuumController.storage.onBagUpdated -= UpdateBagUI;
        }

        if (CleanlinessManager.Instance != null)
        {
            CleanlinessManager.Instance.OnCleanlinessPercentageChanged -= UpdateCleanlinessUI;
            CleanlinessManager.Instance.OnScoreChanged -= UpdateScoreUI;
        }
    }

    void UpdateBagUI()
    {
        if (vacuumController == null || vacuumController.storage == null) return;

        var storage = vacuumController.storage;

        if (bagCapacitySlider != null)
        {
            bagCapacitySlider.maxValue = storage.maxCapacity;
            bagCapacitySlider.value = storage.currentVolume;
        }

        if (bagCapacityText != null)
        {
            bagCapacityText.text = storage.isFull
                ? "BAG FULL"
                : $"Bag: {storage.currentVolume:F0} / {storage.maxCapacity:F0}";
        }
    }

    void UpdateCleanlinessUI(float percentageClean)
    {
        if (cleanlinessText != null)
        {
            cleanlinessText.text = $"House Clean: {percentageClean:F0}%";
        }
    }

    void UpdateScoreUI(int currentScore)
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {currentScore}";
        }
    }
}
