using System;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace FriendsAndCo
{
	public class opzioniGruppi
	{
		int id;
		string descrizione;
		int deleted;
		int automatico;

		[JsonProperty(PropertyName = "id")]
		public int Id
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
		public int Deleted
		{
			get { return deleted; }
			set { deleted = value; }
		}

		[JsonProperty(PropertyName = "automatico")]
		public int Automatico
		{
			get { return automatico; }
			set { automatico = value; }
		}

		[Version]
		public string Version { get; set; }
	}
}

