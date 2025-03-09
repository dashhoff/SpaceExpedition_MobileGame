using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerResources _playerResources;
    [SerializeField] private PlayerUI _playerUI;

    [SerializeField] private Rigidbody _rb;

    [SerializeField] private bool _victory = false;
    [SerializeField] private bool _defeat = false;

    private void Update()
    {
        float maxOxygen = _playerResources.MaxOxygen;
        float currentOxygen = _playerResources.CurrentOxygen;

        float maxFuel = _playerResources.MaxFuel;
        float currentFuel = _playerResources.CurrentFuel;

        _playerUI.UpdateOxygen(currentOxygen, maxOxygen);
        _playerUI.UpdateFuel(currentFuel, maxFuel);
    }

    public void Victory()
    {
        if (_victory || _defeat) return;

        _victory = true;

        EventController.InvokeVictory();
    }

    public void Defeat()
    {
        if (_victory || _defeat) return;

        _defeat = true;

        EventController.InvokeDefeat();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_victory || _defeat) return;

        if (collision.gameObject.CompareTag("UFO"))
            Defeat();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_victory || _defeat) return;

        if (other.gameObject.CompareTag("Finish"))
            Victory();
    }
}
