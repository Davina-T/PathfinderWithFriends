﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PwF.CharacterCreation
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TesterPage : ContentPage
	{
        TesterPageViewModel viewModel;

        public TesterPage()
		{
            InitializeComponent();

            viewModel = new TesterPageViewModel();

            ConfirmCharacter.BindingContext = viewModel;
            ConfirmCharacter.Text = "Confirm Character";

            ConfirmCharacter.Command = new Command(() => {
                viewModel.ReturnToList();
            });
            
        }
	}
}