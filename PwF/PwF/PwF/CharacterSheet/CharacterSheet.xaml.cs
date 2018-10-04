using PwF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PwF.CharacterSheet
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CharacterSheet : ContentPage
	{
		public CharacterSheet ()
		{
            BindingContext = new CharacterSheetViewModel();
			InitializeComponent ();
		}
	}
}