using System;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;

    public void CallMoveEvnet(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }
}
