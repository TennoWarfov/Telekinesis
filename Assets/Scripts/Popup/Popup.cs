using System.Collections;
using UnityEngine;

public class Popup : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _fadeOutDuration = 2f;
    [SerializeField] private Vector3 _step = new(0, .01f, 0);

    private Transform _transform;

    public void Initialize()
    {
        _transform = transform;
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float startAlpha = _canvasGroup.alpha;
        float startTime = Time.time;

        while (Time.time - startTime < _fadeOutDuration)
        {
            _transform.position += _step;
            float progress = (Time.time - startTime) / _fadeOutDuration;
            _canvasGroup.alpha = Mathf.Lerp(startAlpha, 0, progress);
            yield return null;
        }

        _canvasGroup.alpha = 0;

        Destroy(gameObject);
    }
}
