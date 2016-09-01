using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{
    private float m_timeMax = 180.0f;
    private Text m_time;
    public bool a_allBallsPocketed;
    public bool a_blackBallFault;
    public float m_bestTime;
    public float m_currTime;
    // Use this for initialization
    void Start()
    {
        m_bestTime = -1;
        a_allBallsPocketed = false;
        m_time = GetComponent<Text>();
    }

    // Update is called once per frame

    // Created: Vince
    // Date: 9/1/2016
    // Time: 7:11pm
    /// <summary>
    /// Update timer display
    /// </summary>
    void Update()
    {
        m_time.text = "Time:    " + ((Time.realtimeSinceStartup)).ToString();

        if (Time.realtimeSinceStartup >= m_timeMax)
        {
            //TODO
            //GAME OVER


        }
        else if (a_allBallsPocketed)
        {
            if (Time.realtimeSinceStartup < m_bestTime || m_bestTime == -1)
            {
                
                m_bestTime = Time.realtimeSinceStartup;//update best time
                m_currTime = m_bestTime;
                //record broken!
                //TODO
                //show current time
                //Game Over
            }
            else//if not best time
            {
                //TODO
                //game over, show current time and best time
                m_currTime = Time.realtimeSinceStartup;

            }
        }
        else if (a_blackBallFault)//if black ball is not pocketed last
        {
            //TODO
            //game over
            //current time is m_timeMax
            m_currTime = m_timeMax;
            //display best time
        }


    }
}
