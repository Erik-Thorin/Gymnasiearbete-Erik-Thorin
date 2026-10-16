using UnityEngine;
[RequireComponent(typeof(Collider))]
public class DebrisItem : Collectible<DebrisData>
{
    public bool isCollected = false;
    private void Awake()
    {
        GetComponent<Collider>().isTrigger = true;
    }
    
    public override bool Collect(GameObject collector)
    {
        if (isCollected)
        {
            return false;
        }
        isCollected = true;
        if (data.collectionFxPrefab != null)
        {
            Instantiate(data.collectionFxPrefab, transform.position, Quaternion.identity);
        }

        if (CleanlinessManager.Instance != null)
        {
            CleanlinessManager.Instance.RegisterDebrisCollected(data);
        }

        Destroy(gameObject);
        return true;
    }
}
