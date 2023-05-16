using System.Collections;
using TowerDefender.Application.Services;
using TowerDefender.Game.ScriptableObjects;
using TowerDefender.Game.UI;
using UnityEngine;
using UnityEngine.Events;

namespace TowerDefender.Game.Environment
{
    public class Enemy : MonoBehaviour
    {
        public EnemyProfile EnemyProfile;
        [SerializeField] private UILifeBar uILifeBar;

        public UnityEvent<Enemy> onKilled;
        private float _speedModifier;

        private void Start() // TODO - AWAKE
        {
            _speedModifier = 1;
            uILifeBar.CurrentHP = uILifeBar.MaxHP = EnemyProfile.DefaultHP;
        }
        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, AllServices.MatchService.DefaultMatchProfile.TowerPosition, _speedModifier * EnemyProfile.Speed * Time.deltaTime);
        }

        public void AddDamage(int amount)
        {
            uILifeBar.CurrentHP -= amount;
            if (uILifeBar.CurrentHP == 0)
            {
                AllServices.CoinService.Add(EnemyProfile.goldReward);
                Kill();
            }
        }
        public void AlterSpeed(float speedModifier)
        {
            _speedModifier = speedModifier;
            Invoke("RestoreSpeedModifier", 5);
        }

        public void Kill()
        {
            onKilled.Invoke(this);
            Destroy(gameObject);
        }

        private void RestoreSpeedModifier() => _speedModifier = 1;
    }
}