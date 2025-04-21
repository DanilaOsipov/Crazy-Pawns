using UnityEngine;

namespace CrazyPawn.Services.Input
{
    public interface IInputService
    {
        bool IsMouseDown { get; }
        Vector3 MousePosition { get; }
        bool IsMouseHold { get; }
    }
}