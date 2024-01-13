using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private BoxCollider _collider;

    private const string walk = "Walk";
    private const string attack = "Attack";
    private const string run = "Run";
    private const string stun = "Stun";
    void Start()
    {
        animator = GetComponent<Animator>();
        _collider.enabled = false;
    }

    public void IdleAnim()
    {
        animator.SetBool(walk, false);
        animator.SetBool(run, false);
        animator.SetBool(stun, false);
    }

    public void WalkAnim()
    {
        animator.SetBool(walk, true);
        animator.SetBool(run, false);
        animator.SetBool(stun, false);
    }

    public void RunAnim()
    {
        animator.SetBool(run, true);
        animator.SetBool(walk, false);
        animator.SetBool(stun, false);
    }
    public void AttackAnim()
    {
        //animator.SetBool(walk, false);
        animator.SetTrigger(attack);
        animator.SetBool(stun, false);
    }

    public void StunAnim()
    {
        animator.SetBool(stun, true);
    }

    public void onAttackHit()
    {
        _collider.enabled = true;
    }

    public void offAttackHit()
    {
        _collider.enabled = false;
    }
}
