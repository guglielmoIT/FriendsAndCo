﻿using System;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace FriendsAndCo
{
	public class ListaItem
	{
		string id;
		string descrizione;
		bool deleted;
		string idUtenteCreatore;
		DateTime dataFineValidita;

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

		[JsonProperty(PropertyName = "idUtenteCreatore")]
		public string IdUtenteCreatore
		{
			get { return idUtenteCreatore; }
			set { idUtenteCreatore = value; }
		}
		[JsonProperty(PropertyName = "dataFineValidita")]
		public DateTime DataFineValidita
		{
			get { return dataFineValidita; }
			set { dataFineValidita = value; }
		}
[Version]
		public string Version { get; set; }
	}
}

