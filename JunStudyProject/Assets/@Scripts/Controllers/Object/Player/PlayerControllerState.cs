
using UnityEngine;

public enum EPlayerState
{

}

public static class AnimatorHelper
{
    public static void Play(this Animator animator, EPlayerState characterState)
    {
        animator.Play(characterState.ToString());
    }

    public static void Play(this Animator animator, EPlayerState characterState, float normalizedTime)
    {
        animator.Play(characterState.ToString(), 0, normalizedTime);
    }

    public static bool IsState(this Animator animator, EPlayerState characterState)
    {
        return IsState(animator.GetCurrentAnimatorStateInfo(0), characterState);
    }

    public static bool IsState(this AnimatorStateInfo stateInfo, EPlayerState characterState)
    {
        return stateInfo.IsName(characterState.ToString());
    }

    public static bool IsEndState(this AnimatorStateInfo stateInfo)
    {
        return stateInfo.normalizedTime >= 1.0f;
    }
}

public class PlayerControllerState : StateMachineBehaviour
{

}
