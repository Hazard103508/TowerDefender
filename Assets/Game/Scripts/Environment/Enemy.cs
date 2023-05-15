using TowerDefender.Application.Services;
using TowerDefender.Game.ScriptableObjects;
using TowerDefender.Game.UI;
using UnityEngine;

namespace TowerDefender.Game.Environment
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] EnemyProfile enemyProfile;
        [SerializeField] UILifeBar uILifeBar;

        private void Start() // TODO - AWAKE
        {
            uILifeBar.CurrentHP = uILifeBar.MaxHP = enemyProfile.DefaultHP;
            transform.LookAt(AllServices.MatchService.DefaultMatchProfile.TowerPosition);
        }
        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, AllServices.MatchService.DefaultMatchProfile.TowerPosition, enemyProfile.Speed * Time.deltaTime);
        }

        public void AddDamage(int amount)
        {
            uILifeBar.CurrentHP -= amount;
        }
    }
}