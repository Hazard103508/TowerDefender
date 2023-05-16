using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TowerDefender.Application.Services;
using TowerDefender.Commons;
using TowerDefender.Commons.Extensions;
using TowerDefender.Game.ScriptableObjects;
using UnityEngine;

namespace TowerDefender.Game.Environment
{
    public class WaveSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _enemiesRoot;

        private int waveIndex = 0;
        private int _enemyKlled = 0;

        public WaveProfile CurrentWave => AllServices.MatchService.DefaultMatchProfile.Waves[waveIndex];

        private void Start()
        {
            StartWave();  // ver...
        }
        public void StartWave()
        {
            _enemyKlled = 0;
            AllServices.MatchService.MatchState = MatchState.CoolDown;
            StartCoroutine(ShowColdDown());
        }
        private IEnumerator ShowColdDown()
        {
            int _timer = CurrentWave.CoolDownTime;

            do
            {
                AllServices.MatchService.Timer = _timer--;
                yield return new WaitForSeconds(1);
            }
            while (_timer > 0);

            AllServices.MatchService.Timer = 0;
            AllServices.MatchService.MatchState = MatchState.WaveBegan;

            StartCoroutine(SpawnEnemy());
        }
        private IEnumerator SpawnEnemy()
        {
            int _spawnCount = 0;

            while (_spawnCount < CurrentWave.EnemyCount)
            {
                var prefab = AllServices.MatchService.DefaultMatchProfile.Enemies.Choose(1).First();
                var position = AllServices.MatchService.DefaultMatchProfile.SpawnPoints.Choose(1).First();

                var enemy = Instantiate(prefab, _enemiesRoot);
                enemy.transform.position = position;
                enemy.transform.LookAt(AllServices.MatchService.DefaultMatchProfile.TowerPosition);
                enemy.onKilled.AddListener(OnEnemyKilled);
                _spawnCount++;

                if (_spawnCount < CurrentWave.EnemyCount)
                    yield return new WaitForSeconds(CurrentWave.SpawnFrequency);

                if (AllServices.MatchService.IsGameOver)
                    break;
            }

            if (!AllServices.MatchService.IsGameOver)
                AllServices.MatchService.MatchState = MatchState.WaveEnded;
        }
        private void OnEnemyKilled(Enemy enemy)
        {
            _enemyKlled++;

            if (_enemyKlled == CurrentWave.EnemyCount)
            {
                if (waveIndex < AllServices.MatchService.DefaultMatchProfile.Waves.Length - 1)
                {
                    waveIndex++;
                    StartWave();
                }
                else
                    AllServices.MatchService.MatchState = MatchState.Win;
            }
        }
    }
}