using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class OnClickChar : MonoBehaviour
{

    public DialogueActivator diaActivator;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        /*
        ps.haveRiffle = true;
        ps.haveGun = false;
        ps.haveBat = false;
        ps.haveFlamethrower = false;
       // ps.haveKnife = false;
        */
        Debug.Log("Click DETECTED ON RIFFLE IMAGE");
        if (diaActivator) diaActivator.Interacted();

    }
}
