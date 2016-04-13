using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountDownScript : MonoBehaviour {
    public GameObject character;
    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject ground;
    public int maxCountDown;
    private int countDown;
    public TextMesh guiTextCountDown;

	// Use this for initialization
	void Start () {
        MonoBehaviour[] scriptComponentsGameControl = gameObject.GetComponents<MonoBehaviour>();   // Get all the script components attached
        // Loop through all the scripts and disable them
        foreach (MonoBehaviour script in scriptComponentsGameControl)
        {
            script.enabled = false;
        }

        // Disable all the scripts attached to the walls, ground. Also disable the animation of character
        leftWall.GetComponent<GroundControl>().enabled = false;
        rightWall.GetComponent<GroundControl>().enabled = false;
        ground.GetComponent<GroundControl>().enabled = false;
        character.GetComponent<Animation>().enabled = false;

        StartCoroutine(CountDown());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Count down
    IEnumerator CountDown() {
        // Start the countdown
        for (countDown = maxCountDown; countDown > -1; countDown--)
        {
            if (countDown != 0)
            {
                guiTextCountDown.text = countDown.ToString();
                yield return new WaitForSeconds(1);
            }
            else
            {
                guiTextCountDown.text = "GO!";
                yield return new WaitForSeconds(1);
            }
        }

        // Enable all the scripts and animation once the count is down
        MonoBehaviour[] scriptComponentsGameControl = gameObject.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scriptComponentsGameControl)
        {
            script.enabled = true;
        }
        leftWall.GetComponent<GroundControl>().enabled = true;
        rightWall.GetComponent<GroundControl>().enabled = true;
        ground.GetComponent<GroundControl>().enabled = true;
        character.GetComponent<Animation>().enabled = true;

        // Disable the GUIText
        guiTextCountDown.GetComponent<Renderer>().enabled = false;
    }
}
