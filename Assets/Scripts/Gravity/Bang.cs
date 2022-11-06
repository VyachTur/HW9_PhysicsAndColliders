using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;

public class Bang : MonoBehaviour
{
    [SerializeField] private float _power;
    [SerializeField] private float _radius;
    [SerializeField] private float _upForce = 5f;
    [SerializeField] private ParticleSystem _bangEffect;
    [SerializeField] private AudioSource _bangSound;

    private void Start()
    {
        Invoke("MakeBang", 1f);
    }

    private void MakeBang()
    {
        var rigidbodies = new List<Collider>(Physics.OverlapSphere(transform.position, _radius))
                                                .Select(collider => collider.GetComponent<Rigidbody>())
                                                .Where(rigidbody => rigidbody != null)
                                                .ToArray();

        _bangEffect.Play();
        _bangSound.Play();

        foreach (Rigidbody rigidbody in rigidbodies)
            rigidbody.AddExplosionForce(_power, transform.position, _radius, _upForce, ForceMode.Impulse);
    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }

#endif
}
