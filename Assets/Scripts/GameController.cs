using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using StartApp;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public GUIText gameOverText;
    public GUIText restartText;

    private bool gameOver;
    private bool restart;

    // Use this for initialization
    void Start () {

#if UNITY_ANDROID
        StartAppWrapper.removeBanner();
#endif

        gameOver = false;
        restart = false;
        PlayerPrefs.SetInt("Score", 0);
        StartCoroutine(SpawnWalls());
    }
	
	// Update is called once per frame
	void Update () {
        if (restart && Input.GetButton("Fire1"))
        {
            SceneManager.LoadScene("Main");
        }
        if (Input.GetKey("escape"))
            SceneManager.LoadScene("Home");
            //Application.Quit();
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

            if (gameOver)
            {
                restartText.text = "Tap anywhere to restart";
                restart = true;
                //Application.LoadLevel("MainMenu");
                break;
            }
        }
    }

    public void GameOver()
    {
        gameOverText.text = "GAME OVER!";
        gameOver = true;
    }

    public bool IsGameOver()
    {
        return gameOver;
    }
}
