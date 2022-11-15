using health_calc_pack_dotnet;
using health_calc_pack_dotnet.Enums;
using health_calc_pack_dotnet.Models;

try
{
    Console.WriteLine("Digite sua altura e peso para calcular seu IMC.");

    Console.Write("Altura: ");

    string? input1 = Console.ReadLine();

    double height = 0;

    if (input1 != null)
    {
        height = double.Parse(input1);
    }

    Console.Write("Peso: ");

    string? input2 = Console.ReadLine();

    double weight = 0;

    if (input2 != null)
    {
        weight = double.Parse(input2);
    }

    BMI bmi = new BMI();

    if (height > 0 && weight > 0)
    {
        double result = bmi.Calculate(height, weight);        
        Console.WriteLine("IMC calculado: " + result);

        string classification = bmi.GetClassification(result);
        Console.WriteLine("Classificação: " + classification);

        Console.WriteLine("Digite seu sexo para calcular os macronutrientes.");

        Console.Write("Sexo (F ou M): ");

        string? input3 = Console.ReadLine();

        if (input3 != null && (input3.ToUpper() == "F" || input3.ToUpper() == "M"))
        {
            Gender gender = input3.ToUpper() == "F" ? Gender.Female : Gender.Male;

            MacronutrientGroup macronutrientGroup = new MacronutrientGroup();
            MacronutrientGroupModel model = macronutrientGroup.Calculate(gender, weight, PhysicalActivityLevel.ModeratelyActive, PhysicalGoal.Maintenance);

            Console.WriteLine("Macronutrientes calculados para manutenção de peso de pessoa moderadamente ativa:");
            Console.WriteLine("-Carboidratos: " + model.Carbohydrates);
            Console.WriteLine("-Proteínas: " + model.Proteins);
            Console.WriteLine("-Gorduras: " + model.Fats);
        }
        else
        {
            Console.WriteLine("Sexo incorreto.");
        }
    }
    else
    {
        Console.WriteLine("Altura e/ou peso incorretos.");
    }
}
catch (Exception)
{
    Console.WriteLine("Algo deu errado. Por favor, revise os dados e tente novamente.");
    throw;
}