using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CustomerState
{
    Idle,
    Walking,
    Shock,
    ShockWalking
}

public class CustomerBehaviour : MonoBehaviour
{
    public string customerName;
    public float hitPoint;
    public float speedModifier;
    public CustomerState state = CustomerState.Idle;
    public int screamPoint;
    public bool shock = false;
}