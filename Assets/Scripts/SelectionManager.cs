using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectionManager : MonoBehaviour
{
    public GameObject interaction_Info_UI;
    TextMeshProUGUI interaction_text;

    private void Start()
    {
        interaction_text = interaction_Info_UI.GetComponentInChildren<TextMeshProUGUI>();
        if(interaction_text ==  null)
        {
            Debug.Log("Interaction text is null");
        }
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;
            if (hit.transform.name != "Terrain")
            {
                Debug.Log("Ray hit: " + hit.transform.name);
            }

            if (selectionTransform.GetComponent<InteractableObject>())
            {
                Debug.Log("Interactable component seen.");
                interaction_text.text = selectionTransform.GetComponent<InteractableObject>().GetItemName();
                interaction_Info_UI.SetActive(true);
            }
            else
            {
                interaction_Info_UI.SetActive(false);
            }
        }
        else
        {
            interaction_Info_UI.SetActive(false);
        }
    }
}
