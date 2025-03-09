using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RectTransform _knob;
    [SerializeField] private float _radius = 100f;

    private Vector2 _input;

    public Vector2 Direction => _input.normalized;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = eventData.position - (Vector2)transform.position;
        _input = Vector2.ClampMagnitude(pos, _radius);
        _knob.localPosition = _input;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _input = Vector2.zero;
        _knob.localPosition = Vector2.zero;
    }
}
