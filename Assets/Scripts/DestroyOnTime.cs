using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTime : MonoBehaviour
{
    public float deathTime = 5f; 
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, deathTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(1.0f * Time.deltaTime * Vector3.down);
    }
}