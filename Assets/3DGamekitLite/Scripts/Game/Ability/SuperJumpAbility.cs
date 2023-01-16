using UnityEngine;
using Gamekit3D;
using DG.Tweening;
public class SuperJumpAbility : AbilityBase
{
    [Header("Jump Properties")]
    [SerializeField] CharacterController characterController = default;
    [SerializeField] float jumpHeight = default;
    [SerializeField] private Damageable damageable = default;
    [SerializeField] private Animator animator = default;

    public override void Ability()
    {
      

        // Smoothly move the character to the target jump height
        Sequence dash = DOTween.Sequence()
           .AppendCallback(() => damageable.isInvulnerable = true)
           .Insert(0, transform.DOMove(transform.position + (transform.up * 10), 1f))
           .AppendCallback(() => damageable.isInvulnerable = false)
           .AppendCallback(() => { animator.SetTrigger("SuperJump"); transform.DOMove(transform.position, 2f); });


    }
}
