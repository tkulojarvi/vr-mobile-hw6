using UnityEngine;
using UnityEngine.UI;

public class HuePicker : MonoBehaviour
{
    public RawImage colorWheel; // Reference to the color wheel image
    public CardboardReticlePointer reticlePointer; // Reference to the Cardboard reticle pointer
    public Camera mainCamera; // Reference to the main camera
    public GameObject targetObject; // Reference to the target object whose color will be updated

    private Renderer targetRenderer; // Renderer of the target object

    void Start()
    {
        // Get the Renderer component from the target object
        if (targetObject != null)
        {
            targetRenderer = targetObject.GetComponent<Renderer>();
        }
    }

    void Update()
    {
        // Perform a raycast from the reticle pointer to detect the color wheel
        Ray ray = new Ray(reticlePointer.transform.position, reticlePointer.transform.forward);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * 700, Color.red); // Draw the ray in the scene view for debugging

        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log("Raycast hit: " + hit.transform.name); // Log the hit object

            // Ensure the hit object is the color wheel
            if (hit.transform == colorWheel.transform)
            {
                // Convert hit point to local coordinates of the color wheel
                Vector2 localCursor;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    colorWheel.rectTransform, hit.point, null, out localCursor);

                // Clamp the local coordinates to ensure they fall within the color wheel bounds
                //localCursor.x = Mathf.Clamp(localCursor.x, colorWheel.rectTransform.rect.xMin, colorWheel.rectTransform.rect.xMax);
                //localCursor.y = Mathf.Clamp(localCursor.y, colorWheel.rectTransform.rect.yMin, colorWheel.rectTransform.rect.yMax);

                // Convert local coordinates to texture coordinates
                Rect rect = colorWheel.rectTransform.rect;
                int x = Mathf.RoundToInt((localCursor.x - rect.xMin) * colorWheel.texture.width / rect.width);
                int y = Mathf.RoundToInt((localCursor.y - rect.yMin) * colorWheel.texture.height / rect.height);

                // Get the color from the texture at the calculated coordinates
                Texture2D texture = colorWheel.texture as Texture2D;
                Color color = texture.GetPixel(x, y);

                // Update the target object's material color to the selected color
                targetRenderer.material.color = color;
                
            }
        }
        else
        {
            Debug.Log("Raycast did not hit any object.");
        }
    }
}

