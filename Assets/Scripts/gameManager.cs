using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int deaths = 0;
    public int coinsCollected = 0;
    public int totalCoinsInLevel = 0;
    public TextMeshProUGUI deathText;
    private Vector3 currentCheckpoint;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        coinsCollected = 0;
        totalCoinsInLevel = 0;
        if (deathText == null)
        {
            deathText = FindObjectOfType<TextMeshProUGUI>();
        }
        UpdateUI();
    }

    public void RegisterCoin()
    {
        totalCoinsInLevel++;
    }

    public void CollectCoin()
    {
        coinsCollected++;
    }

    public void SetCheckpoint(Vector3 pos)
    {
        currentCheckpoint = pos;
    }

    public void Die(GameObject player)
    {
        deaths++;
        UpdateUI();
        player.transform.position = currentCheckpoint;
        ResetCoins();
    }

    private void ResetCoins()
    {
        coinsCollected = 0;
        Coin[] coins = Resources.FindObjectsOfTypeAll<Coin>();
        foreach (Coin c in coins)
        {
            if (c.gameObject.scene == SceneManager.GetActiveScene())
            {
                c.gameObject.SetActive(true);
            }
        }
    }

    public void CheckFinish()
    {
        if (coinsCollected >= totalCoinsInLevel)
        {
            int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextScene < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextScene);
            }
        }
    }

    private void UpdateUI()
    {
        if (deathText != null)
        {
            deathText.text = "DEATHS: " + deaths;
        }
    }
}