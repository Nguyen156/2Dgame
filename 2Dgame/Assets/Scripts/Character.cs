using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] Animator anim;
    protected bool isRight;

    string curState;

    public void Flip()
    {
        isRight = !isRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void ChangeAnim(string newState)
    {
        if (curState != newState)
        {
            anim.ResetTrigger(newState);
            curState = newState;
            anim.SetTrigger(curState);
        }
    }
}
