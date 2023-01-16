using UnityEngine;
using Gamekit3D;
using DG.Tweening;
public class Hollow : AbilityBase
{
    [Header("Hollow Properties")]
    [SerializeField] CharacterController characterController = default;
    [SerializeField] private Damageable damageable = default;
    [SerializeField] private Animator animator = default;
    [SerializeField] private GameObject hollow = default;


    public override void Ability()
    {


        // Smoothly move the character to the target jump height
        Sequence dash = DOTween.Sequence()
           .AppendCallback(() => damageable.isInvulnerable = true)
           .AppendCallback(() =>
           {
               animator.SetTrigger("Hollow");
               hollow.GetComponent<RedHollowControl>().Play_Charging();
           }).Insert(0, DOTween.To(() => 0, x =>
           {

           }, 0, 4)).AppendCallback(() =>
           {
               hollow.GetComponent<RedHollowControl>().Finish_Charging();

           }).Insert(0, DOTween.To(() => 0, x =>
           {

           }, 0, 4)).AppendCallback(() =>
               {
           hollow.GetComponent<RedHollowControl>().Burst_Beam();

       })
          
           .Insert(0, DOTween.To(() => 0, x => { }, 0, 4))
            .AppendCallback(() =>
            {
                hollow.GetComponent<RedHollowControl>().Dead();
            }).AppendCallback(() => damageable.isInvulnerable = false)
;


    }
}