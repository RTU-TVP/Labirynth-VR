using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private float lookRadius = 10f;

    [SerializeField]
    private float attackRange = 3f;

    [SerializeField]
    private EnemyAnimationController _animationController;

    [SerializeField]
    private float stunTimer = 0f;

    [SerializeField]
    private float attackCooldown = 5f;
    private float attackCooldownTimer = 0f;

    [Header("Audio")]
    [SerializeField] AudioSource _audioSource;
    [SerializeField] GameObject _roar;
    [SerializeField] AudioClip _footstep;
    [SerializeField] AudioClip _run;

    private bool isRoar = false;
    private enum EnemyState
    {
        Patroling,
        Chase,
        Attack,
        AttackCoolDown,
        Stun
    }

    [SerializeField] private EnemyState currentState;
    private Vector3 patrolPoint;

    [SerializeField]
    private float patrolTimer = 15f;
    private float timer;

    private bool inRadius;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        _audioSource = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        currentState = EnemyState.Patroling;
        FindRandomPatrolPoint();
        _roar.gameObject.SetActive(false);
        _animationController = GetComponent<EnemyAnimationController>();
    }


    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        player.GetComponent<PlayerSound>().PlayHeartBeat(inRadius);

        if (stunTimer > 0f)
        {
            stunTimer -= Time.deltaTime;
            currentState = EnemyState.Stun;
        }
        if (attackCooldownTimer > 0f)
        {
            attackCooldownTimer -= Time.deltaTime;
        }

        switch (currentState)
        {
            case EnemyState.Patroling:
                Patrol();
                break;
            case EnemyState.Chase:
                Chase();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.AttackCoolDown:
                _animationController.IdleAnim();
                agent.isStopped = true;
                break;
            case EnemyState.Stun:
                Stun();
                break;
        }

        if (distance <= attackRange)
        {
            currentState = EnemyState.Attack;
            inRadius = true;
        }
        else if (distance <= lookRadius)
        {
            currentState = EnemyState.Chase;
            inRadius = true;
        }
        else
        {
            currentState = EnemyState.Patroling;
            inRadius = false;
        }

    }

    private void PlayAudio(AudioClip clip)
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.PlayOneShot(clip);
        }
    }

    private void Stun()
    {
        _animationController.StunAnim();
        agent.isStopped = true;

        if (stunTimer <= 0f)
        {
            currentState = EnemyState.Patroling;
            FindRandomPatrolPoint();
            agent.isStopped = false;
        }

        isRoar = false;
    }

    private void Patrol()
    {
        timer += Time.deltaTime;

        if (timer >= patrolTimer)
        {
            FindRandomPatrolPoint();
            timer = 0f;
        }

        agent.SetDestination(patrolPoint);

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            FindRandomPatrolPoint();
        }

        _roar.gameObject.SetActive(false);

        FaceToTargetSmooth(agent.velocity.normalized);

        _animationController.WalkAnim();

        PlayAudio(_footstep); 
        isRoar = false;
    }

    private void Chase()
    {
        agent.SetDestination(player.position);
        _animationController.RunAnim();

        agent.speed = 6;

        FaceToTargetSmooth(agent.velocity.normalized);

        if(!_audioSource.isPlaying && !isRoar)
        {
            _roar.gameObject.SetActive(true);
            isRoar = true;
        }
        PlayAudio(_run);
    }

    private void Attack()
    {
        if (attackCooldownTimer <= 0f)
        {
            //Логика атаки
            
            _animationController.AttackAnim();
            FaceToTargetSmooth(agent.velocity.normalized);

            currentState = EnemyState.AttackCoolDown;
            attackCooldownTimer = attackCooldown;
        }

        isRoar = false;
        PlayAudio(_run);
    }

    private void FindRandomPatrolPoint()
    {
        float patrolRadius = 25f;
        Vector3 randomPoint = transform.position + UnityEngine.Random.insideUnitSphere * patrolRadius;

        NavMeshHit hit;
        NavMesh.SamplePosition(randomPoint, out hit, patrolRadius, 1);
        patrolPoint = hit.position;
    }

    private void FaceToTargetSmooth(Vector3 targetDirection)
    {
        if (targetDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    public void HitStun(float duration)
    {
        stunTimer = duration;
    }
}
