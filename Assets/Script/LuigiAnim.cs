using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuigiAnim : MonoBehaviour
{
    public Animator anim;
   
    private void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (Luigi.currentStates == Luigi.LuigiStates.Land)
        {
            anim.SetBool("IsSwimming", false);
            anim.SetFloat("Speed", Luigi.totalSpeed);
            if (controller.isGrounded)
            {
                anim.SetBool("IsJumping", false);
            }
            else
            {
                anim.SetBool("IsJumping", true);
            }
        }

        if (Luigi.currentStates == Luigi.LuigiStates.Swim)
        {
            anim.SetBool("IsSwimming", true);
        }

    }
}
