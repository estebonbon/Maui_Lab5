using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
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
        private Games chess;


        //Constructor For Game 
        public MyViewModel() 
        {
            Chess = new Games() { Name = "Chess", Difficulty = Difficulty.Hard, NumberOfPlayers = 2, Rounds = 0 }; //Creates the object for chess
        }

        // 5c would only be possible with a [RelayCommand]
        [RelayCommand]
        void ChangeTheDifficulty(Difficulty difficulty)
        {
            Chess = new Games() { Name = Chess.Name, Difficulty = difficulty, NumberOfPlayers = Chess.NumberOfPlayers, Rounds = Chess.Rounds };
        }
        //The reason the whole object has to change is becuase the indiviual property is not ObservableProperty
        // We replace the entire Chess object because Games does not
        // notify the UI when its individual properties change.
        // Assigning a new Chess object triggers PropertyChanged.

        //This will be the dependent property

    }
}
