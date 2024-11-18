using UnityEngine;
using TMPro; // Для работы с TextMeshPro

public class Calculator : MonoBehaviour
{
    public TMP_Text resultText; // Поле для отображения результата на экране
    private string currentInput = ""; // Текущий ввод пользователя
    private float operand1 = 0f; // Первый операнд для вычислений
    private float operand2 = 0f; // Второй операнд для вычислений
    private string currentOperation = ""; // Текущая операция (например, "+" или "-")

    // Метод для обработки нажатия кнопки с цифрой
    public void OnButtonPress(string value)
    {
        currentInput += value; // Добавляем цифру к текущему вводу
        resultText.text = currentInput; // Обновляем отображение текста
    }

    // Метод для обработки нажатия кнопки с операцией
    public void OnOperationPress(string operation)
    {
        if (currentInput == "") return;  // Если нет числа, ничего не делаем

        operand1 = float.Parse(currentInput); // Преобразуем текущий ввод в число
        currentOperation = operation; // Сохраняем операцию
        currentInput = ""; // Очищаем ввод для следующего числа
        resultText.text = currentOperation; // Отображаем операцию на экране
    }

    // Метод для выполнения вычислений и отображения результата
    public void OnEqualPress()
    {
        if (currentInput == "") return; // Если нет второго числа, ничего не делаем

        operand2 = float.Parse(currentInput); // Преобразуем второй операнд в число
        float result = 0f; // Переменная для хранения результата

        // В зависимости от текущей операции выполняем вычисление
        switch (currentOperation)
        {
            case "+":
                result = operand1 + operand2;
                break;
            case "-":
                result = operand1 - operand2;
                break;
            case "*":
                result = operand1 * operand2;
                break;
            case "/":
                if (operand2 != 0) // Проверка на деление на ноль
                    result = operand1 / operand2;
                else
                    resultText.text = "Error"; // Ошибка при делении на ноль
                return;
            default:
                resultText.text = "Error"; // Если операция не была выбрана
                return;
        }

        resultText.text = result.ToString(); // Отображаем результат
        currentInput = result.ToString(); // Обновляем ввод результатом
    }

    // Метод для очистки экрана
    public void OnClearPress()
    {
        currentInput = ""; // Очищаем текущий ввод
        resultText.text = "0"; // Сбрасываем отображение на "0"
    }
}