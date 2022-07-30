using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class InputController : MonoBehaviour
    {
        private Input _input;

        [field: Header("Input Values")]
        public InputAction PressInputAction { get; private set; }

        private void Awake()
        {
            _input = new Input();
        }

        private void OnEnable()
        {
            PressInputAction = _input.Player.Press;
            _input.Player.Enable();
        }

        private void OnDisable()
        {
            _input.Player.Disable();
        }
    }
}
