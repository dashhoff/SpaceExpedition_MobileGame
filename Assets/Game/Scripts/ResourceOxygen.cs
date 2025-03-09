using Unity.VisualScripting;
using UnityEngine;

public class ResourceOxygen : Resource
{
    [SerializeField] private float _oxygenAmount;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerResources playerResources = collision.gameObject.GetComponent<PlayerResources>();

            Collect(playerResources);
        }
    }

    public override void Collect(PlayerResources playerResources)
    {
        playerResources.AddOxygen(_oxygenAmount);

        Destroy();
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}