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
		bool completo;
		bool selezionato;
		string iduserCompletato;
		bool completabile;

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

		[JsonProperty(PropertyName = "completo")]
		public bool Completo
		{
			get { return completo; }
			set { completo = value; }
		}

		[JsonProperty(PropertyName = "selezionato")]
		public bool Selezionato
		{
			get { return selezionato; }
			set { selezionato = value; }
		}

		[JsonProperty(PropertyName = "iduserCompletato")]
		public string IdUserCompletato
		{
			get { return iduserCompletato; }
			set { iduserCompletato = value; }
		}

		[JsonProperty(PropertyName = "completabile")]
		public bool Completabile
		{
			get { return completabile; }
			set { completabile = value; }
		}

		[Version]
		public string Version { get; set; }
	}
}

