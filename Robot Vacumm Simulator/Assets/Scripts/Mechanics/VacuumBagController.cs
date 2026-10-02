using UnityEngine;

public class VacuumBagController : MonoBehaviour
{
    [Header("Capacity Settings")]
    [SerializeField] float maxBagCapacity = 50f;

    public StorageBag<DebrisData> storage { get; private set; }

    private void Awake()
    {
        storage = new StorageBag<DebrisData>(maxBagCapacity);
        storage.onBagFull += HandleBagFull;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<DebrisItem>(out var debris))
        {
            if (storage.isFull)
            {
                Debug.Log("Vacuum bag is full! Return to base station to empty it.");
                return;
            }
        }

        if (storage.TryAdd(debris.Data, debris.Data.volume))
        {
            debris.Collect(gameObject);
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
