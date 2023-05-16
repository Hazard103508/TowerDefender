using System.Collections;
using TowerDefender.Game.ScriptableObjects;
using UnityEngine;


namespace TowerDefender.Game.Environment
{
    public class Projectile : MonoBehaviour
    {
        [HideInInspector] public ProjectileProfile ProjectileProfile;


        public void Shoot(ProjectileProfile projectileProfile, Vector3 targetPosition)
        {
            ProjectileProfile = projectileProfile;
            StartCoroutine(ShootCO(targetPosition));
        }

        private IEnumerator ShootCO(Vector3 targetPosition)
        {
            while (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, ProjectileProfile.Speed * Time.deltaTime);
                yield return null;
            }

            gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject != null && other.gameObject.CompareTag("Enemy"))
            {
                var enemy = other.gameObject.GetComponent<Enemy>();

                switch (ProjectileProfile.EffectType)
                {
                    case ProjectileEffect.Damage:
                        enemy.AddDamage((int)ProjectileProfile.EffectValue);
                        break;
                    case ProjectileEffect.Freezing:
                        enemy.AlterSpeed(ProjectileProfile.EffectValue);
                        break;
                }
            }
        }
    }
}