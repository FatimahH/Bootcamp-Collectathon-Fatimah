using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isGameOver;

    [SerializeField] private int allCollectibles;
    [SerializeField] private int collectibles;
    [SerializeField] private TextMeshProUGUI collectiblesText;

    private void Start()
    {
        isGameOver = false;
    }

    public void AddCollectible()
    {
        collectibles++;
        collectiblesText.text = "" + collectibles;
    }

    public void GameOver()
    {
        isGameOver = true;
        SceneManager.LoadScene("Lose");
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public int GetCollectibles()
    {
        return collectibles;
    }

    public bool HasCollectedAll()
    {
        if(collectibles == allCollectibles)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
