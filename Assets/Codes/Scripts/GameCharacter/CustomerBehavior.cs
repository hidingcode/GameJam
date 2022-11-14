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

public class CustomerBehavior : MonoBehaviour
{
    // General information
    [SerializeField] public string customerName;

    // Character information
    [SerializeField] public float hitPoint;
    [SerializeField] public float speedModifier;
    [SerializeField] public CustomerState state = CustomerState.Idle;
    [SerializeField] public int screamPoint;

    // Start is called before the first frame update
    void Start()
    {
        this.state = CustomerState.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        if (hitPoint <= 0)
        {
            this.state = CustomerState.ShockWalking;
        }
    }
}