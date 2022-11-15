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
        [InlineData(PhysicalActivityLevel.Sedentary, Gender.Male, 1.68, 85, 340, 170, 170)]
        [InlineData(PhysicalActivityLevel.ModeratelyActive, Gender.Male, 2.02, 103, 412, 206, 206)]
        [InlineData(PhysicalActivityLevel.ExtremelyActive, Gender.Male, 1.60, 60, 420, 120, 120)]
        [InlineData(PhysicalActivityLevel.Sedentary, Gender.Female, 1.68, 85, 272, 136, 136)]
        [InlineData(PhysicalActivityLevel.QuiteActive, Gender.Female, 1.56, 50, 280, 80, 80)]
        [InlineData(PhysicalActivityLevel.ModeratelyActive, Gender.Female, 1.81, 80, 256, 128, 128)]

        public void When_RequestsMacronutrientGroupToBulkingWithValidData_Then_ReturnsMacronutrientGroup(PhysicalActivityLevel level, Gender gender, double height, double weight, double expectedCarbohydrates, double expectedProteins, double expectedFats)
        {
            // Arrange
            MacronutrientGroup macronutrientGroup = new MacronutrientGroup();

            PhysicalGoal goal = PhysicalGoal.Bulking;

            MacronutrientGroupModel expected = new MacronutrientGroupModel
            {
                Carbohydrates = expectedCarbohydrates,
                Proteins = expectedProteins,
                Fats = expectedFats
            };

            // Act
            MacronutrientGroupModel result = macronutrientGroup.Calculate(gender, height, weight, level, goal);

            // Assert
            Assert.Equal(expected.Carbohydrates, result.Carbohydrates);
            Assert.Equal(expected.Proteins, result.Proteins);
            Assert.Equal(expected.Fats, result.Fats);
        }

        [Theory]
        [InlineData(PhysicalActivityLevel.Sedentary, Gender.Male, 1.80, 102.5, 205, 205, 102.5)]
        [InlineData(PhysicalActivityLevel.QuiteActive, Gender.Male, 1.92, 110, 220, 220, 110)]
        [InlineData(PhysicalActivityLevel.ModeratelyActive, Gender.Female, 1.71, 69, 138, 138, 69)]
        [InlineData(PhysicalActivityLevel.ExtremelyActive, Gender.Female, 1.60, 62, 124, 124, 62)]
        public void When_RequestsMacronutrientGroupToCuttingWithValidData_Then_ReturnsMacronutrientGroup(PhysicalActivityLevel level, Gender gender, double height, double weight, double expectedCarbohydrates, double expectedProteins, double expectedFats)
        {
            // Arrange
            MacronutrientGroup macronutrientGroup = new MacronutrientGroup();

            PhysicalGoal goal = PhysicalGoal.Cutting;

            MacronutrientGroupModel expected = new MacronutrientGroupModel
            {
                Carbohydrates = expectedCarbohydrates,
                Proteins = expectedProteins,
                Fats = expectedFats
            };

            // Act
            MacronutrientGroupModel result = macronutrientGroup.Calculate(gender, height, weight, level, goal);

            // Assert
            Assert.Equal(expected.Carbohydrates, result.Carbohydrates);
            Assert.Equal(expected.Proteins, result.Proteins);
            Assert.Equal(expected.Fats, result.Fats);
        }

        [Theory]
        [InlineData(PhysicalActivityLevel.Sedentary, Gender.Male, 1.67, 70, 350, 140, 70)]
        [InlineData(PhysicalActivityLevel.ModeratelyActive, Gender.Male, 1.89, 99, 495, 198, 99)]
        [InlineData(PhysicalActivityLevel.QuiteActive, Gender.Female, 1.66, 62, 310, 124, 62)]
        [InlineData(PhysicalActivityLevel.ExtremelyActive, Gender.Female, 1.84, 79.9, 399.5, 159.8, 79.9)]
        public void When_RequestsMacronutrientGroupToMaintenanceWithValidData_Then_ReturnsMacronutrientGroup(PhysicalActivityLevel level, Gender gender, double height, double weight, double expectedCarbohydrates, double expectedProteins, double expectedFats)
        {
            // Arrange
            MacronutrientGroup macronutrientGroup = new MacronutrientGroup();

            PhysicalGoal goal = PhysicalGoal.Maintenance;

            MacronutrientGroupModel expected = new MacronutrientGroupModel
            {
                Carbohydrates = expectedCarbohydrates,
                Proteins = expectedProteins,
                Fats = expectedFats
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
