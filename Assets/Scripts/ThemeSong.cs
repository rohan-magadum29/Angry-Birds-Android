using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeSong : MonoBehaviour
{
    public AudioSource themeSong;
    void Start()
    {
        themeSong.loop = true;
        themeSong.Play();
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame

}
