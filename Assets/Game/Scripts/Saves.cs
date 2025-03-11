using UnityEngine;

public class Saves : MonoBehaviour
{
    private const string SensitivityKey = "Sensitivity";
    private const string GraphicsPresetKey = "GraphicsPreset";
    private const string TargetFPSKey = "TargetFPS";

    public static float Sensitivity
    {
        get => PlayerPrefs.GetFloat(SensitivityKey, 1f);
        set => PlayerPrefs.SetFloat(SensitivityKey, value);
    }

    public static int GraphicsPreset
    {
        get => PlayerPrefs.GetInt(GraphicsPresetKey, 2);
        set => PlayerPrefs.SetInt(GraphicsPresetKey, value);
    }

    public static int TargetFPS
    {
        get => PlayerPrefs.GetInt(TargetFPSKey, 60);
        set
        {
            PlayerPrefs.SetInt(TargetFPSKey, value);
            Application.targetFrameRate = value;
        }
    }

    public static void Save()
    {
        PlayerPrefs.Save();
    }
}
