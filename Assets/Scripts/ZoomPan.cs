using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class ZoomPan : MonoBehaviour
{
    public float panSpeed = 10f;    // Скорость перемещения камеры
    public float panBorderThickness = 10f;  // Толщина границы экрана, при достижении которой начнется перемещение камеры

    private bool isPanning = false; // Флаг, указывающий на то, что камера сейчас перемещается
    private Vector3 lastPanPosition; 
    private void Start()
    {
        
    }

    private void Update()
    {
        // Проверяем, происходит ли перемещение мыши или касание на экране
        if (Input.GetMouseButtonDown(0))
        {
            // Запоминаем текущую позицию мыши (касания) как стартовую позицию перемещения
            lastPanPosition = Input.mousePosition;
            isPanning = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // Завершаем перемещение камеры
            isPanning = false;
        }

        // Перемещение камеры
        if (isPanning)
        {
            // Рассчитываем разницу между текущей и предыдущей позициями мыши (касания)
            Vector3 mouseDelta = Input.mousePosition - lastPanPosition;

            // Рассчитываем новую позицию камеры
            Vector3 newPosition = transform.position;
            newPosition.x -= mouseDelta.x * panSpeed * Time.deltaTime;
            newPosition.z -= mouseDelta.y * panSpeed * Time.deltaTime;

            // Ограничиваем перемещение камеры, чтобы она не выходила за пределы игрового мира (по желанию)
            // Здесь вы можете настроить ограничения в соответствии с вашей сценой.

            // Применяем новую позицию камеры
            transform.position = newPosition;

            // Обновляем lastPanPosition
            lastPanPosition = Input.mousePosition;

            
        }
    }
}

