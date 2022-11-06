using UnityEngine;

public class StartPool : MonoBehaviour
{
    [SerializeField] private Rigidbody _cueBallRB;
    [SerializeField] private float _impactForce;
    [SerializeField] private float _delay = 2f;

    private void Start()
    {
        Invoke("CueKick", _delay);
    }

    private void CueKick()
    {
        _cueBallRB.AddForce(_cueBallRB.transform.forward * _impactForce, ForceMode.Impulse);
    }
}
