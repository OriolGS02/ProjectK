using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class cam : MonoBehaviour
{
    public Transform go1,go2,go3;
    public float speed;

    float timer;
    float t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, go1.position);

        if (dist>0) 
        {
            timer += Time.deltaTime;
            t = Mathf.Clamp01(timer / dist);
        }

        transform.position = Vector3.MoveTowards(transform.position, go1.position, speed* Time.deltaTime);

        // transform.rotation=Quaternion.RotateTowards(transform.rotation, go1.rotation,speed*10*1.5f*Time.deltaTime);

        transform.rotation = Quaternion.Slerp(transform.rotation, go1.rotation, t/10);
        
    }
    //Vector3.Distance(transform.position, go1.position)
}
