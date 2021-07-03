using UnityEngine;

public enum PortalInOutDirection : byte
{
    Left, Right
}

public static class PortalInOutDirectionExtensions
{
    public static Vector2 GetVector(this PortalInOutDirection direction)
    {
        return direction switch
        {
            PortalInOutDirection.Left => Vector2.left,
            PortalInOutDirection.Right => Vector2.right,
            _ => Vector2.zero,
        };
    }
}