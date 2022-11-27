using Codes.Scripts.Utils;
using UnityEngine;

namespace Codes.Scripts
{
    public class ObjectPlacementManager : MonoBehaviour
    {
        public GameObject[] objects;
        [SerializeField] private Material[] materials;

        private GameObject _pendingObject;
        [SerializeField] private Material[] pendingMaterials;

        public int objectIndex;
        private Vector3 _pos;

        private RaycastHit _hit;
        [SerializeField] LayerMask layerMask;

        private bool canPlace;

        // Update is called once per frame
        private void Update()
        {
            if(_pendingObject != null)
            {
                float offset = UtilsClass.GetGameObjectHeight(_pendingObject) / 2;
                _pendingObject.transform.position = new Vector3(_pos.x, offset, _pos.z);
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

            if(Physics.Raycast(ray, out _hit, 1000, layerMask))
            {
                _pos = _hit.point;
            }
        }
        
        // Spawn selected object
        public void SelectObject()
        {
            _pendingObject = Instantiate(objects[objectIndex], _pos, transform.rotation);
        }
        
        // Place selected object
        public void PlaceObject()
        {
            _pendingObject.GetComponent<MeshRenderer>().material = materials[objectIndex];
            _pendingObject = null;
        }
        
        // Update the Material of the selected object
        void UpdateMaterials()
        {
            if(canPlace)
            {
                _pendingObject.GetComponent<MeshRenderer>().material = pendingMaterials[0];
            }
            else
            {
                _pendingObject.GetComponent<MeshRenderer>().material = pendingMaterials[1];
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
}
