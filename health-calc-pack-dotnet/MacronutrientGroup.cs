using health_calc_pack_dotnet.Enums;
using health_calc_pack_dotnet.Interfaces;
using health_calc_pack_dotnet.Models;
using health_calc_pack_dotnet.Utils;

namespace health_calc_pack_dotnet
{
    public class MacronutrientGroup : IMacronutrientGroup
    {        
        public MacronutrientGroupModel Calculate(Gender gender, double weight, PhysicalActivityLevel phisicalActivityLevel, PhysicalGoal physicalGoal)
        {
            if (!Validate(weight))
            {
                throw new InvalidDataException("Parâmetro inválido.");
            }

            if (physicalGoal == PhysicalGoal.Cutting)
            {
                return CalculateValuesToCutting(weight);
            }
            else if (physicalGoal == PhysicalGoal.Bulking)
            {
                return CalculateValuesToBulking(gender, weight, phisicalActivityLevel);
            }
            else
            {
               return CalculateValuesToMaintenance(weight);
            }
        }

        private MacronutrientGroupModel CalculateValuesToCutting(double weight)
        {
            return new MacronutrientGroupModel
            {
                Carbohydrates = Constants.GRAMS_OF_CARBOHYDRATE_TO_CUTTING * weight,
                Proteins = Constants.GRAMS_OF_PROTEIN * weight,
                Fats = Constants.GRAMS_OF_FAT * weight
            };
        }

        private MacronutrientGroupModel CalculateValuesToBulking(Gender gender, double weight, PhysicalActivityLevel phisicalActivityLevel)
        {
            MacronutrientGroupModel model = new MacronutrientGroupModel();
            double multiplier = gender == Gender.Male ? Constants.MALE_MULTIPLIER_TO_BULKING : Constants.FEMALE_MULTIPLIER_TO_BULKING;
            
            model.Proteins = Constants.GRAMS_OF_PROTEIN * weight * multiplier;
            model.Fats = Constants.GRAMS_OF_FAT_TO_BULKING * weight * multiplier;

            if (phisicalActivityLevel == PhysicalActivityLevel.QuiteActive || phisicalActivityLevel == PhysicalActivityLevel.ExtremelyActive)
            {
                model.Carbohydrates = Constants.GRAMS_OF_CARBOHYDRATE_TO_BULKING_FOR_MORE_ACTIVE_PEOPLE * weight * multiplier;
            }
            else
            {
                model.Carbohydrates = Constants.GRAMS_OF_CARBOHYDRATE_TO_BULKING * weight * multiplier;
            }

            return model;
        }

        private MacronutrientGroupModel CalculateValuesToMaintenance(double weight)
        {
            return new MacronutrientGroupModel
            {
                Carbohydrates = Constants.GRAMS_OF_CARBOHYDRATE_TO_MAINTENANCE * weight,
                Proteins = Constants.GRAMS_OF_PROTEIN * weight,
                Fats = Constants.GRAMS_OF_FAT * weight
            };
        }

        public bool Validate(double weight)
        {
            if (weight <= Constants.MIN_WEIGHT)
            {
                return false;
            }

            return true;
        }
    }
}
