using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTrashcan : MonoBehaviour
{
    public string tagName;
    private void OnTriggerEnter2D(Collider2D other)
    {
        DragAndDrop draggable = other.GetComponent<DragAndDrop>();

        if (draggable != null && other.gameObject.tag == tagName)
        {
            Destroy(other.gameObject);
        }
        else
        {
            draggable.resetPos();
        }
    }
}
