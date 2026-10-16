using UnityEngine;
using System;
using System.Xml.Serialization;
public class CleanlinessManager : MonoBehaviour
{
    public static CleanlinessManager Instance { get; private set; }

    int totalDebrisCount;
    int CollectedDebrisCount;

    public event Action<float> OnCleanlinessPercentageChanged;

    [SerializeField] PlayerMovement playerMovement;

    [SerializeField] GameObject finishedLevelUI;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        totalDebrisCount = FindObjectsByType<DebrisItem>(FindObjectsSortMode.None).Length;
        UpdateProgress();
    }

    public void RegisterDebrisCollected(DebrisData data)
    {
        CollectedDebrisCount++;
        UpdateProgress();
    }

    void UpdateProgress()
    {
        if (totalDebrisCount == 0) return;

        float percentClean = ((float)CollectedDebrisCount / totalDebrisCount) * 100f;
        OnCleanlinessPercentageChanged?.Invoke(percentClean);
    }

    public void LevelCompleted()
    {
        playerMovement.canMove = false;
        finishedLevelUI.SetActive(true);
    }
}
