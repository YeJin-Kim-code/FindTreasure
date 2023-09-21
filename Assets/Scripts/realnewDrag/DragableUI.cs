using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragableUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform canvas;
    private Transform previousParent;
    private RectTransform rect;
    private CanvasGroup canvasGroup;



    // Start is called before the first frame update

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

     public void OnBeginDrag(PointerEventData eventData)
    {
        previousParent = transform.parent;//드래그 직전에 소속되어있던 부모 transform의 정보저장

        //현재 드래그중인 ui가 화면의 최상단에 출력되도록 하기위해
        transform.SetParent(canvas);//부모 오브젝트를 canvas로 설정
        transform.SetAsLastSibling(); //가장 앞에 보이도록 마지막 자식으로 설정

        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(transform.parent == canvas)
        {
            transform.SetParent(previousParent);
            rect.position = previousParent.GetComponent<RectTransform>().position;
        }

        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
    }   
}
