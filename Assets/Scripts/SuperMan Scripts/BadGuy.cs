using UnityEngine;

public class BadGuy : MonoBehaviour
{
    public int Health => _health;

    [SerializeField] private int _health = 1;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private GameObject _destroyedGO;

    private Transform _lookObjectTransform;
    private EnemiesMarker _enemiesHierarñhyHome;

    private void Awake()
    {
        _enemiesHierarñhyHome = FindObjectOfType<EnemiesMarker>();
    }

    private void Start()
    {
        _lookObjectTransform = FindObjectOfType<Superman>().transform;
    }

    private void Update()
    {
        if (_lookObjectTransform)
        {
            Vector3 lookTo = _lookObjectTransform.position - transform.position;

            BadGuyRotate(lookTo);
        }
    }

    private void BadGuyRotate(Vector3 lookTo)
    {
        Quaternion rotation = Quaternion.LookRotation(lookTo);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * _rotationSpeed);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);

        GameObject destroyBadGuy = Instantiate(_destroyedGO, transform.position, transform.rotation);
        destroyBadGuy.transform.SetParent(_enemiesHierarñhyHome.transform);

        Destroy(destroyBadGuy, 10f);
    }
}
