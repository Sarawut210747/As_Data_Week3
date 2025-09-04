using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OOPExit : Identity
{
    public GameObject Youwin;


    public override void Hit()
    {
        Youwin.SetActive(true);
        mapGenerator.mapdata[positionX, positionY] = mapGenerator.empty;
        
    }
}


