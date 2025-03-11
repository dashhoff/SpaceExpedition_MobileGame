using UnityEngine;
using UnityEngine.UI;

public class SensitivitySlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private void Init()
    {
        _slider.value = Saves.Sensitivity;
        _slider.onValueChanged.AddListener(UpdateSensitivity);
    }

    private void UpdateSensitivity(float value)
    {
        Saves.Sensitivity = value;
        Saves.Save();
    }
}
