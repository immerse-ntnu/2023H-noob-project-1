using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FartPower : MonoBehaviour
{
    [SerializeField] float cooldown = 1f;
    [SerializeField] Image fartCooldownImage;

    private float currentCooldown;
    private ParticleSystem _particleSystem;
    private List<AudioSource> _audioSources = new();

    // Start is called before the first frame update
    void Start()
    {
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        foreach (var source in GetComponents<AudioSource>())
        {
            _audioSources.Add(source);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentCooldown -= Time.deltaTime;
        fartCooldownImage.fillAmount = Mathf.Clamp(currentCooldown / cooldown, 0f, 1f);

        if (!GameController.instance.Active)
            return;
        if (!Input.GetKeyDown(KeyCode.F))
            return;
        if (currentCooldown > 0)
            return;
        _particleSystem.Play();
        _audioSources[Random.Range(0, _audioSources.Count)].Play();
        currentCooldown = cooldown;
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
