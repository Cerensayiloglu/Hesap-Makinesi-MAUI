namespace hesap_makinesi33.view;

public partial class StandardPage : ContentPage
{
    int count = 0;
    double firstNumber = 0;
    string currentOperator = "";
    bool isNewNumber = true;
    public StandardPage()
	{
		InitializeComponent();
	}

    

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;


        }
        private void NumberClicked(object? sender, EventArgs e)
        {
            Button button = (Button)sender;
            string number = button.Text;

            if (isNewNumber)
            {
                if (currentOperator == "")
                {
                    OperationLabel.Text = "";
                }

                DisplayLabel.Text = number;
                isNewNumber = false;
            }
            else
            {
                DisplayLabel.Text += number;
            }
        }

        private void OperatorClicked(object? sender, EventArgs e)
        {
            Button button = (Button)sender;

            firstNumber = Convert.ToDouble(DisplayLabel.Text);

            currentOperator = button.Text;

            OperationLabel.Text = firstNumber.ToString() + " " + currentOperator;

            isNewNumber = true;



        }
        private void CalculateClicked(object? sender, EventArgs e)
        {
            {
                double secondNumber = Convert.ToDouble(DisplayLabel.Text);

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
                            OperationLabel.Text = "";
                            isNewNumber = true;
                            currentOperator = "";
                            return;
                        }
                        result = firstNumber / secondNumber;
                        break;
                }
                OperationLabel.Text += " " + secondNumber.ToString() + " =";
                DisplayLabel.Text = result.ToString();

                isNewNumber = true;
                currentOperator = "";
            }


        }
        private void ClearClicked(object? sender, EventArgs e)
        {
            DisplayLabel.Text = "0";
            OperationLabel.Text = "";

            firstNumber = 0;
            currentOperator = "";
            isNewNumber = true;
        }
        private void CleargirilenClicked(object? sender, EventArgs e)
        {
            DisplayLabel.Text = "0";
            isNewNumber = true;

        }
        private void ClearadımClicked(object? sender, EventArgs e)
        {
            string value = DisplayLabel.Text;
            if (value.Length <= 1 || (value.Length == 2 && value.StartsWith("-")))
            {
                DisplayLabel.Text = "0";
            }
            else
            {
                DisplayLabel.Text = value.Substring(0, value.Length - 1);
            }
            isNewNumber = false;
        }
        private void virgulClicked(object? sender, EventArgs e)
        {
            if (isNewNumber)
            {
                DisplayLabel.Text = "0,";
                isNewNumber = false;

            }
            else
            {
                DisplayLabel.Text += ",";
            }

        }
        private void isaretClicked(object? sender, EventArgs e)
        {
            double number = Convert.ToDouble(DisplayLabel.Text);
            number = number * -1;
            DisplayLabel.Text = number.ToString();
            isNewNumber = false;
        }
        private void birboluxClicked(object? sender, EventArgs e)
        {
            double number = Convert.ToDouble(DisplayLabel.Text);
            if (number == 0) 
            {
                DisplayLabel.Text = "Hata";
                isNewNumber = true;
                return;
            }

            double result = 1 / number;
            DisplayLabel.Text = result.ToString();
            isNewNumber = true;
        }
        private void yuzdeClicked(object? sender, EventArgs e)
        {
            double number = Convert.ToDouble(DisplayLabel.Text);
            if (currentOperator != "") 
            {
                number = firstNumber * number / 100;

            }
            else
            {
                number = number / 100;
            }

            DisplayLabel.Text = number.ToString();
            isNewNumber = true;
        }
        private void kareusClicked(object? sender, EventArgs e)
        {
            double Number = Convert.ToDouble(DisplayLabel.Text);
            double result = Number * Number;
            DisplayLabel.Text = result.ToString();
            isNewNumber = true;

        }
        private void karekokClicked(object? sender, EventArgs e)
        {
            double number = Convert.ToDouble(DisplayLabel.Text);

            if (number < 0) 
            {
                DisplayLabel.Text = "Hata";
                isNewNumber = true;
                return;
            }

            double result = Math.Sqrt(number);

            DisplayLabel.Text = result.ToString();

            isNewNumber = true;
        }

    


}

