using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] float decelerate;
   [SerializeField]float maxSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public float GetDecelerate()
    {
        return decelerate;
    }
    public float GetMaxSpeed()
    {
        return maxSpeed;
    }

}
