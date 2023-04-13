using System;
using UnityEngine;


public class PlayerAnimate : MonoBehaviour
{
    public Animator animator;
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        if(Mathf.Abs(horizontal) > 0 || Mathf.Abs(vertical) > 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        if(WeaponsManager.Instance.equippedWeapon != null)
        {
            animator.SetBool("isArmed", true);
        }
        else
        {
            animator.SetBool("isArmed", false);

        }

        if(Input.GetKey("c"))
        {
            if(Input.GetKey("a"))
            {
                if(Input.GetKey("t"))
                {
                    animator.SetTrigger("dance");
                    SoundManager.PlayMusic(SoundManager.Music.CatJazz);
                }
            }
        }
    }
}
