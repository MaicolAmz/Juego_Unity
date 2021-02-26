using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float startWaiTime;
    private float waitedTime;
    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKey("s"))
        {
            waitedTime = startWaiTime;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))
        {
            if (waitedTime <= 0)
            {
                effector.rotationalOffset = 180f;
                waitedTime = startWaiTime;
            }
            else
            {
                waitedTime -= Time.deltaTime;
            }
        }
        if (Input.GetKey("space"))
        {
            effector.rotationalOffset = 0;
        }
    }
    public void Duck()
    {
        if (waitedTime <= 0)
        {
            effector.rotationalOffset = 180f;
            waitedTime = startWaiTime;
        }
        else
        {
            waitedTime -= Time.deltaTime;
        }
    }

    public void Jump() {
        effector.rotationalOffset = 0;
    }
}
