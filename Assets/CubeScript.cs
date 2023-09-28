using UnityEngine;

public class CubeScript : MonoBehaviour
{
    [field: SerializeField] public int PointsOnFall { get; private set; }

    private void Update()
    {
        if (transform.position.y < -50)
            Destroy(gameObject);
    }
}
