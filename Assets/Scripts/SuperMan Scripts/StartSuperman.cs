using System.Collections.Generic;
using UnityEngine;

public class StartSuperman : MonoBehaviour
{
    public IList<Transform> AllEnemyTransforms => _allEnemyTransforms.AsReadOnly();

    [SerializeField] private Transform[] _boundsLeftUpRightDown;
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private int _numberOfEnemies;

    private List<Transform> _allEnemyTransforms = new List<Transform>();
    private EnemiesMarker _enemiesHierarñhyHome;

    private void Awake()
    {
        _enemiesHierarñhyHome = FindObjectOfType<EnemiesMarker>();

        for (int i = 0; i < _numberOfEnemies; i++)
        {
            Vector3 currentPosition = GetRandomPosition();
            GameObject currentEnemy = GetRandomEnemy();

            GameObject Enemy = Instantiate(currentEnemy, currentPosition, Quaternion.identity);
            Enemy.transform.SetParent(_enemiesHierarñhyHome.transform);

            _allEnemyTransforms.Add(Enemy.transform);
        }
    }

    private GameObject GetRandomEnemy() =>
                        _enemyPrefabs[Random.Range(0, 2)];

    private Vector3 GetRandomPosition() => 
                    new Vector3(Random.Range(_boundsLeftUpRightDown[0].position.x, _boundsLeftUpRightDown[2].position.x),
                                0.5f, Random.Range(_boundsLeftUpRightDown[1].position.z, _boundsLeftUpRightDown[3].position.z));
}
