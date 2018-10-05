using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PwF.CharacterSheet;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace PwF
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            CharacterCreation.RacePage mainPage = new CharacterCreation.RacePage();
      
            CharacterCreation.ClassPage mainPage = new CharacterCreation.ClassPage();
            
            MainPage = new NavigationPage(mainPage);
            Pwf.Navigation.PageNavigationManager.Instance.Navigation = MainPage.Navigation;
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
