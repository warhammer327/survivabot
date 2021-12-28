using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject[] spawnPoints;
    public GameObject[] enemyPrefab;
    public GameObject gameOverPanel;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreText1;
    public AudioSource waveCompleteSound;
    public int enemyAlive = 0;
    public int round = 0;
    private int enemyType;
    void Start()
    {
        enemyType = 0;
    
    }

    // Update is called once per frame
    void Update()
    {

        if (enemyAlive == 0)
        {
            round++;

            NextWave(round);
            scoreText.text = round.ToString();
        }
    }

    public void NextWave(int round)
    {
        enemyType = Random.Range(0,3);
        waveCompleteSound.Play();
        for (int i = 0; i < round; i++)
        {
            GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject enemySpawned = Instantiate(enemyPrefab[enemyType], spawnPoint.transform.position, Quaternion.identity);
            enemySpawned.GetComponent<EnemyManager>().gameManger = GetComponent<GameManger>();
            enemyAlive++;
        }
    }

    public void ShowGameOverPanel()
    {
       
        gameOverPanel.SetActive(true);
        scoreText1.text = round.ToString();
        StartCoroutine(PauseTime()); 
        

    }

     public IEnumerator PauseTime()
    { 
        yield return new WaitForSeconds(2); 
        Time.timeScale = 0;
    }

    public void LoadMainMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void QuitGame(){
        Application.Quit();
    }

}
