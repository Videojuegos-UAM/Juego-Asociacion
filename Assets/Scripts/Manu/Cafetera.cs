using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Cafetera : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [Header("Positions")]
    [SerializeField] private RectTransform _cafeteraPosition;
    [SerializeField] private RectTransform _tablePosition;
    [Header ("Differences")]
    [SerializeField] private int _differenceY;
    [SerializeField] private int _differenceX;
    [Header ("Sprites")]
    [SerializeField] Sprite _cupWhithCoffee;
    [SerializeField] Sprite _cupShaked;
    private Image _cup;
    private bool _whithCoffee=false;
    private bool _shaked = false;
    private Vector3 _previousPosition;

    // Start is called before the first frame update

    private void Awake()
    {
        _cup = gameObject.GetComponent<Image>();
        _whithCoffee = false;
        _shaked = false;
    }

    public void ServeCoffee()
    {
        if (_cup.rectTransform.anchoredPosition == _cafeteraPosition.anchoredPosition && _shaked==false && _whithCoffee == false)
        {
            _cup.sprite = _cupWhithCoffee;
            _whithCoffee = true;
            return;
        }
        print("No estas en la cafetera");
    }

    public void ShakeCoffee()
    {
        if (_cup.rectTransform.anchoredPosition == _tablePosition.anchoredPosition && _whithCoffee==true)
        {
            _cup.sprite = _cupShaked;

            return;
        }
        print("No estas en la mesa o no has servido el cafe");
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _previousPosition=_cup.rectTransform.anchoredPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        bool placeCafeteraMargin=(Mathf.Abs(_cup.rectTransform.anchoredPosition.x-_cafeteraPosition.anchoredPosition.x)<=_differenceX && Mathf.Abs(_cup.rectTransform.anchoredPosition.y - _cafeteraPosition.anchoredPosition.y) <= _differenceY);
        if (placeCafeteraMargin)
        {
            _cup.rectTransform.anchoredPosition = _cafeteraPosition.anchoredPosition;
            return;
        }
        bool placeTableMargin = (Mathf.Abs(_cup.rectTransform.anchoredPosition.x - _tablePosition.anchoredPosition.x) <= _differenceX && Mathf.Abs(_cup.rectTransform.anchoredPosition.y - _tablePosition.anchoredPosition.y) <= _differenceY);
        if (placeTableMargin)
        {
            _cup.rectTransform.anchoredPosition = _tablePosition.anchoredPosition;
            return;
        }
        _cup.rectTransform.anchoredPosition = _previousPosition;
        
    }

    public void OnDrag(PointerEventData eventData)
    {
       _cup.rectTransform.anchoredPosition += eventData.delta/canvas.scaleFactor;
    }
}
