using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public LineRenderer line;
    public Transform BirdPos;
    private Bird player;
    private Vector3 StartPos;
    public Vector3 offset;
    void Start()
    {
        StartPos = line.GetPosition(0);
        player = BirdPos.gameObject.GetComponent<Bird>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.isFired == false)
        {
            line.SetPosition(1, BirdPos.position + offset);
        }
        
        else
        {
            line.SetPosition(1, StartPos);
        }
    }
}
