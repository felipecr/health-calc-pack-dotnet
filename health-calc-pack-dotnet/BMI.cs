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

        throw new InvalidDataException("Parâmetro(s) inválido(s).");
    }

    public string GetClassification(double bmi)
    {
        if (Validate(bmi))
        {
            if (bmi < 18.5)
            {
                return "Abaixo do peso";
            }
            else if (bmi >= 18.5 && bmi < 25)
            {
                return "Peso normal";
            }
            else if (bmi >= 25 && bmi < 30)
            {
                return "Pré-obesidade";
            }
            else if (bmi >= 30 && bmi < 35)
            {
                return "Obesidade Grau 1";
            }
            else if (bmi >= 35 && bmi < 40)
            {
                return "Obesidade Grau 2";
            }
            else
            {
                return "Obesidade Grau 3";
            }
        }

        throw new InvalidDataException("Parâmetro inválido.");
    }

    public bool Validate(double height, double weight)
    {
        if (height <= 0 || weight <= 0)
        {
            return false;
        }

        return true;
    }

    public bool Validate(double bmi)
    {
        return bmi > 0;
    }
}
