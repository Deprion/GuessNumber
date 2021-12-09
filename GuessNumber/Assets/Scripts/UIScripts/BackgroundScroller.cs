using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroller : MonoBehaviour
{
    private RawImage image;
    private float speedX = -0.05f, speedY = 0.05f;
    void Start()
    {
        image = GetComponent<RawImage>();
    }

    void Update()
    {
        image.uvRect = new Rect(image.uvRect.position + new Vector2(speedX, speedY) * Time.deltaTime, 
            image.uvRect.size);
    }
}
