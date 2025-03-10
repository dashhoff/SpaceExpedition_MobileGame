using UnityEngine;

public class RandomScaler : MonoBehaviour, IInitializable
{
    [SerializeField] private Vector3 _minScale;
    [SerializeField] private Vector3 _maxScale;

    [SerializeField] private Vector2 _randomScale;

    [SerializeField] private bool _autoStart;

    private void Start()
    {
        if (_autoStart)
            Init();
    }

    public void Init()
    {
        float randomScale = Random.Range(_randomScale.x, _randomScale.y);
        Vector3 newScale = new Vector3(randomScale, randomScale, randomScale);

        /*Vector3 randomScale = new Vector3(
            Random.Range(_minScale.x, _maxScale.x),
            Random.Range(_minScale.y, _maxScale.y),
            Random.Range(_minScale.z, _maxScale.z)
        );*/

        transform.localScale = newScale;
    }
}
