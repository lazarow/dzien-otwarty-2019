using System.Collections;
using TMPro;
using UnityEngine;

public class MugScript : MonoBehaviour
{
    GameScript gameScript;
    Animator animator;
    GameObject score;

    private void Start()
    {
        gameScript = (GameScript) FindObjectOfType(typeof(GameScript));
        animator = GetComponent<Animator>();
        score = GameObject.Find("Score");
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
        gameScript.nofClicks += 1;

        score.GetComponent<TextMeshProUGUI>().text = gameScript.nofClicks.ToString().PadLeft(3, '0');
        if (transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled)
        {
            animator.SetTrigger("ZoomIn");
        }
        else
        {
            animator.SetTrigger("LayDown");
        }
    }    

    public void OnZoomInCompleted()
    {
        if (gameScript.currentLevel < 4) {
            gameScript.currentLevel += 1;
            gameScript.Init();
        }
    }

    public void OnLayDownCompleted()
    {
        gameScript.nofLiftedMugs -= 1;

        if (gameScript.nofClicks % 2 == 0)
            gameScript.SwapInit();
    }

    public void InitAnim(bool left)
    {
        if (left)
            animator.SetTrigger("SwapLeft");
        else
            animator.SetTrigger("SwapRight");
    }    
}
