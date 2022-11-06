using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Superman : MonoBehaviour
{
    [SerializeField] private float _flySpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _hitPower;
    [SerializeField] private int _hitDamage = 1;

    private StartSuperman _startGame;
    private Rigidbody _playerRB;
    private Transform _destinationObject;
    private int _nextEnemy;

    private void Start()
    {
        _startGame = FindObjectOfType<StartSuperman>();
        _playerRB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_nextEnemy < _startGame.AllEnemyTransforms.Count)
            _destinationObject = _startGame.AllEnemyTransforms[_nextEnemy];

        PlayerRotate();

        IncrementNextEnemy();
    }

    private void IncrementNextEnemy()
    {
        if (!_destinationObject && _nextEnemy < _startGame.AllEnemyTransforms.Count - 1 ||
            _destinationObject && Vector3.Distance(transform.position, _destinationObject.position) <= 0.2f)
        {
            _nextEnemy++;
        }
    }

    private void PlayerRotate()
    {
        if (_destinationObject)
        {
            Vector3 direction = GetPlayerDirection();
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * _rotationSpeed);
        }
    }

    private Vector3 GetPlayerDirection() => (_destinationObject.position - transform.position).normalized;

    private void FixedUpdate()
    {
        if (_destinationObject)
        {
            if (Vector3.Distance(transform.position, _destinationObject.position) > 0.2f)
            {
                PlayerMove(_flySpeed);
            }
        }
            
    }

    private void PlayerMove(float speed) =>
         _playerRB.AddForceAtPosition(GetPlayerDirection() * speed, _destinationObject.position, ForceMode.VelocityChange);


    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody collisionRB = collision.gameObject.GetComponent<Rigidbody>();

        if (collisionRB)
        {
            BadGuy badGuy = collisionRB.GetComponent<BadGuy>();
            if (badGuy)
            {
                badGuy.TakeDamage(_hitDamage);
            }

            collisionRB.AddForce(transform.up * _hitPower, ForceMode.Impulse);
        }
    }
}
