using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppTempeture.Models.Utilitys
{
    public class TempetureConverter
    {
        private delegate double ConvertTemp(double t);

        //Example: (50°F — 32) x .5556 = 10°C
        //Example: 100°K - 273.15 = -173.15°C

        //Example: (30°C x 1.8) + 32 = 86°F
        //Example: 100°C + 273.15 = 373.15°K

        public static double ConvertTempature(double tempValue, TempatureUnit fromTemp, TempatureUnit toTemp)
        {
 
            if (fromTemp == toTemp)
            {
                return tempValue;
            }

            //going to use Celsius as a base for my conversions so I´ll convert the inputed tempeture to it then convert if needed to the other units.

            tempValue = ToCelsius(tempValue, fromTemp);//convert to Celsius.

            if (toTemp == TempatureUnit.Celsius)
            {
                return tempValue;
            }

            return CelsiusTo(tempValue, toTemp);
        }

        public static double ToCelsius(double tempValue, TempatureUnit fromTemp)
        {
            ConvertTemp convertTemp = null;
            switch (fromTemp)
            {
                case TempatureUnit.Fahrenheit:
                    convertTemp = delegate (double t)
                    {
                        return (t - 32) * 0.5556;
                    };
                    //convertTemp = t => (t - 32) * 0.5556;//Lambda version
                    break;
                case TempatureUnit.Kelvin:
                    convertTemp = delegate (double t)
                    {
                        return t - 273.15;
                    };
                    //convertTemp = t => t - 273.15;//Lambda version
                    break;

                case TempatureUnit.Celsius:
                    throw new ArgumentException("Will not convert Celsius to Celsius", "fromTemp");
            }

            return convertTemp(tempValue);//convert to Celsius and return the result.
        }
        public static double CelsiusTo(double tempValue, TempatureUnit toTemp)
        {
            ConvertTemp convertTemp = null;
            switch (toTemp)
            {
                case TempatureUnit.Fahrenheit:
                    convertTemp = delegate (double t)
                    {
                        return (t * 1.8) + 32;
                    };
                    break;
                case TempatureUnit.Kelvin:
                    convertTemp = delegate (double t)
                    {
                        return t + 273.15;
                    };
                    break;
                case TempatureUnit.Celsius:
                    throw new ArgumentException("Will not convert Celsius to Celsius", "toTemp");
            }

            return convertTemp(tempValue);//convert to Celsius and return the result.
        }

    }
}
