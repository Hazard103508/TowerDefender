using TowerDefender.Application.Services;
using TowerDefender.Commons.Behaviours;
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

        private void Awake()
        {
            AllServices.MatchService.OnMatchStateChanged.AddListener(OnMatchStateChanged);
        }
        private void OnDestroy() => AllServices.MatchService.OnMatchStateChanged.RemoveListener(OnMatchStateChanged);
        private void Update()
        {
            PlaceTurret();
            DisableTurretSpawner();
        }
        private void OnMatchStateChanged()
        {
            if (AllServices.MatchService.IsGameOver)
                ClearSelectedTurret();
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
            if (AllServices.MatchService.IsGameOver)
                return;

            if (_turret == null)
                return;

            if (EventSystem.current.IsPointerOverGameObject())
                return;

            if (Input.GetMouseButtonDown(0))
            {
                var finalTurret = Instantiate(_turret, _turret.transform.position, Quaternion.identity, turretRoot);
                finalTurret.name = _turret.name;
                finalTurret.AllowShoot = true;

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