using SevDesk.Extensions.ClientApi.Client;
using SevDesk.Extensions.ClientApi.Model;

namespace SevDesk.Extensions.ClientApi.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IOrderPosApi : IApiAccessor
{
	#region Synchronous Operations

	/// <summary>
	///     Deletes an order Position
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderPosId">Id of order position resource to delete</param>
	/// <returns>InlineResponse2003</returns>
	InlineResponse2003 DeleteOrderPos(int? orderPosId);

	/// <summary>
	///     Deletes an order Position
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderPosId">Id of order position resource to delete</param>
	/// <returns>ApiResponse of InlineResponse2003</returns>
	ApiResponse<InlineResponse2003> DeleteOrderPosWithHttpInfo(int? orderPosId);

	/// <summary>
	///     Find order position by ID
	/// </summary>
	/// <remarks>
	///     Returns a single order position
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderPosId">ID of order position to return</param>
	/// <returns>InlineResponse2007</returns>
	InlineResponse2007 GetOrderPositionById(int? orderPosId);

	/// <summary>
	///     Find order position by ID
	/// </summary>
	/// <remarks>
	///     Returns a single order position
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderPosId">ID of order position to return</param>
	/// <returns>ApiResponse of InlineResponse2007</returns>
	ApiResponse<InlineResponse2007> GetOrderPositionByIdWithHttpInfo(int? orderPosId);

	/// <summary>
	///     Retrieve order positions
	/// </summary>
	/// <remarks>
	///     Retrieve all order positions depending on the filters defined in the query.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">
	///     Retrieve all order positions belonging to this order. Must be provided with voucher[objectName]
	///     (optional)
	/// </param>
	/// <param name="orderObjectName">
	///     Only required if order[id] was provided. &#x27;Order&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <returns>InlineResponse2007</returns>
	InlineResponse2007 GetOrderPositions(int? orderId = null, string orderObjectName = null);

	/// <summary>
	///     Retrieve order positions
	/// </summary>
	/// <remarks>
	///     Retrieve all order positions depending on the filters defined in the query.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">
	///     Retrieve all order positions belonging to this order. Must be provided with voucher[objectName]
	///     (optional)
	/// </param>
	/// <param name="orderObjectName">
	///     Only required if order[id] was provided. &#x27;Order&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <returns>ApiResponse of InlineResponse2007</returns>
	ApiResponse<InlineResponse2007> GetOrderPositionsWithHttpInfo(int? orderId = null, string orderObjectName = null);

	/// <summary>
	///     Update an existing order position
	/// </summary>
	/// <remarks>
	///     Update an order position
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderPosId">ID of order position to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>InlineResponse2007</returns>
	InlineResponse2007 UpdateOrderPosition(int? orderPosId, ModelOrderPosUpdate body = null);

	/// <summary>
	///     Update an existing order position
	/// </summary>
	/// <remarks>
	///     Update an order position
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderPosId">ID of order position to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>ApiResponse of InlineResponse2007</returns>
	ApiResponse<InlineResponse2007> UpdateOrderPositionWithHttpInfo(int? orderPosId, ModelOrderPosUpdate body = null);

	#endregion Synchronous Operations

	#region Asynchronous Operations

	/// <summary>
	///     Deletes an order Position
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderPosId">Id of order position resource to delete</param>
	/// <returns>Task of InlineResponse2003</returns>
	Task<InlineResponse2003> DeleteOrderPosAsync(int? orderPosId);

	/// <summary>
	///     Deletes an order Position
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderPosId">Id of order position resource to delete</param>
	/// <returns>Task of ApiResponse (InlineResponse2003)</returns>
	Task<ApiResponse<InlineResponse2003>> DeleteOrderPosAsyncWithHttpInfo(int? orderPosId);

	/// <summary>
	///     Find order position by ID
	/// </summary>
	/// <remarks>
	///     Returns a single order position
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderPosId">ID of order position to return</param>
	/// <returns>Task of InlineResponse2007</returns>
	Task<InlineResponse2007> GetOrderPositionByIdAsync(int? orderPosId);

	/// <summary>
	///     Find order position by ID
	/// </summary>
	/// <remarks>
	///     Returns a single order position
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderPosId">ID of order position to return</param>
	/// <returns>Task of ApiResponse (InlineResponse2007)</returns>
	Task<ApiResponse<InlineResponse2007>> GetOrderPositionByIdAsyncWithHttpInfo(int? orderPosId);

	/// <summary>
	///     Retrieve order positions
	/// </summary>
	/// <remarks>
	///     Retrieve all order positions depending on the filters defined in the query.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">
	///     Retrieve all order positions belonging to this order. Must be provided with voucher[objectName]
	///     (optional)
	/// </param>
	/// <param name="orderObjectName">
	///     Only required if order[id] was provided. &#x27;Order&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <returns>Task of InlineResponse2007</returns>
	Task<InlineResponse2007> GetOrderPositionsAsync(int? orderId = null, string orderObjectName = null);

	/// <summary>
	///     Retrieve order positions
	/// </summary>
	/// <remarks>
	///     Retrieve all order positions depending on the filters defined in the query.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">
	///     Retrieve all order positions belonging to this order. Must be provided with voucher[objectName]
	///     (optional)
	/// </param>
	/// <param name="orderObjectName">
	///     Only required if order[id] was provided. &#x27;Order&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <returns>Task of ApiResponse (InlineResponse2007)</returns>
	Task<ApiResponse<InlineResponse2007>> GetOrderPositionsAsyncWithHttpInfo(int? orderId = null,
		string orderObjectName = null);

	/// <summary>
	///     Update an existing order position
	/// </summary>
	/// <remarks>
	///     Update an order position
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderPosId">ID of order position to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>Task of InlineResponse2007</returns>
	Task<InlineResponse2007> UpdateOrderPositionAsync(int? orderPosId, ModelOrderPosUpdate body = null);

	/// <summary>
	///     Update an existing order position
	/// </summary>
	/// <remarks>
	///     Update an order position
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderPosId">ID of order position to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse2007)</returns>
	Task<ApiResponse<InlineResponse2007>> UpdateOrderPositionAsyncWithHttpInfo(int? orderPosId,
		ModelOrderPosUpdate body = null);

	#endregion Asynchronous Operations
}