using UnityEngine;

public class GameEntryPoint : MonoBehaviour
{
    [SerializeField] private PlayerResources PlayerResources;



    private void Start()
    {
        Init();
    }

    private void Init()
    {
        PlayerResources.Init();
    }
}
