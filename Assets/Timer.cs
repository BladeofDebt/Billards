using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Timer : MonoBehaviour
{
    private float m_timeMax = 180.0f;
    private Text m_time;
    public bool a_allBallsPocketed;
    public bool a_blackBallFault;
    public float m_bestTime;
    public float m_currTime;
    private float m_runTime;

    // Use this for initialization
    void Start()
    {
        m_runTime = Time.realtimeSinceStartup;
        try
        {
            BinaryReader read = new BinaryReader(File.Open(Application.persistentDataPath + "/Time.bin", FileMode.Open));
            m_bestTime = read.ReadSingle();
            read.Close();
        }
        catch (System.Exception excep)
        {
            m_bestTime = -1;
        }
        a_allBallsPocketed = false;
        m_time = GetComponent<Text>();
        m_currTime = 0.0f;
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
        m_currTime += Time.deltaTime;
        m_time.text = "Time: " + (m_currTime).ToString();

        if (m_currTime > m_timeMax)
        {
            //you suck
            Save();
            SceneManager.LoadScene("Game Over Screen");
        }

    }


    public void Save()
    {


        //if no best time of new best time
        if (m_bestTime == -1 || m_bestTime > m_currTime)
        {
            m_bestTime = m_currTime;
        }

        try
        {
            BinaryWriter writer = new BinaryWriter(File.Open(Application.persistentDataPath + "/Time.bin", FileMode.OpenOrCreate, FileAccess.Write));



            //GameObject m_gameCont = GameObject.FindGameObjectWithTag("GameController");
            //if (m_gameCont.GetComponent<BallManager>().m_gameobjectarrayBalls.Length == 0)
            //{
                
            //}
            writer.Write(m_bestTime);
            writer.Write(m_currTime);
            


            writer.Close();
        }
        catch (System.Exception excep)
        {
            Debug.LogWarning(excep.ToString());
        }


    }
}
