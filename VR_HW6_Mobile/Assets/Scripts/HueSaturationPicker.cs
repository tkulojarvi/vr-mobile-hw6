using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class HueSaturationPicker : MonoBehaviour
{
    public RawImage colorWheel; // Reference to the color wheel image
    public CardboardReticlePointer reticlePointer; // Reference to the Cardboard reticle pointer
    public Camera mainCamera; // Reference to the main camera
    public GameObject targetObject; // Reference to the target object whose color will be updated

    private Renderer targetRenderer; // Renderer of the target object
    public HSVColor hsvColorScript; // Color object

    private Vector3 lastPointerPosition; // Last position of the reticle pointer
    private float pointerStayTime; // Time the pointer has stayed in the same position
    private const float tolerance = 0.01f; // Tolerance for position difference

    void Start()
    {
        // Get the Renderer component from the target object
        if (targetObject != null)
        {
            targetRenderer = targetObject.GetComponent<Renderer>();
        }

        lastPointerPosition = Vector3.zero;
        pointerStayTime = 0f;
    }

    void Update()
    {
        // Perform a raycast from the reticle pointer to detect the color wheel
        Ray ray = new Ray(reticlePointer.transform.position, reticlePointer.transform.forward);
        RaycastHit hit;

        // Define the layer mask for the color wheel layer
        int layerMask = 1 << LayerMask.NameToLayer("ColorWheelLayer");

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            // Ensure the hit object is the color wheel
            if (hit.transform == colorWheel.transform)
            {
                // Convert hit point to local coordinates of the color wheel
                Vector2 localCursor;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    colorWheel.rectTransform, hit.point, null, out localCursor);

                // Convert local coordinates to texture coordinates
                Rect rect = colorWheel.rectTransform.rect;
                int x = Mathf.RoundToInt((localCursor.x - rect.xMin) * colorWheel.texture.width / rect.width);
                int y = Mathf.RoundToInt((localCursor.y - rect.yMin) * colorWheel.texture.height / rect.height);

                // Get the color from the texture at the calculated coordinates
                Texture2D texture = colorWheel.texture as Texture2D;
                Color color = texture.GetPixel(x, y);

                // Convert RGB color to HSV
                float h, s, v;
                Color.RGBToHSV(color, out h, out s, out v);

                // Set the hue and saturation of the object's material
                hsvColorScript.SetHue(h);
                hsvColorScript.SetSaturation(s);

                // Check if the pointer has stayed in the same position with tolerance
                if (Vector3.Distance(hit.point, lastPointerPosition) > tolerance)
                {
                    lastPointerPosition = hit.point;
                    pointerStayTime = 0f;
                }
                else
                {
                    pointerStayTime += Time.deltaTime;

                    // If the pointer has stayed for more than 3 seconds
                    if (pointerStayTime >= 3f)
                    {
                        Debug.Log("Pointer stayed at the same position for more than 3 seconds.");

                        // Load the scene by its name
                        SceneManager.LoadScene("Main");
                    }
                }
            }
        }
        else
        {
            Debug.Log("Raycast did not hit the color wheel.");
        }
    }
}


