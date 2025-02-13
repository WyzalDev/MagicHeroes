using System;
using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class PointsAnimation : MonoBehaviour
{
    [SerializeField] private TMP_Text textPrefabWithNeededFont; 
    
    private TMP_Text _text;

    private readonly WaitForSeconds _cachedWaitForSeconds = new WaitForSeconds(0.3f);

    private const string ONE_DOT = ".";
    private const string TWO_DOTS = "..";
    private const string THREE_DOTS = "...";
    
    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
        textPrefabWithNeededFont.ForceMeshUpdate();
        _text.fontSize = textPrefabWithNeededFont.fontSize;
    }

    private void OnEnable()
    {
        StartCoroutine(AnimationCoroutine());
    }

    private void OnDisable()
    {
        StopCoroutine(AnimationCoroutine());
    }

    private IEnumerator AnimationCoroutine()
    {
        do
        {
            yield return _cachedWaitForSeconds;
            _text.text = ONE_DOT;
            yield return _cachedWaitForSeconds;
            _text.text = TWO_DOTS;
            yield return _cachedWaitForSeconds;
            _text.text = THREE_DOTS;
            yield return _cachedWaitForSeconds;
        } while (true);
    }

}
