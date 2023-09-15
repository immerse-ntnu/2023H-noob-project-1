using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] GameObject goodCubePrefab;
    [SerializeField] GameObject badCubePrefab;
    [SerializeField] float spawnRadius = 10;
    [SerializeField] int goodCubesCount = 100;
    [SerializeField] int badCubesCount = 10;

    // Start is called before the first frame update
    void Start()
    {
        SpawnCubes(goodCubePrefab, goodCubesCount);
        SpawnCubes(badCubePrefab, badCubesCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnCubes(GameObject prefab, int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject cube = Instantiate(prefab);
            Transform cubeTransform = cube.transform;
            Vector2 randomXZ = spawnRadius * Random.insideUnitCircle;
            cubeTransform.position = new Vector3(randomXZ.x, 1f, randomXZ.y);
        }
    }
}
