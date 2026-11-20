using TMPro;
using UnityEngine;

public class VacuumBagController : MonoBehaviour
{
    [Header("Capacity Settings")]
    public float maxBagCapacity;

    public StorageBag<DebrisData> storage { get; private set; }

    private void Awake()
    {
        storage = new StorageBag<DebrisData>(maxBagCapacity);
        storage.onBagFull += HandleBagFull;
    }

    public void TryCollectDebris(DebrisItem debris)
    {
        if (debris.isCollected)
        {
            return;
        }

        if (storage.isFull)
        {
            return;
        }

        if (debris.Collect(gameObject))
        {
            storage.TryAdd(debris.Data, debris.Data.volume);
        }
    }

    private void HandleBagFull()
    {
        Debug.Log("Vacuum storage bag is completely full!");
    }

    public void EmptyVacumm()
    {
        storage.EmptyBag();
        Debug.Log("Vacuum bag emptied!");
    }
}
