using System;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace FriendsAndCo
{
	public class ListaGruppiItemItem
	{
		string id;
		string descrizione;
		bool deleted;
		string idgruppo;

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

		[JsonProperty(PropertyName = "idgruppo")]
		public string Idgruppo
		{
			get { return idgruppo; }
			set { idgruppo = value; }
		}


		[Version]
		public string Version { get; set; }
	}
}

