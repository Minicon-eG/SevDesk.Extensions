using SevDesk.Extensions.ClientApi.Client;
using SevDesk.Extensions.ClientApi.Model;

namespace SevDesk.Extensions.ClientApi.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IPartApi : IApiAccessor
{
	#region Synchronous Operations

	/// <summary>
	///     Create a new part
	/// </summary>
	/// <remarks>
	///     Creates a part in your sevDesk inventory.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">
	///     Creation data. Please be aware, that you need to provide at least all required parameter
	///     of the part model! (optional)
	/// </param>
	/// <returns>InlineResponse20021</returns>
	InlineResponse20021 CreatePart(ModelPart body = null);

	/// <summary>
	///     Create a new part
	/// </summary>
	/// <remarks>
	///     Creates a part in your sevDesk inventory.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">
	///     Creation data. Please be aware, that you need to provide at least all required parameter
	///     of the part model! (optional)
	/// </param>
	/// <returns>ApiResponse of InlineResponse20021</returns>
	ApiResponse<InlineResponse20021> CreatePartWithHttpInfo(ModelPart body = null);

	/// <summary>
	///     Find part by ID
	/// </summary>
	/// <remarks>
	///     Returns a single part
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="partId">ID of part to return</param>
	/// <returns>InlineResponse20021</returns>
	InlineResponse20021 GetPartById(int? partId);

	/// <summary>
	///     Find part by ID
	/// </summary>
	/// <remarks>
	///     Returns a single part
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="partId">ID of part to return</param>
	/// <returns>ApiResponse of InlineResponse20021</returns>
	ApiResponse<InlineResponse20021> GetPartByIdWithHttpInfo(int? partId);

	/// <summary>
	///     Retrieve parts
	/// </summary>
	/// <remarks>
	///     Retrieve all parts in your sevDesk inventory according to the applied filters.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="partNumber">Retrieve all parts with this part number (optional)</param>
	/// <param name="name">Retrieve all parts with this name (optional)</param>
	/// <returns>InlineResponse20021</returns>
	InlineResponse20021 GetParts(string partNumber = null, string name = null);

	/// <summary>
	///     Retrieve parts
	/// </summary>
	/// <remarks>
	///     Retrieve all parts in your sevDesk inventory according to the applied filters.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="partNumber">Retrieve all parts with this part number (optional)</param>
	/// <param name="name">Retrieve all parts with this name (optional)</param>
	/// <returns>ApiResponse of InlineResponse20021</returns>
	ApiResponse<InlineResponse20021> GetPartsWithHttpInfo(string partNumber = null, string name = null);

	/// <summary>
	///     Get stock of a part
	/// </summary>
	/// <remarks>
	///     Returns the current stock amount of the given part.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="partId">ID of part for which you want the current stock.</param>
	/// <returns>InlineResponse20026</returns>
	InlineResponse20026 PartGetStock(int? partId);

	/// <summary>
	///     Get stock of a part
	/// </summary>
	/// <remarks>
	///     Returns the current stock amount of the given part.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="partId">ID of part for which you want the current stock.</param>
	/// <returns>ApiResponse of InlineResponse20026</returns>
	ApiResponse<InlineResponse20026> PartGetStockWithHttpInfo(int? partId);

	/// <summary>
	///     Update an existing part
	/// </summary>
	/// <remarks>
	///     Update a part
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="partId">ID of part to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>InlineResponse20021</returns>
	InlineResponse20021 UpdatePart(int? partId, ModelPartUpdate body = null);

	/// <summary>
	///     Update an existing part
	/// </summary>
	/// <remarks>
	///     Update a part
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="partId">ID of part to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>ApiResponse of InlineResponse20021</returns>
	ApiResponse<InlineResponse20021> UpdatePartWithHttpInfo(int? partId, ModelPartUpdate body = null);

	#endregion Synchronous Operations

	#region Asynchronous Operations

	/// <summary>
	///     Create a new part
	/// </summary>
	/// <remarks>
	///     Creates a part in your sevDesk inventory.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">
	///     Creation data. Please be aware, that you need to provide at least all required parameter
	///     of the part model! (optional)
	/// </param>
	/// <returns>Task of InlineResponse20021</returns>
	Task<InlineResponse20021> CreatePartAsync(ModelPart body = null);

	/// <summary>
	///     Create a new part
	/// </summary>
	/// <remarks>
	///     Creates a part in your sevDesk inventory.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">
	///     Creation data. Please be aware, that you need to provide at least all required parameter
	///     of the part model! (optional)
	/// </param>
	/// <returns>Task of ApiResponse (InlineResponse20021)</returns>
	Task<ApiResponse<InlineResponse20021>> CreatePartAsyncWithHttpInfo(ModelPart body = null);

	/// <summary>
	///     Find part by ID
	/// </summary>
	/// <remarks>
	///     Returns a single part
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="partId">ID of part to return</param>
	/// <returns>Task of InlineResponse20021</returns>
	Task<InlineResponse20021> GetPartByIdAsync(int? partId);

	/// <summary>
	///     Find part by ID
	/// </summary>
	/// <remarks>
	///     Returns a single part
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="partId">ID of part to return</param>
	/// <returns>Task of ApiResponse (InlineResponse20021)</returns>
	Task<ApiResponse<InlineResponse20021>> GetPartByIdAsyncWithHttpInfo(int? partId);

	/// <summary>
	///     Retrieve parts
	/// </summary>
	/// <remarks>
	///     Retrieve all parts in your sevDesk inventory according to the applied filters.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="partNumber">Retrieve all parts with this part number (optional)</param>
	/// <param name="name">Retrieve all parts with this name (optional)</param>
	/// <returns>Task of InlineResponse20021</returns>
	Task<InlineResponse20021> GetPartsAsync(string partNumber = null, string name = null);

	/// <summary>
	///     Retrieve parts
	/// </summary>
	/// <remarks>
	///     Retrieve all parts in your sevDesk inventory according to the applied filters.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="partNumber">Retrieve all parts with this part number (optional)</param>
	/// <param name="name">Retrieve all parts with this name (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse20021)</returns>
	Task<ApiResponse<InlineResponse20021>> GetPartsAsyncWithHttpInfo(string partNumber = null, string name = null);

	/// <summary>
	///     Get stock of a part
	/// </summary>
	/// <remarks>
	///     Returns the current stock amount of the given part.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="partId">ID of part for which you want the current stock.</param>
	/// <returns>Task of InlineResponse20026</returns>
	Task<InlineResponse20026> PartGetStockAsync(int? partId);

	/// <summary>
	///     Get stock of a part
	/// </summary>
	/// <remarks>
	///     Returns the current stock amount of the given part.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="partId">ID of part for which you want the current stock.</param>
	/// <returns>Task of ApiResponse (InlineResponse20026)</returns>
	Task<ApiResponse<InlineResponse20026>> PartGetStockAsyncWithHttpInfo(int? partId);

	/// <summary>
	///     Update an existing part
	/// </summary>
	/// <remarks>
	///     Update a part
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="partId">ID of part to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>Task of InlineResponse20021</returns>
	Task<InlineResponse20021> UpdatePartAsync(int? partId, ModelPartUpdate body = null);

	/// <summary>
	///     Update an existing part
	/// </summary>
	/// <remarks>
	///     Update a part
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="partId">ID of part to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse20021)</returns>
	Task<ApiResponse<InlineResponse20021>> UpdatePartAsyncWithHttpInfo(int? partId, ModelPartUpdate body = null);

	#endregion Asynchronous Operations
}