using SevDesk.Extensions.ClientApi.Client;
using SevDesk.Extensions.ClientApi.Model;

namespace SevDesk.Extensions.ClientApi.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IContactApi : IApiAccessor
{
	#region Synchronous Operations

	/// <summary>
	///     Check if a customer number is available
	/// </summary>
	/// <remarks>
	///     Checks if a given customer number is available or already used.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="customerNumber">The customer number to be checked. (optional)</param>
	/// <returns>InlineResponse20011</returns>
	InlineResponse20011 ContactCustomerNumberAvailabilityCheck(string customerNumber = null);

	/// <summary>
	///     Check if a customer number is available
	/// </summary>
	/// <remarks>
	///     Checks if a given customer number is available or already used.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="customerNumber">The customer number to be checked. (optional)</param>
	/// <returns>ApiResponse of InlineResponse20011</returns>
	ApiResponse<InlineResponse20011> ContactCustomerNumberAvailabilityCheckWithHttpInfo(string customerNumber = null);

	/// <summary>
	///     Create a new contact
	/// </summary>
	/// <remarks>
	///     Creates a new contact.&lt;br&gt;       For adding addresses and communication ways, you will need to use the
	///     ContactAddress and CommunicationWay endpoints.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">Creation data (optional)</param>
	/// <returns>GetContactResponse</returns>
	GetContactResponse CreateContact(ModelContact body = null);

	/// <summary>
	///     Create a new contact
	/// </summary>
	/// <remarks>
	///     Creates a new contact.&lt;br&gt;       For adding addresses and communication ways, you will need to use the
	///     ContactAddress and CommunicationWay endpoints.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">Creation data (optional)</param>
	/// <returns>ApiResponse of GetContactResponse</returns>
	ApiResponse<GetContactResponse> CreateContactWithHttpInfo(ModelContact body = null);

	/// <summary>
	///     Deletes a contact
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactId">Id of contact resource to delete</param>
	/// <returns>InlineResponse2003</returns>
	InlineResponse2003 DeleteContact(int? contactId);

	/// <summary>
	///     Deletes a contact
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactId">Id of contact resource to delete</param>
	/// <returns>ApiResponse of InlineResponse2003</returns>
	ApiResponse<InlineResponse2003> DeleteContactWithHttpInfo(int? contactId);

	/// <summary>
	///     Find contact by ID
	/// </summary>
	/// <remarks>
	///     Returns a single contact
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactId">ID of contact to return</param>
	/// <returns>GetContactResponse</returns>
	GetContactResponse GetContactById(int? contactId);

	/// <summary>
	///     Find contact by ID
	/// </summary>
	/// <remarks>
	///     Returns a single contact
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactId">ID of contact to return</param>
	/// <returns>ApiResponse of GetContactResponse</returns>
	ApiResponse<GetContactResponse> GetContactByIdWithHttpInfo(int? contactId);

	/// <summary>
	///     Get number of all items
	/// </summary>
	/// <remarks>
	///     Get number of all invoices, orders, etc. of a specified contact
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactId">ID of contact to return</param>
	/// <returns>InlineResponse20018</returns>
	InlineResponse20018 GetContactTabsItemCountById(int? contactId);

	/// <summary>
	///     Get number of all items
	/// </summary>
	/// <remarks>
	///     Get number of all invoices, orders, etc. of a specified contact
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactId">ID of contact to return</param>
	/// <returns>ApiResponse of InlineResponse20018</returns>
	ApiResponse<InlineResponse20018> GetContactTabsItemCountByIdWithHttpInfo(int? contactId);

	/// <summary>
	///     Retrieve contacts
	/// </summary>
	/// <remarks>
	///     There are a multitude of parameter which can be used to filter.&lt;br&gt;       A few of them are attached but
	///     for a complete list please check out &lt;a href&#x3D;&#x27;
	///     https://api.sevdesk.de/#section/How-to-filter-for-certain-contacts&#x27;&gt;this&lt;/a&gt; list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="depth">
	///     Defines if both organizations &lt;b&gt;and&lt;/b&gt; persons should be returned.&lt;br&gt;
	///     &#x27;0&#x27; -&gt; only organizations, &#x27;1&#x27; -&gt; organizations and persons (optional)
	/// </param>
	/// <param name="customerNumber">Retrieve all contacts with this customer number (optional)</param>
	/// <returns>GetContactResponse</returns>
	GetContactResponse GetContacts(string depth = null, string customerNumber = null);

	/// <summary>
	///     Retrieve contacts
	/// </summary>
	/// <remarks>
	///     There are a multitude of parameter which can be used to filter.&lt;br&gt;       A few of them are attached but
	///     for a complete list please check out &lt;a href&#x3D;&#x27;
	///     https://api.sevdesk.de/#section/How-to-filter-for-certain-contacts&#x27;&gt;this&lt;/a&gt; list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="depth">
	///     Defines if both organizations &lt;b&gt;and&lt;/b&gt; persons should be returned.&lt;br&gt;
	///     &#x27;0&#x27; -&gt; only organizations, &#x27;1&#x27; -&gt; organizations and persons (optional)
	/// </param>
	/// <param name="customerNumber">Retrieve all contacts with this customer number (optional)</param>
	/// <returns>ApiResponse of GetContactResponse</returns>
	ApiResponse<GetContactResponse> GetContactsWithHttpInfo(string depth = null, string customerNumber = null);

	/// <summary>
	///     Get next free customer number
	/// </summary>
	/// <remarks>
	///     Retrieves the next available customer number. Avoids duplicates.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>InlineResponse20035</returns>
	InlineResponse20035 GetNextCustomerNumber();

	/// <summary>
	///     Get next free customer number
	/// </summary>
	/// <remarks>
	///     Retrieves the next available customer number. Avoids duplicates.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>ApiResponse of InlineResponse20035</returns>
	ApiResponse<InlineResponse20035> GetNextCustomerNumberWithHttpInfo();

	/// <summary>
	///     Update a existing contact
	/// </summary>
	/// <remarks>
	///     Update a contact
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactId">ID of contact to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>GetContactResponse</returns>
	GetContactResponse UpdateContact(int? contactId, ModelContactUpdate body = null);

	/// <summary>
	///     Update a existing contact
	/// </summary>
	/// <remarks>
	///     Update a contact
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactId">ID of contact to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>ApiResponse of GetContactResponse</returns>
	ApiResponse<GetContactResponse> UpdateContactWithHttpInfo(int? contactId, ModelContactUpdate body = null);

	#endregion Synchronous Operations

	#region Asynchronous Operations

	/// <summary>
	///     Check if a customer number is available
	/// </summary>
	/// <remarks>
	///     Checks if a given customer number is available or already used.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="customerNumber">The customer number to be checked. (optional)</param>
	/// <returns>Task of InlineResponse20011</returns>
	Task<InlineResponse20011> ContactCustomerNumberAvailabilityCheckAsync(string customerNumber = null);

	/// <summary>
	///     Check if a customer number is available
	/// </summary>
	/// <remarks>
	///     Checks if a given customer number is available or already used.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="customerNumber">The customer number to be checked. (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse20011)</returns>
	Task<ApiResponse<InlineResponse20011>> ContactCustomerNumberAvailabilityCheckAsyncWithHttpInfo(
		string customerNumber = null);

	/// <summary>
	///     Create a new contact
	/// </summary>
	/// <remarks>
	///     Creates a new contact.&lt;br&gt;       For adding addresses and communication ways, you will need to use the
	///     ContactAddress and CommunicationWay endpoints.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">Creation data (optional)</param>
	/// <returns>Task of GetContactResponse</returns>
	Task<GetContactResponse> CreateContactAsync(ModelContact body = null);

	/// <summary>
	///     Create a new contact
	/// </summary>
	/// <remarks>
	///     Creates a new contact.&lt;br&gt;       For adding addresses and communication ways, you will need to use the
	///     ContactAddress and CommunicationWay endpoints.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">Creation data (optional)</param>
	/// <returns>Task of ApiResponse (GetContactResponse)</returns>
	Task<ApiResponse<GetContactResponse>> CreateContactAsyncWithHttpInfo(ModelContact body = null);

	/// <summary>
	///     Deletes a contact
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactId">Id of contact resource to delete</param>
	/// <returns>Task of InlineResponse2003</returns>
	Task<InlineResponse2003> DeleteContactAsync(int? contactId);

	/// <summary>
	///     Deletes a contact
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactId">Id of contact resource to delete</param>
	/// <returns>Task of ApiResponse (InlineResponse2003)</returns>
	Task<ApiResponse<InlineResponse2003>> DeleteContactAsyncWithHttpInfo(int? contactId);

	/// <summary>
	///     Find contact by ID
	/// </summary>
	/// <remarks>
	///     Returns a single contact
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactId">ID of contact to return</param>
	/// <returns>Task of GetContactResponse</returns>
	Task<GetContactResponse> GetContactByIdAsync(int? contactId);

	/// <summary>
	///     Find contact by ID
	/// </summary>
	/// <remarks>
	///     Returns a single contact
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactId">ID of contact to return</param>
	/// <returns>Task of ApiResponse (GetContactResponse)</returns>
	Task<ApiResponse<GetContactResponse>> GetContactByIdAsyncWithHttpInfo(int? contactId);

	/// <summary>
	///     Get number of all items
	/// </summary>
	/// <remarks>
	///     Get number of all invoices, orders, etc. of a specified contact
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactId">ID of contact to return</param>
	/// <returns>Task of InlineResponse20018</returns>
	Task<InlineResponse20018> GetContactTabsItemCountByIdAsync(int? contactId);

	/// <summary>
	///     Get number of all items
	/// </summary>
	/// <remarks>
	///     Get number of all invoices, orders, etc. of a specified contact
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactId">ID of contact to return</param>
	/// <returns>Task of ApiResponse (InlineResponse20018)</returns>
	Task<ApiResponse<InlineResponse20018>> GetContactTabsItemCountByIdAsyncWithHttpInfo(int? contactId);

	/// <summary>
	///     Retrieve contacts
	/// </summary>
	/// <remarks>
	///     There are a multitude of parameter which can be used to filter.&lt;br&gt;       A few of them are attached but
	///     for a complete list please check out &lt;a href&#x3D;&#x27;
	///     https://api.sevdesk.de/#section/How-to-filter-for-certain-contacts&#x27;&gt;this&lt;/a&gt; list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="depth">
	///     Defines if both organizations &lt;b&gt;and&lt;/b&gt; persons should be returned.&lt;br&gt;
	///     &#x27;0&#x27; -&gt; only organizations, &#x27;1&#x27; -&gt; organizations and persons (optional)
	/// </param>
	/// <param name="customerNumber">Retrieve all contacts with this customer number (optional)</param>
	/// <returns>Task of GetContactResponse</returns>
	Task<GetContactResponse> GetContactsAsync(string depth = null, string customerNumber = null);

	/// <summary>
	///     Retrieve contacts
	/// </summary>
	/// <remarks>
	///     There are a multitude of parameter which can be used to filter.&lt;br&gt;       A few of them are attached but
	///     for a complete list please check out &lt;a href&#x3D;&#x27;
	///     https://api.sevdesk.de/#section/How-to-filter-for-certain-contacts&#x27;&gt;this&lt;/a&gt; list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="depth">
	///     Defines if both organizations &lt;b&gt;and&lt;/b&gt; persons should be returned.&lt;br&gt;
	///     &#x27;0&#x27; -&gt; only organizations, &#x27;1&#x27; -&gt; organizations and persons (optional)
	/// </param>
	/// <param name="customerNumber">Retrieve all contacts with this customer number (optional)</param>
	/// <returns>Task of ApiResponse (GetContactResponse)</returns>
	Task<ApiResponse<GetContactResponse>> GetContactsAsyncWithHttpInfo(string depth = null,
		string customerNumber = null);

	/// <summary>
	///     Get next free customer number
	/// </summary>
	/// <remarks>
	///     Retrieves the next available customer number. Avoids duplicates.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of InlineResponse20035</returns>
	Task<InlineResponse20035> GetNextCustomerNumberAsync();

	/// <summary>
	///     Get next free customer number
	/// </summary>
	/// <remarks>
	///     Retrieves the next available customer number. Avoids duplicates.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ApiResponse (InlineResponse20035)</returns>
	Task<ApiResponse<InlineResponse20035>> GetNextCustomerNumberAsyncWithHttpInfo();

	/// <summary>
	///     Update a existing contact
	/// </summary>
	/// <remarks>
	///     Update a contact
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactId">ID of contact to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>Task of GetContactResponse</returns>
	Task<GetContactResponse> UpdateContactAsync(int? contactId, ModelContactUpdate body = null);

	/// <summary>
	///     Update a existing contact
	/// </summary>
	/// <remarks>
	///     Update a contact
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactId">ID of contact to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>Task of ApiResponse (GetContactResponse)</returns>
	Task<ApiResponse<GetContactResponse>>
		UpdateContactAsyncWithHttpInfo(int? contactId, ModelContactUpdate body = null);

	#endregion Asynchronous Operations
}