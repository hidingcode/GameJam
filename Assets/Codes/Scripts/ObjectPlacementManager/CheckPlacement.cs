using UnityEngine;

namespace Codes.Scripts
{
    public class CheckPlacement : MonoBehaviour
    {
        ObjectPlacementManager _objPlacementManager;

        // Start is called before the first frame update
        void Start()
        {
            _objPlacementManager = GameObject.Find("ObjectPlacementManager").GetComponent<ObjectPlacementManager>();
        }

        private void Update()
        {   
            
            if(Input.GetMouseButtonDown(1))
            {
                _objPlacementManager.SetCanPlace(false);
            }
        }
        
        // Check if the object enter the trigger
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Object"))
            {
                _objPlacementManager.SetCanPlace(false);
            }
        }
        
        // Check if the object can exit the trigger
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Object"))
            {
                _objPlacementManager.SetCanPlace(true);
            }
        }

    }
}
