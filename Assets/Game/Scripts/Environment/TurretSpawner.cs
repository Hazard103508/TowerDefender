using System.Reflection;
using TowerDefender.Application.Services;
using TowerDefender.Commons;
using TowerDefender.Game.ScriptableObjects;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

namespace TowerDefender.Game.UI
{
    public class TurretSpawner : MonoBehaviour
    {
        [SerializeField] private Transform turretRoot;
        [SerializeField] private AudioSource _buildAudioSource;

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
            InstantiateTurret();
        }
        private void InstantiateTurret()
        {
            turret = Instantiate(_turretProfile.Prefabs.Turret, transform);
            turret.name = _turretProfile.Prefabs.Turret.name;

            var maxRange = Instantiate(_turretProfile.Prefabs.Range, turret.transform);
            maxRange.name = "Range";
            maxRange.DrawCircle(20, _turretProfile.RadiusRange);
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
                var finalTurret = Instantiate(turret, turret.transform.position, Quaternion.identity, turretRoot);
                finalTurret.name = turret.name;

                AllServices.CoinService.Remove(_turretProfile.BuildCost);
                _buildAudioSource.Play();
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