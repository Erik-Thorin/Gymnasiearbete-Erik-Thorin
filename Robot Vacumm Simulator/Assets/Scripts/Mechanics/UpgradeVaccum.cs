using UnityEngine;

public class UpgradeVaccum : MonoBehaviour
{
    [Header("Vacumm Reference")]
    [SerializeField] VacuumBagController vacuumController;

    [Header("Player Movement")]
    [SerializeField] PlayerMovement playerMovement;

    float upgradeMaxBagCapacity = 1.25f;
    float upgradePlayerSpeed = 1.25f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vacuumController = FindFirstObjectByType<VacuumBagController>();
        playerMovement = FindFirstObjectByType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeMaxBagCapacity()
    {
        vacuumController.maxBagCapacity *= upgradeMaxBagCapacity;
        upgradeMaxBagCapacity *= 0.25f;
    }
}
