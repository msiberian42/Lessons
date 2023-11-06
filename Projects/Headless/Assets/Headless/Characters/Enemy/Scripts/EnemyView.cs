using EnemyMVC;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyView : ViewBase
{
    [SerializeField] private AudioSource attackingSound;
    [SerializeField] private AudioSource dyingSound;

    private SpriteRenderer sprite;
    private Animator anim;
    private State state;
    private Direction direction;

    private const string idleAnim = "Idle";
    private const string attackingAnim = "Attacking";
    private const string movingAnim = "Moving";
    private const string deathAnim = "Death";

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    public override void OnStateChanged(State state, Direction direction)
    {
        if (state == this.state && direction == this.direction)
        {
            return;
        }

        this.state = state;
        this.direction = direction;

        if (direction == Direction.Left)
            sprite.flipX = false;
        else
            sprite.flipX = true;
        
        switch (state)
        {
            case State.Patrolling:
                anim.Play(movingAnim);
                break;
            case State.Chasing:
                anim.Play(movingAnim);
                break;
            case State.Attacking:
                anim.Play(attackingAnim);
                break;
            case State.Death:
                anim.Play(deathAnim);
                break;
            default: // Idle
                anim.Play(idleAnim);
                PlayDyingSound();
                break;
        }
    }

    private void PlayAttackingSound()
    {
        attackingSound.Play();
    }
    private void PlayDyingSound()
    {
        dyingSound.Play();
    }
}
