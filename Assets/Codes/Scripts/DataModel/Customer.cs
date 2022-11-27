using UnityEngine;

namespace Codes.Scripts.DataModel
{
    [CreateAssetMenu(fileName = "Customer", menuName = "Data/Customer")]
    public class Customer : ScriptableObject
    {   
        public enum CustomerState
        {
            Idle,
            Walking,
            Shock,
            ShockWalking
        }
    
        public string customerName;
    
        // To prevent from modify the whole data please make a copy of the data
        [Header("Customer Stats")]
        public float hitPoint;
        public float speedModifier;
        public int screamPoint;
        public bool shock = false;
    }
}