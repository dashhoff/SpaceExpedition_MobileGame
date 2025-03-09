using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private PlayerResources PlayerResources;

    [SerializeField] private TextMeshProUGUI _timerText;

    private float _timeRemaining;
    private bool _isTimerRunning;

    private void Start()
    {
        _isTimerRunning = true;
        UpdateTimerText();
    }

    private void Update()
    {
        if (_isTimerRunning)
        {
            //_timeRemaining -= Time.deltaTime;
            _timeRemaining = PlayerResources.CurrentOxygen;

            if (_timeRemaining <= 0)
            {
                _timeRemaining = 0;
                _isTimerRunning = false;
                OnTimerEnd();
            }

            UpdateTimerText();
        }
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(_timeRemaining / 60);
        int seconds = Mathf.FloorToInt(_timeRemaining % 60);
        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void OnTimerEnd()
    {
        Debug.Log("Время вышло!");
    }

    public void ResetTimer()
    {
        _isTimerRunning = true;
    }
}
