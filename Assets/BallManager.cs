using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BallManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] m_gameobjectarrayBalls = null;

    // Created: River
    // Date: 9/1/2016
    // Time: 2:26
    /// <summary>
    /// Returns a list of all the balls in the ball list
    /// </summary>
    public GameObject[] Balls
    {
        get
        {
            return m_gameobjectarrayBalls;
        }
    }

    // Created: River
    // Date: 9/1/2016
    // Time: 1:58
    void EndGame()
    {

    }

    // Created: River
    // Date: 9/1/2016
    // Time: 2:04
    /// <summary>
    /// Removes the ball from the registered ball list
    /// </summary>
    /// <param name="a_gameobjectBall"></param>
    public void RemoveBall(GameObject a_gameobjectBall)
    {
        bool boolFound = false;

        for (int i = 0; i < m_gameobjectarrayBalls.Length; i++)
        {
            if (a_gameobjectBall == m_gameobjectarrayBalls[i])
            {
                m_gameobjectarrayBalls[i] = null;
                boolFound = true;
                break;
            }
        }

        if (!boolFound)
        {
            return;
        }

        GameObject[] gameobjectarrayTemp = new GameObject[m_gameobjectarrayBalls.Length - 1];

        int j = 0;
        for (int i = 0; i < m_gameobjectarrayBalls.Length - 1; ++i)
        {
            if (j < m_gameobjectarrayBalls.Length)
            {
                if (m_gameobjectarrayBalls[j] == null)
                {
                    ++j;
                }
            }

            gameobjectarrayTemp[i] = m_gameobjectarrayBalls[j];

            ++j;
        }

        m_gameobjectarrayBalls = gameobjectarrayTemp;

        System.GC.Collect(0);
    }

    // Update is called once per frame
    // Created: River
    // Date: 9/1/2016
    // Time: 1:56
    void Update()
    {
        if (m_gameobjectarrayBalls.Length == 0)
        {
            EndGame();
        }
        else
        {
            // TODO: Remove
            RemoveBall(m_gameobjectarrayBalls[0]);
        }
    }
}
