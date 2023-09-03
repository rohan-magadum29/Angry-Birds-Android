using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    public int explosionForce;
    public int explosionRadius;
    private Rigidbody2D rb;
    public GameObject explosionPrefab;
    public AudioSource explosionSound;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Block") || collision.gameObject.CompareTag("Player"))
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

            foreach (Collider2D nearbyObject in colliders)
            {
                Rigidbody2D rb = nearbyObject.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    Vector2 explosionDirection = rb.transform.position - transform.position;
                    rb.AddForce(explosionDirection.normalized * explosionForce, ForceMode2D.Impulse);
                    Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                    explosionSound.Play();
                    gameObject.GetComponent<Exploder>().enabled = false;
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                }
            }
        }
    }
}
