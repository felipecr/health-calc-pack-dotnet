using health_calc_pack_dotnet.Interfaces;

namespace health_calc_pack_dotnet;

public class BMI : IBMI
{
    public double Calculate(double height, double weight)
    {
        if (Validate(height, weight))
        {
            return Math.Round((weight / Math.Pow(height, 2)), 2);
        }

        throw new Exception("Invalid parameters.");
    }

    public string GetClassification(double bmi)
    {
        string classification = string.Empty;

        if (bmi < 18.5)
        {
           classification = "Abaixo do peso";
        }
        else if (bmi >= 18.5 && bmi < 25)
        {
            classification = "Peso normal";
        }
        else if (bmi >= 25 && bmi < 30)
        {
            classification = "Pré-obesidade";
        }
        else if (bmi >= 30 && bmi < 35)
        {
            classification = "Obesidade Grau 1";
        }
        else if (bmi >= 35 && bmi < 40)
        {
            classification = "Obesidade Grau 2";
        }
        else
        {
            classification = "Obesidade Grau 3";
        }

        return classification;
    }

    public bool Validate(double height, double weight)
    {
        if (height <= 0 || weight <= 0)
        {
            return false;
        }

        return true;
    }
}
