using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class SuctionZone : MonoBehaviour
{
    [SerializeField] VacuumBagController vacuumController;
    SphereCollider suctionCollider;

    void Awake()
    {
        suctionCollider = GetComponent<SphereCollider>();
        suctionCollider.isTrigger = true;

        if (vacuumController == null)
        {
            vacuumController = GetComponentInParent<VacuumBagController>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<DebrisItem>(out var debris))
        {
            vacuumController.TryCollectDebris(debris);
        }
    }

    public void UpgradeRadius(float newRadius)
    {
        suctionCollider.radius = newRadius;
    }
}
