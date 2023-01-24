using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField, Tooltip("移動速度")] float _speed = 5;
    [SerializeField, Tooltip("左のキャラかどうか")] bool _isLeft = true;

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
            Debug.Log("ゲームパッドがありません。");
            return;
        }

        //移動
        if (_isLeft)//左
        {
            //スティック入力の検出
            _stickValue = gamepad.leftStick.ReadValue().normalized;
            // 移動

        }
        else//右
        {
            //スティック入力の検出
            _stickValue = gamepad.rightStick.ReadValue().normalized;
        }
        
        if (_stickValue != new Vector2(0, 0))
        {
            var dir = new Vector2(_stickValue.x,_stickValue.y);
            transform.Translate(dir*_speed * Time.deltaTime);

        }
    }
}