using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MugScript : MonoBehaviour
{
    GameScript gameScript;
    Animator animator;

    private void Start()
    {
        gameScript = (GameScript) FindObjectOfType(typeof(GameScript));
        animator = GetComponent<Animator>();
        StartCoroutine("JumpRandomly");
    }

    IEnumerator JumpRandomly()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(Random.Range(2.0f, 10.0f));
            AnimatorStateInfo animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (gameScript.nofLiftedMugs == 0 && animatorStateInfo.IsName("Idle"))
            {
                animator.SetTrigger("Jump");
            }
        }
    }

    void OnMouseDown()
    {
        AnimatorStateInfo animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (gameScript.nofLiftedMugs == 0 && animatorStateInfo.IsName("Idle"))
        {
            gameScript.nofLiftedMugs += 1;
            animator.SetTrigger("Lift");
        }
    }

    public void OnLiftCompleted()
    {
        animator.SetTrigger("LayDown");
    }

    public void OnLayDownCompleted()
    {
        gameScript.nofLiftedMugs -= 1;
    }
}
