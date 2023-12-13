using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyController _enemyPrefab;
    [SerializeField] private int _enemyCount;

    private ColorsProvider _colorsProvider;

    public void Initialize(ColorsProvider colorsProvider)
    {
        _colorsProvider = colorsProvider;
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < _enemyCount; i++)
        {
            var position = GetRandomPosition();
            InstantiateEnemy(position);
        }
    }

    private void InstantiateEnemy(Vector3 position)
    {
        var enemy = Instantiate(_enemyPrefab, position, Quaternion.identity);
        enemy.Initialize(_colorsProvider.GetColor());
    }

    private static Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(-10f, 10f);
        float randomZ = Random.Range(-10f, 10f);
        
        return new Vector3(randomX, 0f, randomZ);
    }
}
