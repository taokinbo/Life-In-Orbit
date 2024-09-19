using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public char position;
    public float curRotation;

    public float[] posibleRotations = { 0, 90, 180, 270 };

    public void OnMouseDown()
    {
        transform.Rotate( new Vector3(0 ,0 ,90 ) );
    }
}
