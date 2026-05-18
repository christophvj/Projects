using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GBG_CALCULATOR
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Store the first number
        /// </summary>
        private double firstNumber = 0;
        /// <summary>
        /// Store the second number
        /// </summary>
        private double secondNumber = 0;
        /// <summary>
        /// Store the selected operation symbol
        /// </summary>
        private string operation = "";
        /// <summary>
        /// Detect when equal button is pressed 
        /// </summary>
        private bool isEqualPressed = false;
        /// <summary>
        /// List to store calculation history
        /// </summary>
        private List<string> calculationHistory = new List<string>();
        /// <summary>
        /// detect if operator is clicked
        /// </summary>
        private bool isOperatorClicked = false;

        //==============================================================================================================================================================================//

        public Form1()
        {
            InitializeComponent();
            pnlHistory.Visible = false;


        }

        //==============================================================================================================================================================================//
        /// <summary>
        /// Handles all the click events for buttons 0 to 9 and .
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNum_click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                // If the "Cannot divide by zero" message is displayed, reset the display and font
                if (txtMainDisplay.Text == "Cannot divide by zero")
                {
                    txtMainDisplay.Text = ""; // Clear the message
                    txtMainDisplay.Font = new Font(txtMainDisplay.Font.FontFamily, 30, txtMainDisplay.Font.Style); // Reset font size to 30pt
                }
                //If the equal button was pressed before, reset the display for new input
                if (isEqualPressed)
                {
                    txtMainDisplay.Text = "";
                    isEqualPressed = false;
                }
                // Clear the display if an operator was clicked
                if (isOperatorClicked)
                {
                    txtMainDisplay.Text = "";
                    isOperatorClicked = false;
                }

                // Clears calculator default startup text if it exists
                if (txtMainDisplay.Text == "0")
                {
                    txtMainDisplay.Text = "";
                }

                // Handle decimal point separately to avoid multiple decimals in one number
                if (clickedButton.Text == ".")
                {
                    // Allow single decimal per number
                    if (!txtMainDisplay.Text.Contains("."))
                    {
                        txtMainDisplay.Text += clickedButton.Text;
                    }
                }
                else
                {
                    // Append the number to the main display
                    txtMainDisplay.Text += clickedButton.Text;
                }
            }
        }


        //==============================================================================================================================================================================//
        /// <summary>
        /// Handles all Operator buttons.
        /// Gets result from special operators
        /// Formats text display for special operators
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperator_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button != null)
            {
                string operatorText = button.Text;

                if (operatorText == "±")
                {
                    // Handle toggle sign operation
                    if (!string.IsNullOrEmpty(txtMainDisplay.Text))
                    {
                        double num = double.Parse(txtMainDisplay.Text, System.Globalization.CultureInfo.InvariantCulture);
                        num = -num;
                        txtMainDisplay.Text = num.ToString();
                    }
                    return;
                }

                // If equal was pressed before, clear the sum display and start with the new result
                if (isEqualPressed)
                {
                    txtSumDisplay.Text = firstNumber.ToString() + " " + operatorText + " ";
                    isEqualPressed = false;
                }
                else
                {
                    txtSumDisplay.Text += txtMainDisplay.Text + " " + operatorText + " ";
                }

                if (operatorText == "+" || operatorText == "−" || operatorText == "X" || operatorText == "÷")
                {
                    if (!string.IsNullOrEmpty(operation))
                    {
                        secondNumber = double.Parse(txtMainDisplay.Text, System.Globalization.CultureInfo.InvariantCulture);
                        double result = 0.0;

                        switch (operation)
                        {
                            case "+":
                                result = firstNumber + secondNumber;
                                break;
                            case "−":
                                result = firstNumber - secondNumber;
                                break;
                            case "X":
                                result = firstNumber * secondNumber;
                                break;
                            case "÷":
                                result = firstNumber / secondNumber;
                                break;
                        }

                        firstNumber = result;
                        txtMainDisplay.Text = result.ToString();
                    }
                    else
                    {
                        firstNumber = double.Parse(txtMainDisplay.Text, System.Globalization.CultureInfo.InvariantCulture);
                    }

                    operation = operatorText;

                    // Set the flag to true to indicate an operator was clicked
                    isOperatorClicked = true;

                    // Append only the first number and the operator
                    txtSumDisplay.Text = firstNumber.ToString() + " " + operatorText;
                }
                else
                {
                    // Handle special operators (√, x², 1/x, %)
                    double num = double.Parse(txtMainDisplay.Text, System.Globalization.CultureInfo.InvariantCulture);
                    double result = 0.0;

                    switch (operatorText)
                    {
                        case "√":
                            result = Math.Sqrt(num);
                            txtMainDisplay.Text += result.ToString();
                            txtSumDisplay.Text = "√" + num.ToString() + " ";
                            break;
                        case "x²":
                            result = Math.Pow(num, 2);
                            txtMainDisplay.Text += result.ToString();
                            txtSumDisplay.Text = num.ToString() + "² ";
                            break;
                        case "1/𝑥":
                            result = 1 / num;
                            txtMainDisplay.Text += result.ToString();
                            txtSumDisplay.Text = "1/" + num.ToString() + " ";
                            break;
                        case "%":
                            result = num / 100;
                            txtMainDisplay.Text += result.ToString();
                            txtSumDisplay.Text = num.ToString() + "% ";
                            break;
                    }

                    // Display the result in txtMian but dont append it to txtSum
                    txtMainDisplay.Text = result.ToString();
                }
            }
        }




        //==============================================================================================================================================================================//
        /// <summary>
        /// Get result from the calculation
        /// Display result on Main display
        /// Clear all display variables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEqual_Click(object sender, EventArgs e)
        {
            secondNumber = double.Parse(txtMainDisplay.Text);
            double result = 0.0;

            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "−":
                    result = firstNumber - secondNumber;
                    break;
                case "X":
                    result = firstNumber * secondNumber;
                    break;
                case "÷":
                    if (secondNumber == 0)  // Check for division by zero
                    {
                        txtMainDisplay.Text = "Cannot divide by zero";  // Display error message
                        AdjustFontSize();
                        return;  // Exit the method early to avoid further processing
                    }
                    result = firstNumber / secondNumber;
                    break;
            }

            // Clear the sum display and add the final result
            txtSumDisplay.Text = firstNumber.ToString() + " " + operation + " " + secondNumber.ToString() + " = ";

            // Update the main display with the result
            txtMainDisplay.Text = result.ToString();
           

            // Add the calculation to history
            string historyEntry = $"{firstNumber} {operation} {secondNumber} = {result}";
            calculationHistory.Add(historyEntry);

            // Reset values
            firstNumber = result; // Keep the result for future operations
            secondNumber = 0;
            operation = "";
            isEqualPressed = true; // Mark that the equal button was pressed
        }

        private void AdjustFontSize()
        {
            // Measure the width of the text inside the txtMainDisplay
            SizeF textSize = TextRenderer.MeasureText(txtMainDisplay.Text, txtMainDisplay.Font);

            // Reduce the font size if the text is too wide to fit in the display box
            while (textSize.Width > txtMainDisplay.ClientSize.Width && txtMainDisplay.Font.Size > 8)
            {
                txtMainDisplay.Font = new Font(txtMainDisplay.Font.FontFamily, txtMainDisplay.Font.Size - 1, txtMainDisplay.Font.Style);
                textSize = TextRenderer.MeasureText(txtMainDisplay.Text, txtMainDisplay.Font);
            }

            // Optionally, reset the font size if the text fits comfortably (e.g., when shorter text is entered)
            while (textSize.Width < txtMainDisplay.ClientSize.Width / 2 && txtMainDisplay.Font.Size < 18)
            {
                txtMainDisplay.Font = new Font(txtMainDisplay.Font.FontFamily, txtMainDisplay.Font.Size + 1, txtMainDisplay.Font.Style);
                textSize = TextRenderer.MeasureText(txtMainDisplay.Text, txtMainDisplay.Font);
            }
        }


        //==============================================================================================================================================================================//
        /// <summary>
        /// backspace method to clear main display text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            if (txtMainDisplay.Text.Length > 0)
            {
                txtMainDisplay.Text = txtMainDisplay.Text.Substring(0, txtMainDisplay.Text.Length - 1); // Remove last character
            }

            // If no characters left, set the display to 0
            if (string.IsNullOrEmpty(txtMainDisplay.Text))
            {
                txtMainDisplay.Text = "0";
            }
            
        }
//==========================================================================================================================================================================//
       /// <summary>
       /// clears user input, main text display
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            txtMainDisplay.Text = "0";
            txtMainDisplay.Font = new Font(txtMainDisplay.Font.FontFamily, 30, txtMainDisplay.Font.Style);
        }
//==========================================================================================================================================================================//
        /// <summary>
        /// sets all variables back to zero.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMainDisplay.Text = "0";   
            txtSumDisplay.Text = "";     
            firstNumber = 0;             
            secondNumber = 0;            
            operation = "";             
            isEqualPressed = false;
            txtMainDisplay.Font = new Font(txtMainDisplay.Font.FontFamily, 30, txtMainDisplay.Font.Style);
        }
//==========================================================================================================================================================================//
        /// <summary>
        /// history button 
        /// displays all calculation history
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHistory_Click(object sender, EventArgs e)
        {
            // Toggle the visibility of the history panel
            pnlHistory.Visible = !pnlHistory.Visible;

            if (pnlHistory.Visible)
            {
               

                // Bring the panel to the front to ensure it is visible above other controls
                pnlHistory.BringToFront();

                lstHistory.Items.Clear(); // Clear current items

                if (calculationHistory.Count == 0)
                {
                    // Display "No history" if there are no items
                    lblNoHistory.Visible = true;
                }
                else
                {
                    // Add each entry to the ListBox
                    foreach (string history in calculationHistory)
                    {
                        lstHistory.Items.Add(history);
                    }
                    lblNoHistory.Visible = false; // Hide "No history" message if there are items
                }
            }
        }
//==========================================================================================================================================================================//
        /// <summary>
        /// method to clear history list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHistoryClear_Click(object sender, EventArgs e)
        {
            // Clear the history list and ListBox
            calculationHistory.Clear();
            lstHistory.Items.Clear();

            // Check if history is empty and show/hide the label accordingly
            if (calculationHistory.Count == 0)
            {
                lblNoHistory.Visible = true; // Show "No history" message
            }
            else
            {
                lblNoHistory.Visible = false; // Hide "No history" message
            }
        }
    //==========================================================================================================================================================================//

    }
}
//=========================================================================END OF FILE==========================================================================================//

