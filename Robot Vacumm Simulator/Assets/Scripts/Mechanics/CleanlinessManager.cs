using UnityEngine;
using System;
using System.Xml.Serialization;
public class CleanlinessManager : MonoBehaviour
{
    public static CleanlinessManager Instance { get; private set; }

    int totalDebrisCount;
    int CollectedDebrisCount;
    int currentScore;

    public event Action<float> OnCleanlinessPercentageChanged;
    public event Action<int> OnScoreChanged;

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
        currentScore += data.scoreValue;

        OnScoreChanged?.Invoke(currentScore);
        UpdateProgress();

        float percent = ((float)CollectedDebrisCount / totalDebrisCount) * 100f;
        Debug.Log($"Collected: {data.debrisName} (+{data.scoreValue} pts) | Bag/House Progress: {percent:F1}%");
    }

    void UpdateProgress()
    {
        if (totalDebrisCount == 0) return;

        float percentClean = ((float)CollectedDebrisCount / totalDebrisCount) * 100f;
        OnCleanlinessPercentageChanged?.Invoke(percentClean);
    }
}
