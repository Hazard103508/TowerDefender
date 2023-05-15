using TowerDefender.Game.ScriptableObjects;
using UnityEngine;

namespace TowerDefender.Game.Environment
{
    public class Turret : MonoBehaviour
    {
        public TurretProfile TurretProfile;
        [SerializeField] private TurretRange turretRange;

        private void Awake()
        {
            turretRange.DrawCircle(20, TurretProfile.RadiusRange);
        }
    }
}