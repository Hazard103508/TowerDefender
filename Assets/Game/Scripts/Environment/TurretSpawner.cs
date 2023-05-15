using TowerDefender.Application.Services;
using TowerDefender.Commons;
using TowerDefender.Game.Environment;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TowerDefender.Game.UI
{
    public class TurretSpawner : MonoBehaviour
    {
        [SerializeField] private Transform turretRoot;
        [SerializeField] private AudioSource _buildAudioSource;
        [SerializeField] private AttachObjectToMouse _attachObjectToMouse;
        private Turret _turret;

        private void Update()
        {
            PlaceTurret();
            DisableTurretSpawner();
        }

        public void Show(Turret turret)
        {
            ClearSelectedTurret();

            _turret = turret;
            InstantiateTurret();
        }
        private void InstantiateTurret()
        {
            _turret = Instantiate(_turret, transform);
            _turret.name = _turret.TurretProfile.name;
        }
        private void ClearSelectedTurret()
        {
            if (_turret != null)
                Destroy(_turret.gameObject);
        }
        private void PlaceTurret()
        {
            if (_turret == null)
                return;

            if (EventSystem.current.IsPointerOverGameObject())
                return;

            if (Input.GetMouseButtonDown(0))
            {
                var finalTurret = Instantiate(_turret, _turret.transform.position, Quaternion.identity, turretRoot);
                finalTurret.name = _turret.name;

                AllServices.CoinService.Remove(_turret.TurretProfile.BuildCost);
                _buildAudioSource.Play();
            }

            if (_turret.TurretProfile.BuildCost > AllServices.CoinService.Coins)
                ClearSelectedTurret();
        }
        private void DisableTurretSpawner()
        {
            if (Input.GetMouseButtonDown(1))
                ClearSelectedTurret();
        }
    }
}