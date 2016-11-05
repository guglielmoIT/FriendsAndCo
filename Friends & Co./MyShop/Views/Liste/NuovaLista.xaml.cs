using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FriendsAndCo
{
	public partial class NuovaLista : ContentPage
	{
		ListeItemManager manager;
		ListeJoinUtentiManager managerJoin;

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

			LocalDb Db = new LocalDb();
			User usr = await Db.GetLocalUserAsync();


			ListaItem lista = new ListaItem();
			lista.Descrizione = descrizioneLista.Text;
			lista.DataFineValidita = dataFinoAl.Date;
			if (idLista.Text != "")
			{
				lista.Id = idLista.Text;
			}
			lista.IdUtenteCreatore = usr.Id;
			manager = ListeItemManager.DefaultManager;

			await manager.SaveTaskAsync(lista);

			if (idLista.Text == "")
			{
				//salvataggio Join utenti
				ListaJoinUtentiItem listaJoin = new ListaJoinUtentiItem();
				listaJoin.IdLista = lista.Id;
				listaJoin.IdUtente = usr.Id;
				listaJoin.Proprietario = true;
				managerJoin = ListeJoinUtentiManager.DefaultManager;

				await managerJoin.SaveTaskAsync(listaJoin);

			}

			idLista.Text = lista.Id;


			buttonsGruppiPanel0.IsVisible = true;
			buttonsGruppiPanel1.IsVisible = true;
			buttonsGruppiPanel2.IsVisible = true;
		}
		public async void OnGestIntolleranze(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new GestIntolleranze());
		}
		public async void OnGestAllergie(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new GestAllergie());
		}
		public async void OnGestQuote(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NuovaLista());
		}
		public async void OnGestPersonalizzato(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new gestPersonalizzato());
		}

	}
}
