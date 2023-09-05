using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public GameObject[] livesObjects;
    private void Start()
    {
        SpriteRenderer playerSpriteRenderer = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        for ( int i = 0; i < 3; i++)
        {
            livesObjects[i].SetActive(true);
            livesObjects[i].GetComponent<Image>().sprite = playerSpriteRenderer.sprite;
        }
    }
    private void Update()
    {
        UpdateLives();
    }
    private void UpdateLives()
    {
        if(LevelManager.birdCount < 1)
        {
            livesObjects[0].SetActive(false);
        } 
        else if(LevelManager.birdCount < 2)
        {
            livesObjects[1].SetActive(false);
        }
        else if(LevelManager.birdCount < 3)
        {
            livesObjects[2].SetActive(false);
        }
    }
    // Update is called once per frame
}
