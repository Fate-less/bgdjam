using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Rigidbody2D rb;
    private Vector3 startPos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            rb.MovePosition(newPosition);
        }
    }

    public void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
        rb.velocity = Vector2.zero;
    }

    public void OnMouseUp()
    {
        isDragging = false;
    }

    public void resetPos()
    {
        isDragging = false;
        transform.position = startPos;
    }
}
