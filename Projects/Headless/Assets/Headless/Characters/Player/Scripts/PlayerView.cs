using UnityEngine;
using PlayerMVC;
using TMPro;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerView : ViewBase
{
    [SerializeField] private AudioSource jumpingSound;
    [SerializeField] private AudioSource attackingSound;
    [SerializeField] private AudioSource dyingSound;
    [SerializeField] private GameObject gameOverScreen;

    private SpriteRenderer sprite;
    private Animator anim;
    private State state;
    private Direction direction;

    private const string idleAnim = "Idle";
    private const string attackingAnim = "Attacking";
    private const string movingAnim = "Moving";
    private const string jumpingAnim = "Jumping";
    private const string fallingAnim = "Falling";
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
            case State.Moving:
                anim.Play(movingAnim);
                break;
            case State.Jumping:
                anim.Play(jumpingAnim);
                PlayJumpingSound();
                break;
            case State.Falling:
                anim.Play(fallingAnim);
                break;
            case State.Attacking:
                anim.Play(attackingAnim);
                break;
            case State.Death: 
                anim.Play(deathAnim);
                PlayDyingSound();
                break;
            default: // Idle
                anim.Play(idleAnim);
                break;
        }
    }

    private void PlayJumpingSound()
    {
        jumpingSound.Play();
    }
    private void PlayAttackingSound()
    {
        attackingSound.Play();
    }
    private void PlayDyingSound()
    {
        dyingSound.Play();
    }
    private void OnPlayerDeath()
    {
        gameOverScreen.SetActive(true);
    }
}
