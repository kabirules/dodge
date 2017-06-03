using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    private bool gameOver;

    // Use this for initialization
    void Start () {
        gameOver = false;
        PlayerPrefs.SetInt("Score", 0);
        StartCoroutine(SpawnWalls());
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    IEnumerator SpawnWalls()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
/*
            if (gameOver)
            {
                //restartText.text = "Press 'R' for Restart";
                restartText.text = "Tap anywhere to Restart";
                restart = true;
                //Application.LoadLevel("MainMenu");
                break;
            }
*/
        }
    }

    public void GameOver()
    {
        //gameOverText.text = "Game Over!";
        gameOver = true;
    }

    public bool IsGameOver()
    {
        return gameOver;
    }
}
