using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragManager : MonoBehaviour
{
    [SerializeField] GameObject mouseSphere;
    [SerializeField] RectTransform canvas;
    private Vector3 debugMousePos;
    private Vector3 debugMousePos2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(debugMousePos, Vector3.one);
        Gizmos.color = Color.red;
        Gizmos.DrawCube(debugMousePos2, Vector3.one);
    }

    // Update is called once per frame
    void Update()
    {
        // Get the mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Set a fixed Y position
        mousePosition.y = 1f;

        // Convert the screen position to world position relative to Camera.main
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));

        // Set the game object's position in world coordinates
        transform.position = worldPosition;

    }
}
