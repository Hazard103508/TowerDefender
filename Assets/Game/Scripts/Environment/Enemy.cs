using TowerDefender.Game.ScriptableObjects;
using TowerDefender.Game.UI;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace TowerDefender.Game.Environment
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] EnemyProfile enemyProfile;
        [SerializeField] UILifeBar uILifeBar;
        
        public Vector3 GoalPosition;

        private void Awake()
        {
            uILifeBar.CurrentHP = uILifeBar.MaxHP = enemyProfile.DefaultHP;
            transform.LookAt(GoalPosition);
        }
        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, GoalPosition, enemyProfile.Speed * Time.deltaTime);
        }

        public void AddDamage(int amount)
        {
            uILifeBar.CurrentHP -= amount;
        }
    }
}