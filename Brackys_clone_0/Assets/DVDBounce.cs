using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DVDBounce : MonoBehaviour
{
    public float speed = 5f; // Speed of movement
    private Vector3 direction; // Direction of movement
    private RectTransform rectTransform; // Reference to the RectTransform component
    private float textWidth; // Width of the text object
    private float textHeight; // Height of the text object

    void Start()
    {
        rectTransform = GetComponent<RectTransform>(); // Get the RectTransform component
        direction = Random.insideUnitCircle.normalized; // Generate a random direction

        // Get the width and height of the text object
        textWidth = rectTransform.rect.width;
        textHeight = rectTransform.rect.height;
    }

    void Update()
    {
        // Calculate the new position
        Vector3 newPos = rectTransform.position + direction * speed * Time.deltaTime;

        // Check if the new position collides with the outer edges of the screen
        if (newPos.x - textWidth / 2 < 0 || newPos.x + textWidth / 2 > Screen.width)
        {
            direction.x *= -1; // Reverse horizontal direction
        }
        if (newPos.y - textHeight / 2 < 0 || newPos.y + textHeight / 2 > Screen.height)
        {
            direction.y *= -1; // Reverse vertical direction
        }

        // Update the position
        rectTransform.position = newPos;
    }
}
