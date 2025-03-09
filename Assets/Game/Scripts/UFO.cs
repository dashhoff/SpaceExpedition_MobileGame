using UnityEngine;
using System.Collections;

public class UFO : MonoBehaviour
{
    public enum UFOState { Patrolling, Chasing }

    public UFOState CurrentState { get; private set; } = UFOState.Patrolling;

    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _chaseSpeed = 8f;
    [SerializeField] private float _detectionRadius = 15f;
    [SerializeField] private float _viewDistance = 20f;
    [SerializeField] private Transform _player;
    [SerializeField] private LayerMask _obstacleMask;

    private UFOState _currentState = UFOState.Patrolling;
    private Vector3 _patrolTarget;

    private void Start()
    {
        StartCoroutine(PatrolRoutine());
    }

    private void Update()
    {
        switch (_currentState)
        {
            case UFOState.Patrolling:
                Patrol();
                CheckForPlayer();
                break;

            case UFOState.Chasing:
                ChasePlayer();
                CheckIfLostPlayer();
                break;
        }
    }

    private void Patrol()
    {
        if (Vector3.Distance(transform.position, _patrolTarget) < 2f)
            SetRandomPatrolPoint();

        MoveTowards(_patrolTarget, _speed);
    }

    private void ChasePlayer()
    {
        if (_player != null)
            MoveTowards(_player.position, _chaseSpeed);
    }

    private void CheckForPlayer()
    {
        if (Vector3.Distance(transform.position, _player.position) <= _detectionRadius)
        {
            if (!Physics.Raycast(transform.position, (_player.position - transform.position).normalized, _viewDistance, _obstacleMask))
            {
                _currentState = UFOState.Chasing;
            }
        }
    }

    private void CheckIfLostPlayer()
    {
        if (Vector3.Distance(transform.position, _player.position) > _detectionRadius)
            _currentState = UFOState.Patrolling;
    }

    private void MoveTowards(Vector3 target, float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        //transform.LookAt(target);
    }

    private IEnumerator PatrolRoutine()
    {
        while (true)
        {
            if (_currentState == UFOState.Patrolling)
                SetRandomPatrolPoint();

            yield return new WaitForSeconds(5f);
        }
    }

    private void SetRandomPatrolPoint()
    {
        _patrolTarget = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), Random.Range(-50, 50));
    }

    public void SetPlayer(GameObject newPlayer)
    {
        _player = newPlayer.transform;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);
    }
}
