using health_calc_pack_dotnet.Enums;
using health_calc_pack_dotnet.Interfaces;
using health_calc_pack_dotnet.Models;

namespace health_calc_pack_dotnet
{
    public class Macronutrient : IMacronutrient
    {
        const double MIN_WEIGHT = 35;
        const int GRAMS_OF_PROTEIN = 2;
        const int GRAMS_OF_FAT_TO_BULKING = 2;
        const int GRAMS_OF_FAT = 1;
        const int GRAMS_OF_CARBOHYDRATE_TO_BULKING = 4;
        const int GRAMS_OF_CARBOHYDRATE_TO_BULKING_2 = 7;
        const int GRAMS_OF_CARBOHYDRATE_TO_CUTTING = 2;
        const int GRAMS_OF_CARBOHYDRATE_TO_MAINTENANCE = 5;
        
        public MacronutrientModel Calculate(Gender gender, double height, double weight, PhysicalActivityLevel phisicalActivityLevel, PhysicalGoal physicalGoal)
        {
            if (!Validate(weight))
            {
                throw new Exception("Invalid parameter.");
            }

            MacronutrientModel model = new MacronutrientModel();

            if (physicalGoal == PhysicalGoal.Cutting)
            {                
                model.Carbohydrates = GRAMS_OF_CARBOHYDRATE_TO_CUTTING * (int)weight;
                model.Proteins = GRAMS_OF_PROTEIN * (int)weight;
                model.Fats = GRAMS_OF_FAT * (int)weight;
            }
            else if (physicalGoal == PhysicalGoal.Bulking)
            {
                model.Proteins = GRAMS_OF_PROTEIN * (int)weight;
                model.Fats = GRAMS_OF_FAT_TO_BULKING * (int)weight;

                if (phisicalActivityLevel == PhysicalActivityLevel.QuiteActive || phisicalActivityLevel == PhysicalActivityLevel.ExtremelyActive)
                {
                    model.Carbohydrates = GRAMS_OF_CARBOHYDRATE_TO_BULKING_2 * (int)weight;
                }
                else
                {
                    model.Carbohydrates = GRAMS_OF_CARBOHYDRATE_TO_BULKING * (int)weight;
                }
            }
            else if (physicalGoal == PhysicalGoal.Maintenance)
            {
                model.Carbohydrates = GRAMS_OF_CARBOHYDRATE_TO_MAINTENANCE * (int)weight;
                model.Proteins = GRAMS_OF_PROTEIN * (int)weight;
                model.Fats = GRAMS_OF_FAT * (int)weight;
            }

            return model;
        }

        public bool Validate(double weight)
        {
            if (weight <= MIN_WEIGHT)
            {
                return false;
            }

            return true;
        }
    }
}
