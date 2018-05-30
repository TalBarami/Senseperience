using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public Vector3 amplitude;
    public Vector3 speed;
    private Vector3 direction;
    private Vector3 pos0;

    // Use this for initialization
    void Start()
    {
        pos0 = transform.position;
        direction = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 diff = pos - pos0;

        for(int i=0; i<3; i++)
        {
            pos[i] += CalculateDeltaPosition(i, diff[i]);
        }

        transform.position = pos;
    }

    float CalculateDeltaPosition(int axis, float diff)
    {
        diff *= direction[axis];

        if (diff >= amplitude[axis])
        {
            direction[axis] *= -1;
        }

        return direction[axis] * speed[axis] * Time.deltaTime;
    }
}
