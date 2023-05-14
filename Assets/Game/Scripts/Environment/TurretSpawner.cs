using TowerDefender.Commons;
using TowerDefender.Game.ScriptableObjects;
using UnityEngine;

namespace TowerDefender.Game.UI
{
    public class TurretSpawner : MonoBehaviour
    {
        private AttachObjectToMouse _attachObjectToMouse;
        private GameObject turret;

        private void Awake()
        {
            _attachObjectToMouse = GetComponent<AttachObjectToMouse>();
        }
        private void Update()
        {
            // si hace click clonarlo y depositarlo en el mapa
            // mostrar rango de algance
        }

        public void Show(TurretProfile turretProfile)
        {
            if (turret != null)
                Destroy(turret);

            turret = Instantiate(turretProfile.Prefab, transform);
        }
    }
}