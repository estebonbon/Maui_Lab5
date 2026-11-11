using Lab5.ViewModels;
namespace Lab5.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //await DisplayAlertAsync(
            //    "TEST",
            //    "The button event handler is working!",
            //    "OK"
            //    );

            //Confirm the user wants to change the difficulty
            string action = await DisplayActionSheet(
                "Would you like to play another round",
                "No",
                null,
                "Yes"
                );

            if (action == "Yes")
            {
                await DisplayAlert("Let's Play!", "Good luck on your next round", "OK");
            }

            //if(action == "Yes")
            //{
            //    //Change the difficulty level
            //    //First it checks whether the BindingContext Contains a MyViewModel object, and if it does, it assigns that object to the viewModel variable.
            //    //.Excute tells the command to run, tostring converts the option into a string.
            //    if (BindingContext is MyViewModel vm)
            //    {
            //        vm.ChangeTheDifficultyCommand.Execute(DifficultyPicker.SelectedItem.ToString());
            //    }
            //}
        }
    }
}
