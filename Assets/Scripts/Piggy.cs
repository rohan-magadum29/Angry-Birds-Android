using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piggy : MonoBehaviour
{
    public Sprite aliveSprite;
    public Sprite injuredSprite;
    private SpriteRenderer sp;
    private int health = 100;
    public AudioSource Piggy1;
    public AudioSource PiggyDestroyed;
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        Piggy1.Play();
        StartCoroutine(PlaySound());
    }
    IEnumerator PlaySound()
    {
        float time = Random.Range(0, 8);
        yield return new WaitForSeconds(time);
        Piggy1.Play();
        StartCoroutine(PlaySound());
    }
    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DamageAfterCollision(collision);
    }
    public void Injure()
    {
        sp.sprite = injuredSprite;//Changing the sprite of the piggy
    }
    private void Die()
    {
        LevelManager.DecrementPigCount();
        PiggyDestroyed.Play();
        gameObject.SetActive(false);//Disabling the piggy gameobject
    }

    private void DamageAfterCollision(Collision2D collision)
    {
        Bird bird = collision.gameObject.GetComponent<Bird>();//Find whether the gameobject we collided is Bird

        if (bird != null)
        {
            health = health - 100;
            Die();
        }
        if (collision.gameObject.CompareTag("Block"))//Find whether the gameobject we collided is Block
        {
            health = health - 50;
            if(health <= 0)
            {
                Die();
            }
            else
            {
                Injure();
            }
        }
    }
}
