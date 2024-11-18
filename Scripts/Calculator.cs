using UnityEngine;
using TMPro; // Для работы с TextMeshPro

public class Calculator : MonoBehaviour
{
    public TMP_Text resultText; // Поле для отображения результата на экране
    private string currentInput = ""; // Текущий ввод пользователя
    private float operand1 = 0f; // Первый операнд для вычислений
    private float operand2 = 0f; // Второй операнд для вычислений
    private string currentOperation = ""; // Текущая операция (например, "+" или "-")

    private CalculatorLogic calculatorLogic; // Ссылка на класс логики расчётов

    private void Start()
    {
        calculatorLogic = new CalculatorLogic(); // Создаем экземпляр класса логики
    }

    // Метод для обработки нажатия кнопки с цифрой
    public void OnButtonPress(string value)
    {
        currentInput += value; // Добавляем цифру к текущему вводу
        resultText.text = currentInput; // Обновляем отображение текста
    }

    // Метод для обработки нажатия кнопки с операцией
    public void OnOperationPress(string operation)
    {
        if (!float.TryParse(currentInput, out operand1)) // Преобразуем текущий ввод в число
        {
            resultText.text = "Error";
            return;
        }

        currentOperation = operation; // Сохраняем операцию
        currentInput = ""; // Очищаем ввод для следующего числа
        resultText.text = currentOperation; // Отображаем операцию на экране
    }

    // Метод для выполнения вычислений и отображения результата
    public void OnEqualPress()
    {
        if (!float.TryParse(currentInput, out operand2)) // Преобразуем второй операнд в число
        {
            resultText.text = "Error";
            return;
        }

        try
        {
            // Вызываем логику вычислений из класса CalculatorLogic
            float result = calculatorLogic.Calculate(operand1, operand2, currentOperation);
            resultText.text = result.ToString(); // Отображаем результат
            currentInput = result.ToString(); // Обновляем ввод результатом
        }
        catch (System.Exception e)
        {
            resultText.text = e.Message; // Показываем сообщение об ошибке
        }
    }

    // Метод для очистки экрана
    public void OnClearPress()
    {
        currentInput = ""; // Очищаем текущий ввод
        resultText.text = "0"; // Сбрасываем отображение на "0"
    }
}