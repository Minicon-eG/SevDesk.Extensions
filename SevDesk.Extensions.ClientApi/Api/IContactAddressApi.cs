using SevDesk.Extensions.ClientApi.Client;
using SevDesk.Extensions.ClientApi.Model;

namespace SevDesk.Extensions.ClientApi.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IContactAddressApi : IApiAccessor
{
	#region Synchronous Operations

	/// <summary>
	///     Find contact address by ID
	/// </summary>
	/// <remarks>
	///     Returns a single contact address
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactAddressId">ID of contact address to return</param>
	/// <returns>InlineResponse20013</returns>
	InlineResponse20013 ContactAddressId(int? contactAddressId);

	/// <summary>
	///     Find contact address by ID
	/// </summary>
	/// <remarks>
	///     Returns a single contact address
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactAddressId">ID of contact address to return</param>
	/// <returns>ApiResponse of InlineResponse20013</returns>
	ApiResponse<InlineResponse20013> ContactAddressIdWithHttpInfo(int? contactAddressId);

	/// <summary>
	///     Create a new contact address
	/// </summary>
	/// <remarks>
	///     Creates a new contact address.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">Creation data (optional)</param>
	/// <returns>InlineResponse20013</returns>
	InlineResponse20013 CreateContactAddress(ModelContactAddress body = null);

	/// <summary>
	///     Create a new contact address
	/// </summary>
	/// <remarks>
	///     Creates a new contact address.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">Creation data (optional)</param>
	/// <returns>ApiResponse of InlineResponse20013</returns>
	ApiResponse<InlineResponse20013> CreateContactAddressWithHttpInfo(ModelContactAddress body = null);

	/// <summary>
	///     Deletes a contact address
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactAddressId">Id of contact address resource to delete</param>
	/// <returns>InlineResponse2003</returns>
	InlineResponse2003 DeleteContactAddress(int? contactAddressId);

	/// <summary>
	///     Deletes a contact address
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactAddressId">Id of contact address resource to delete</param>
	/// <returns>ApiResponse of InlineResponse2003</returns>
	ApiResponse<InlineResponse2003> DeleteContactAddressWithHttpInfo(int? contactAddressId);

	/// <summary>
	///     Retrieve contact addresses
	/// </summary>
	/// <remarks>
	///     Retrieve all contact addresses
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>InlineResponse20013</returns>
	InlineResponse20013 GetContactAddresses();

	/// <summary>
	///     Retrieve contact addresses
	/// </summary>
	/// <remarks>
	///     Retrieve all contact addresses
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>ApiResponse of InlineResponse20013</returns>
	ApiResponse<InlineResponse20013> GetContactAddressesWithHttpInfo();

	/// <summary>
	///     update a existing contact address
	/// </summary>
	/// <remarks>
	///     update a existing contact address.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactAddressId">ID of contact address to return</param>
	/// <param name="body">Creation data (optional)</param>
	/// <returns>InlineResponse20013</returns>
	InlineResponse20013 UpdateContactAddress(int? contactAddressId, ModelContactAddressUpdate body = null);

	/// <summary>
	///     update a existing contact address
	/// </summary>
	/// <remarks>
	///     update a existing contact address.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactAddressId">ID of contact address to return</param>
	/// <param name="body">Creation data (optional)</param>
	/// <returns>ApiResponse of InlineResponse20013</returns>
	ApiResponse<InlineResponse20013> UpdateContactAddressWithHttpInfo(int? contactAddressId,
		ModelContactAddressUpdate body = null);

	#endregion Synchronous Operations

	#region Asynchronous Operations

	/// <summary>
	///     Find contact address by ID
	/// </summary>
	/// <remarks>
	///     Returns a single contact address
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactAddressId">ID of contact address to return</param>
	/// <returns>Task of InlineResponse20013</returns>
	Task<InlineResponse20013> ContactAddressIdAsync(int? contactAddressId);

	/// <summary>
	///     Find contact address by ID
	/// </summary>
	/// <remarks>
	///     Returns a single contact address
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactAddressId">ID of contact address to return</param>
	/// <returns>Task of ApiResponse (InlineResponse20013)</returns>
	Task<ApiResponse<InlineResponse20013>> ContactAddressIdAsyncWithHttpInfo(int? contactAddressId);

	/// <summary>
	///     Create a new contact address
	/// </summary>
	/// <remarks>
	///     Creates a new contact address.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">Creation data (optional)</param>
	/// <returns>Task of InlineResponse20013</returns>
	Task<InlineResponse20013> CreateContactAddressAsync(ModelContactAddress body = null);

	/// <summary>
	///     Create a new contact address
	/// </summary>
	/// <remarks>
	///     Creates a new contact address.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">Creation data (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse20013)</returns>
	Task<ApiResponse<InlineResponse20013>> CreateContactAddressAsyncWithHttpInfo(ModelContactAddress body = null);

	/// <summary>
	///     Deletes a contact address
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactAddressId">Id of contact address resource to delete</param>
	/// <returns>Task of InlineResponse2003</returns>
	Task<InlineResponse2003> DeleteContactAddressAsync(int? contactAddressId);

	/// <summary>
	///     Deletes a contact address
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactAddressId">Id of contact address resource to delete</param>
	/// <returns>Task of ApiResponse (InlineResponse2003)</returns>
	Task<ApiResponse<InlineResponse2003>> DeleteContactAddressAsyncWithHttpInfo(int? contactAddressId);

	/// <summary>
	///     Retrieve contact addresses
	/// </summary>
	/// <remarks>
	///     Retrieve all contact addresses
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of InlineResponse20013</returns>
	Task<InlineResponse20013> GetContactAddressesAsync();

	/// <summary>
	///     Retrieve contact addresses
	/// </summary>
	/// <remarks>
	///     Retrieve all contact addresses
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ApiResponse (InlineResponse20013)</returns>
	Task<ApiResponse<InlineResponse20013>> GetContactAddressesAsyncWithHttpInfo();

	/// <summary>
	///     update a existing contact address
	/// </summary>
	/// <remarks>
	///     update a existing contact address.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactAddressId">ID of contact address to return</param>
	/// <param name="body">Creation data (optional)</param>
	/// <returns>Task of InlineResponse20013</returns>
	Task<InlineResponse20013> UpdateContactAddressAsync(int? contactAddressId, ModelContactAddressUpdate body = null);

	/// <summary>
	///     update a existing contact address
	/// </summary>
	/// <remarks>
	///     update a existing contact address.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactAddressId">ID of contact address to return</param>
	/// <param name="body">Creation data (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse20013)</returns>
	Task<ApiResponse<InlineResponse20013>> UpdateContactAddressAsyncWithHttpInfo(int? contactAddressId,
		ModelContactAddressUpdate body = null);

	#endregion Asynchronous Operations
}