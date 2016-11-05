// To add offline sync support: add the NuGet package WindowsAzure.MobileServices.SQLiteStore
// to all projects in the solution and uncomment the symbol definition OFFLINE_SYNC_ENABLED
// For Xamarin.iOS, also edit AppDelegate.cs and uncomment the call to SQLitePCL.CurrentPlatform.Init()
// For more information, see: http://go.microsoft.com/fwlink/?LinkId=620342 
//#define OFFLINE_SYNC_ENABLED

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;



namespace FriendsAndCo
{
	public partial class ListeItemManager
	{
		static ListeItemManager defaultInstance = new ListeItemManager();
		MobileServiceClient client;

		IMobileServiceTable<ListaItem> todoTable;

		private ListeItemManager()
		{
			this.client = new MobileServiceClient(
				Constants.ApplicationURL);


			this.todoTable = client.GetTable<ListaItem>();
		}

		public static ListeItemManager DefaultManager
		{
			get
			{
				return defaultInstance;
			}
			private set
			{
				defaultInstance = value;
			}
		}

		public MobileServiceClient CurrentClient
		{
			get { return client; }
		}

		public bool IsOfflineEnabled
		{
			get { return todoTable is Microsoft.WindowsAzure.MobileServices.Sync.IMobileServiceSyncTable<ListaItem>; }
		}

		public async Task<ObservableCollection<ListaItem>> GetTodoItemsAsync(bool syncItems = false)
		{
			try
			{

				IEnumerable<ListaItem> items = await todoTable
					.Where(todoItem => !todoItem.Deleted)
					.ToEnumerableAsync();

				return new ObservableCollection<ListaItem>(items);
			}
			catch (MobileServiceInvalidOperationException msioe)
			{
				Debug.WriteLine(@"Invalid sync operation: {0}", msioe.Message);
			}
			catch (Exception e)
			{
				Debug.WriteLine(@"Sync error: {0}", e.Message);
			}
			return null;
		}

		public async Task SaveTaskAsync(ListaItem item)
		{
			if (item.Id == null)
			{
				await todoTable.InsertAsync(item);

			}
			else {
				await todoTable.UpdateAsync(item);
			}
		}


	}
}
