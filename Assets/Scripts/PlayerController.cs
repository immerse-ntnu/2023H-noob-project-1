using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] float speed;
    private Rigidbody _rb;
    private Vector3 dragStartPosition;
    private Vector3 dragEndPosition;

    private void Awake()
    {
        instance = this;
        _rb = GetComponent<Rigidbody>();
    }

    private static Vector3 MousePos => Camera.main.ScreenToWorldPoint(
        new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            Camera.main.transform.position.y));

    void Update()
    {
        if (!GameController.instance.Active)
            return;
            // Drag and drop shooting logic
        if (Input.GetMouseButtonDown(0))
            dragStartPosition = MousePos;
        if (Input.GetMouseButtonUp(0))
        {
            dragEndPosition = MousePos;
            Shoot();
        }
    }
    private void Shoot()
    {
        var shootDirection = dragStartPosition - dragEndPosition;
        shootDirection.y = 0;
        if (shootDirection.magnitude < 0.1f)
            return;
        _rb.AddForce(shootDirection * speed, ForceMode.Impulse);
        GameController.instance.ChangeTurn();
    }

    private void OnCollisionEnter(Collision collision)
    {
        var rb = collision.gameObject.GetComponent<Rigidbody>();
        if (rb == null)
            return;

        var force = collision.gameObject.transform.position - transform.position;
        force = force.normalized;
        rb.AddForce(force * 1000);
    }

    public void AddScore(int pointsOnFall)
    {
        GameController.instance.OnAddCurrentPlayerScore(pointsOnFall);
    }
}
