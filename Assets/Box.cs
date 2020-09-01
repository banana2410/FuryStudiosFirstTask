using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BoxColorType
{
    Red,
    Blue
}
public class Box : MonoBehaviour
{
    private BoxColorType _boxColorType;
    private SpriteRenderer _spriteRenderer => gameObject.GetComponent<SpriteRenderer>();

    private Pickuper _pickuper => GameObject.FindGameObjectWithTag("Player").GetComponent<Pickuper>();

    private Color32 _redColor =  new Color32(255, 7, 0, 255);
    private Color32 _blueColor =  new Color32(0, 24, 255, 255);

    private void Start()
    {
        SetBoxColorType((BoxColorType)Random.Range(0, 2));
        initalizeBox();
        _pickuper.ActiveBoxesList.Add(this);
    }
    private void Awake()
    {

    }

    public BoxColorType GetBoxColorType()
    {
        return _boxColorType;
    }


    public void SetBoxColorType(BoxColorType boxColorType)
    {
        _boxColorType = boxColorType;
    }

    private void setBoxColorSprite(Color color)
    {
        _spriteRenderer.color = color;
    }
    private void initalizeBox()
    {
        switch (_boxColorType)
        {
            case BoxColorType.Red:
                setBoxColorSprite(_redColor);
                break;
            case BoxColorType.Blue:
                setBoxColorSprite(_blueColor);
                break;
            default:
                Debug.LogError("Something is wrong");
                break;
        }
    }
}
