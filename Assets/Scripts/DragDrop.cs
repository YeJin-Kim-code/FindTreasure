using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Transform previousParent;//해당 오브젝트가 직전에 소속되어 있었던 부모 transform

    public float x1;
    public float y1;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    private void Start()
    {
        x1 = transform.position.x;
        y1 = transform.position.y;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("lol");
        previousParent = transform.parent;

        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("DARG");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        transform.position = mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //if (!eventData.pointerEnter.gameObject.CompareTag("slot")||eventData.pointerEnter == null)//슬롯이 아닌 엉뚱한 곳에 드랍할시 원래있던 자리로 돌아감
        //{
        //    transform.SetParent(previousParent);
        //    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        //    eventData.pointerDrag.transform.localPosition = Vector3.zero;
        //    //transform.localPosition = Vector3.zero;
        //    //rectTransform.position = previousParent.GetComponent<RectTransform>().position;
        //}
        //transform.SetParent(previousParent);
        Vector2 mousePositionEnd = new Vector2(x1, y1);
        transform.position = mousePositionEnd;
        eventData.pointerDrag.transform.localPosition = Vector3.zero;

        //if(eventData.pointerEnter.gameObject.CompareTag("Final"))
        //{
        //    Debug.Log("Final!!");
        //}
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("wow");
    }

    public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
