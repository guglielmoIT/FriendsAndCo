﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace FriendsAndCo
{
	public partial class GestioneListe : ContentPage
	{
		ListeItemManager manager ;

		public GestioneListe()
		{
			InitializeComponent();
		}
		protected override async void OnAppearing()
		{
			base.OnAppearing();

			// Set syncItems to true in order to synchronize the data on startup when running in offline mode
			//await RefreshItems(true, syncItems: false);
		}

	
		async Task CompleteItem(ListaItem item)
		{
			//item.Done = true;
			await manager.SaveTaskAsync(item);
			//todoList.ItemsSource = await manager.GetTodoItemsAsync();
		}

		public async void OnAdd(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NuovaLista());
		}

		public async void OnJoin(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new JoinLista());
		}
		// Event handlers
		public async void OnSelected(object sender, SelectedItemChangedEventArgs e)
		{
			await Navigation.PushAsync(new ListaDettaglio());
			// prevents background getting highlighted
			//todoList.SelectedItem = null;
		}

		// http://developer.xamarin.com/guides/cross-platform/xamarin-forms/working-with/listview/#pulltorefresh
		public async void OnRefresh(object sender, EventArgs e)
		{
			var list = (ListView)sender;
			Exception error = null;
			try
			{
				await RefreshItems(false, true);
			}
			catch (Exception ex)
			{
				error = ex;
			}
			finally
			{
				list.EndRefresh();
			}

			if (error != null)
			{
				await DisplayAlert("Refresh Error", "Couldn't refresh data (" + error.Message + ")", "OK");
			}
		}

		public async void OnSyncItems(object sender, EventArgs e)
		{
			await RefreshItems(true, true);
		}

		private async Task RefreshItems(bool showActivityIndicator, bool syncItems)
		{
			using (var scope = new ActivityIndicatorScope(syncIndicator, showActivityIndicator))
			{
				//todoList.ItemsSource = await manager.GetTodoItemsAsync(syncItems);
			}
		}

		private class ActivityIndicatorScope : IDisposable
		{
			private bool showIndicator;
			private ActivityIndicator indicator;
			private Task indicatorDelay;

			public ActivityIndicatorScope(ActivityIndicator indicator, bool showIndicator)
			{
				this.indicator = indicator;
				this.showIndicator = showIndicator;

				if (showIndicator)
				{
					indicatorDelay = Task.Delay(2000);
					SetIndicatorActivity(true);
				}
				else {
					indicatorDelay = Task.FromResult(0);
				}
			}

			private void SetIndicatorActivity(bool isActive)
			{
				this.indicator.IsVisible = isActive;
				this.indicator.IsRunning = isActive;
			}

			public void Dispose()
			{
				if (showIndicator)
				{
					indicatorDelay.ContinueWith(t => SetIndicatorActivity(false), TaskScheduler.FromCurrentSynchronizationContext());
				}
			}
		}
	}
}

