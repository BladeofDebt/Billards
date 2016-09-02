using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class MainMenu : MonoBehaviour
{
    float m_BestTime;
    float m_CurrTime;
    

	// Use this for initialization
	void Start ()
    {
        try
        {
            BinaryReader read = new BinaryReader(File.Open(Application.persistentDataPath + "/Time.bin", FileMode.Open));
            m_BestTime = read.ReadSingle();
            m_CurrTime = read.ReadSingle();
            read.Close();
        }
        catch(System.Exception excep)
        {
            Debug.LogWarning(excep.ToString());
        }
        GameObject bestObj = GameObject.FindGameObjectWithTag("BestTimeDisplay");
        GameObject currObj = GameObject.FindGameObjectWithTag("CurrentTimeDisplay");
       

        if (currObj == null || bestObj == null)
        {
            return;
        }
        Text bestText = bestObj.GetComponent<Text>();
        Text currText = currObj.GetComponent<Text>();

        bestText.text = "Best Time: " + m_BestTime.ToString();
        currText.text = "Current Time: " + m_CurrTime.ToString();
       

    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    //created: liam 
    //Date: 9/2/16
    //time: 9:12
    public void OnStartButton()
    {
        //Debug.Log("Start Game");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Pool");
        //load other scene
    }

    //created: liam
    //Date: 9/2/16
    //Time 9:14
    public void OnQuitButton()
    {
        //Debug.Log("Quit Game");
        Application.Quit();
    }

    //created: liam
    //Date: 9/2/16
    //Time: 10:43
    public void OnReplayButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Pool");
    }

    //created: liam
    //date: 9/2/16
    //TIme: 10:32
    public void OnMainMenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }

}
