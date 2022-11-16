# health-calc-pack-dotnet

Projeto do Curso de Pós-Graduação em Engenharia de Software da PUC-MG. Trata-se de um pacote NuGet para cálculo de IMC (Índice de Massa Corporal) e macronutrientes.

https://www.nuget.org/packages/health-calc-pack-dotnet-felipecr/

## Classes

### BMI

Responsável pelo cálculo e pela classificação do IMC (em inglês, Body Mass Index - BMI).

---

#### Calculate

```
public double Calculate(double height, double weight)
```

##### Parâmetros

|Nome|Descrição|
|----|---------|
|height|Altura em metros|
|weight|Peso em quilos|

##### Retorno

IMC calculado.

---

#### GetClassification

```
public string GetClassification(double bmi)
```

##### Parâmetro

|Nome|Descrição|
|----|---------|
|bmi|Índice de massa corporal|

##### Retorno

Classificação textual do IMC em português.

---

#### Validate

```
public bool Validate(double height, double weight)
```

##### Parâmetros

|Nome|Descrição|
|----|---------|
|height|Altura em metros|
|weight|Peso em quilos|

##### Retorno

True caso os valores sejam válidos, False caso contrário.

---

#### Validate

```
public bool Validate(double bmi)
```

##### Parâmetro

|Nome|Descrição|
|----|---------|
|bmi|Índice de massa corporal|

##### Retorno

True caso o valor seja válido, False caso contrário.

---

### MacronutrientGroup

Responsável pelos cálculos dos três componentes que formam o grupo de macronutrientes: carboidratos, proteínas e gorduras.

---

#### Calculate

```
public MacronutrientGroupModel Calculate(Gender gender, double weight, PhysicalActivityLevel phisicalActivityLevel, PhysicalGoal physicalGoal)
```

##### Parâmetros

|Nome|Descrição|
|----|---------|
|[gender](health-calc-pack-dotnet/Enums/Gender.cs)|Sexo|
|weight|Peso em quilos|
|[phisicalActivityLevel](health-calc-pack-dotnet/Enums/PhysicalActivityLevel.cs)|Nível de atividade física|
|[physicalGoal](health-calc-pack-dotnet/Enums/PhysicalGoal.cs)|Objetivo da dieta|

##### Retorno

Objeto contendo os valores calculados para os três macronutrientes: carboidratos, proteínas e gorduras.

---

#### Validate

```
public bool Validate(double weight)
```

##### Parâmetros

|Nome|Descrição|
|----|---------|
|weight|Peso em quilos|

##### Retorno

True caso o valor seja válido, False caso contrário.

---

# health-calc-console-dotnet

Console Application que faz uso do **health_calc_pack_dotnet** para demonstrar o cálculo do IMC e dos macronutrientes a partir de dados digitados pelo usuário.

# health-calc-text-xunit

XUnit Application com testes unitários escritos para funções contidas no projeto **health_calc_pack_dotnet**.

## Classes

### BMITest

Contém testes unitários da classe BMI do projeto **health-calc-pack-dotnet**.

---

### MacronutrientGroupTest

Contém testes unitários da classe MacronutrientGroup do projeto **health-calc-pack-dotnet**.
