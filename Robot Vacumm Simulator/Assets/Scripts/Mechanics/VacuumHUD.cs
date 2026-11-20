using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class VacuumHUD : MonoBehaviour
{
    [Header("Vacumm Reference")]
    [SerializeField] VacuumBagController vacuumController;
    [Header("Bag Capacity UI")]
    [SerializeField] TMP_Text bagCapacityText;
    [SerializeField] TextMeshProUGUI bagIsFull;
    [SerializeField] TextMeshProUGUI PressToEmptyBag;

    [Header("Level Cleanliness UI")]
    [SerializeField] TMP_Text cleanlinessText;
    [SerializeField] Slider cleanlinessSlider;

    [Header("Level Finished UI")]
    [SerializeField] GameObject levelFinishedUI;

    [Header("Player")]
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] IsInChargingStation inChargingStation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovement = FindFirstObjectByType<PlayerMovement>();

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
        levelFinishedUI.SetActive(false);
    }

    void Update()
    {
        var storage = vacuumController.storage;
        if (inChargingStation.isInChargingStation && storage.isFull)
        {
            PressToEmptyBag.text = "Press E to empty bag";
        }
        else
        {
            PressToEmptyBag.text = "";
        }

        if (inChargingStation.isInChargingStation == true && Input.GetKey(KeyCode.E))
        {
            print("emptying bag!!!");
            vacuumController.EmptyVacumm();
        }
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
            bagIsFull.text = "Bag is full!\r\nGo to charging station and empty the bag";
        }
        else
        {
            bagCapacityText.text = "Bag: " + Mathf.FloorToInt(storage.currentVolume) + " / " + Mathf.FloorToInt(storage.maxCapacity);
            bagIsFull.text = "";
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

        if (percentageClean == 100)
        {
            LevelIsCompleted();
        }
    }

    void LevelIsCompleted()
    {
        levelFinishedUI.SetActive(true);
        playerMovement.canMove = false;
    }
}
