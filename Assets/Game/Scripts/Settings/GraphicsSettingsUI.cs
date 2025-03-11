using UnityEngine;
using UnityEngine.UI;

public class GraphicsSettingsUI : MonoBehaviour
{
    [SerializeField] private Dropdown _graphicsDropdown;
    [SerializeField] private Dropdown _fpsDropdown;

    private readonly int[] _fpsOptions = { 30, 60, 120, 144, 240 };

    private void Init()
    {
        _graphicsDropdown.value = Saves.GraphicsPreset;
        _fpsDropdown.value = GetFPSIndex(Saves.TargetFPS);

        _graphicsDropdown.onValueChanged.AddListener(SetGraphicsPreset);
        _fpsDropdown.onValueChanged.AddListener(SetTargetFPS);
    }

    private void SetGraphicsPreset(int index)
    {
        Saves.GraphicsPreset = index;
        QualitySettings.SetQualityLevel(index);
        Saves.Save();
    }

    private void SetTargetFPS(int index)
    {
        Saves.TargetFPS = _fpsOptions[index];
        Saves.Save();
    }

    private int GetFPSIndex(int fps)
    {
        for (int i = 0; i < _fpsOptions.Length; i++)
        {
            if (_fpsOptions[i] == fps) return i;
        }
        return 1;
    }
}
