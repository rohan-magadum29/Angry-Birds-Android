using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sp;
    private Vector2 startPos;
    public float Force;
    private Vector2 initialVelocity;
    public float maxDragDistance;
    public bool isFired = false;
    public AudioSource slingshotSound;
    public AudioSource flyingSound;
    public GameObject trajectoryDot;
    public GameObject[] trajectoryPoints;
    public int numberOfPoints = 10;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        sp = GetComponent<SpriteRenderer>();
        startPos = transform.position;
        trajectoryPoints = new GameObject[numberOfPoints];
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        sp.color = Color.red;
        isFired = false;
        slingshotSound.Play();
        for (int i = 0; i < numberOfPoints; i++)
        {
            trajectoryPoints[i] = Instantiate(trajectoryDot, gameObject.transform.position, Quaternion.identity);
        }
    }
    private void OnMouseDrag()
    {
        DrawTrajectory();
        isFired = false;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 desiredPos = mousePosition;
        initialVelocity = desiredPos - startPos;
        float distance = Vector2.Distance(desiredPos, startPos);
        if(distance > maxDragDistance)
        {
            Vector2 direction = desiredPos - startPos;
            direction.Normalize();
            desiredPos = startPos + (direction * maxDragDistance);
        }
        transform.position = desiredPos;
    }
    private void OnMouseUp()
    {
        isFired = true;
        Vector2 currentPos = transform.position;
        direction = startPos - currentPos;
        rb.isKinematic = false;
        direction = direction * 0.75f;
        rb.AddForce(direction * Force);
        sp.color = Color.white;
        flyingSound.Play();
        DisableTrajectory();
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
    private void DrawTrajectory()
    {
        for(int i = 0; i < numberOfPoints; i++)
        {
            trajectoryPoints[i].transform.position = CalculatePosition(i * 0.1f);
        }
    }
    private void DisableTrajectory()
    {
        for(int i = 0; i < numberOfPoints;i++)
        {
            Destroy(trajectoryPoints[i]);
        }
    }
    // s = ut + 0.5gt2
    private Vector2 CalculatePosition(float interval)
    {
        Vector2 position = startPos + (-initialVelocity * 9) * interval;
        // Adjust the position for gravity (assuming Physics2D.gravity is a Vector2)
        position += 0.5f * Physics2D.gravity * interval * interval;
        return position;
    }
}
