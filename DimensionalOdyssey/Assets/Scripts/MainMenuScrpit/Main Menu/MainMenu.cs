// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEngine.UI;

// public class MainMenu : Menu
// {
//     [Header("Menu Navigation")]
//     [SerializeField] private SaveSlotsMenu saveSlotsMenu;

//     [Header("Menu Buttons")]
//     [SerializeField] private Button newGameButton;
//     [SerializeField] private Button loadGameButton;

//     private void Start() 
//     {
//         if (!DataPersistenceManager.instance.HasGameData()) 
//         {
//             loadGameButton.interactable = false;
//         }
//     }

//     public void OnNewGameClicked() 
//     {
//         saveSlotsMenu.ActivateMenu(false);
//         this.DeactivateMenu();
//     }

//     public void OnLoadGameClicked() 
//     {
//         saveSlotsMenu.ActivateMenu(true);
//         this.DeactivateMenu();
//     }

//     private void DisableMenuButtons() 
//     {
//         newGameButton.interactable = false;
//     }

//     public void ActivateMenu() 
//     {
//         this.gameObject.SetActive(true);
//     }

//     public void DeactivateMenu() 
//     {
//         this.gameObject.SetActive(false);
//     }
// }