using System;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace FriendsAndCo
{
	public class ListaGruppiItem
	{
		string id;
		string descrizione;
		bool deleted;
		string idLista;

		[JsonProperty(PropertyName = "id")]
		public string Id
		{
			get { return id; }
			set { id = value; }
		}

		[JsonProperty(PropertyName = "descrizione")]
		public string Descrizione
		{
			get { return descrizione; }
			set { descrizione = value; }
		}

		[JsonProperty(PropertyName = "deleted")]
		public bool Deleted
		{
			get { return deleted; }
			set { deleted = value; }
		}

		[JsonProperty(PropertyName = "idLista")]
		public string IdLista
		{
			get { return idLista; }
			set { idLista = value; }
		}

		[Version]
		public string Version { get; set; }
	}
}

