using UnityEngine;

public class GoodBoy : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private Transform _lookObjectTransform;

    private void Start()
    {
        _lookObjectTransform = FindObjectOfType<Superman>().transform;
    }

    private void Update()
    {
        if (_lookObjectTransform)
        {
            Vector3 lookTo = _lookObjectTransform.position - transform.position;

            GoodBoyRotate(lookTo);
        }
    }

    private void GoodBoyRotate(Vector3 lookTo)
    {
        Quaternion rotation = Quaternion.LookRotation(lookTo);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * _rotationSpeed);
    }
}