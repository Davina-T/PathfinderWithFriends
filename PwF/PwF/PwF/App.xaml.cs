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

            CharacterList.CharacterList mainPage = new CharacterList.CharacterList();

            //CharacterCreation.LevelPage mainPage = new CharacterCreation.LevelPage();
            //CharacterCreation.LanguagePage mainPage = new CharacterCreation.LanguagePage();
            //CharacterCreation.LevelPage mainPage = new CharacterCreation.LevelPage();
            //CharacterCreation.AbilityScorePage mainPage = new CharacterCreation.AbilityScorePage();
            //CharacterCreation.FeatsPage mainPage = new CharacterCreation.FeatsPage();
            //CharacterCreation.AbilityScorePage mainPage = new CharacterCreation.AbilityScorePage();

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
