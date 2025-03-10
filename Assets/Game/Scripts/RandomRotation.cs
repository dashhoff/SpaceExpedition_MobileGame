using UnityEngine;

public class RandomRotation : MonoBehaviour, IInitializable
{
    [SerializeField] private Vector3 _minRotation;
    [SerializeField] private Vector3 _maxRotation;

    [SerializeField] private bool _autoStart;

    private void Start()
    {
        if (_autoStart)
            Init();
    }

    public void Init()
    {
        gameObject.transform.Rotate(new Vector3(Random.Range(_minRotation.x, _maxRotation.x), Random.Range(_minRotation.y, _maxRotation.y), Random.Range(_minRotation.z, _maxRotation.z)));
    }
}
