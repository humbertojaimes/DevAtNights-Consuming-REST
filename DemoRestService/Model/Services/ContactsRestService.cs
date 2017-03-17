using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text;

namespace DemoRestService
{
	public enum Response
	{
		Ok,
		Error,
		CommunicationError,
		LocalError,
		UnknownError
	}

	public class ContactsRestService
	{

		const string uri = "http://adventureservicedemo.azurewebsites.net/Api/Contacts";

		public async Task<List<Contact>>  GetContacts( ) 
		{
			Response result = Response.UnknownError;
			List<Contact> contacts = null;
			HttpRequestMessage getContactsRequest =
				new HttpRequestMessage();
			getContactsRequest.Headers.Add("Accept","application/json");
			getContactsRequest.RequestUri
			                  = new Uri(uri);
			getContactsRequest.Method = HttpMethod.Get;

			HttpClient client = new HttpClient();

			HttpResponseMessage getContactResponse 
			= await client.SendAsync(getContactsRequest);

			var contactsResponse = await client.GetStringAsync(uri);

			if (getContactResponse.StatusCode == HttpStatusCode.OK)
			{
				contacts =  JsonConvert.DeserializeObject <List<Contact>>(await getContactResponse.Content.ReadAsStringAsync());
				result = Response.Ok;
			}
			else
			{
				result = Response.Error;
			}

			return contacts;
		}


		public async Task<Response> AddContacts(Contact contact)
		{
			Response result = Response.UnknownError;
			contact.ID = Guid.NewGuid().ToString().Substring(0, 6);

			var contactJson = JsonConvert.SerializeObject(contact,Formatting.None);

			HttpClient client = new HttpClient();


			HttpResponseMessage getContactResponse
			= await client.PostAsync(uri,new StringContent(contactJson, Encoding.UTF8, "application/json"));

			if (getContactResponse.StatusCode == HttpStatusCode.Created)
			{
				
				result = Response.Ok;
			}
			else
			{
				result = Response.Error;
			}

			return result;
		}


		public async Task<Response> DeleteContacts(Contact contact)
		{
			Response result = Response.UnknownError;


			var contactJson = JsonConvert.SerializeObject(contact, Formatting.None);

			HttpClient client = new HttpClient();


			HttpResponseMessage getContactResponse
			= await client.DeleteAsync(string.Format($"{uri}/{contact.ID.Trim()}"));

			if (getContactResponse.StatusCode == HttpStatusCode.OK)
			{

				result = Response.Ok;
			}
			else
			{
				result = Response.Error;
			}

			return result;
		}


		public async Task<Response> UpdateContacts(Contact contact)
		{
			Response result = Response.UnknownError;


			var contactJson = JsonConvert.SerializeObject(contact,Formatting.None);

			HttpClient client = new HttpClient();


			HttpResponseMessage getContactResponse
			= await client.PutAsync(string.Format($"{uri}/{contact.ID.Trim()}"), new StringContent(contactJson, Encoding.UTF8, "application/json"));

			if (getContactResponse.StatusCode == HttpStatusCode.NoContent)
			{

				result = Response.Ok;
			}
			else
			{
				result = Response.Error;
			}

			return result;
		}

	}
}
