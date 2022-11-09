using health_calc_pack_dotnet;

namespace health_calc_test_xunit;

public class BMITest
{
    [Fact]
    public void When_RequestBMIWithValidData_Then_ReturnBMI()
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
    public void When_RequestBMIWithValidData_Then_ReturnBMIInRange()
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

    /*[Fact]
    public void WhenRequestIMCCalcWithInvalidData_ThenReturnNaN()
    {
        // Arrange
        IMC imc = new IMC();
        double height = 0;
        double weight = 0;
        double expected = double.NaN;

        // Act
        double result = imc.Calculate(height, weight);

        // Assert
        Assert.Equal(expected, result);
    }*/

    [Fact]
    public void When_RequestBMIWithInvalidData_Then_ThrowException()
    {
        // Arrange
        BMI bmi = new BMI();
        double height = 0;
        double weight = 0;

        // Assert
        Assert.Throws<Exception>(() => bmi.Calculate(height, weight));
    }

    /*[Fact]
    public void When_RequestIMCCalcWithInvalidData_Then_ReturnPositiveInfinity()
    {
        // Arrange
        IMC imc = new IMC();
        double height = 0;
        double weight = 85;
        double expected = double.PositiveInfinity;

        // Act
        double result = imc.Calculate(height, weight);

        // Assert
        Assert.Equal(expected, result);
    }*/

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
    public void When_RequestBmiClassification_Then_ReturnClassification(double bmiP, string expectedResult)
    {
        // Arrange
        BMI bmi = new BMI();

        // Act
        string result = bmi.GetClassification(bmiP);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    /*[Theory]
    [InlineData(17.5, "Abaixo do peso")]
    public void When_RequestBmiClassification_Then_ReturnClassification(double bmiP, string expectedResult)
    {
        // Arrange
        IMC bmi = new IMC();

        // Act
        string result = bmi.GetClassification(bmiP);

        // Assert
        Assert.Equal(expectedResult, result);
    }*/
}