using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    [SerializeField] float intensityLength;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Light var in FindObjectsOfType(typeof(Light))) {
            Debug.Log(var.name);
            var.intensity = Mathf.PingPong(Time.time, intensityLength);
        }
    }
}
