using System.Collections;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    [SerializeField] int pointsOnFall;
    private const float Y_THRESHOLD = -0.8f;

    void Update()
    {
        if (transform.position.y < Y_THRESHOLD)
        {
            if (GameController.instance.Active)
                PlayerController.instance.AddScore(pointsOnFall);
            Destroy(gameObject);
        }
    }
}
