public class CalculatorLogic
{
    // Выполняет расчет на основе двух операндов и операции
    public float Calculate(float operand1, float operand2, string operation)
    {
        switch (operation)
        {
            case "+":
                return operand1 + operand2;
            case "-":
                return operand1 - operand2;
            case "*":
                return operand1 * operand2;
            case "/":
                if (operand2 == 0) throw new System.DivideByZeroException("Cannot divide by zero");
                return operand1 / operand2;
            default:
                throw new System.InvalidOperationException("Invalid operation");
        }
    }
}
