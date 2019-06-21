using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPlatform : MonoBehaviour
{
    public float frequance;
    private float timer = 0;
    bool platformCanBreak = false;
    void Update()
    {
        if (platformCanBreak)
        {
            timer += Time.deltaTime;
            if (timer > frequance)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.transform.SetParent(transform);
            platformCanBreak = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.transform.SetParent(null);
        }
    }
}