using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillsUserInterface : PartyBehaviour
{
    [SerializeField] private Transform skillContainer;
    [SerializeField] private Button skillButtonPrefab;

    private void Start()
    {
        GenerateSkillButtons(); 
    }

    public void GenerateSkillButtons()
    {
        ResetSkillButtons();
        foreach (Action skill in party.GetSelectedCharacter().GetActionList().GetActions())
        {
            Button newButton = Instantiate(skillButtonPrefab, skillContainer);
            newButton.GetComponentInChildren<TextMeshProUGUI>().text = skill.GetActionName();

            newButton.onClick.AddListener(() => OnSkillButtonClick(skill));
        }
    }

    private void OnSkillButtonClick(Action skill)
    {
        party.GetSelectedCharacter().GetActionList().SetSelectedAction(skill);
    }

    private void ResetSkillButtons()
    {
        foreach (Transform child in skillContainer)
        {
            Debug.Log("delete");
            Destroy(child.gameObject);
        }
    }


}
