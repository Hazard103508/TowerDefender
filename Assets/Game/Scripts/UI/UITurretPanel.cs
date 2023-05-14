using System;
using TowerDefender.Game.ScriptableObjects;
using UnityEngine;

namespace TowerDefender.Game.UI
{
    public class UITurretPanel : MonoBehaviour
    {
        [SerializeField] private TurretProfile[] turretProfiles;
        [SerializeField] private UITurretButton buttonPrefab;

        private void Awake()
        {
            InstantiateButtons();
        }
        private void InstantiateButtons()
        {
            Array.ForEach(turretProfiles, t =>
            {
                var btn = Instantiate(buttonPrefab, transform);
                btn.gameObject.SetActive(true);
                btn.name = $"Button{t.name}";
                btn.Initialize(t);
            });
        }
    }
}
