using health_calc_pack_dotnet;
using health_calc_pack_dotnet.Enums;
using health_calc_pack_dotnet.Models;

namespace health_calc_test_xunit
{
    public class MacronutrientGroupTest
    {
        [Fact]
        public void When_RequestsMacronutrientGroupWithValidData_Then_ReturnsMacronutrientGroup()
        {
            // Arrange
            Gender gender = Gender.Male;
            MacronutrientGroup macronutrientGroup = new MacronutrientGroup();
            double height = 1.68;
            double weight = 85;
            
            PhysicalActivityLevel level = PhysicalActivityLevel.Sedentary;
            PhysicalGoal goal = PhysicalGoal.Cutting;

            MacronutrientGroupModel expected = new MacronutrientGroupModel
            {
                Carbohydrates = 170,
                Proteins = 170,
                Fats = 85
            };

            // Act
            MacronutrientGroupModel result = macronutrientGroup.Calculate(gender, height, weight, level, goal);

            // Assert
            Assert.Equal(expected.Carbohydrates, result.Carbohydrates);
            Assert.Equal(expected.Proteins, result.Proteins);
            Assert.Equal(expected.Fats, result.Fats);
        }

        [Theory]
        [InlineData(PhysicalActivityLevel.Sedentary, 340, 170, 170, Gender.Male)]
        [InlineData(PhysicalActivityLevel.ModeratelyActive, 340, 170, 170, Gender.Male)]
        [InlineData(PhysicalActivityLevel.QuiteActive, 595, 170, 170, Gender.Male)]
        [InlineData(PhysicalActivityLevel.ExtremelyActive, 595, 170, 170, Gender.Male)]
        [InlineData(PhysicalActivityLevel.QuiteActive, 476, 136, 136, Gender.Female)]
        [InlineData(PhysicalActivityLevel.ExtremelyActive, 476, 136, 136, Gender.Female)]
        public void When_RequestsMacronutrientGroupForBulkingWithValidData_Then_ReturnsMacronutrientGroup(PhysicalActivityLevel level, int carbohydrates, int proteins, int fats, Gender gender)
        {
            // Arrange
            MacronutrientGroup macronutrientGroup = new MacronutrientGroup();
            double height = 1.68;
            double weight = 85;

            PhysicalGoal goal = PhysicalGoal.Bulking;

            MacronutrientGroupModel expected = new MacronutrientGroupModel
            {
                Carbohydrates = carbohydrates,
                Proteins = proteins,
                Fats = fats
            };

            // Act
            MacronutrientGroupModel result = macronutrientGroup.Calculate(gender, height, weight, level, goal);

            // Assert
            Assert.Equal(expected.Carbohydrates, result.Carbohydrates);
            Assert.Equal(expected.Proteins, result.Proteins);
            Assert.Equal(expected.Fats, result.Fats);
        }

        [Fact]
        public void When_RequestsMacronutrientGroupWithInvalidData_Then_ThrowsException()
        {
            // Arrange
            Gender gender = Gender.Male;
            MacronutrientGroup macronutrientGroup = new MacronutrientGroup();
            double height = 1.68;
            double weight = 34;

            PhysicalActivityLevel level = PhysicalActivityLevel.Sedentary;
            PhysicalGoal goal = PhysicalGoal.Cutting;

            // Assert
            Assert.Throws<InvalidDataException>(() => macronutrientGroup.Calculate(gender, height, weight, level, goal));
        }
    }
}
