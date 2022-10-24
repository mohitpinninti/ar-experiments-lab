using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public GameObject sun;
    public float rotationSpeed = 50f;
    public float orbitSpeed = 20f;
    public float orbitRadius = 20f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(orbitRadius, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.RotateAround(sun.transform.position, Vector3.up, orbitSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
