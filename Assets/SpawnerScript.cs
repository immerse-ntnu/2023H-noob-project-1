using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] GameObject cubePrefab;
    [SerializeField] float spawnRadius = 10;
    [SerializeField] int boxCount = 100;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < boxCount; i++)
        {
            GameObject cube = Instantiate(cubePrefab);
            Transform cubeTransform = cube.transform;
            Vector2 randomXZ = spawnRadius*Random.insideUnitCircle;
            cubeTransform.position = new Vector3(randomXZ.x, 1f, randomXZ.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
