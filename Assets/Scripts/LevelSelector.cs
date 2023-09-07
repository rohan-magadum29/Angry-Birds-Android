using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public Button[] buttons;
    //public GameObject levelButtons;
    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = 0; i < unlockedLevel && i < 5; i++)// i < 5 is added because we have only 5 levels in the game
        {
            buttons[i].interactable = true;
        }
    }
    public void GoToLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
