using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limits : MonoBehaviour
{
    private Transform theTransformr;
    public Vector2 Hrange = Vector2.zero;
    public Vector2 Vrange = Vector2.zero;
    
    public void LateUpdate() 
    {
        theTransformr.position = new Vector3 (
            Mathf.Clamp(transform.position.x, Vrange.x, Vrange.y),
            Mathf.Clamp(transform.position.y, Vrange.x, Vrange.y),
            transform.position.z
        );
    }
    // Start is called before the first frame update
    void Start()
    {
        theTransformr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
