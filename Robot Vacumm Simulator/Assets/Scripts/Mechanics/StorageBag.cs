using UnityEngine;
using System;
using System.Collections.Generic;

public class StorageBag<T>
{
    public float maxCapacity { get; private set; }
    public float currentVolume { get; private set; }
    public bool isFull => currentVolume >= maxCapacity;

    readonly List<T> items = new List<T>();
    public IReadOnlyList<T> Items => items;

    public event Action onBagUpdated;
    public event Action onBagFull;

    public StorageBag(float maxCapacity)
    {
        this.maxCapacity = maxCapacity;
        currentVolume = 0f;
    }

    public bool TryAdd(T item, float itemVolume)
    {
        if (currentVolume + itemVolume > maxCapacity)
        {
            onBagFull?.Invoke();
            return false;
        }

        items.Add(item);
        currentVolume += itemVolume;
        onBagUpdated?.Invoke();
        return true;
    }

    public void EmptyBag()
    {
        items.Clear();
        currentVolume = 0f;
        onBagUpdated?.Invoke();
    }
}
