using System;
using UnityEngine;

namespace ECS.Components.Input
{
    struct PlayerKeyboardInputComponent
    {
        public KeyboardInputs CurrentKeyInput;

        public enum KeyboardInputs
        {
            None,
            IsForwardKeyDown,
            IsLeftKeyDown,
            IsRightKeyDown,
            IsBackKeyDown
        }
    }
}