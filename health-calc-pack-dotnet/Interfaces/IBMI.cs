namespace health_calc_pack_dotnet.Interfaces
{
    public interface IBMI
    {
        double Calculate(double height, double weight);

        string GetClassification(double bmi);

        bool Validate(double height, double weight);
    }
}