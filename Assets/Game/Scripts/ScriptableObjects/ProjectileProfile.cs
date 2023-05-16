using UnityEngine;


namespace TowerDefender.Game.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ProjectileProfile", menuName = "ScriptableObjects/Game/ProjectileProfile", order = 2)]
    public class ProjectileProfile : ScriptableObject
    {
        public ProjectileEffect EffectType;
        public float EffectValue;
        public float Speed;
    }

    public enum ProjectileEffect
    { 
        Damage,
        Freezing
    }
}
