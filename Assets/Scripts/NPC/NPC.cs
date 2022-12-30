using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [SerializeField] private List<string> sentences;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private float stopTimeEachSentence;
    [SerializeField] private float stopTimeEachChar;
    [SerializeField] private GameObject dialog;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (animator.isActiveAndEnabled == false)
            {
                animator.enabled = true;
                dialog.SetActive(true);
                StartCoroutine("StartDialog");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (animator.isActiveAndEnabled == true)
            {
                animator.enabled = false;
                dialog.SetActive(false);
                StopCoroutine("StartDialog");
            }
        }
    }

    IEnumerator StartDialog()
    {
        while (true)
        {
            dialogText.text = "";
            foreach (string sentence in sentences)
            {
                dialogText.text = "";
                foreach (char c in sentence.ToCharArray())
                {
                    dialogText.text += c;
                    yield return new WaitForSeconds(stopTimeEachChar);
                }
                dialogText.text += " ...";
                yield return new WaitForSeconds(stopTimeEachSentence);
            }
        }
    }
}
