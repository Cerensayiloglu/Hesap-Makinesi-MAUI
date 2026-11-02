namespace hesap_makinesi33.view;

using System.Globalization;

public partial class ScientificPage : ContentPage
{
    string currentInput = "";
    double firstNumber = 0;
    string currentOperator = "";
    bool isNewNumber = true;
    bool isSecondFunction = false;
    public ScientificPage()
	{
		InitializeComponent();
	}
    private void NumberClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        string number = button.Text;

        if (isNewNumber)
        {
            currentInput = number;
            isNewNumber = false;
        }
        else
        {
            currentInput += number;
        }

        DisplayLabel.Text = currentInput;
    }
    private void ClearClicked(object sender, EventArgs e)
    {
        currentInput = "";
        firstNumber = 0;
        currentOperator = "";
        isNewNumber = true;

        DisplayLabel.Text = "0";
        OperationLabel.Text = "";
    }
    private void adımsilmeClicked(object sender, EventArgs e)
    {
        if (currentInput.Length > 0)
        {
            currentInput = currentInput.Remove(currentInput.Length - 1);
        }

        if (currentInput == "")
        {
            DisplayLabel.Text = "0";
        }
        else
        {
            DisplayLabel.Text = currentInput;
        }
    }
    private void ondalıkClicked(object sender, EventArgs e)
    {
        if (isNewNumber)
        {
            currentInput = "0,";
            isNewNumber = false;
        }
        else if (!currentInput.Contains(","))
        {
            currentInput += ",";
        }

        DisplayLabel.Text = currentInput;
    }
    private void isaretClicked(object sender, EventArgs e)
    {
        if (currentInput == "")
            return;

        double number = double.Parse(currentInput);

        number = -number;

        currentInput = number.ToString();

        DisplayLabel.Text = currentInput;
    }
    private void PiClicked(object sender, EventArgs e)
    {
        currentInput = Math.PI.ToString();
        DisplayLabel.Text = currentInput;
        isNewNumber = true;
    }
    private void EulerClicked(object sender, EventArgs e)
    {
        currentInput = Math.E.ToString();
        DisplayLabel.Text = currentInput;
        isNewNumber = true;
    }
    private void kareusClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(currentInput))
        {
            return;
        }

        double number = double.Parse(currentInput);

        double result = Math.Pow(number, 2);

        currentInput = result.ToString();

        DisplayLabel.Text = currentInput;
        isNewNumber = true;
    }
    private void bırboluxClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(currentInput))
        {
            return;
        }

        double number = double.Parse(currentInput);

        if (number == 0)
        {
            DisplayLabel.Text = "Hata";
            return;
        }

        double result = 1 / number;

        currentInput = result.ToString();

        DisplayLabel.Text = currentInput;
        isNewNumber = true;
    }
    private void mutlakClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(currentInput))
        {
            return;
        }

        double number = double.Parse(currentInput);

        double result = Math.Abs(number);

        currentInput = result.ToString();

        DisplayLabel.Text = currentInput;
        isNewNumber = true;
    }
    private void kokxClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(currentInput))
        {
            return;
        }

        double number = double.Parse(currentInput);

        if (number < 0)
        {
            DisplayLabel.Text = "Hata";
            return;
        }

        double result = Math.Sqrt(number);

        currentInput = result.ToString();
        DisplayLabel.Text = currentInput;
        isNewNumber = true;
    }
    private void usalmaClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(currentInput))
        {
            return;
        }

        firstNumber = double.Parse(currentInput);

        currentOperator = "^";

        OperationLabel.Text = currentInput + " ^";

        isNewNumber = true;
    }
    private void FactoriyelClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(currentInput))
        {
            return;
        }

        int number = int.Parse(currentInput);

        if (number < 0 || number > 170)
        {
            DisplayLabel.Text = "Hata";
            return;
        }

        double result = 1;

        for (int i = 1; i <= number; i++)
        {
            result *= i;
        }

        currentInput = result.ToString();
        DisplayLabel.Text = currentInput;
        isNewNumber = true;
    }
    private void LogClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(currentInput))
        {
            return;
        }

        double number = double.Parse(currentInput);

        if (number <= 0)
        {
            DisplayLabel.Text = "Hata";
            return;
        }

        double result = Math.Log10(number);

        currentInput = result.ToString();
        DisplayLabel.Text = currentInput;
        isNewNumber = true;
    }
    private void LnClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(currentInput))
        {
            return;
        }

        double number = double.Parse(currentInput);

        if (number <= 0)
        {
            DisplayLabel.Text = "Hata";
            return;
        }

        double result = Math.Log(number);

        currentInput = result.ToString();
        DisplayLabel.Text = currentInput;
        isNewNumber = true;
    }
    private void onussuClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(currentInput))
        {
            return;
        }

        double number = double.Parse(currentInput);

        double result = Math.Pow(10, number);

        currentInput = result.ToString();
        DisplayLabel.Text = currentInput;
        isNewNumber = true;
    }
    private void ExpClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(currentInput))
        {
            return;
        }

        double number = double.Parse(currentInput);

        double result = Math.Exp(number);

        currentInput = result.ToString();
        DisplayLabel.Text = currentInput;
        isNewNumber = true;
    }
    private double GetNumber()
    {
        if (string.IsNullOrEmpty(currentInput))
        {
            return 0;
        }

        if (currentInput.Contains("(") || currentInput.Contains(")"))
        {
            DisplayLabel.Text = "Hata";
            return 0;
        }

        return double.Parse(
            currentInput,
            CultureInfo.CurrentCulture
        );
    }
    private void OperatorClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        firstNumber = GetNumber();

        currentOperator = button.Text;

        OperationLabel.Text = currentInput + " " + currentOperator;

        isNewNumber = true;
    }
    private void EqualsClicked(object sender, EventArgs e)
    {
        double secondNumber = GetNumber();

        double result = 0;

        switch (currentOperator)
        {
            case "+":
                result = firstNumber + secondNumber;
                break;

            case "-":
                result = firstNumber - secondNumber;
                break;

            case "×":
                result = firstNumber * secondNumber;
                break;

            case "÷":
                if (secondNumber == 0)
                {
                    DisplayLabel.Text = "Hata";
                    return;
                }

                result = firstNumber / secondNumber;
                break;

            case "mod":
                if (secondNumber == 0)
                {
                    DisplayLabel.Text = "Hata";
                    return;
                }

                result = firstNumber % secondNumber;
                break;

            case "xʸ":
                result = Math.Pow(firstNumber, secondNumber);
                break;

            default:
                return;
        }

        currentInput = result.ToString(CultureInfo.CurrentCulture);

        DisplayLabel.Text = currentInput;

        OperationLabel.Text = "";

        currentOperator = "";

        isNewNumber = true;
    }
    private void ParantezAcClicked(object sender, EventArgs e)
    {
        if (isNewNumber)
        {
            currentInput += "(";
            isNewNumber = false;
        }
        else
        {
            currentInput += "(";
        }

        DisplayLabel.Text = currentInput;
    }

    private void ParantezKapatClicked(object sender, EventArgs e)
    {
        currentInput += ")";
        DisplayLabel.Text = currentInput;
    }
    private void SecondClicked(object sender, EventArgs e)
    {
        isSecondFunction = !isSecondFunction;
    }

}