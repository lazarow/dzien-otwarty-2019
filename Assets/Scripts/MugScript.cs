using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MugScript : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine("RandomlyAnim");
    }

    void OnMouseDown()
    {
        AnimatorStateInfo animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (animatorStateInfo.IsName("Idle"))
        {
            Debug.Log("The mug has been clicked");
        }
    }

    IEnumerator RandomlyAnim()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(Random.Range(4.0f, 12.0f));
            AnimatorStateInfo animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (animatorStateInfo.IsName("Idle"))
            {
                animator.SetTrigger("Jump");
            }
        }
    }
}
