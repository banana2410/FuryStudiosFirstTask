using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    private List<Box> _boxesInContainer = new List<Box>();
    private Pickuper _pickuper => GameObject.FindGameObjectWithTag("Player").GetComponent<Pickuper>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _boxesInContainer.Add(_pickuper._targetBox);
            _pickuper.ActiveBoxesList.Remove(_pickuper._targetBox);
            Destroy(_pickuper._targetBox.gameObject);
            _pickuper.isCarryingBox = false;
        }
    }
}
