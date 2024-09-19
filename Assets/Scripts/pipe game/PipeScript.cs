using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public float curRotation = 0;

    public float[] posibleRotations = { 0, 90, 180, 270 };

    public void OnMouseDown()
    {
        transform.Rotate( new Vector3(0 ,0 ,90 ) );
        if (curRotation < 270)
        {
            curRotation += 90;
        } 
        else
        {
            curRotation = 0;

        }
            
    }
    
}
