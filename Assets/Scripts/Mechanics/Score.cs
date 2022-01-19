using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int _score = 0;

    public void Increment(int score)
    {
        _score += score;
    }

    public int GetScore()
    {
        return _score;
    }
}
