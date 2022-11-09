using health_calc_pack_dotnet;
using health_calc_pack_dotnet.Enums;
using health_calc_pack_dotnet.Models;

namespace health_calc_test_xunit
{
    public class MacronutrientTest
    {
        [Fact]
        public void When_RequestMacronutrientWithValidData_Then_ReturnMacronutrient()
        {
            // Arrange
            Gender gender = Gender.Male;
            Macronutrient macronutrient = new Macronutrient();
            double height = 1.68;
            double weight = 85;
            
            PhysicalActivityLevel level = PhysicalActivityLevel.Sedentary;
            PhysicalGoal goal = PhysicalGoal.Cutting;

            MacronutrientModel expected = new MacronutrientModel
            {
                Carbohydrates = 170,
                Proteins = 170,
                Fats = 85
            };

            // Act
            MacronutrientModel result = macronutrient.Calculate(gender, height, weight, level, goal);

            // Assert
            Assert.Equal(expected.Carbohydrates, result.Carbohydrates);
            Assert.Equal(expected.Proteins, result.Proteins);
            Assert.Equal(expected.Fats, result.Fats);
        }

        [Theory]
        [InlineData(PhysicalActivityLevel.Sedentary, 340)]
        public void When_RequestMacronutrientForBulkingWithValidData_Then_ReturnMacronutrient(PhysicalActivityLevel level, int carbohydrates)
        {
            // Arrange
            Gender gender = Gender.Male;
            Macronutrient macronutrient = new Macronutrient();
            double height = 1.68;
            double weight = 85;

            PhysicalGoal goal = PhysicalGoal.Bulking;

            MacronutrientModel expected = new MacronutrientModel
            {
                Carbohydrates = carbohydrates,
                Proteins = 170,
                Fats = 170
            };

            // Act
            MacronutrientModel result = macronutrient.Calculate(gender, height, weight, level, goal);

            // Assert
            Assert.Equal(expected.Carbohydrates, result.Carbohydrates);
            Assert.Equal(expected.Proteins, result.Proteins);
            Assert.Equal(expected.Fats, result.Fats);
        }

        [Fact]
        public void When_RequestMacronutrientWithInvalidData_Then_ThrowException()
        {
            // Arrange
            Gender gender = Gender.Male;
            Macronutrient macronutrient = new Macronutrient();
            double height = 1.68;
            double weight = 34;

            PhysicalActivityLevel level = PhysicalActivityLevel.Sedentary;
            PhysicalGoal goal = PhysicalGoal.Cutting;

            // Assert
            Assert.Throws<Exception>(() => macronutrient.Calculate(gender, height, weight, level, goal));
        }
    }
}
