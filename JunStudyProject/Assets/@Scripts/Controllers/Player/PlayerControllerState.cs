
using UnityEngine;

public enum EPlayerState
{
    Idle,
    Move,
    Jump,
    Fall,
    Roll,
    Climb,
    Dead,

    // Bow - 공격타입 하나임 활쏘는거
    // Spear - 공격 1,2 / 던지기
    // Sword - 공격 1,2,3
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
    // 모든 플레이어 State가 가지고 있는 무언가.
    // controller를 바꿔끼는 것에 대해서는 좀 에반거 같기도 하고... 괜찮은 거 같기도 하고...?
    // 뭔가 좀 애매한 느낌이긴해 공격 외에 동작은 똑같을거거든.

    // 똑같은 동작에 대해서는 그냥 같게 해도 될 것 같은 느낌이긴 함.

    
}
