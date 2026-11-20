using UnityEngine;

public class IsInChargingStation : MonoBehaviour
{
    public bool isInChargingStation;

    void OnTriggerEnter(Collider other)
    {
        isInChargingStation = true;
        print("IM IN STATION");
    }

    void OnTriggerExit(Collider other)
    {
        isInChargingStation = false;
    }
}
