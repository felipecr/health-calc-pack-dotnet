using health_calc_pack_dotnet;
using System;

namespace health_calc_test_xunit;

public class BMITest
{
    [Fact]
    public void When_RequestsBMIWithValidData_Then_ReturnsBMI()
    {
        // Arrange
        BMI bmi = new BMI();
        double height = 1.68;
        double weight = 85;
        double expected = 30.12;

        // Act
        double result = bmi.Calculate(height, weight);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void When_RequestsBMIWithValidData_Then_ReturnsBMIInGivenRange()
    {
        // Arrange
        BMI bmi = new BMI();
        double height = 1.68;
        double weight = 85;
        double expectedMin = 30.10;
        double expectedMax = 30.14;

        // Act
        double result = bmi.Calculate(height, weight);

        // Assert
        Assert.InRange(result, expectedMin, expectedMax);
    }

    [Fact]
    public void When_RequestsBMIWithInvalidData_Then_ThrowsException()
    {
        // Arrange
        BMI bmi = new BMI();
        double height = 0;
        double weight = 0;

        // Act & Assert
        Assert.Throws<InvalidDataException>(() => bmi.Calculate(height, weight));
    }

    [Theory]
    [InlineData(17.5, "Abaixo do peso")]
    [InlineData(18.49, "Abaixo do peso")]
    [InlineData(18.50, "Peso normal")]
    [InlineData(24.99, "Peso normal")]
    [InlineData(25, "Pré-obesidade")]
    [InlineData(30, "Obesidade Grau 1")]
    [InlineData(34.99, "Obesidade Grau 1")]
    [InlineData(35, "Obesidade Grau 2")]
    [InlineData(39.99, "Obesidade Grau 2")]
    [InlineData(40, "Obesidade Grau 3")]
    [InlineData(45, "Obesidade Grau 3")]
    public void When_RequestsBmiClassification_Then_ReturnsBmiClassification(double bmiValue, string expectedResult)
    {
        // Arrange
        BMI bmi = new BMI();

        // Act
        string result = bmi.GetClassification(bmiValue);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(-26.5)]
    [InlineData(-15)]
    [InlineData(0)]
    public void When_RequestsBmiClassificationWithInvalidData_Then_ThrowsException(double bmiValue)
    {
        // Arrange
        BMI bmi = new BMI();

        // Act & Assert
        Assert.Throws<InvalidDataException>(() => bmi.GetClassification(bmiValue));
    }
    
}