using health_calc_pack_dotnet.Enums;
using health_calc_pack_dotnet.Interfaces;
using health_calc_pack_dotnet.Models;

namespace health_calc_pack_dotnet
{
    public class MacronutrientGroup : IMacronutrientGroup
    {
        const double MIN_WEIGHT = 35;
        const int GRAMS_OF_PROTEIN = 2;
        const int GRAMS_OF_FAT_TO_BULKING = 2;
        const int GRAMS_OF_FAT = 1;
        const int GRAMS_OF_CARBOHYDRATE_TO_BULKING = 4;
        const int GRAMS_OF_CARBOHYDRATE_TO_BULKING_2 = 7;
        const int GRAMS_OF_CARBOHYDRATE_TO_CUTTING = 2;
        const int GRAMS_OF_CARBOHYDRATE_TO_MAINTENANCE = 5;
        const double MALE_MULTIPLIER_TO_BULKING = 1;
        const double FEMALE_MULTIPLIER_TO_BULKING = 0.8;
        
        public MacronutrientGroupModel Calculate(Gender gender, double height, double weight, PhysicalActivityLevel phisicalActivityLevel, PhysicalGoal physicalGoal)
        {
            if (!Validate(weight))
            {
                throw new InvalidDataException("Parâmetro inválido.");
            }

            MacronutrientGroupModel model = new MacronutrientGroupModel();

            if (physicalGoal == PhysicalGoal.Cutting)
            {                
                model.Carbohydrates = GRAMS_OF_CARBOHYDRATE_TO_CUTTING * (int)weight;
                model.Proteins = GRAMS_OF_PROTEIN * (int)weight;
                model.Fats = GRAMS_OF_FAT * (int)weight;
            }
            else if (physicalGoal == PhysicalGoal.Bulking)
            {
                double multiplier = gender == Gender.Male ? MALE_MULTIPLIER_TO_BULKING : FEMALE_MULTIPLIER_TO_BULKING;
                model.Proteins = GRAMS_OF_PROTEIN * (int)weight * multiplier;
                model.Fats = GRAMS_OF_FAT_TO_BULKING * (int)weight * multiplier;

                if (phisicalActivityLevel == PhysicalActivityLevel.QuiteActive || phisicalActivityLevel == PhysicalActivityLevel.ExtremelyActive)
                {
                    model.Carbohydrates = GRAMS_OF_CARBOHYDRATE_TO_BULKING_2 * (int)weight * multiplier;
                }
                else
                {
                    model.Carbohydrates = GRAMS_OF_CARBOHYDRATE_TO_BULKING * (int)weight * multiplier;
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
