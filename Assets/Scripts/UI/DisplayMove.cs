using System.Collections;
using UnityEngine;

public class DisplayMove : MonoBehaviour
{
    private bool visible = true;
    private RectTransform rectTransform;
    public RectTransform moveButton;

    [Header("Transition Settings")]
    public float moveTransitionDuration = 1.0f;
    public float rotateTransitionDuration = 1.0f;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void Move()
    {
        if (visible)
        {
            StartCoroutine(TransitionMove(rectTransform.anchoredPosition, new Vector3(1072.80005f, 0f, 0f), moveTransitionDuration));
        }
        else
        {
            StartCoroutine(TransitionMove(rectTransform.anchoredPosition, new Vector3(848.316895f, 0f, 0f), moveTransitionDuration));
        }
        visible = !visible;

        StartCoroutine(RotateOverTime(moveButton, 180f, rotateTransitionDuration));
    }

    IEnumerator TransitionMove(Vector3 startPosition, Vector3 endPosition, float duration)
    {
        float time = 0;
        while (time < duration)
        {
            rectTransform.anchoredPosition = Vector3.Lerp(startPosition, endPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        rectTransform.anchoredPosition = endPosition;
    }

    IEnumerator RotateOverTime(RectTransform target, float angle, float duration)
    {
        Quaternion startRotation = target.rotation;
        Quaternion endRotation = Quaternion.Euler(target.eulerAngles + new Vector3(0, 0, angle));
        float time = 0;
        while (time < duration)
        {
            target.rotation = Quaternion.Lerp(startRotation, endRotation, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        target.rotation = endRotation;
    }
}
