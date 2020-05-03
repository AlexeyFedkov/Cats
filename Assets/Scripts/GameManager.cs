using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Animator fadeAnimator;
    private static readonly int gameOver = Animator.StringToHash("gameOver");

    public void GameOver()
    {
        fadeAnimator.SetTrigger(gameOver);   
    }
}
