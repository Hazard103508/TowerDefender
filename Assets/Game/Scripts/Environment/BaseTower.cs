using Newtonsoft.Json.Linq;
using TowerDefender.Game.ScriptableObjects;
using TowerDefender.Game.UI;
using UnityEngine;

namespace TowerDefender.Game.Environment
{
    public class BaseTower : MonoBehaviour
    {
        [SerializeField] BaseTowerProfile baseTowerProfile;
        [SerializeField] UILifeBar uILifeBar;


        private void Awake()
        {
            uILifeBar.CurrentHP = uILifeBar.MaxHP = baseTowerProfile.DefaultHP;
        }

        public void AddDamage(int amount)
        {
            uILifeBar.CurrentHP -= amount;
        }
    }
}