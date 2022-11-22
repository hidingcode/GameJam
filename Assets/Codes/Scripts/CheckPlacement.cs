using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckPlacement : MonoBehaviour
{
    ObjectPlacementManager objPlacementManager;

    // Start is called before the first frame update
    void Start()
    {
        objPlacementManager = GameObject.Find("ObjectPlacementManager").GetComponent<ObjectPlacementManager>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            objPlacementManager.SetCanPlace(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (other.gameObject.CompareTag("Object"))
        {
            objPlacementManager.SetCanPlace(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Object"))
        {
            objPlacementManager.SetCanPlace(true);
        }
    }

}
