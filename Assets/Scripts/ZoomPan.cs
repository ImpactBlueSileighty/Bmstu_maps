using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class ZoomPan : MonoBehaviour
{
    public float panSpeed = 10f;    // �������� ����������� ������
    public float panBorderThickness = 10f;  // ������� ������� ������, ��� ���������� ������� �������� ����������� ������

    private bool isPanning = false; // ����, ����������� �� ��, ��� ������ ������ ������������
    private Vector3 lastPanPosition; 
    private void Start()
    {
        
    }

    private void Update()
    {
        // ���������, ���������� �� ����������� ���� ��� ������� �� ������
        if (Input.GetMouseButtonDown(0))
        {
            // ���������� ������� ������� ���� (�������) ��� ��������� ������� �����������
            lastPanPosition = Input.mousePosition;
            isPanning = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // ��������� ����������� ������
            isPanning = false;
        }

        // ����������� ������
        if (isPanning)
        {
            // ������������ ������� ����� ������� � ���������� ��������� ���� (�������)
            Vector3 mouseDelta = Input.mousePosition - lastPanPosition;

            // ������������ ����� ������� ������
            Vector3 newPosition = transform.position;
            newPosition.x -= mouseDelta.x * panSpeed * Time.deltaTime;
            newPosition.z -= mouseDelta.y * panSpeed * Time.deltaTime;

            // ������������ ����������� ������, ����� ��� �� �������� �� ������� �������� ���� (�� �������)
            // ����� �� ������ ��������� ����������� � ������������ � ����� ������.

            // ��������� ����� ������� ������
            transform.position = newPosition;

            // ��������� lastPanPosition
            lastPanPosition = Input.mousePosition;

            
        }
    }
}

