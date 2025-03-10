using UnityEngine;
using UnityEngine.UI;

public class ObjectMarker : MonoBehaviour
{
    [SerializeField] private Transform _target; // Цель (объект)
    [SerializeField] private RectTransform _markerUI; // UI-метка
    [SerializeField] private Canvas _canvas; // Canvas с меткой
    [SerializeField] private float _screenOffset = 50f; // Отступ от краёв экрана

    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (_target == null) return;

        Vector3 screenPos = _mainCamera.WorldToScreenPoint(_target.position);
        bool isBehind = screenPos.z < 0; // Объект позади игрока

        if (isBehind)
        {
            // Отражаем позицию на экране
            screenPos.x = Screen.width - screenPos.x;
            screenPos.y = Screen.height - screenPos.y;

            // Направляем метку к границе экрана
            Vector3 dirToTarget = (_target.position - _mainCamera.transform.position).normalized;
            screenPos = GetEdgePosition(dirToTarget);
        }

        // Ограничиваем в пределах экрана
        screenPos.x = Mathf.Clamp(screenPos.x, _screenOffset, Screen.width - _screenOffset);
        screenPos.y = Mathf.Clamp(screenPos.y, _screenOffset, Screen.height - _screenOffset);

        _markerUI.gameObject.SetActive(true);
        _markerUI.position = screenPos;
    }

    private Vector3 GetEdgePosition(Vector3 direction)
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Vector3 screenDir = _mainCamera.WorldToScreenPoint(_mainCamera.transform.position + direction) - screenCenter;
        screenDir.z = 0;

        float maxX = (Screen.width - _screenOffset) / 2;
        float maxY = (Screen.height - _screenOffset) / 2;
        float scale = Mathf.Min(maxX / Mathf.Abs(screenDir.x), maxY / Mathf.Abs(screenDir.y));

        return screenCenter + screenDir * scale;
    }
}
