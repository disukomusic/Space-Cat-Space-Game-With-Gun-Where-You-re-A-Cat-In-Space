using System;
using UnityEngine;


public class PlayerAnimate : MonoBehaviour
{
    public Animator animator;
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        if (GameManager.Instance.gameState == GameManager.GameState.Gaming)
        {
            if (Mathf.Abs(horizontal) > 0 || Mathf.Abs(vertical) > 0)
            {
                animator.SetBool("isMoving", true);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }

            if (WeaponsManager.Instance.equippedWeapon != null)
            {
                animator.SetBool("isArmed", true);
            }
            else
            {
                animator.SetBool("isArmed", false);

            }
        }
    }

    public void CatJazz()
    {
        animator.SetBool("isMoving", false);
        animator.SetBool("isArmed", false);

        transform.rotation = Quaternion.LookRotation(Vector3.zero);
        animator.SetTrigger("dance");
        SoundManager.PlayMusic(SoundManager.Music.CatJazz);
    }
}
