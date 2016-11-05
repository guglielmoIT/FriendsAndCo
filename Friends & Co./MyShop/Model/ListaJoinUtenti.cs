using System;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace FriendsAndCo
{
	public class ListaJoinUtentiItem
	{
		string id;
		bool deleted;
		string idLista;
		string idUtente;
		bool proprietario;

		[JsonProperty(PropertyName = "id")]
		public string Id
		{
			get { return id; }
			set { id = value; }
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
		[JsonProperty(PropertyName = "idUtente")]
		public string IdUtente
		{
			get { return idUtente; }
			set { idUtente = value; }
		}

		[JsonProperty(PropertyName = "proprietario")]
		public bool Proprietario
		{
			get { return proprietario; }
			set { proprietario = value; }
		}


		[Version]
		public string Version { get; set; }
	}
}

