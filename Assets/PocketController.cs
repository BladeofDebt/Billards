using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

enum e_ballType
{
    Normal,
    Eight,
    Cue
}


public class PocketController : MonoBehaviour
{
    GameObject obj;
    Timer tmr;

    [SerializeField]
    e_ballType m_enumBallType;

    BallManager m_ballManagerManager;

    // Created: River
    // Date: 1/9/2016
    // Time: 3:40pm
    /// <summary>
    /// What is called when the balls are destroyed
    /// </summary>
    void DestroyBall()
    {
        // Any extra destruction stuff in here
    }

    // Created: River
    // Date: 1/9/2016
    // Time: 3:52pm
    /// <summary>
    /// What is called if the eight ball is detected going in when the rest of the balls are still active
    /// </summary>
    void EightBallGameOver()
    {
        // TODO: Implement eightball gameover
        //end condition 1

        if(tmr != null)
        {
            
            tmr.m_currTime = 180;
            tmr.Save();
        }
       
        SceneManager.LoadScene("Game Over Screen");

    }

    // Created: River
    // Date: 1/9/2016
    // Time: 3:52pm
    /// <summary>
    /// What is called to cause the penalty for the cue
    /// </summary>
    void CuePenalty()
    {
        if (tmr != null)
        {
            tmr.m_currTime += 10;

        }

        Debug.Log("Cue Penalty");
        // TODO: Implement cue penalty
    }

    // Created: River
    // Date: 1/9/2016
    // Time: 3:52pm
    /// <summary>
    /// What is called to reset the cue
    /// </summary>
    void CueReset()
    {
        // TODO: Implement proper cue reset
        Instantiate(gameObject, new Vector3(4.96f, -0.02f), Quaternion.identity);
    }

    // Created: River
    // Date: 1/9/2016
    // Time: 3:40
    void Start()
    {


        obj = GameObject.FindGameObjectWithTag("Timer");

        if (obj != null)
        {
            tmr = obj.GetComponent<Timer>();


        }

        GameObject temp = GameObject.FindGameObjectWithTag("GameController");

        if (temp != null)
        {
            m_ballManagerManager = temp.GetComponent<BallManager>();

            if (m_ballManagerManager == null)
            {
                Debug.Log("Missing BallManager on GameController");
            }
        }
        else
        {
            Debug.Log("Missing Gamecontroller make sure gamecontroller is tagged as GameController");
        }

    }

    // Created: River
    // Date: 1/9/2016
    // Time: 3:32
    void OnTriggerEnter2D(Collider2D a_collider2DCollision)
    {
        if (a_collider2DCollision.tag == "Pocket")
        {
            m_ballManagerManager.RemoveBall(gameObject);
            DestroyBall();

            switch (m_enumBallType)
            {
                case e_ballType.Eight:
                    {
                        if (m_ballManagerManager.Balls.Length != 0)
                        {
                            EightBallGameOver();
                        }

                        break;
                    }
                case e_ballType.Cue:
                    {
                        CuePenalty();
                        CueReset();

                        break;
                    }
            }

            Destroy(gameObject);
        }
    }
}
