using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TowerDefender.Application.Services;
using TowerDefender.Commons;
using TowerDefender.Game.ScriptableObjects;
using UnityEngine;

namespace TowerDefender.Game.Environment
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private WaveProfile waveProfile;
        [SerializeField] private Transform EnemiesRoot;

        private int _spawnCount = 0;

        private void Start()
        {
            InitializeSpawn();  // ver...
        }
        public void InitializeSpawn()
        {
            _spawnCount = 0;
            Invoke("SpawnEnemy", waveProfile.CoolDownTime);
        }
        public void SpawnEnemy()
        {
            var prefab = AllServices.MatchService.DefaultMatchProfile.Enemies.Choose(1).First();
            var position = AllServices.MatchService.DefaultMatchProfile.SpawnPoints.Choose(1).First();

            var enemy = Instantiate(prefab, EnemiesRoot);
            enemy.transform.position = position;
            enemy.transform.LookAt(AllServices.MatchService.DefaultMatchProfile.TowerPosition);
            _spawnCount++;

            if (_spawnCount < waveProfile.EnemyCount)
                Invoke("SpawnEnemy", waveProfile.SpawnFrequency);
        }
    }
}