using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public AudioSource[] blockSounds;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        blockSounds[Random.Range(0, blockSounds.Length)].Play();
    }
}
