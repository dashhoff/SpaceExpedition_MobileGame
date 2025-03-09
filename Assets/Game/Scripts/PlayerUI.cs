using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Image _oxygenBar;
    [SerializeField] private Image _fuelBar;

    public void UpdateOxygen(float current, float max)
    {
        _oxygenBar.fillAmount = current / max;
    }

    public void UpdateFuel(float current, float max)
    {
        _fuelBar.fillAmount = current / max;
    }
}
