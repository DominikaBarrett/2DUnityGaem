﻿using DungeonCrawl.Core;
using Source.Actors.Characters;
using Source.Core;
using Source.Core.SavingManager;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Source.UI
{
    public class QuickMenu : Menu
    {
        private Player _player;
        public bool enabled
        {
            get => transform.parent.gameObject.activeSelf;
            set
            {
                transform.parent.gameObject.SetActive(value);
                _player.enabled = !value;
            }
        }
        protected override void HandleOption()
        {
            switch (Selected)
            {
                case 0:
                    // Continue game
                    enabled = false;
                    break;
                case 1:
                    // Start new game
                    SceneManager.LoadScene("Level1");
                    break;
                case 2:
                    // Save game
                    SavingManager.Singleton.SaveGame();
                    gameObject.transform.parent.gameObject.SetActive(false);
                    ActorManager.Singleton.Player.enabled = true;
                    MessageBox.Singleton.DisplayMessage("Game saved.");
                    Debug.Log("Game saved.");
                    break;
                case 3:
                    // Load game
                    SavingManager.Singleton.LoadSave(SavingManager.Singleton.LoadFromFileSave());
                    gameObject.transform.parent.gameObject.SetActive(false);
                    ActorManager.Singleton.Player.enabled = true;
                    MessageBox.Singleton.DisplayMessage("Game Loaded.");
                    Debug.Log("Game loaded.");
                    break;
                case 4:
                    // TODO Settings
                    break;
                case 5:
                    // Go to Main Menu
                    SceneManager.LoadScene("MainMenu");
                    break;
            }
        }

        protected override void OnAwake()
        {
            base.OnAwake();
            _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        }
    }
}