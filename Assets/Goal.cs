using UnityEngine;

public class Goal : MonoBehaviour
{
	private void OnTriggerExit(Collider other)
	{
		if (!other.gameObject.TryGetComponent(out CubeScript cubeScript))
			return;
		if (GameController.instance.Active)
			PlayerController.instance.AddScore(cubeScript.PointsOnFall);
		Destroy(other.gameObject);
	}
}
