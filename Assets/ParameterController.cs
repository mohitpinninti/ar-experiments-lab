using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParameterController : MonoBehaviour
{

    public Text parameterText;

    enum Parameter { Orbit, Atmosphere, Water };
    Parameter currParam = Parameter.Orbit;

    //Start is called before the first frame update
    void Start()
    {
        parameterText.text = EnumVal(currParam);
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
    
}
