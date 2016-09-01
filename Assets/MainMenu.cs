using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void OnStartButton()
    {
        Debug.Log("Start Game");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Pool");
        //load other scene
    }

    public void OnQuitButton()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

}
