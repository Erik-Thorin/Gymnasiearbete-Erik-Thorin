using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VacuumHUD : MonoBehaviour
{
    [Header("Vacumm Reference")]
    [SerializeField] VacuumBagController vacuumController;
    [Header("Bag Capacity UI")]
    [SerializeField] TMP_Text bagCapacityText;

    [Header("Level Cleanliness UI")]
    [SerializeField] TMP_Text cleanlinessText;
    [SerializeField] Slider cleanlinessSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (vacuumController == null)
        {
            vacuumController = FindFirstObjectByType<VacuumBagController>();
        }

        if (cleanlinessSlider != null)
        {
            cleanlinessSlider.minValue = 0f;
            cleanlinessSlider.maxValue = 100f;
            cleanlinessSlider.value = 0f;
        }

        if (vacuumController != null && vacuumController.storage != null)
        {
            vacuumController.storage.onBagUpdated += UpdateBagUI;
        }

        if (CleanlinessManager.Instance != null)
        {
            CleanlinessManager.Instance.OnCleanlinessPercentageChanged += UpdateCleanlinessUI;
        }

        UpdateBagUI();
        UpdateCleanlinessUI(0f);
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
        }
    }

    void UpdateBagUI()
    {
        if (vacuumController == null || vacuumController.storage == null)
        {
            return;
        }

        var storage = vacuumController.storage;

        if (storage.isFull)
        {
            bagCapacityText.text = "Bag Full!";
        }
        else
        {
            bagCapacityText.text = "Trash: " + Mathf.FloorToInt(storage.currentVolume) + " / " + Mathf.FloorToInt(storage.maxCapacity);
        }
    }

    void UpdateCleanlinessUI(float percentageClean)
    {
        if (cleanlinessSlider != null)
        {
            cleanlinessSlider.value = percentageClean;
        }

        if (cleanlinessText != null)
        {
            cleanlinessText.text = "House Clean: " + Mathf.FloorToInt(percentageClean) + "%";
        }
    }
}
