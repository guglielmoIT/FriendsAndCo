using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FriendsAndCo
{
	public partial class NuovaLista : ContentPage
	{
		ListeItemManager manager;
		public NuovaLista()
		{
			InitializeComponent();
			gestQuote.IsVisible = false;
			dataFinoAl.Date = System.DateTime.Now.AddDays(30);
		}
		protected override async void OnAppearing()
		{
			base.OnAppearing();

			// Set syncItems to true in order to synchronize the data on startup when running in offline mode
			//await RefreshItems(true, syncItems: false);
		}
		public async void OnSalvaDescrizione(object sender, EventArgs e)
		{
			ListaItem lista = new ListaItem();
			lista.Descrizione = descrizioneLista.Text;
			await manager.SaveTaskAsync(lista);

			buttonsGruppiPanel0.IsVisible = true;
			buttonsGruppiPanel1.IsVisible = true;
			buttonsGruppiPanel2.IsVisible = true;
		}
		public async void OnGestIntolleranze(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NuovaLista());
		}
		public async void OnGestAllergie(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NuovaLista());
		}
		public async void OnGestQuote(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NuovaLista());
		}
		public async void OnGestPersonalizzato(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NuovaLista());
		}

	}
}
