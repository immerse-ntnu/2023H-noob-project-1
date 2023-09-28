using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FartPower : MonoBehaviour
{
    private ParticleSystem _particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        _particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameController.instance.Active)
            return;
        if (!Input.GetKeyDown(KeyCode.F))
            return;
        _particleSystem.Play();
        var colliders = Physics.OverlapSphere(transform.position, 5f);
        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out Rigidbody rb))
            {
                var distance = collider.transform.position - transform.position;
                var force = 1000 * distance.normalized;
                rb.AddForce(force);
            }
        }
    }
}
