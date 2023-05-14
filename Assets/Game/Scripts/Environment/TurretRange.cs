using UnityEngine;

namespace TowerDefender.Game.Environment
{
    public class TurretRange : MonoBehaviour
    {
        private LineRenderer _circleRender;

        private void Awake()
        {
            _circleRender = GetComponent<LineRenderer>();
        }
        public void DrawCircle(int steps, float radius)
        {
            _circleRender.positionCount = steps + 1;

            for (int currentStep = 0; currentStep < steps; currentStep++)
            {
                float circumferenceProgress = (float)currentStep / steps;
                float currentRadian = circumferenceProgress * 2 * Mathf.PI;

                float xScaled = Mathf.Cos(currentRadian);
                float zScaled = Mathf.Sin(currentRadian);

                float x = xScaled * radius;
                float z = zScaled * radius;

                Vector3 CurrentPosition = new Vector3(x, 0, z);
                _circleRender.SetPosition(currentStep, CurrentPosition);
            }

            var firstPosition = _circleRender.GetPosition(0);
            _circleRender.SetPosition(steps, firstPosition);
        }
    }
}