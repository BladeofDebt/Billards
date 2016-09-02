using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class BallManager : MonoBehaviour
{
    [SerializeField]
    public GameObject[] m_gameobjectarrayBalls = null;

    // Created: River
    // Date: 1/9/2016
    // Time: 2:26pm
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
    // Date: 1/9/2016
    // Time: 1:58
    // Modified: River
    // Date: 2/9/2016
    // Time: 10:04am
    void EndGame()
    {
        //Save
        GameObject obj = GameObject.FindGameObjectWithTag("Timer");

        if (obj != null)
        {
            Timer tmr = obj.GetComponent<Timer>();

            if (tmr != null)
            {
                tmr.Save();
            }
        }
        SceneManager.LoadScene("Game Over Screen");
    }

    // Created: River
    // Date: 2/9/2016
    // Time: 11:07am

    // Created: River
    // Date: 1/9/2016
    // Time: 2:04pm
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
    // Time: 1:56pm
    void Update()
    {
        if (m_gameobjectarrayBalls.Length == 0)
        {
            EndGame();//end condition
        }
    }
}
