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
            GameObject spawnedAsteroids = Instantiate(_prefabsAsteroid, Vector3.zero, Quaternion.identity);
            spawnedAsteroids.GetComponent<Asteroids>().Initialize(Direction.Down);
        }
    }
}
