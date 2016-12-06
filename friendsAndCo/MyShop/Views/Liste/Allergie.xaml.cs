using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FriendsAndCo
{
	public partial class Allergie : ContentPage
	{
		ListaItem paramLista = new ListaItem();

		OpzioniGruppiManager opzManager = OpzioniGruppiManager.DefaultManager;

		public Allergie(ListaItem lst)
		{
			InitializeComponent();
			paramLista = lst;

			titolo.Text = paramLista.Operazione;

			//nel campo deleted è dichiarato il parametro automatico



			if (titolo.Text == "Personalizzato")
			{
				addLista.IsVisible = true;
			}
			else
			{
				addLista.IsVisible = false;
			}




		}

		public Allergie()
		{
			InitializeComponent();

		}

		void OnAdd(object sender, System.EventArgs e)
		{
			throw new NotImplementedException();
		}
		void OnSelected(object sender, System.EventArgs e)
		{
			throw new NotImplementedException();
		}
		void OnRefresh(object sender, System.EventArgs e)
		{
			throw new NotImplementedException();
		}

	}
}
