using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Temperature : MonoBehaviour
{
    //Albedo = Bond albedo
    //lumonisty = in watts of the star
    static double sbConst = 5.670374419e-8;

    //Calculate temp based on atmosphere
    public static float CalcAtmoTemp()
    {
        return 0f;
    }

    //https://en.wikipedia.org/wiki/Effective_temperature
    //based on equation for effective temp of a planet
    //returns value in Kelvin
    public static float GetEffectiveTemp(double areaAbs, double areaRads, double planetAlbedo, double emissivity, double luminosity, double radius)
    {

        double numer = (areaAbs * luminosity * (1 - planetAlbedo));
        double denomin = (areaRads * 4 * Mathf.PI * sbConst * emissivity * radius * radius);
        double temp = System.Math.Pow((numer / denomin), 0.25);
        return (float) temp;
    }

    //https://en.wikipedia.org/wiki/Planetary_equilibrium_temperature
    //based on equation for radiative equilibrium temp of a planet
    //returns value in Kelvin
    public static float GetRadEqTemp(double planetAlbedo, double luminosity, double radius)
    {
        double numer = (luminosity * (1 - planetAlbedo));
        double denomin = (16 * Mathf.PI * sbConst * radius * radius);
        double temp = System.Math.Pow((numer / denomin), 0.25);
        return (float) temp;
    }

    //Temperature Conversions
    //Coverts Celsius to Farenheit
    public static float CelToFar(float temp)
    {
        return temp  * (9 / 5) +  32;
    }

    //Coverts Farenheit to Celsius
    public static float FarToCel(float temp)
    {
        return (temp - 32) *  (5/ 9);
    }

    //Coverts Kelvin to Farenheit
    public static float KelToFar(float temp)
    {
        return (temp - 273.15f) * (9 / 5) + 32;
    }

    //Coverts Farenheit to Kelvin
    public static float FarToKel(float temp)
    {
        return (temp - 32) * (5 / 9) + 273.15f;
    }

    //Coverts Kelvin to Celsius 
    public static float KelToCel(float temp)
    {
        return temp - 273.15f;
    }

    //Coverts Celsius to Kelvin
    public static float CelToKel(float temp)
    {
        return temp + 273.15f;
    }

    //test equations
    void Start()
    {
        //test Values for earth
        //double d = 149000000000;
        //double l = 3.846e26;
        //double a = 0.29;
        //print(GetRadEqTemp(a,l,d));
    }


}
