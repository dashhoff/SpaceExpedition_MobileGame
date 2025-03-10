using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UI_Panel : MonoBehaviour
{
    [SerializeField] private Image _background;
    [SerializeField] private GameObject _panel;

    [SerializeField] private float _backAlpha = 0.45f;
    [SerializeField] private float _timeToFade = 0.5f;

    public void OpenPanel()
    {
        if (_background == null)
        {
            _panel.SetActive(true);
            return;
        }

        _panel.SetActive(true);

        StartCoroutine(FadeBackground(_background.color.a, _backAlpha));
    }

    public void ClosePanel()
    {
        if (_background == null)
        {
            _panel.SetActive(false);
            return;
        }
        StartCoroutine(FadeBackground(_background.color.a, 0, () => {
            _panel.SetActive(false);
        }));
    }

    private IEnumerator FadeBackground(float startAlpha ,float targetAlpha, System.Action onComplete = null)
    {
        float time = 0;
        while (time < _timeToFade)
        {
            SetAlpha(Mathf.Lerp(startAlpha, targetAlpha, time / _timeToFade));
            //_backAlpha = Mathf.Lerp(startAlpha, targetAlpha, time / _timeToFade );
            time += Time.unscaledDeltaTime;
            yield return null;
        }

        SetAlpha(targetAlpha);
        onComplete?.Invoke();
    }

    private void SetAlpha(float alpha)
    {
        Color color = _background.color;
        color.a = alpha;
        _background.color = color;
    }
}
