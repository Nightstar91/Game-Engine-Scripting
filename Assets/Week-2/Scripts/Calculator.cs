/*
Alvaro Troncoso
Week 2 - Calculator

Thanks Oliver for additional help over at programming help channel
*/

using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;

public class Calculator : MonoBehaviour
{
    //TODO: Create a TextMeshProUGUI variable here and assign it in the inspector
    public TextMeshProUGUI value;

    //TODO: Create a temporary float variable here called prevInput so we can store the previous input value
    //      when performaing calculations
    public float prevInput;

    //TODO: Create a bool variable called clearPrevInput here so we can flip it to true/false if we should clear the prior input
    //      when typing in values. Example, if we type in the value 402 and then press the + button, the next value I enter
    //      should replace the 402 I previously entered
    public Boolean clearPrevInput;

    //TODO: Leave this alone
    private EquationType equationType;

    private void Start()
    {
        // Starts with a zero
        Clear();
    }

    public void AddInput(string input)
    {
        //TODO: Check the clearPrevInput variable you created
        //      and if true then set the current value of the text label to be string.Empty
        //      and set the clearPrevInput value to false
        if(clearPrevInput == true){
            value.text = string.Empty;
            clearPrevInput = false;
        }
        //TODO: Add the input passed into the AddInput function to the current value of the label
        //      Hint. You can perform the + operations on string data to combine them
        value.text += input;
    }

    public void SetEquationAsAdd()
    {
        //TODO: Store the current input value on the text label into the float variable you created.
        //      Hint. You will need to google float.Parse() and pass in the string value of the label.
        //TODO: Set the bool you made to true so that the next number that gets typed in clears the calculator display.
        prevInput = float.Parse(value.text);
        clearPrevInput = true;
        equationType = EquationType.ADD;
    }

    //TODO: Create a SetEquationAsSubtract function similar to SetEquationAsAdd.
    //      Make sure you set equationType to EquationType.SUBTRACT
    public void SetEquationAsSubtract()
    {
        prevInput = float.Parse(value.text);
        clearPrevInput = true;
        equationType = EquationType.SUBTRACT;
    }

    //TODO: Create a SetEquationAsMultiply function similar to SetEquationAsAdd.
    //      Make sure you set equationType to EquationType.Multiply
    public void SetEquationAsMultiply()
    {
        prevInput = float.Parse(value.text);
        clearPrevInput = true;
        equationType = EquationType.MULTIPLY;
    }

    //TODO: Create a SetEquationAsDivide function similar to SetEquationAsAdd.
    //      Make sure you set equationType to EquationType.DIVIDE
    public void SetEquationAsDivide()
    {
        prevInput = float.Parse(value.text);
        clearPrevInput = true;
        equationType = EquationType.DIVIDE;
    }

    public void Add()
    {
        //TODO: Calculate the sum of the float variable that stores the previous input value and the current input value
        //      Set the text label to display that sum
        float current_input = float.Parse(value.text);
        float result = prevInput + current_input;
        value.text = result.ToString();
    }

    //TODO: Implement Subtract function
    public void Subtract()
    {
        float current_input = float.Parse(value.text);
        float result = prevInput - current_input;
        value.text = result.ToString();
    }


    //TODO: Implement Multiply function
    public void Multiply()
    {
        float current_input = float.Parse(value.text);
        float result = prevInput * current_input;
        value.text = result.ToString();
    }

    //TODO: Implement Divide function
    public void Divide()
    {
        float current_input = float.Parse(value.text);
        float result = prevInput / current_input;
        value.text = result.ToString();
    }

    public void Clear()
    {
        //TODO: Reset the state of your calculator... reset the display value to a 0, reset the bool variable
        //      that represents if the display should be cleared to true, reset the temporary float variable as well to 0
        value.text = string.Empty;

        //TODO: Leave this alone
        equationType = EquationType.None;        
    }

    public void Calculate()
    {
        //TODO: Check if equationTypep is Add/Subtract/Multiply/Divide and call the correct function
        if (equationType == EquationType.ADD) Add();
        else if (equationType == EquationType.SUBTRACT) Subtract();
        else if (equationType == EquationType.DIVIDE) Divide();
        else if (equationType == EquationType.MULTIPLY) Multiply();
        else
        {
            Debug.Log("WHAT???"); // send help
        }
        clearPrevInput = true;
    }

    //TODO: Leave this alone
    public enum EquationType
    {
        None = 0,
        ADD = 1,
        SUBTRACT = 2,
        MULTIPLY = 3,
        DIVIDE = 4
    }
}
