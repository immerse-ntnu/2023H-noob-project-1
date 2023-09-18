using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    [SerializeField] float yThreshold;
    [SerializeField] int pointsOnFall;

    void Update()
    {
        if (transform.position.y < yThreshold)
        {
            PlayerController.instance.AddScore(pointsOnFall);
            Destroy(gameObject);
        }
    }
}
