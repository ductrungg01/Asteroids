using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefabsAsteroid;

    // Start is called before the first frame update
    void Start()
    {
        if (_prefabsAsteroid)
        {
            GameObject spawnedAsteroidsTop = Instantiate(_prefabsAsteroid, Vector3.zero, Quaternion.identity);
            spawnedAsteroidsTop.GetComponent<Asteroids>().
                Initialize(Direction.Down, new Vector3(0, ScreenUtils.ScreenTop));

            GameObject spawnedAsteroidsLeft = Instantiate(_prefabsAsteroid, Vector3.zero, Quaternion.identity);
            spawnedAsteroidsLeft.GetComponent<Asteroids>().
                Initialize(Direction.Right, new Vector3(ScreenUtils.ScreenLeft, 0));

            GameObject spawnedAsteroidsBottom = Instantiate(_prefabsAsteroid, Vector3.zero, Quaternion.identity);
            spawnedAsteroidsBottom.GetComponent<Asteroids>().
                Initialize(Direction.Up, new Vector3(0, ScreenUtils.ScreenBottom));

            GameObject spawnedAsteroidsRight = Instantiate(_prefabsAsteroid, Vector3.zero, Quaternion.identity);
            spawnedAsteroidsRight.GetComponent<Asteroids>().
                Initialize(Direction.Left, new Vector3(ScreenUtils.ScreenRight, 0));
        }
    }
}
