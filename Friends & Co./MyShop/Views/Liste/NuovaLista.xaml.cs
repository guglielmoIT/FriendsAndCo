using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MvvmHelpers;

using Xamarin.Forms;

namespace FriendsAndCo
{
	public partial class NuovaLista : ContentPage
	{
		ListeItemManager manager;
		ListeJoinUtentiManager managerJoin;
		ListeGruppiManager managerGruppi;
		ListaGruppiItemManager managerGruppiItem;
		IntolleranzeItemManager managerIntolleranze;
		AllergieItemManager managerAllergie;

		public ObservableRangeCollection<IntolleranzeItem> itemsIntolleranze { get; set; }
		public ObservableRangeCollection<AllergieItem> itemsAllergie { get; set; }

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

				//Inserisco le intolleranze 
				IntolleranzeItem listIntolleranze = new IntolleranzeItem();
				var intolleranzeVar = await managerIntolleranze.GetTodoItemsAsync(false);
				itemsIntolleranze.Clear();
				itemsIntolleranze.ReplaceRange(intolleranzeVar);


				foreach (var item in itemsIntolleranze)
				{
					ListaGruppiItem listaGruppiItem = new ListaGruppiItem();
					listaGruppiItem.IdLista = lista.Id;
					listaGruppiItem.Descrizione = "Intolleranze";
					await managerGruppi.SaveTaskAsync(listaGruppiItem);

					ListaGruppiItemItem listaGruppiItemItem = new ListaGruppiItemItem();
					listaGruppiItemItem.Completo = false;
					listaGruppiItemItem.Descrizione = item.Descrizione;
					listaGruppiItemItem.Selezionato = false;
					listaGruppiItemItem.Idgruppo = listaGruppiItem.Id;
					listaGruppiItemItem.Completabile = false;

					await managerGruppiItem.SaveTaskAsync(listaGruppiItemItem);
				}

				//Inserisco le allergie 
				AllergieItem listAllergie = new AllergieItem();
				var allergieVar = await managerAllergie.GetTodoItemsAsync(false);
				itemsAllergie.Clear();
				itemsAllergie.ReplaceRange(allergieVar);


				foreach (var item in itemsAllergie)
				{
					ListaGruppiItem listaGruppiItem = new ListaGruppiItem();
					listaGruppiItem.IdLista = lista.Id;
					listaGruppiItem.Descrizione = "Allegie";
					await managerGruppi.SaveTaskAsync(listaGruppiItem);

					ListaGruppiItemItem listaGruppiItemItem = new ListaGruppiItemItem();
					listaGruppiItemItem.Completo = false;
					listaGruppiItemItem.Descrizione = item.Descrizione;
					listaGruppiItemItem.Selezionato = false;
					listaGruppiItemItem.Idgruppo = listaGruppiItem.Id;
					listaGruppiItemItem.Completabile = false;

					await managerGruppiItem.SaveTaskAsync(listaGruppiItemItem);
				}



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
