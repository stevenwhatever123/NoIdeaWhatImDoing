using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private PlayerState playerState = PlayerState.IDLE;

    public CharacterController characterController;

    public Animator animator;

    // Used for checking velocity
    private Vector3 currentPosition = Vector3.zero;
    private Vector3 previousPosition = Vector3.zero;

    void Update()
    {
        // Update Position
        previousPosition = currentPosition;
        currentPosition = transform.position;

        Tick();
    }

    void Tick()
    {
        switch(playerState)
        {
            case PlayerState.IDLE:
                float velocity = Vector3.Distance(previousPosition, currentPosition);
                if (velocity > 0)
                {
                    playerState = PlayerState.WALKING;
                    WalkingState(velocity);
                }
                break;
            case PlayerState.WALKING:
                if (Vector3.Distance(previousPosition, currentPosition) == 0)
                {
                    playerState = PlayerState.IDLE;
                    IdleState();
                }
                break;
        }
    }

    void IdleState()
    {
        animator.SetBool("Walking", false);
    }

    void WalkingState(float velocity)
    {
        animator.SetBool("Walking", true);

    }
}
