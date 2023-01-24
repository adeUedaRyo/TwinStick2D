using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField, Tooltip("�ړ����x")] float _speed = 5;
    [SerializeField, Tooltip("���̃L�������ǂ���")] bool _isLeft = true;

    Vector2 _stickValue = default;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var gamepad = Gamepad.current;
        if (gamepad == null)
        {
            Debug.Log("�Q�[���p�b�h������܂���B");
            return;
        }

        //�ړ�
        if (_isLeft)//��
        {
            //�X�e�B�b�N���͂̌��o
            _stickValue = gamepad.leftStick.ReadValue().normalized;
            // �ړ�

        }
        else//�E
        {
            //�X�e�B�b�N���͂̌��o
            _stickValue = gamepad.rightStick.ReadValue().normalized;
        }
        
        if (_stickValue != new Vector2(0, 0))
        {
            var dir = new Vector2(_stickValue.x,_stickValue.y);
            transform.Translate(dir*_speed * Time.deltaTime);

        }
    }
}