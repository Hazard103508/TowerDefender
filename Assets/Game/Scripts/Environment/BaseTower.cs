using TowerDefender.Application.Services;
using TowerDefender.Game.ScriptableObjects;
using TowerDefender.Game.UI;
using UnityEngine;

namespace TowerDefender.Game.Environment
{
    public class BaseTower : MonoBehaviour
    {
        [SerializeField] UILifeBar uILifeBar;

        private void Start()
        {
            uILifeBar.CurrentHP = uILifeBar.MaxHP = AllServices.MatchService.DefaultMatchProfile.HP;
            transform.position = AllServices.MatchService.DefaultMatchProfile.TowerPosition;
        }

        public void AddDamage(int amount)
        {
            uILifeBar.CurrentHP -= amount;
        }
    }
}