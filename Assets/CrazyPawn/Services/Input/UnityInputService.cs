using UnityEngine;

namespace CrazyPawn.Services.Input
{
    public class UnityInputService : IInputService
    {
        bool IInputService.IsMouseDown => UnityEngine.Input.GetMouseButtonDown(0);

        Vector3 IInputService.MousePosition => UnityEngine.Input.mousePosition;

        bool IInputService.IsMouseHold => UnityEngine.Input.GetMouseButton(0);
    }
}