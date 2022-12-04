using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;

public class SwordAttack : GenericBehaviour
{
    public Animator animator;
    private bool fire1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fire1 = Input.GetButtonDown("Fire1");
        animator.SetBool("Attack1", fire1);
        if (animator.GetCurrentAnimatorStateInfo(animator.GetLayerIndex("Attack")).IsName("Attack1"))
        {
            animator.SetLayerWeight(animator.GetLayerIndex("Attack"), 1);
        }
        else
        {
            animator.SetLayerWeight(animator.GetLayerIndex("Attack"), 0);
        }
        
    }
}