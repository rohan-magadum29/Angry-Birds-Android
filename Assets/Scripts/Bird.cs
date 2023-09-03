using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sp;
    private Vector2 startPos;
    public float Force;
    public float maxDragDistance;
    public bool isFired = false;
    public AudioSource slingshotSound;
    public AudioSource flyingSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        sp = GetComponent<SpriteRenderer>();
        startPos = transform.position;
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        sp.color = Color.red;
        isFired = false;
        slingshotSound.Play();
    }
    private void OnMouseDrag()
    {
        isFired = false;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 desiredPos = mousePosition;
        float distance = Vector2.Distance(desiredPos, startPos);
        if(distance > maxDragDistance)
        {
            Vector2 direction = desiredPos - startPos;
            direction.Normalize();
            desiredPos = startPos + (direction * maxDragDistance);
        }
        /*if(desiredPos.x > startPos.x)
        {
            desiredPos.x = startPos.x;
        }*/
        transform.position = desiredPos;
    }
    private void OnMouseUp()
    {
        isFired = true;
        Vector2 currentPos = transform.position;
        Vector2 direction = startPos - currentPos;
        direction.Normalize();
        rb.isKinematic = false;
        rb.AddForce(direction * Force);
        sp.color = Color.white;
        flyingSound.Play();
        StartCoroutine(ResetBird(5));
    }
    
    IEnumerator ResetBird(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        transform.position = startPos;
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
        isFired = false;
        LevelManager.DecrementBirdCount();
    }
    void Update()
    {
        //
    }
}
