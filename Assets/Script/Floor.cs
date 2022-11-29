using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private int floorCount;
    public float floorLength = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float TeachFloorLength() 
    {
        return floorLength;
    }

    public void AddFloorLength() 
    {
        floorCount = floorCount + 1;
    }

}
