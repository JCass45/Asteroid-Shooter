using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject drop;
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public float shieldTime;

    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameoverText;

    private bool dropped;
    private bool restart;
    private bool gameover;
    private int score;

    void Start ()
    {
        score = 0;
        UpdateScore();
        dropped = false;
        restart = false;
        gameover = false;
        restartText.text = "";
        gameoverText.text = "";
        StartCoroutine (SpawnWaves());
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown (KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);

                if (!dropped)
                {
                    if (Random.value >= 0.5)
                    {
                        spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                        spawnRotation = Quaternion.identity;
                        Instantiate(drop, spawnPosition, spawnRotation);

                        dropped = true;
                    }
                }

                yield return new WaitForSeconds(spawnWait);
            }

            dropped = false;
            yield return new WaitForSeconds(waveWait);

            if (gameover)
            {
                restartText.text = "Press 'R' to restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore ()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver ()
    {
        gameoverText.text = "Game Over!";
        gameover = true;
    }
}
