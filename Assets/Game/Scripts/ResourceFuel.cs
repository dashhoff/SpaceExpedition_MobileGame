using UnityEngine;

public class ResourceFuel : Resource
{
    [SerializeField] private float _fuelAmount;

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
        playerResources.AddFuel(_fuelAmount);

        Destroy();
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}