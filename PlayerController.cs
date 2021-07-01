using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
   [SerializeField]
   private float speed = 5f;
   [SerializeField]
   private float lookSensitivity = 3f;

   private PlayerMotor motor;

   void Start()
   {
   	motor = GetComponent<PlayerMotor>();
   }

   void Update()
   {
   	float _xMov = Input.GetAxisRaw("Horizontal");
   	float _zMov = Input.GetAxisRaw("Vertical");

   	Vector3 _movHorizontal = transform.right * _xMov; 
   	Vector3 _movVertical = transform.forward * _zMov;

   	Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

   	motor.Move(_velocity);

   	float _yRot = Input.GetAxisRaw("Mouse X");

   	Vector3 _rotation = new Vector3 (0f, _yRot, 0 ).normalized * lookSensitivity;

   	motor.Rotate(_rotation);

   }
}
