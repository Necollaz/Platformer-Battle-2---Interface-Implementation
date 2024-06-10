using TMPro;
using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private float _delay = 0.5f;
    private float _number = 0;
    private Coroutine _countCoroutine = null;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
            ToggleCounting();
    }

    private void ToggleCounting()
    {
        if (_countCoroutine == null)
        {
            _countCoroutine = StartCoroutine(Countup(_delay));
        }
        else
        {
            StopCoroutine(_countCoroutine);
            _countCoroutine = null;
        }
    }

    private IEnumerator Countup(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (_countCoroutine != null)
        {
            _number++;
            DisplayCountup(_number);
            yield return wait;
        }
    }

    private void DisplayCountup(float number)
    {
        _text.text = number.ToString();
    }
}
