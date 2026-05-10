using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceNode : MonoBehaviour
{
    [Header("Resource Settings")]
    [SerializeField] private ResourceType resourceType;
    [SerializeField] private int currentAmount = 50;

    public ResourceType ResourceType => resourceType;
    public bool HasResource()
    {
        return currentAmount > 0;
    }
    public int Gather(int amount)
    {
        int gatherAmount = Mathf.Min(amount, currentAmount);
        currentAmount -= gatherAmount;
        return gatherAmount;
    }
}
