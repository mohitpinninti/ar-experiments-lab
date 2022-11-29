using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public GameObject star;
    public float rotationSpeed = 50f;
    public float orbitSpeed = 20f;
    public float orbitRadius = 20f;

    public bool water = false;
    public float temp = 0; //in Celsius
    public float atmo_nitro = 0;
    public float atmo_oxyg = 0;
    public float atmo_hydro= 0;

    public float albedo = 0.29f;

    public bool hasLife = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = star.transform.position + new Vector3(orbitRadius, 0, 0);
        temp = Random.Range(-100000000, 10000000);
        atmo_nitro = Random.Range(0, 1.0f);
        atmo_hydro = Random.Range(0, 1.0f);
        atmo_oxyg = Random.Range(0, 1.0f);
    }


    // Update is called once per frame
    void Update()
    {
        if (!hasLife)
        {
            hasLife = CheckLife();
        }
        transform.RotateAround(star.transform.position, Vector3.up, orbitSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    public bool CheckLife()
    {
        temp = Temperature.CalcAtmoTemp();
        //check temp
        if (-15 >= temp && temp >= 122)
        {
            return false;
        }

        //check water
        if (!water)
        {
            return false;
        }

        //check atmosphere
        if (0.1 >= atmo_hydro && atmo_hydro >= 0.2)
        {
            return false;
        }
        if (0.2 >= atmo_oxyg && atmo_oxyg >= 0.3)
        {
            return false;
        }
        if (0.7 >= atmo_nitro && atmo_nitro >= 0.8)
        {
            return false;
        }
        Debug.Log("LIFE!");
        return true;

    }
}
