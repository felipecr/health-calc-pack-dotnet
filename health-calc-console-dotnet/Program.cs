using health_calc_pack_dotnet;

Console.WriteLine("Digite sua altura e peso para calcular seu IMC.");

Console.Write("Altura: ");
double height = double.Parse(Console.ReadLine());

Console.Write("Peso: ");
double weight = double.Parse(Console.ReadLine());

BMI bmi = new BMI();

double result = bmi.Calculate(height, weight);
Console.WriteLine(result);
