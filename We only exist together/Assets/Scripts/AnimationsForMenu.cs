using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsForMenu : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void FadeInButtons()
    {
        animator.SetBool("MenuBool", true);
    }

}
