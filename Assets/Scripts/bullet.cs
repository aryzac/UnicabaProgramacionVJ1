using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float timeToDestroy = 2f;
   
    void Start()
    {
       // transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()

    {
        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy <= 0)
        {
            Destroy(gameObject);
        }
    }
    
}
