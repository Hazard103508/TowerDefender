using TowerDefender.Application.Services;
using TowerDefender.Game.ScriptableObjects;
using TowerDefender.Game.UI;
using UnityEngine;

namespace TowerDefender.Game.Environment
{
    public class Enemy : MonoBehaviour
    {
        public EnemyProfile EnemyProfile;
        [SerializeField] UILifeBar uILifeBar;

        private void Start() // TODO - AWAKE
        {
            uILifeBar.CurrentHP = uILifeBar.MaxHP = EnemyProfile.DefaultHP;
        }
        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, AllServices.MatchService.DefaultMatchProfile.TowerPosition, EnemyProfile.Speed * Time.deltaTime);
        }

        public void AddDamage(int amount)
        {
            uILifeBar.CurrentHP -= amount;
        }
    }
}