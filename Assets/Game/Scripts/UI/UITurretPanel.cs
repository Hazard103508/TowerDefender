using System;
using TowerDefender.Application.Services;
using UnityEngine;

namespace TowerDefender.Game.UI
{
    public class UITurretPanel : MonoBehaviour
    {
        [SerializeField] private UITurretButton buttonPrefab;

        private void Start() // TODO - AWAKE
        {
            InstantiateButtons();
        }
        private void InstantiateButtons()
        {
            Array.ForEach(AllServices.MatchService.DefaultMatchProfile.Turrets, t =>
            {
                var btn = Instantiate(buttonPrefab, transform);
                btn.gameObject.SetActive(true);
                btn.name = $"Button{t.name}";
                btn.Initialize(t);
            });
        }
    }
}
