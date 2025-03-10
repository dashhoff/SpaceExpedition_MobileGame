using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _objectsToSpawn;
    [SerializeField] private Vector3 _spawnAreaSize;
    [SerializeField] private Vector2 _spawnCount;
    [SerializeField] private Transform _parent;

    private void Start()
    {
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        float count = Random.Range(_spawnCount.x, _spawnCount.y);

        for (int i = 0; i < count; i++)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(-_spawnAreaSize.x / 2, _spawnAreaSize.x / 2),
                Random.Range(-_spawnAreaSize.y / 2, _spawnAreaSize.y / 2),
                Random.Range(-_spawnAreaSize.z / 2, _spawnAreaSize.z / 2)
            ) + transform.position;

            GameObject obj = Instantiate(
                _objectsToSpawn[Random.Range(0, _objectsToSpawn.Length)],
                spawnPosition,
                Quaternion.identity,
                _parent
            );

            //CallInit(obj);
        }
    }

    private void CallInit(GameObject obj)
    {
        var initMethod = obj.GetComponent(typeof(IInitializable)) as IInitializable;
        initMethod?.Init();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position, _spawnAreaSize);
    }
}

public interface IInitializable
{
    void Init();
}
