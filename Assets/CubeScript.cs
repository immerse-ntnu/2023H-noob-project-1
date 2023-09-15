using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    [SerializeField] float yThreshold;
    [SerializeField] int pointsOnFall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < yThreshold)
        {
            PlayerController.instance.score += pointsOnFall;
            Destroy(gameObject);
        }
    }
}
