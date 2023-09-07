using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static int pigCount;
    public static int birdCount = 3;
    public GameObject levelEndPanel;
    private Text levelText;
    public Button nextButton;
    public AudioSource levelWinSound;
    public AudioSource levelLoseSound;
    void Start()
    {
        pigCount = FindObjectsOfType<Piggy>().Length;
        levelEndPanel.SetActive(false);
        levelText = levelEndPanel.GetComponentInChildren<Text>();
        levelWinSound = levelEndPanel.GetComponents<AudioSource>()[0];
        levelLoseSound = levelEndPanel.GetComponents<AudioSource>()[1];
        levelWinSound.enabled = false;
        levelLoseSound.enabled = false;
    }
    private void Update()
    {
        if(pigCount <=0)
        {
            levelEndPanel.SetActive(true);
            nextButton.enabled = true;
            levelText.text = "You Won";
            birdCount = 3;
            levelWinSound.enabled = true;
        }
        if(birdCount <= 0 )
        {
            levelEndPanel.SetActive(true);
            nextButton.enabled = false;
            levelText.text = "You Lose";
            birdCount = 3;
            levelLoseSound.enabled = true;
        }
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        birdCount = 3;
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
    }
    public static void DecrementPigCount()
    {
        pigCount--;
    }
    public static void DecrementBirdCount()
    {
        birdCount--;
    }

    // Update is called once per frame
    
}
