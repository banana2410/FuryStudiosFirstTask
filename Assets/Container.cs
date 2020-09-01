using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    private List<Box> _boxesInContainer = new List<Box>();


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("AA");
            Pickuper pickuper = collision.gameObject.GetComponent<Pickuper>();//Could cache it if needed
            _boxesInContainer.Add(pickuper._targetBox);
            pickuper._targetBox.gameObject.SetActive(false);
            pickuper._targetBox = null;
        }
    }
}
