using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] float speed;
    private Rigidbody _rb;

    [field: SerializeField] public int Score { get; private set; }

    private void Awake()
    {
        instance = this;
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!GameController.instance.Active)
            return;
        var x = Input.GetAxis("Horizontal") * speed;
        var y = Input.GetAxis("Vertical") * speed;
        _rb.velocity = speed * new Vector3(x, 0, y);
    }

    void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (rb == null)
        {
            return;
        }

        Vector3 force = collision.gameObject.transform.position - transform.position;
        force = force.normalized;
        rb.AddForce(force * 1000);
    }

    public void AddScore(int pointsOnFall)
    {
        Score += pointsOnFall;
        GameController.instance.OnUpdateScore(Score);
    }
}
