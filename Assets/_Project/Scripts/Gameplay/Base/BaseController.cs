using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    [SerializeField] private int storedResources;
    
    public void Deposit(int amount)
    {
        storedResources += amount;
        Debug.Log($"Base Resources: {storedResources}");
    }
}
