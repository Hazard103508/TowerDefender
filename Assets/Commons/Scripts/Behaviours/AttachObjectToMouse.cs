using UnityEngine;

namespace TowerDefender.Commons.Behaviours
{
    public class AttachObjectToMouse : MonoBehaviour
    {
        [SerializeField] private LayerMask _contactLayer;

        void Update()
        {
            Move();
        }
        private void Move()
        {
            if (GetPointerRayCast(out RaycastHit hit))
                this.transform.position = hit.point;
        }
        private bool GetPointerRayCast(out RaycastHit hit)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            return Physics.Raycast(ray, out hit, float.PositiveInfinity, _contactLayer);
        }
    }
}