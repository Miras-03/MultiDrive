using System.Collections;
using UnityEngine;

public sealed class EnableFinishPanel : MonoBehaviour, IFinishObserver
{
    [SerializeField] private GameObject finishPanel;
    private const int waitForSeconds = 5;

    public void Execute() => StartCoroutine(EnablePanel());

    private IEnumerator EnablePanel()
    {
        yield return new WaitForSeconds(waitForSeconds);
        EnableFinishIcons();
    }

    private void EnableFinishIcons() => finishPanel.SetActive(true);
}
