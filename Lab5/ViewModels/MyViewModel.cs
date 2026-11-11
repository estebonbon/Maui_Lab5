using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lab5.Models;

namespace Lab5.ViewModels
{
    //Obersvable objects creat public properties for private fields
    public partial class MyViewModel : ObservableObject
    {

        //I dont understand why i cant just create the object for the variable as soon as i declare the variable, why do i need a constructor
        //[ObservableProperty]
        //private Games chess = new Games() { Name = "Chess", Difficulty = Difficulty.Hard, NumberOfPlayers = 2 };

        //Create the private property
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(DifficultyColor))] //This will notify the UI that the property has changed, and it will let DifficultyColor know that it needs to update the color of the text based on the new difficulty level
        private Games gameOne;


        //Constructor For Game 
        public MyViewModel() 
        {
            GameOne = new Games() { Name = "Chess", Difficulty = Difficulty.Hard, NumberOfPlayers = 2, Rounds = 0 }; //Creates the object for chess
        }

        // 5c would only be possible with a [RelayCommand]
        [RelayCommand]
        void ChangeTheDifficulty(string? difficulty) //changed it to string
        {
            if (string.IsNullOrWhiteSpace(difficulty))
            {
                return;
            }

            GameOne = new Games() { Name = GameOne.Name, Difficulty = Enum.Parse<Difficulty>(difficulty), NumberOfPlayers = GameOne.NumberOfPlayers, Rounds = GameOne.Rounds };
        }
        //The reason the whole object has to change is becuase the indiviual property is not ObservableProperty
        // We replace the entire GameOne object because Games does not
        // notify the UI when its individual properties change.
        // Assigning a new GameOne object triggers PropertyChanged.

        //This will be the dependent property
        public Color DifficultyColor =>
            GameOne.Difficulty switch
            {
                Difficulty.Hard => Colors.Red,
                Difficulty.Intermediate => Colors.Orange,
                Difficulty.Easy => Colors.Green,
                _ => Colors.Black //Incase there is a value that is not in the enum, it will default to black, its an if/else statement
            }; 
    }
}
