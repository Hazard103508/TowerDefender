using TowerDefender.Game.Environment;
using UnityEngine;

public class _BORRAR : MonoBehaviour
{
    public BaseTower baseTower;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            baseTower.AddDamage(10);
    }
}
