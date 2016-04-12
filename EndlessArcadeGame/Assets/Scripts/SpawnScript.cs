using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
    public GameObject obstacle;
    public GameObject powerUp;

    private float timeElapsed = 0;
    private float spawnCycle = 0.5f;
    private bool spawnPowerUp = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > spawnCycle)
        {
            GameObject temp;
            if (spawnPowerUp)
            {
                temp = (GameObject)Instantiate(powerUp);
                Vector3 pos = temp.transform.position;
                temp.transform.position = new Vector3(Random.Range(-3, 4), pos.y, pos.z);
            }
            else
            {
                temp = (GameObject)Instantiate(obstacle);
                Vector3 pos = temp.transform.position;
                temp.transform.position = new Vector3(Random.Range(-3, 4), pos.y, pos.z);
            }

            timeElapsed -= spawnCycle;
            spawnPowerUp = !spawnPowerUp;
        }
	}
}
