using UnityEngine;

namespace RAP.Scripts
{
    public class CapsulePlayerController : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public float rotationSpeed = 2f;

        private Camera playerCamera;
        private Rigidbody rb;

        private float pitch = 0f;

        public bool hasKey = false;
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            playerCamera = GetComponentInChildren<Camera>();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void Update()
        {
            // Получаем ввод от мыши
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            // Вращаем капсулу вокруг оси Y
            if(mouseX != 0) transform.Rotate(Vector3.up * mouseX * rotationSpeed);

            // Изменяем угол наклона камеры вокруг оси X
            pitch -= mouseY * rotationSpeed;
            pitch = Mathf.Clamp(pitch, -90f, 90f);

            // Поворачиваем камеру
            playerCamera.transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);

            // Получаем ввод от пользователя для передвижения
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Вычисляем направление движения относительно направления камеры
            if (horizontalInput != 0 || verticalInput != 0)
            {
                Vector3 moveDirection =
                    (playerCamera.transform.forward * verticalInput + playerCamera.transform.right * horizontalInput)
                    .normalized;

                // Двигаем капсулу
                Vector3 moveVelocity = moveDirection * moveSpeed;
                
                MoveCharacter(moveDirection);
            }

            void MoveCharacter(Vector3 moveDirection)
            {
                // Используем MovePosition для управления позицией объекта
                rb.MovePosition(transform.position + moveDirection * moveSpeed * Time.deltaTime);
            }
                /*rb.velocity = new Vector3(moveVelocity.x, rb.velocity.y, moveVelocity.z);
            }
            else
            {
                rb.velocity = Vector3.zero;
            }*/
        }
    }
}