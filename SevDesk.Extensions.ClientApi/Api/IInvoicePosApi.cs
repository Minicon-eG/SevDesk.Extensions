using SevDesk.Extensions.ClientApi.Client;
using SevDesk.Extensions.ClientApi.Model;

namespace SevDesk.Extensions.ClientApi.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IInvoicePosApi : IApiAccessor
{
	#region Synchronous Operations

	/// <summary>
	///     Retrieve InvoicePos
	/// </summary>
	/// <remarks>
	///     There are a multitude of parameter which can be used to filter.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="id">Retrieve all InvoicePos with this InvoicePos id (optional)</param>
	/// <param name="invoiceId">
	///     Retrieve all invoices positions with this invoice. Must be provided with invoice[objectName]
	///     (optional)
	/// </param>
	/// <param name="invoiceObjectName">
	///     Only required if invoice[id] was provided. &#x27;Invoice&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <param name="partId">Retrieve all invoices positions with this part. Must be provided with part[objectName] (optional)</param>
	/// <param name="partObjectName">
	///     Only required if part[id] was provided. &#x27;Part&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <returns>InlineResponse20022</returns>
	InlineResponse20022 GetInvoicePos(decimal? id = null, decimal? invoiceId = null, string invoiceObjectName = null,
		decimal? partId = null, string partObjectName = null);

	/// <summary>
	///     Retrieve InvoicePos
	/// </summary>
	/// <remarks>
	///     There are a multitude of parameter which can be used to filter.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="id">Retrieve all InvoicePos with this InvoicePos id (optional)</param>
	/// <param name="invoiceId">
	///     Retrieve all invoices positions with this invoice. Must be provided with invoice[objectName]
	///     (optional)
	/// </param>
	/// <param name="invoiceObjectName">
	///     Only required if invoice[id] was provided. &#x27;Invoice&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <param name="partId">Retrieve all invoices positions with this part. Must be provided with part[objectName] (optional)</param>
	/// <param name="partObjectName">
	///     Only required if part[id] was provided. &#x27;Part&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <returns>ApiResponse of InlineResponse20022</returns>
	ApiResponse<InlineResponse20022> GetInvoicePosWithHttpInfo(decimal? id = null, decimal? invoiceId = null,
		string invoiceObjectName = null, decimal? partId = null, string partObjectName = null);

	#endregion Synchronous Operations

	#region Asynchronous Operations

	/// <summary>
	///     Retrieve InvoicePos
	/// </summary>
	/// <remarks>
	///     There are a multitude of parameter which can be used to filter.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="id">Retrieve all InvoicePos with this InvoicePos id (optional)</param>
	/// <param name="invoiceId">
	///     Retrieve all invoices positions with this invoice. Must be provided with invoice[objectName]
	///     (optional)
	/// </param>
	/// <param name="invoiceObjectName">
	///     Only required if invoice[id] was provided. &#x27;Invoice&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <param name="partId">Retrieve all invoices positions with this part. Must be provided with part[objectName] (optional)</param>
	/// <param name="partObjectName">
	///     Only required if part[id] was provided. &#x27;Part&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <returns>Task of InlineResponse20022</returns>
	Task<InlineResponse20022> GetInvoicePosAsync(decimal? id = null, decimal? invoiceId = null,
		string invoiceObjectName = null, decimal? partId = null, string partObjectName = null);

	/// <summary>
	///     Retrieve InvoicePos
	/// </summary>
	/// <remarks>
	///     There are a multitude of parameter which can be used to filter.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="id">Retrieve all InvoicePos with this InvoicePos id (optional)</param>
	/// <param name="invoiceId">
	///     Retrieve all invoices positions with this invoice. Must be provided with invoice[objectName]
	///     (optional)
	/// </param>
	/// <param name="invoiceObjectName">
	///     Only required if invoice[id] was provided. &#x27;Invoice&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <param name="partId">Retrieve all invoices positions with this part. Must be provided with part[objectName] (optional)</param>
	/// <param name="partObjectName">
	///     Only required if part[id] was provided. &#x27;Part&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <returns>Task of ApiResponse (InlineResponse20022)</returns>
	Task<ApiResponse<InlineResponse20022>> GetInvoicePosAsyncWithHttpInfo(decimal? id = null, decimal? invoiceId = null,
		string invoiceObjectName = null, decimal? partId = null, string partObjectName = null);

	#endregion Asynchronous Operations
}