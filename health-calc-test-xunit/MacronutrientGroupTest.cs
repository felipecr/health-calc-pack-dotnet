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
            MacronutrientGroupModel result = macronutrientGroup.Calculate(gender, weight, level, goal);

            // Assert
            Assert.Equal(expected.Carbohydrates, result.Carbohydrates);
            Assert.Equal(expected.Proteins, result.Proteins);
            Assert.Equal(expected.Fats, result.Fats);
        }

        [Theory]
        [InlineData(PhysicalActivityLevel.Sedentary, Gender.Male, 85, 340, 170, 170)]
        [InlineData(PhysicalActivityLevel.ModeratelyActive, Gender.Male, 103, 412, 206, 206)]
        [InlineData(PhysicalActivityLevel.ExtremelyActive, Gender.Male, 60, 420, 120, 120)]
        [InlineData(PhysicalActivityLevel.Sedentary, Gender.Female, 85, 272, 136, 136)]
        [InlineData(PhysicalActivityLevel.QuiteActive, Gender.Female, 50, 280, 80, 80)]
        [InlineData(PhysicalActivityLevel.ModeratelyActive, Gender.Female, 80, 256, 128, 128)]

        public void When_RequestsMacronutrientGroupToBulkingWithValidData_Then_ReturnsMacronutrientGroup(PhysicalActivityLevel level, Gender gender, double weight, double expectedCarbohydrates, double expectedProteins, double expectedFats)
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
            MacronutrientGroupModel result = macronutrientGroup.Calculate(gender, weight, level, goal);

            // Assert
            Assert.Equal(expected.Carbohydrates, result.Carbohydrates);
            Assert.Equal(expected.Proteins, result.Proteins);
            Assert.Equal(expected.Fats, result.Fats);
        }

        [Theory]
        [InlineData(PhysicalActivityLevel.Sedentary, Gender.Male, 102.5, 205, 205, 102.5)]
        [InlineData(PhysicalActivityLevel.QuiteActive, Gender.Male, 110, 220, 220, 110)]
        [InlineData(PhysicalActivityLevel.ModeratelyActive, Gender.Female, 69, 138, 138, 69)]
        [InlineData(PhysicalActivityLevel.ExtremelyActive, Gender.Female, 62, 124, 124, 62)]
        public void When_RequestsMacronutrientGroupToCuttingWithValidData_Then_ReturnsMacronutrientGroup(PhysicalActivityLevel level, Gender gender, double weight, double expectedCarbohydrates, double expectedProteins, double expectedFats)
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
            MacronutrientGroupModel result = macronutrientGroup.Calculate(gender, weight, level, goal);

            // Assert
            Assert.Equal(expected.Carbohydrates, result.Carbohydrates);
            Assert.Equal(expected.Proteins, result.Proteins);
            Assert.Equal(expected.Fats, result.Fats);
        }

        [Theory]
        [InlineData(PhysicalActivityLevel.Sedentary, Gender.Male, 70, 350, 140, 70)]
        [InlineData(PhysicalActivityLevel.ModeratelyActive, Gender.Male, 99, 495, 198, 99)]
        [InlineData(PhysicalActivityLevel.QuiteActive, Gender.Female, 62, 310, 124, 62)]
        [InlineData(PhysicalActivityLevel.ExtremelyActive, Gender.Female, 79.9, 399.5, 159.8, 79.9)]
        public void When_RequestsMacronutrientGroupToMaintenanceWithValidData_Then_ReturnsMacronutrientGroup(PhysicalActivityLevel level, Gender gender, double weight, double expectedCarbohydrates, double expectedProteins, double expectedFats)
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
            MacronutrientGroupModel result = macronutrientGroup.Calculate(gender, weight, level, goal);

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
            double weight = 34;

            PhysicalActivityLevel level = PhysicalActivityLevel.Sedentary;
            PhysicalGoal goal = PhysicalGoal.Cutting;

            // Assert
            Assert.Throws<InvalidDataException>(() => macronutrientGroup.Calculate(gender, weight, level, goal));
        }
    }
}
