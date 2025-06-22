using UnityEngine;

public static class Utils
{

    public static void GetMainCameraLeftRightEdge(out float leftEdge, out float rightEdge)
    {
        Camera mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found.");
            leftEdge = 0f;
            rightEdge = 0f;
            return;
        }

        float cameraHeight = mainCamera.orthographicSize * 2f;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        leftEdge = mainCamera.transform.position.x - (cameraWidth / 2f);
        rightEdge = mainCamera.transform.position.x + (cameraWidth / 2f);
    }
    
}
