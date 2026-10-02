using Unity.VisualScripting;
using UnityEngine;

public abstract class Collectible<T> : MonoBehaviour
{
    [SerializeField] protected T data;
    public T Data => data;
    public abstract bool Collect(GameObject collector);
}
