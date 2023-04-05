using UnityEngine;

namespace Hunter
{
    public static class Utility
    {
        public static Vector3 GetMousePositionOnGroundPlane()
        {
            var mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);//making assumptions about how the scene is laid out
            Vector3 mouseWorldPoint = Vector3.zero;
            if (groundPlane.Raycast(mouseRay, out float distanceToGroundFromCamera))
            {
                 return mouseRay.GetPoint(distanceToGroundFromCamera);
            }
            else
            {
                Debug.LogError("Can't shoot into sky");
                return Vector3.zero;
            }
        }
    }
}