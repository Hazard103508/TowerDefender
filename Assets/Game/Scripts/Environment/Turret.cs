using TowerDefender.Application.Services;
using TowerDefender.Game.ScriptableObjects;
using UnityEngine;

namespace TowerDefender.Game.Environment
{
    public class Turret : MonoBehaviour
    {
        public TurretProfile TurretProfile;
        [SerializeField] private TurretRange turretRange;
        [SerializeField] private Projectile projectile;
        [SerializeField] private CapsuleCollider collider;
        public bool AllowShoot;


        private float _shootCooldown;

        private void Awake()
        {
            _shootCooldown = 0;
            AllowShoot = false;
            turretRange.DrawCircle(20, TurretProfile.RadiusRange);
            collider.radius = TurretProfile.RadiusRange;
        }
        private void Update()
        {
            _shootCooldown = Mathf.Max(0, _shootCooldown - Time.deltaTime);
        }
        private void OnTriggerStay(Collider other)
        {
            if (!AllowShoot)
                return;

            if (AllServices.MatchService.IsGameOver)
                return;

            if (other.gameObject != null && other.gameObject.CompareTag("Enemy"))
            {
                if (_shootCooldown == 0)
                {
                    _shootCooldown = TurretProfile.FiringCoolDown;
                    projectile.gameObject.SetActive(true);
                    projectile.transform.localPosition = Vector3.zero;
                    projectile.Shoot(TurretProfile.ProjectileProfile, other.transform.position);
                }
            }
        }
    }
}