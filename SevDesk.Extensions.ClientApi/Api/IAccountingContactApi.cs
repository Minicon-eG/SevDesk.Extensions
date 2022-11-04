using SevDesk.Extensions.ClientApi.Client;
using SevDesk.Extensions.ClientApi.Model;

namespace SevDesk.Extensions.ClientApi.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IAccountingContactApi : IApiAccessor
{
	#region Synchronous Operations

	/// <summary>
	///     Create a new accounting contact
	/// </summary>
	/// <remarks>
	///     Creates a new accounting contact.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">Creation data (optional)</param>
	/// <returns>GetAccountContactResponse</returns>
	GetAccountContactResponse CreateAccountingContact(ModelAccountingContact body = null);

	/// <summary>
	///     Create a new accounting contact
	/// </summary>
	/// <remarks>
	///     Creates a new accounting contact.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">Creation data (optional)</param>
	/// <returns>ApiResponse of GetAccountContactResponse</returns>
	ApiResponse<GetAccountContactResponse> CreateAccountingContactWithHttpInfo(ModelAccountingContact body = null);

	/// <summary>
	///     Deletes an accounting contact
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="accountingContactId">Id of accounting contact resource to delete</param>
	/// <returns>InlineResponse2003</returns>
	InlineResponse2003 DeleteAccountingContact(int? accountingContactId);

	/// <summary>
	///     Deletes an accounting contact
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="accountingContactId">Id of accounting contact resource to delete</param>
	/// <returns>ApiResponse of InlineResponse2003</returns>
	ApiResponse<InlineResponse2003> DeleteAccountingContactWithHttpInfo(int? accountingContactId);

	/// <summary>
	///     Retrieve accounting contact
	/// </summary>
	/// <remarks>
	///     Returns all accounting contact which have been added up until now. Filters can be added.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactId">ID of contact for which you want the accounting contact. (optional)</param>
	/// <param name="contactObjectName">Object name. Only needed if you also defined the ID of a contact. (optional)</param>
	/// <returns>GetAccountContactResponse</returns>
	GetAccountContactResponse GetAccountingContact(string contactId = null, string contactObjectName = null);

	/// <summary>
	///     Retrieve accounting contact
	/// </summary>
	/// <remarks>
	///     Returns all accounting contact which have been added up until now. Filters can be added.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactId">ID of contact for which you want the accounting contact. (optional)</param>
	/// <param name="contactObjectName">Object name. Only needed if you also defined the ID of a contact. (optional)</param>
	/// <returns>ApiResponse of GetAccountContactResponse</returns>
	ApiResponse<GetAccountContactResponse> GetAccountingContactWithHttpInfo(string contactId = null,
		string contactObjectName = null);

	/// <summary>
	///     Find accounting contact by ID
	/// </summary>
	/// <remarks>
	///     Returns a single accounting contac
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="accountingContactId">ID of accounting contact to return</param>
	/// <returns>GetAccountContactResponse</returns>
	GetAccountContactResponse GetAccountingContactById(int? accountingContactId);

	/// <summary>
	///     Find accounting contact by ID
	/// </summary>
	/// <remarks>
	///     Returns a single accounting contac
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="accountingContactId">ID of accounting contact to return</param>
	/// <returns>ApiResponse of GetAccountContactResponse</returns>
	ApiResponse<GetAccountContactResponse> GetAccountingContactByIdWithHttpInfo(int? accountingContactId);

	/// <summary>
	///     Update an existing accounting contact
	/// </summary>
	/// <remarks>
	///     Update an accounting contact
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="accountingContactId">ID of accounting contact to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>GetAccountContactResponse</returns>
	GetAccountContactResponse UpdateAccountingContact(int? accountingContactId,
		ModelAccountingContactUpdate body = null);

	/// <summary>
	///     Update an existing accounting contact
	/// </summary>
	/// <remarks>
	///     Update an accounting contact
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="accountingContactId">ID of accounting contact to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>ApiResponse of GetAccountContactResponse</returns>
	ApiResponse<GetAccountContactResponse> UpdateAccountingContactWithHttpInfo(int? accountingContactId,
		ModelAccountingContactUpdate body = null);

	#endregion Synchronous Operations

	#region Asynchronous Operations

	/// <summary>
	///     Create a new accounting contact
	/// </summary>
	/// <remarks>
	///     Creates a new accounting contact.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">Creation data (optional)</param>
	/// <returns>Task of GetAccountContactResponse</returns>
	Task<GetAccountContactResponse> CreateAccountingContactAsync(ModelAccountingContact body = null);

	/// <summary>
	///     Create a new accounting contact
	/// </summary>
	/// <remarks>
	///     Creates a new accounting contact.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">Creation data (optional)</param>
	/// <returns>Task of ApiResponse (GetAccountContactResponse)</returns>
	Task<ApiResponse<GetAccountContactResponse>> CreateAccountingContactAsyncWithHttpInfo(
		ModelAccountingContact body = null);

	/// <summary>
	///     Deletes an accounting contact
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="accountingContactId">Id of accounting contact resource to delete</param>
	/// <returns>Task of InlineResponse2003</returns>
	Task<InlineResponse2003> DeleteAccountingContactAsync(int? accountingContactId);

	/// <summary>
	///     Deletes an accounting contact
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="accountingContactId">Id of accounting contact resource to delete</param>
	/// <returns>Task of ApiResponse (InlineResponse2003)</returns>
	Task<ApiResponse<InlineResponse2003>> DeleteAccountingContactAsyncWithHttpInfo(int? accountingContactId);

	/// <summary>
	///     Retrieve accounting contact
	/// </summary>
	/// <remarks>
	///     Returns all accounting contact which have been added up until now. Filters can be added.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactId">ID of contact for which you want the accounting contact. (optional)</param>
	/// <param name="contactObjectName">Object name. Only needed if you also defined the ID of a contact. (optional)</param>
	/// <returns>Task of GetAccountContactResponse</returns>
	Task<GetAccountContactResponse> GetAccountingContactAsync(string contactId = null, string contactObjectName = null);

	/// <summary>
	///     Retrieve accounting contact
	/// </summary>
	/// <remarks>
	///     Returns all accounting contact which have been added up until now. Filters can be added.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactId">ID of contact for which you want the accounting contact. (optional)</param>
	/// <param name="contactObjectName">Object name. Only needed if you also defined the ID of a contact. (optional)</param>
	/// <returns>Task of ApiResponse (GetAccountContactResponse)</returns>
	Task<ApiResponse<GetAccountContactResponse>> GetAccountingContactAsyncWithHttpInfo(string contactId = null,
		string contactObjectName = null);

	/// <summary>
	///     Find accounting contact by ID
	/// </summary>
	/// <remarks>
	///     Returns a single accounting contac
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="accountingContactId">ID of accounting contact to return</param>
	/// <returns>Task of GetAccountContactResponse</returns>
	Task<GetAccountContactResponse> GetAccountingContactByIdAsync(int? accountingContactId);

	/// <summary>
	///     Find accounting contact by ID
	/// </summary>
	/// <remarks>
	///     Returns a single accounting contac
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="accountingContactId">ID of accounting contact to return</param>
	/// <returns>Task of ApiResponse (GetAccountContactResponse)</returns>
	Task<ApiResponse<GetAccountContactResponse>> GetAccountingContactByIdAsyncWithHttpInfo(int? accountingContactId);

	/// <summary>
	///     Update an existing accounting contact
	/// </summary>
	/// <remarks>
	///     Update an accounting contact
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="accountingContactId">ID of accounting contact to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>Task of GetAccountContactResponse</returns>
	Task<GetAccountContactResponse> UpdateAccountingContactAsync(int? accountingContactId,
		ModelAccountingContactUpdate body = null);

	/// <summary>
	///     Update an existing accounting contact
	/// </summary>
	/// <remarks>
	///     Update an accounting contact
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="accountingContactId">ID of accounting contact to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>Task of ApiResponse (GetAccountContactResponse)</returns>
	Task<ApiResponse<GetAccountContactResponse>> UpdateAccountingContactAsyncWithHttpInfo(int? accountingContactId,
		ModelAccountingContactUpdate body = null);

	#endregion Asynchronous Operations
}