using SevDesk.Extensions.ClientApi.Client;
using SevDesk.Extensions.ClientApi.Model;

namespace SevDesk.Extensions.ClientApi.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IOrderApi : IApiAccessor
{
	#region Synchronous Operations

	/// <summary>
	///     Create contract note from order
	/// </summary>
	/// <remarks>
	///     Create contract note from order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">the id of the order</param>
	/// <param name="orderObjectName">Model name, which is &#x27;Order&#x27;</param>
	/// <param name="body">Create contract note (optional)</param>
	/// <returns>InlineResponse20010</returns>
	InlineResponse20010 CreateContractNoteFromOrder(int? orderId, string orderObjectName,
		ModelCreatePackingListFromOrder body = null);

	/// <summary>
	///     Create contract note from order
	/// </summary>
	/// <remarks>
	///     Create contract note from order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">the id of the order</param>
	/// <param name="orderObjectName">Model name, which is &#x27;Order&#x27;</param>
	/// <param name="body">Create contract note (optional)</param>
	/// <returns>ApiResponse of InlineResponse20010</returns>
	ApiResponse<InlineResponse20010> CreateContractNoteFromOrderWithHttpInfo(int? orderId, string orderObjectName,
		ModelCreatePackingListFromOrder body = null);

	/// <summary>
	///     Create a new order
	/// </summary>
	/// <remarks>
	///     Creates an order to which positions can be added later.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">
	///     Creation data. Please be aware, that you need to provide at least all required parameter
	///     of the order model! (optional)
	/// </param>
	/// <returns>SaveOrderResponse</returns>
	SaveOrderResponse CreateOrder(SaveOrder body = null);

	/// <summary>
	///     Create a new order
	/// </summary>
	/// <remarks>
	///     Creates an order to which positions can be added later.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">
	///     Creation data. Please be aware, that you need to provide at least all required parameter
	///     of the order model! (optional)
	/// </param>
	/// <returns>ApiResponse of SaveOrderResponse</returns>
	ApiResponse<SaveOrderResponse> CreateOrderWithHttpInfo(SaveOrder body = null);

	/// <summary>
	///     Create packing list from order
	/// </summary>
	/// <remarks>
	///     Create packing list from order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">the id of the order</param>
	/// <param name="orderObjectName">Model name, which is &#x27;Order&#x27;</param>
	/// <param name="body">Create packing list (optional)</param>
	/// <returns>InlineResponse20010</returns>
	InlineResponse20010 CreatePackingListFromOrder(int? orderId, string orderObjectName,
		ModelCreatePackingListFromOrder body = null);

	/// <summary>
	///     Create packing list from order
	/// </summary>
	/// <remarks>
	///     Create packing list from order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">the id of the order</param>
	/// <param name="orderObjectName">Model name, which is &#x27;Order&#x27;</param>
	/// <param name="body">Create packing list (optional)</param>
	/// <returns>ApiResponse of InlineResponse20010</returns>
	ApiResponse<InlineResponse20010> CreatePackingListFromOrderWithHttpInfo(int? orderId, string orderObjectName,
		ModelCreatePackingListFromOrder body = null);

	/// <summary>
	///     Deletes an order
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">Id of order resource to delete</param>
	/// <returns>InlineResponse2003</returns>
	InlineResponse2003 DeleteOrder(int? orderId);

	/// <summary>
	///     Deletes an order
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">Id of order resource to delete</param>
	/// <returns>ApiResponse of InlineResponse2003</returns>
	ApiResponse<InlineResponse2003> DeleteOrderWithHttpInfo(int? orderId);

	/// <summary>
	///     Find order discounts
	/// </summary>
	/// <remarks>
	///     Returns all discounts of an order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return the positions</param>
	/// <param name="limit">limits the number of entries returned (optional)</param>
	/// <param name="offset">set the index where the returned entries start (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>InlineResponse2009</returns>
	InlineResponse2009 GetDiscounts(int? orderId, int? limit = null, int? offset = null, List<string> embed = null);

	/// <summary>
	///     Find order discounts
	/// </summary>
	/// <remarks>
	///     Returns all discounts of an order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return the positions</param>
	/// <param name="limit">limits the number of entries returned (optional)</param>
	/// <param name="offset">set the index where the returned entries start (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>ApiResponse of InlineResponse2009</returns>
	ApiResponse<InlineResponse2009> GetDiscountsWithHttpInfo(int? orderId, int? limit = null, int? offset = null,
		List<string> embed = null);

	/// <summary>
	///     Find order by ID
	/// </summary>
	/// <remarks>
	///     Returns a single order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return</param>
	/// <returns>InlineResponse20010</returns>
	InlineResponse20010 GetOrderById(int? orderId);

	/// <summary>
	///     Find order by ID
	/// </summary>
	/// <remarks>
	///     Returns a single order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return</param>
	/// <returns>ApiResponse of InlineResponse20010</returns>
	ApiResponse<InlineResponse20010> GetOrderByIdWithHttpInfo(int? orderId);

	/// <summary>
	///     Find order positions
	/// </summary>
	/// <remarks>
	///     Returns all positions of an order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return the positions</param>
	/// <param name="limit">limits the number of entries returned (optional)</param>
	/// <param name="offset">set the index where the returned entries start (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>InlineResponse2007</returns>
	InlineResponse2007 GetOrderPositionsById(int? orderId, int? limit = null, int? offset = null,
		List<string> embed = null);

	/// <summary>
	///     Find order positions
	/// </summary>
	/// <remarks>
	///     Returns all positions of an order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return the positions</param>
	/// <param name="limit">limits the number of entries returned (optional)</param>
	/// <param name="offset">set the index where the returned entries start (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>ApiResponse of InlineResponse2007</returns>
	ApiResponse<InlineResponse2007> GetOrderPositionsByIdWithHttpInfo(int? orderId, int? limit = null,
		int? offset = null, List<string> embed = null);

	/// <summary>
	///     Retrieve orders
	/// </summary>
	/// <remarks>
	///     There are a multitude of parameter which can be used to filter. A few of them are attached but      for a complete
	///     list please check out &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/How-to-filter-for-certain-orders&#x27;
	///     &gt;this&lt;/a&gt; list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="status">Status of the order (optional)</param>
	/// <param name="orderNumber">Retrieve all orders with this order number (optional)</param>
	/// <param name="startDate">Retrieve all orders with a date equal or higher (optional)</param>
	/// <param name="endDate">Retrieve all orders with a date equal or lower (optional)</param>
	/// <param name="contactId">Retrieve all orders with this contact. Must be provided with contact[objectName] (optional)</param>
	/// <param name="contactObjectName">
	///     Only required if contact[id] was provided. &#x27;Contact&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <returns>InlineResponse20010</returns>
	InlineResponse20010 GetOrders(int? status = null, string orderNumber = null, int? startDate = null,
		int? endDate = null, int? contactId = null, string contactObjectName = null);

	/// <summary>
	///     Retrieve orders
	/// </summary>
	/// <remarks>
	///     There are a multitude of parameter which can be used to filter. A few of them are attached but      for a complete
	///     list please check out &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/How-to-filter-for-certain-orders&#x27;
	///     &gt;this&lt;/a&gt; list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="status">Status of the order (optional)</param>
	/// <param name="orderNumber">Retrieve all orders with this order number (optional)</param>
	/// <param name="startDate">Retrieve all orders with a date equal or higher (optional)</param>
	/// <param name="endDate">Retrieve all orders with a date equal or lower (optional)</param>
	/// <param name="contactId">Retrieve all orders with this contact. Must be provided with contact[objectName] (optional)</param>
	/// <param name="contactObjectName">
	///     Only required if contact[id] was provided. &#x27;Contact&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <returns>ApiResponse of InlineResponse20010</returns>
	ApiResponse<InlineResponse20010> GetOrdersWithHttpInfo(int? status = null, string orderNumber = null,
		int? startDate = null, int? endDate = null, int? contactId = null, string contactObjectName = null);

	/// <summary>
	///     Find related objects
	/// </summary>
	/// <remarks>
	///     Get related objects of a specified order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return the positions</param>
	/// <param name="includeItself">Define if the related objects include the order itself (optional)</param>
	/// <param name="sortByType">Define if you want the related objects sorted by type (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>InlineResponse20038</returns>
	InlineResponse20038 GetRelatedObjects(int? orderId, bool? includeItself = null, bool? sortByType = null,
		List<string> embed = null);

	/// <summary>
	///     Find related objects
	/// </summary>
	/// <remarks>
	///     Get related objects of a specified order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return the positions</param>
	/// <param name="includeItself">Define if the related objects include the order itself (optional)</param>
	/// <param name="sortByType">Define if you want the related objects sorted by type (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>ApiResponse of InlineResponse20038</returns>
	ApiResponse<InlineResponse20038> GetRelatedObjectsWithHttpInfo(int? orderId, bool? includeItself = null,
		bool? sortByType = null, List<string> embed = null);

	/// <summary>
	///     Retrieve pdf document of an order
	/// </summary>
	/// <remarks>
	///     Retrieves the pdf document of an order with additional metadata and commit the order.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order from which you want the pdf</param>
	/// <param name="download">If u want to download the pdf of the order. (optional)</param>
	/// <param name="preventSendBy">Defines if u want to send the order. (optional)</param>
	/// <returns>CreditNoteGetPdfResponse</returns>
	CreditNoteGetPdfResponse OrderGetPdf(int? orderId, bool? download = null, bool? preventSendBy = null);

	/// <summary>
	///     Retrieve pdf document of an order
	/// </summary>
	/// <remarks>
	///     Retrieves the pdf document of an order with additional metadata and commit the order.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order from which you want the pdf</param>
	/// <param name="download">If u want to download the pdf of the order. (optional)</param>
	/// <param name="preventSendBy">Defines if u want to send the order. (optional)</param>
	/// <returns>ApiResponse of CreditNoteGetPdfResponse</returns>
	ApiResponse<CreditNoteGetPdfResponse> OrderGetPdfWithHttpInfo(int? orderId, bool? download = null,
		bool? preventSendBy = null);

	/// <summary>
	///     Mark order as sent
	/// </summary>
	/// <remarks>
	///     Marks an order as sent by a chosen send type.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to mark as sent</param>
	/// <param name="body">Specify the send type (optional)</param>
	/// <returns>InlineResponse20027</returns>
	InlineResponse20027 OrderSendBy(int? orderId, OrderIdSendByBody body = null);

	/// <summary>
	///     Mark order as sent
	/// </summary>
	/// <remarks>
	///     Marks an order as sent by a chosen send type.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to mark as sent</param>
	/// <param name="body">Specify the send type (optional)</param>
	/// <returns>ApiResponse of InlineResponse20027</returns>
	ApiResponse<InlineResponse20027> OrderSendByWithHttpInfo(int? orderId, OrderIdSendByBody body = null);

	/// <summary>
	///     Send order via email
	/// </summary>
	/// <remarks>
	///     This endpoint sends the specified order to a customer via email.&lt;br&gt;      This will automatically mark the
	///     order as sent.&lt;br&gt;      Please note, that in production an order is not allowed to be changed after this
	///     happened!
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to be sent via email</param>
	/// <param name="body">Mail data (optional)</param>
	/// <returns>InlineResponse2013</returns>
	InlineResponse2013 SendorderViaEMail(int? orderId, OrderIdSendViaEmailBody body = null);

	/// <summary>
	///     Send order via email
	/// </summary>
	/// <remarks>
	///     This endpoint sends the specified order to a customer via email.&lt;br&gt;      This will automatically mark the
	///     order as sent.&lt;br&gt;      Please note, that in production an order is not allowed to be changed after this
	///     happened!
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to be sent via email</param>
	/// <param name="body">Mail data (optional)</param>
	/// <returns>ApiResponse of InlineResponse2013</returns>
	ApiResponse<InlineResponse2013> SendorderViaEMailWithHttpInfo(int? orderId, OrderIdSendViaEmailBody body = null);

	/// <summary>
	///     Update an existing order
	/// </summary>
	/// <remarks>
	///     Update an order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>InlineResponse20010</returns>
	InlineResponse20010 UpdateOrder(int? orderId, ModelOrderUpdate body = null);

	/// <summary>
	///     Update an existing order
	/// </summary>
	/// <remarks>
	///     Update an order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>ApiResponse of InlineResponse20010</returns>
	ApiResponse<InlineResponse20010> UpdateOrderWithHttpInfo(int? orderId, ModelOrderUpdate body = null);

	#endregion Synchronous Operations

	#region Asynchronous Operations

	/// <summary>
	///     Create contract note from order
	/// </summary>
	/// <remarks>
	///     Create contract note from order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">the id of the order</param>
	/// <param name="orderObjectName">Model name, which is &#x27;Order&#x27;</param>
	/// <param name="body">Create contract note (optional)</param>
	/// <returns>Task of InlineResponse20010</returns>
	Task<InlineResponse20010> CreateContractNoteFromOrderAsync(int? orderId, string orderObjectName,
		ModelCreatePackingListFromOrder body = null);

	/// <summary>
	///     Create contract note from order
	/// </summary>
	/// <remarks>
	///     Create contract note from order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">the id of the order</param>
	/// <param name="orderObjectName">Model name, which is &#x27;Order&#x27;</param>
	/// <param name="body">Create contract note (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse20010)</returns>
	Task<ApiResponse<InlineResponse20010>> CreateContractNoteFromOrderAsyncWithHttpInfo(int? orderId,
		string orderObjectName, ModelCreatePackingListFromOrder body = null);

	/// <summary>
	///     Create a new order
	/// </summary>
	/// <remarks>
	///     Creates an order to which positions can be added later.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">
	///     Creation data. Please be aware, that you need to provide at least all required parameter
	///     of the order model! (optional)
	/// </param>
	/// <returns>Task of SaveOrderResponse</returns>
	Task<SaveOrderResponse> CreateOrderAsync(SaveOrder body = null);

	/// <summary>
	///     Create a new order
	/// </summary>
	/// <remarks>
	///     Creates an order to which positions can be added later.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">
	///     Creation data. Please be aware, that you need to provide at least all required parameter
	///     of the order model! (optional)
	/// </param>
	/// <returns>Task of ApiResponse (SaveOrderResponse)</returns>
	Task<ApiResponse<SaveOrderResponse>> CreateOrderAsyncWithHttpInfo(SaveOrder body = null);

	/// <summary>
	///     Create packing list from order
	/// </summary>
	/// <remarks>
	///     Create packing list from order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">the id of the order</param>
	/// <param name="orderObjectName">Model name, which is &#x27;Order&#x27;</param>
	/// <param name="body">Create packing list (optional)</param>
	/// <returns>Task of InlineResponse20010</returns>
	Task<InlineResponse20010> CreatePackingListFromOrderAsync(int? orderId, string orderObjectName,
		ModelCreatePackingListFromOrder body = null);

	/// <summary>
	///     Create packing list from order
	/// </summary>
	/// <remarks>
	///     Create packing list from order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">the id of the order</param>
	/// <param name="orderObjectName">Model name, which is &#x27;Order&#x27;</param>
	/// <param name="body">Create packing list (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse20010)</returns>
	Task<ApiResponse<InlineResponse20010>> CreatePackingListFromOrderAsyncWithHttpInfo(int? orderId,
		string orderObjectName, ModelCreatePackingListFromOrder body = null);

	/// <summary>
	///     Deletes an order
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">Id of order resource to delete</param>
	/// <returns>Task of InlineResponse2003</returns>
	Task<InlineResponse2003> DeleteOrderAsync(int? orderId);

	/// <summary>
	///     Deletes an order
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">Id of order resource to delete</param>
	/// <returns>Task of ApiResponse (InlineResponse2003)</returns>
	Task<ApiResponse<InlineResponse2003>> DeleteOrderAsyncWithHttpInfo(int? orderId);

	/// <summary>
	///     Find order discounts
	/// </summary>
	/// <remarks>
	///     Returns all discounts of an order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return the positions</param>
	/// <param name="limit">limits the number of entries returned (optional)</param>
	/// <param name="offset">set the index where the returned entries start (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>Task of InlineResponse2009</returns>
	Task<InlineResponse2009> GetDiscountsAsync(int? orderId, int? limit = null, int? offset = null,
		List<string> embed = null);

	/// <summary>
	///     Find order discounts
	/// </summary>
	/// <remarks>
	///     Returns all discounts of an order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return the positions</param>
	/// <param name="limit">limits the number of entries returned (optional)</param>
	/// <param name="offset">set the index where the returned entries start (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>Task of ApiResponse (InlineResponse2009)</returns>
	Task<ApiResponse<InlineResponse2009>> GetDiscountsAsyncWithHttpInfo(int? orderId, int? limit = null,
		int? offset = null, List<string> embed = null);

	/// <summary>
	///     Find order by ID
	/// </summary>
	/// <remarks>
	///     Returns a single order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return</param>
	/// <returns>Task of InlineResponse20010</returns>
	Task<InlineResponse20010> GetOrderByIdAsync(int? orderId);

	/// <summary>
	///     Find order by ID
	/// </summary>
	/// <remarks>
	///     Returns a single order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return</param>
	/// <returns>Task of ApiResponse (InlineResponse20010)</returns>
	Task<ApiResponse<InlineResponse20010>> GetOrderByIdAsyncWithHttpInfo(int? orderId);

	/// <summary>
	///     Find order positions
	/// </summary>
	/// <remarks>
	///     Returns all positions of an order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return the positions</param>
	/// <param name="limit">limits the number of entries returned (optional)</param>
	/// <param name="offset">set the index where the returned entries start (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>Task of InlineResponse2007</returns>
	Task<InlineResponse2007> GetOrderPositionsByIdAsync(int? orderId, int? limit = null, int? offset = null,
		List<string> embed = null);

	/// <summary>
	///     Find order positions
	/// </summary>
	/// <remarks>
	///     Returns all positions of an order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return the positions</param>
	/// <param name="limit">limits the number of entries returned (optional)</param>
	/// <param name="offset">set the index where the returned entries start (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>Task of ApiResponse (InlineResponse2007)</returns>
	Task<ApiResponse<InlineResponse2007>> GetOrderPositionsByIdAsyncWithHttpInfo(int? orderId, int? limit = null,
		int? offset = null, List<string> embed = null);

	/// <summary>
	///     Retrieve orders
	/// </summary>
	/// <remarks>
	///     There are a multitude of parameter which can be used to filter. A few of them are attached but      for a complete
	///     list please check out &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/How-to-filter-for-certain-orders&#x27;
	///     &gt;this&lt;/a&gt; list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="status">Status of the order (optional)</param>
	/// <param name="orderNumber">Retrieve all orders with this order number (optional)</param>
	/// <param name="startDate">Retrieve all orders with a date equal or higher (optional)</param>
	/// <param name="endDate">Retrieve all orders with a date equal or lower (optional)</param>
	/// <param name="contactId">Retrieve all orders with this contact. Must be provided with contact[objectName] (optional)</param>
	/// <param name="contactObjectName">
	///     Only required if contact[id] was provided. &#x27;Contact&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <returns>Task of InlineResponse20010</returns>
	Task<InlineResponse20010> GetOrdersAsync(int? status = null, string orderNumber = null, int? startDate = null,
		int? endDate = null, int? contactId = null, string contactObjectName = null);

	/// <summary>
	///     Retrieve orders
	/// </summary>
	/// <remarks>
	///     There are a multitude of parameter which can be used to filter. A few of them are attached but      for a complete
	///     list please check out &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/How-to-filter-for-certain-orders&#x27;
	///     &gt;this&lt;/a&gt; list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="status">Status of the order (optional)</param>
	/// <param name="orderNumber">Retrieve all orders with this order number (optional)</param>
	/// <param name="startDate">Retrieve all orders with a date equal or higher (optional)</param>
	/// <param name="endDate">Retrieve all orders with a date equal or lower (optional)</param>
	/// <param name="contactId">Retrieve all orders with this contact. Must be provided with contact[objectName] (optional)</param>
	/// <param name="contactObjectName">
	///     Only required if contact[id] was provided. &#x27;Contact&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <returns>Task of ApiResponse (InlineResponse20010)</returns>
	Task<ApiResponse<InlineResponse20010>> GetOrdersAsyncWithHttpInfo(int? status = null, string orderNumber = null,
		int? startDate = null, int? endDate = null, int? contactId = null, string contactObjectName = null);

	/// <summary>
	///     Find related objects
	/// </summary>
	/// <remarks>
	///     Get related objects of a specified order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return the positions</param>
	/// <param name="includeItself">Define if the related objects include the order itself (optional)</param>
	/// <param name="sortByType">Define if you want the related objects sorted by type (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>Task of InlineResponse20038</returns>
	Task<InlineResponse20038> GetRelatedObjectsAsync(int? orderId, bool? includeItself = null, bool? sortByType = null,
		List<string> embed = null);

	/// <summary>
	///     Find related objects
	/// </summary>
	/// <remarks>
	///     Get related objects of a specified order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return the positions</param>
	/// <param name="includeItself">Define if the related objects include the order itself (optional)</param>
	/// <param name="sortByType">Define if you want the related objects sorted by type (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>Task of ApiResponse (InlineResponse20038)</returns>
	Task<ApiResponse<InlineResponse20038>> GetRelatedObjectsAsyncWithHttpInfo(int? orderId, bool? includeItself = null,
		bool? sortByType = null, List<string> embed = null);

	/// <summary>
	///     Retrieve pdf document of an order
	/// </summary>
	/// <remarks>
	///     Retrieves the pdf document of an order with additional metadata and commit the order.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order from which you want the pdf</param>
	/// <param name="download">If u want to download the pdf of the order. (optional)</param>
	/// <param name="preventSendBy">Defines if u want to send the order. (optional)</param>
	/// <returns>Task of CreditNoteGetPdfResponse</returns>
	Task<CreditNoteGetPdfResponse> OrderGetPdfAsync(int? orderId, bool? download = null, bool? preventSendBy = null);

	/// <summary>
	///     Retrieve pdf document of an order
	/// </summary>
	/// <remarks>
	///     Retrieves the pdf document of an order with additional metadata and commit the order.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order from which you want the pdf</param>
	/// <param name="download">If u want to download the pdf of the order. (optional)</param>
	/// <param name="preventSendBy">Defines if u want to send the order. (optional)</param>
	/// <returns>Task of ApiResponse (CreditNoteGetPdfResponse)</returns>
	Task<ApiResponse<CreditNoteGetPdfResponse>> OrderGetPdfAsyncWithHttpInfo(int? orderId, bool? download = null,
		bool? preventSendBy = null);

	/// <summary>
	///     Mark order as sent
	/// </summary>
	/// <remarks>
	///     Marks an order as sent by a chosen send type.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to mark as sent</param>
	/// <param name="body">Specify the send type (optional)</param>
	/// <returns>Task of InlineResponse20027</returns>
	Task<InlineResponse20027> OrderSendByAsync(int? orderId, OrderIdSendByBody body = null);

	/// <summary>
	///     Mark order as sent
	/// </summary>
	/// <remarks>
	///     Marks an order as sent by a chosen send type.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to mark as sent</param>
	/// <param name="body">Specify the send type (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse20027)</returns>
	Task<ApiResponse<InlineResponse20027>> OrderSendByAsyncWithHttpInfo(int? orderId, OrderIdSendByBody body = null);

	/// <summary>
	///     Send order via email
	/// </summary>
	/// <remarks>
	///     This endpoint sends the specified order to a customer via email.&lt;br&gt;      This will automatically mark the
	///     order as sent.&lt;br&gt;      Please note, that in production an order is not allowed to be changed after this
	///     happened!
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to be sent via email</param>
	/// <param name="body">Mail data (optional)</param>
	/// <returns>Task of InlineResponse2013</returns>
	Task<InlineResponse2013> SendorderViaEMailAsync(int? orderId, OrderIdSendViaEmailBody body = null);

	/// <summary>
	///     Send order via email
	/// </summary>
	/// <remarks>
	///     This endpoint sends the specified order to a customer via email.&lt;br&gt;      This will automatically mark the
	///     order as sent.&lt;br&gt;      Please note, that in production an order is not allowed to be changed after this
	///     happened!
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to be sent via email</param>
	/// <param name="body">Mail data (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse2013)</returns>
	Task<ApiResponse<InlineResponse2013>> SendorderViaEMailAsyncWithHttpInfo(int? orderId,
		OrderIdSendViaEmailBody body = null);

	/// <summary>
	///     Update an existing order
	/// </summary>
	/// <remarks>
	///     Update an order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>Task of InlineResponse20010</returns>
	Task<InlineResponse20010> UpdateOrderAsync(int? orderId, ModelOrderUpdate body = null);

	/// <summary>
	///     Update an existing order
	/// </summary>
	/// <remarks>
	///     Update an order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse20010)</returns>
	Task<ApiResponse<InlineResponse20010>> UpdateOrderAsyncWithHttpInfo(int? orderId, ModelOrderUpdate body = null);

	#endregion Asynchronous Operations
}