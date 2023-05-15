using System;
using TowerDefender.Game.Environment;
using UnityEngine;

namespace TowerDefender.Game.UI
{
    public class UITurretPanel : MonoBehaviour
    {
        [SerializeField] private Turret[] turretPrefabs;
        [SerializeField] private UITurretButton buttonPrefab;

        private void Awake()
        {
            InstantiateButtons();
        }
        private void InstantiateButtons()
        {
            Array.ForEach(turretPrefabs, t =>
            {
                var btn = Instantiate(buttonPrefab, transform);
                btn.gameObject.SetActive(true);
                btn.name = $"Button{t.name}";
                btn.Initialize(t);
            });
        }
    }
}
