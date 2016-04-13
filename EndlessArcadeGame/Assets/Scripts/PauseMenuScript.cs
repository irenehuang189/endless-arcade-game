using UnityEngine;
using System.Collections;

public class PauseMenuScript : MonoBehaviour {
    public GUISkin skin;
    public string levelToLoad;
    public bool isPaused = false;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Escape or back key is pressed
            isPaused = !isPaused;
            if (isPaused)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
	}

    private void OnGUI()
    {
        GUI.skin = skin;
        if (isPaused) {
            GUI.Box(new Rect(Screen.width/4, Screen.height/4, Screen.width/2, Screen.height/2), "PAUSED");
    
            if (GUI.Button(new Rect(Screen.width/4+20, Screen.height/4+Screen.height/10+10, Screen.width/2-40, Screen.height/10), "RESUME"))
            {
                isPaused = false;
                Time.timeScale = 1;
            }
 
            if (GUI.Button(new Rect(Screen.width/4+20, Screen.height/4+2*Screen.height/10+10, Screen.width/2-40, Screen.height/10), "RESTART"))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
    
            if (GUI.Button(new Rect(Screen.width/4+20, Screen.height/4+3*Screen.height/10+10, Screen.width/2-40, Screen.height/10), "MAIN MENU"))
            {
                Application.LoadLevel(levelToLoad);
            }
        }
    }
}
