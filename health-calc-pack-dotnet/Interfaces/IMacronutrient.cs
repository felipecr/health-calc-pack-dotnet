using health_calc_pack_dotnet.Enums;
using health_calc_pack_dotnet.Models;

namespace health_calc_pack_dotnet.Interfaces
{
    public interface IMacronutrient
    {
        MacronutrientModel Calculate(Gender gender, double height, double weight, PhysicalActivityLevel phisicalActivityLevel, PhysicalGoal physicalGoal);

        bool Validate(double weight);
    }
}
