using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public List<GameObject> prefabList = new List<GameObject>();
    public List<Transform> transformList = new List<Transform>();
    public GameObject pointPrefab;
    public TextMeshProUGUI scoreText;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, 1f);
        InvokeRepeating("SpawnPoints", 5f, 8f);
        score = 0;
        
    }

    void SpawnEnemy()
    {
        int prefabIndex = Random.Range(0, prefabList.Count);
        int transformIndex = Random.Range(0, transformList.Count);
        Instantiate(prefabList[prefabIndex], transformList[transformIndex]);
    }
    void SpawnPoints()
    {
        int transformIndex = Random.Range(0, transformList.Count);
        Instantiate(pointPrefab, transformList[transformIndex]);
    }
    public void UpdateScore()
    {
        score++;
    }
    private void Update()
    {
        scoreText.text = score.ToString();
        PlayerPrefs.SetInt("CurrentScore", score);
        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
