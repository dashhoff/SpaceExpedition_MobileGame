using System.Collections;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    [SerializeField] private BlackHole _targetBlackHole;
    [SerializeField] private float _teleportDelay = 0.5f;
    private bool _canTeleport = true;

    private void OnTriggerEnter(Collider other)
    {
        if (_canTeleport && other.CompareTag("Player"))
        {
            StartCoroutine(TeleportPlayer(other.transform));
        }
    }

    private IEnumerator TeleportPlayer(Transform player)
    {
        _canTeleport = false;

        Vector3 offset = new Vector3(Random.Range(-25, 25), Random.Range(-25, 25), Random.Range(-25, 25));
        player.position = _targetBlackHole.transform.position + offset;

        _targetBlackHole.DisableTeleport();
        yield return new WaitForSeconds(_teleportDelay);
        _canTeleport = true;
    }

    public void DisableTeleport()
    {
        StartCoroutine(EnableTeleportAfterDelay());
    }

    private IEnumerator EnableTeleportAfterDelay()
    {
        yield return new WaitForSeconds(_teleportDelay);
        _canTeleport = true;
    }
}