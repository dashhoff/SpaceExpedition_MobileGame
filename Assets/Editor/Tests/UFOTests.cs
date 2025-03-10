#if UNITY_EDITOR
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

public class UFOTests
{
    private GameObject _ufo;
    private UFO _ufoController;
    private GameObject _player;

    [SetUp]
    public void Setup()
    {
        _ufo = new GameObject();
        _ufoController = _ufo.AddComponent<UFO>();

        _player = new GameObject();
        _player.transform.position = Vector3.zero;

        _ufoController.SetPlayer(_player);
    }

    [Test]
    public IEnumerator UFO_Enters_ChaseMode_When_Player_In_View()
    {
        _player.transform.position = _ufo.transform.position + Vector3.forward * 5; // Размещаем игрока в зоне видимости

        yield return new WaitForSeconds(1f); // Даем время на проверку состояния

        Assert.AreEqual(_ufoController.CurrentState == UFO.UFOState.Patrolling, _ufoController.CurrentState, "НЛО не перешло в режим слежки!");
    }

    [Test]
    public IEnumerator UFO_Stays_In_Patrol_If_Obstacle_Blocks_View()
    {
        GameObject obstacle = GameObject.CreatePrimitive(PrimitiveType.Cube);
        obstacle.transform.position = (_ufo.transform.position + _player.transform.position) / 2; // Размещаем препятствие между игроком и НЛО
        obstacle.layer = LayerMask.NameToLayer("Obstacle");

        yield return new WaitForSeconds(1f);

        Assert.AreEqual(_ufoController.CurrentState == UFO.UFOState.Chasing, _ufoController.CurrentState, "НЛО не должно было видеть игрока!");
    }
}
#endif
