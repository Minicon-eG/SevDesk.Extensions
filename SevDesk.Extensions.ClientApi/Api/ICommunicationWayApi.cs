using SevDesk.Extensions.ClientApi.Client;
using SevDesk.Extensions.ClientApi.Model;

namespace SevDesk.Extensions.ClientApi.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface ICommunicationWayApi : IApiAccessor
{
	#region Synchronous Operations

	/// <summary>
	///     Create a new contact communication way
	/// </summary>
	/// <remarks>
	///     Creates a new contact communication way.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">Creation data (optional)</param>
	/// <returns>InlineResponse20025</returns>
	InlineResponse20025 CreateCommunicationWay(ModelCommunicationWay body = null);

	/// <summary>
	///     Create a new contact communication way
	/// </summary>
	/// <remarks>
	///     Creates a new contact communication way.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">Creation data (optional)</param>
	/// <returns>ApiResponse of InlineResponse20025</returns>
	ApiResponse<InlineResponse20025> CreateCommunicationWayWithHttpInfo(ModelCommunicationWay body = null);

	/// <summary>
	///     Deletes a communication way
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="communicationWayId">Id of communication way resource to delete</param>
	/// <returns>InlineResponse2003</returns>
	InlineResponse2003 DeleteCommunicationWay(int? communicationWayId);

	/// <summary>
	///     Deletes a communication way
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="communicationWayId">Id of communication way resource to delete</param>
	/// <returns>ApiResponse of InlineResponse2003</returns>
	ApiResponse<InlineResponse2003> DeleteCommunicationWayWithHttpInfo(int? communicationWayId);

	/// <summary>
	///     Find communication way by ID
	/// </summary>
	/// <remarks>
	///     Returns a single communication way
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="communicationWayId">ID of communication way to return</param>
	/// <returns>InlineResponse20025</returns>
	InlineResponse20025 GetCommunicationWayById(int? communicationWayId);

	/// <summary>
	///     Find communication way by ID
	/// </summary>
	/// <remarks>
	///     Returns a single communication way
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="communicationWayId">ID of communication way to return</param>
	/// <returns>ApiResponse of InlineResponse20025</returns>
	ApiResponse<InlineResponse20025> GetCommunicationWayByIdWithHttpInfo(int? communicationWayId);

	/// <summary>
	///     Retrieve communication way keys
	/// </summary>
	/// <remarks>
	///     Returns all communication way keys.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>InlineResponse20016</returns>
	InlineResponse20016 GetCommunicationWayKeys();

	/// <summary>
	///     Retrieve communication way keys
	/// </summary>
	/// <remarks>
	///     Returns all communication way keys.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>ApiResponse of InlineResponse20016</returns>
	ApiResponse<InlineResponse20016> GetCommunicationWayKeysWithHttpInfo();

	/// <summary>
	///     Retrieve communication ways
	/// </summary>
	/// <remarks>
	///     Returns all communication ways which have been added up until now. Filters can be added.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactId">ID of contact for which you want the communication ways. (optional)</param>
	/// <param name="contactObjectName">Object name. Only needed if you also defined the ID of a contact. (optional)</param>
	/// <param name="type">Type of the communication ways you want to get. (optional)</param>
	/// <param name="main">Define if you only want the main communication way. (optional)</param>
	/// <returns>InlineResponse20025</returns>
	InlineResponse20025 GetCommunicationWays(string contactId = null, string contactObjectName = null,
		string type = null, string main = null);

	/// <summary>
	///     Retrieve communication ways
	/// </summary>
	/// <remarks>
	///     Returns all communication ways which have been added up until now. Filters can be added.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactId">ID of contact for which you want the communication ways. (optional)</param>
	/// <param name="contactObjectName">Object name. Only needed if you also defined the ID of a contact. (optional)</param>
	/// <param name="type">Type of the communication ways you want to get. (optional)</param>
	/// <param name="main">Define if you only want the main communication way. (optional)</param>
	/// <returns>ApiResponse of InlineResponse20025</returns>
	ApiResponse<InlineResponse20025> GetCommunicationWaysWithHttpInfo(string contactId = null,
		string contactObjectName = null, string type = null, string main = null);

	/// <summary>
	///     Update a existing communication way
	/// </summary>
	/// <remarks>
	///     Update a communication way
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="communicationWayId">ID of CommunicationWay to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>InlineResponse20025</returns>
	InlineResponse20025 UpdateCommunicationWay(int? communicationWayId, ModelCommunicationWayUpdate body = null);

	/// <summary>
	///     Update a existing communication way
	/// </summary>
	/// <remarks>
	///     Update a communication way
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="communicationWayId">ID of CommunicationWay to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>ApiResponse of InlineResponse20025</returns>
	ApiResponse<InlineResponse20025> UpdateCommunicationWayWithHttpInfo(int? communicationWayId,
		ModelCommunicationWayUpdate body = null);

	#endregion Synchronous Operations

	#region Asynchronous Operations

	/// <summary>
	///     Create a new contact communication way
	/// </summary>
	/// <remarks>
	///     Creates a new contact communication way.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">Creation data (optional)</param>
	/// <returns>Task of InlineResponse20025</returns>
	Task<InlineResponse20025> CreateCommunicationWayAsync(ModelCommunicationWay body = null);

	/// <summary>
	///     Create a new contact communication way
	/// </summary>
	/// <remarks>
	///     Creates a new contact communication way.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">Creation data (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse20025)</returns>
	Task<ApiResponse<InlineResponse20025>> CreateCommunicationWayAsyncWithHttpInfo(ModelCommunicationWay body = null);

	/// <summary>
	///     Deletes a communication way
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="communicationWayId">Id of communication way resource to delete</param>
	/// <returns>Task of InlineResponse2003</returns>
	Task<InlineResponse2003> DeleteCommunicationWayAsync(int? communicationWayId);

	/// <summary>
	///     Deletes a communication way
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="communicationWayId">Id of communication way resource to delete</param>
	/// <returns>Task of ApiResponse (InlineResponse2003)</returns>
	Task<ApiResponse<InlineResponse2003>> DeleteCommunicationWayAsyncWithHttpInfo(int? communicationWayId);

	/// <summary>
	///     Find communication way by ID
	/// </summary>
	/// <remarks>
	///     Returns a single communication way
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="communicationWayId">ID of communication way to return</param>
	/// <returns>Task of InlineResponse20025</returns>
	Task<InlineResponse20025> GetCommunicationWayByIdAsync(int? communicationWayId);

	/// <summary>
	///     Find communication way by ID
	/// </summary>
	/// <remarks>
	///     Returns a single communication way
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="communicationWayId">ID of communication way to return</param>
	/// <returns>Task of ApiResponse (InlineResponse20025)</returns>
	Task<ApiResponse<InlineResponse20025>> GetCommunicationWayByIdAsyncWithHttpInfo(int? communicationWayId);

	/// <summary>
	///     Retrieve communication way keys
	/// </summary>
	/// <remarks>
	///     Returns all communication way keys.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of InlineResponse20016</returns>
	Task<InlineResponse20016> GetCommunicationWayKeysAsync();

	/// <summary>
	///     Retrieve communication way keys
	/// </summary>
	/// <remarks>
	///     Returns all communication way keys.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ApiResponse (InlineResponse20016)</returns>
	Task<ApiResponse<InlineResponse20016>> GetCommunicationWayKeysAsyncWithHttpInfo();

	/// <summary>
	///     Retrieve communication ways
	/// </summary>
	/// <remarks>
	///     Returns all communication ways which have been added up until now. Filters can be added.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactId">ID of contact for which you want the communication ways. (optional)</param>
	/// <param name="contactObjectName">Object name. Only needed if you also defined the ID of a contact. (optional)</param>
	/// <param name="type">Type of the communication ways you want to get. (optional)</param>
	/// <param name="main">Define if you only want the main communication way. (optional)</param>
	/// <returns>Task of InlineResponse20025</returns>
	Task<InlineResponse20025> GetCommunicationWaysAsync(string contactId = null, string contactObjectName = null,
		string type = null, string main = null);

	/// <summary>
	///     Retrieve communication ways
	/// </summary>
	/// <remarks>
	///     Returns all communication ways which have been added up until now. Filters can be added.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactId">ID of contact for which you want the communication ways. (optional)</param>
	/// <param name="contactObjectName">Object name. Only needed if you also defined the ID of a contact. (optional)</param>
	/// <param name="type">Type of the communication ways you want to get. (optional)</param>
	/// <param name="main">Define if you only want the main communication way. (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse20025)</returns>
	Task<ApiResponse<InlineResponse20025>> GetCommunicationWaysAsyncWithHttpInfo(string contactId = null,
		string contactObjectName = null, string type = null, string main = null);

	/// <summary>
	///     Update a existing communication way
	/// </summary>
	/// <remarks>
	///     Update a communication way
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="communicationWayId">ID of CommunicationWay to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>Task of InlineResponse20025</returns>
	Task<InlineResponse20025> UpdateCommunicationWayAsync(int? communicationWayId,
		ModelCommunicationWayUpdate body = null);

	/// <summary>
	///     Update a existing communication way
	/// </summary>
	/// <remarks>
	///     Update a communication way
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="communicationWayId">ID of CommunicationWay to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse20025)</returns>
	Task<ApiResponse<InlineResponse20025>> UpdateCommunicationWayAsyncWithHttpInfo(int? communicationWayId,
		ModelCommunicationWayUpdate body = null);

	#endregion Asynchronous Operations
}