using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefender.Game.UI
{
    public class UIAttachToObject : MonoBehaviour
    {
        [SerializeField] private GameObject attachObject;
        [SerializeField] private Vector2 _offSet;

        void Update()
        {
            var screenPosition = Camera.main.WorldToScreenPoint(attachObject.transform.position);
            transform.position = screenPosition + (Vector3)_offSet;
        }
    }
}