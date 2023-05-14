using System.Reflection;
using TowerDefender.Application.Services;
using TowerDefender.Commons;
using TowerDefender.Game.ScriptableObjects;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TowerDefender.Game.UI
{
    public class TurretSpawner : MonoBehaviour
    {
        [SerializeField] private Transform turretRoot;
        private AttachObjectToMouse _attachObjectToMouse;
        private TurretProfile _turretProfile;
        private GameObject turret;

        private void Awake()
        {
            _attachObjectToMouse = GetComponent<AttachObjectToMouse>();
        }
        private void Update()
        {
            PlaceTurret();
            DisableTurretSpawner();
        }

        public void Show(TurretProfile turretProfile)
        {
            ClearSelectedTurret();

            _turretProfile = turretProfile;
            turret = Instantiate(turretProfile.Prefab, transform);
        }
        private void ClearSelectedTurret()
        {
            if (turret != null)
                Destroy(turret);

            _turretProfile = null;
        }
        private void PlaceTurret()
        {
            if (turret == null)
                return;

            if (EventSystem.current.IsPointerOverGameObject())
                return;

            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(turret, turret.transform.position, Quaternion.identity, turretRoot);
                AllServices.CoinService.Remove(_turretProfile.BuildCost);
            }

            if (_turretProfile.BuildCost > AllServices.CoinService.Coins)
                ClearSelectedTurret();
        }
        private void DisableTurretSpawner()
        {
            if (Input.GetMouseButtonDown(1))
                ClearSelectedTurret();
        }
    }
}