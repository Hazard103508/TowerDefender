using TowerDefender.Application.Services;
using TowerDefender.Game.ScriptableObjects;
using TowerDefender.Game.UI;
using UnityEngine;

namespace TowerDefender.Game.Environment
{
    public class BaseTower : MonoBehaviour
    {
        [SerializeField] private UILifeBar uILifeBar;
        [SerializeField] private AudioSource _damageAudio;

        private void Start() // TODO - AWAKE
        {
            uILifeBar.CurrentHP = uILifeBar.MaxHP = AllServices.MatchService.DefaultMatchProfile.HP;
            transform.position = AllServices.MatchService.DefaultMatchProfile.TowerPosition;
        }

        private void TakeDamage(int amount)
        {
            uILifeBar.CurrentHP -= amount;
            _damageAudio.Play();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject != null && other.gameObject.CompareTag("Enemy"))
            {
                var enemy = other.gameObject.GetComponent<Enemy>();
                TakeDamage(enemy.EnemyProfile.DamagePoint);
                Destroy(enemy.gameObject);
            }
        }
    }
}