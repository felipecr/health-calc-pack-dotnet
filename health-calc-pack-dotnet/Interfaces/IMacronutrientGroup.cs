using health_calc_pack_dotnet.Enums;
using health_calc_pack_dotnet.Models;

namespace health_calc_pack_dotnet.Interfaces
{
    public interface IMacronutrientGroup
    {
        MacronutrientGroupModel Calculate(Gender gender, double weight, PhysicalActivityLevel phisicalActivityLevel, PhysicalGoal physicalGoal);

        bool Validate(double weight);
    }
}
