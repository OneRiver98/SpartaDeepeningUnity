using UnityEngine;
using UnityEngine.InputSystem;

public class IputController : TopDownController
{
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            Vector2 moveInput = context.ReadValue<Vector2>().normalized;
            CallMoveEvnet(moveInput);
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            CallMoveEvnet(Vector2.zero);
        }
    }
}
