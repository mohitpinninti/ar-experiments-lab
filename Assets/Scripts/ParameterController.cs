using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParameterController : MonoBehaviour
{

    public Text parameterText;

    //Dev Console Text Elements
    public Text devOrbit;
    public Text devAtmosphere;
    public Text devWater;

    public int orbit;
    public int atmosphere;
    public int water;

    enum Parameter { Orbit, Atmosphere, Water };
    Parameter currParam = Parameter.Orbit;

    //Start is called before the first frame update
    void Start()
    {
        //Set starting value of the text box on the left of the screen that shows the parameter being modified
        parameterText.text = EnumVal(currParam);

        //Set starting values of all of the parameters and display them in the console
        orbit = Random.Range(0, 100);
        atmosphere = Random.Range(0, 100);
        water = Random.Range(0, 100);
        updateConsole();
        //Debug.Log("orbit value is: " + orbit.ToString());
        //Debug.Log("atmos val is: " + atmosphere.ToString());
        //Debug.Log("water val is: " + water.ToString());
    }

    string EnumVal (Parameter param)
    {
        if (param == Parameter.Orbit)
        {
            return "Orbit";
        } else if (param == Parameter.Atmosphere)
        {
            return "Atmosphere";
        } else if (param == Parameter.Water)
        {
            return "Water";
        }

        //This means something is wrong
        return "NULL";
    }

    public void LeftClicked()
    {
        switch(currParam)
        {
            case Parameter.Orbit:
                currParam = Parameter.Water;
                break;
            case Parameter.Atmosphere:
                currParam = Parameter.Orbit;
                break;
            case Parameter.Water:
                currParam = Parameter.Atmosphere;
                break;
        }
        parameterText.text = EnumVal(currParam);
    }

    public void RightClicked()
    {
        switch(currParam)
        {
            case Parameter.Orbit:
                currParam = Parameter.Atmosphere;
                break;
            case Parameter.Atmosphere:
                currParam = Parameter.Water;
                break;
            case Parameter.Water:
                currParam = Parameter.Orbit;
                break;
        }
        parameterText.text = EnumVal(currParam);
    }

    public void UpClicked()
    {
        switch (currParam)
        {
            case Parameter.Orbit:
                orbit += Random.Range(0, 10);
                break;
            case Parameter.Atmosphere:
                atmosphere += Random.Range(0, 10);
                break;
            case Parameter.Water:
                water += Random.Range(0, 10);
                break;
        }
        checkParamBounds();
        updateConsole();
    }

    public void DownClicked()
    {
        switch (currParam)
        {
            case Parameter.Orbit:
                orbit -= Random.Range(0, 10);
                break;
            case Parameter.Atmosphere:
                atmosphere -= Random.Range(0, 10);
                break;
            case Parameter.Water:
                water -= Random.Range(0, 10);
                break;
        }
        checkParamBounds();
        updateConsole();
    }

    //makes sure that all of the parameters are within their set bounds
    public void checkParamBounds()
    {
        if (orbit > 100)
        {
            orbit = 100;
        } else if (orbit < 0)
        {
            orbit = 0;
        }

        if (atmosphere > 100)
        {
            atmosphere = 100;
        } else if (atmosphere < 0)
        {
            atmosphere = 0;
        }

        if (water > 100)
        {
            water = 100;
        } else if (water < 0)
        {
            water = 0;
        }
    }

    //updates the dev console parameter texts to update with the most current values of all of the parameters
    public void updateConsole()
    {
        devOrbit.text = orbit.ToString();
        devAtmosphere.text = atmosphere.ToString();
        devWater.text = water.ToString();
    }

}
