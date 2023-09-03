using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithTime : MonoBehaviour
{
    public float time;
    void Start()
    {
        StartCoroutine(destroy());
    }

    // Update is called once per frame
    IEnumerator destroy()
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
