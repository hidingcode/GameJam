using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Utils;

public class ObjectPlacementManager : MonoBehaviour
{
    public GameObject[] objects;
    [SerializeField] private Material[] materials;

    private GameObject pendingObject;
    [SerializeField] private Material[] pendingMaterials;

    public int objectIndex;
    private Vector3 pos;

    private RaycastHit hit;
    [SerializeField] LayerMask layerMask;

    private bool canPlace;

    // Update is called once per frame
    private void Update()
    {   
        if(pendingObject != null)
        {   
            float offset = UtilsClass.GetGameObjectHeight(pendingObject) / 2;
            pendingObject.transform.position = new Vector3(pos.x, offset, pos.z);
            UpdateMaterials();

            if(Input.GetMouseButtonDown(0) && canPlace)
            {
                PlaceObject();
            }
        }
    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            pos = hit.point;
        }
    }

    public void SelectObject()
    {
        pendingObject = Instantiate(objects[objectIndex], pos, transform.rotation);
    }

    public void PlaceObject()
    {
        pendingObject.GetComponent<MeshRenderer>().material = materials[objectIndex];
        pendingObject = null;
    }

    void UpdateMaterials()
    {
        if(canPlace)
        {
            pendingObject.GetComponent<MeshRenderer>().material = pendingMaterials[0];
        }
        else
        {
            pendingObject.GetComponent<MeshRenderer>().material = pendingMaterials[1];
        }
    }

    public void SetObjectIndex(int index)
    {
        objectIndex = index;
    }

    public void SetCanPlace(bool condition)
    {
        canPlace = condition;
    }

    public bool GetCanPlace()
    {
        return canPlace;
    }
}
