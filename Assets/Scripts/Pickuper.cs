using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickuper : MonoBehaviour
{
    public GameObject GameOverScreen;
    public List<Box> ActiveBoxesList = new List<Box>();
    public Box _targetBox { get { return _targetBox; } set { _targetBox = value; } }
    public Vector3 _targetPos;
    public float _speed;

    private Transform _blueContainer => GameObject.FindGameObjectWithTag("BlueContainer").GetComponent<Transform>();
    private Transform _redContainer => GameObject.FindGameObjectWithTag("RedContainer").GetComponent<Transform>();
    private Transform _carryPos => gameObject.GetComponentInChildren<Transform>();

    public bool isCarryingBox;
    private Rigidbody2D _rb => gameObject.GetComponent<Rigidbody2D>();


    private void Start()
    {
        Time.timeScale = 1f;
    }
    void Update()
    {
        if (isThereBoxesAvailable() && doesNeedTarget())
            setBoxTarget(getClosestBox());
        if (isThereBoxesAvailable() && canPickItUp())
        {
            _targetBox.transform.parent = this.gameObject.transform;
            _targetBox.transform.position = _carryPos.position;
            isCarryingBox = true;
        }
        if (isCarryingBox)
        {
            if (_targetBox.GetBoxColorType() == BoxColorType.Blue)
                setTargetPos(_blueContainer.position);
            else
                setTargetPos(_redContainer.position);

        }
        if (!isThereBoxesAvailable())
        {
            GameOverScreen.SetActive(true);
            Time.timeScale = 0f;
        }

    }

    private bool canPickItUp()
    {
        return (Mathf.Abs(gameObject.transform.position.x - _targetBox.transform.position.x)) < 0.1f;
    }
    private bool isThereBoxesAvailable()
    {
        return ActiveBoxesList.Count > 0;
    }
    private void FixedUpdate()
    {
        if (!doesNeedTarget())
        {
            if (_targetPos.x < gameObject.transform.position.x)
            {
                _rb.velocity = (Vector2.left * _speed);
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else
            {
                _rb.velocity = Vector2.right * _speed;
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }

        }
    }
    private void setBoxTarget(Box target)
    {
        _targetBox = target;
        _targetPos = _targetBox.transform.position;
    }
    private bool doesNeedTarget()
    {
        return _targetBox == null;
    }

    private void setTargetPos(Vector3 targetPos)
    {
        _targetPos = targetPos;
    }
    private Box getClosestBox()
    {
        Box closestBox = null;
        float closestBoxPosByX = Mathf.Infinity;
        for (int i = 0; i < ActiveBoxesList.Count; i++)
        {
            float boxPos = ActiveBoxesList[i].transform.position.x;
            float playerDistanceFromBox = Mathf.Abs(boxPos - gameObject.transform.position.x);
            if (playerDistanceFromBox < closestBoxPosByX)
            {
                closestBoxPosByX = playerDistanceFromBox;
                closestBox = ActiveBoxesList[i];
            }
        }
        return closestBox;
    }


}
