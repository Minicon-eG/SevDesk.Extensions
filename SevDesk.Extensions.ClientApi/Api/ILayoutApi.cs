using SevDesk.Extensions.ClientApi.Client;
using SevDesk.Extensions.ClientApi.Model;

namespace SevDesk.Extensions.ClientApi.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface ILayoutApi : IApiAccessor
{
	#region Synchronous Operations

	/// <summary>
	///     Retrieve letterpapers
	/// </summary>
	/// <remarks>
	///     Retrieve all letterpapers with Thumb
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>InlineResponse20015</returns>
	InlineResponse20015 GetLetterpapersWithThumb();

	/// <summary>
	///     Retrieve letterpapers
	/// </summary>
	/// <remarks>
	///     Retrieve all letterpapers with Thumb
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>ApiResponse of InlineResponse20015</returns>
	ApiResponse<InlineResponse20015> GetLetterpapersWithThumbWithHttpInfo();

	/// <summary>
	///     Retrieve templates
	/// </summary>
	/// <remarks>
	///     Retrieve all templates
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="type">Type of the templates you want to get. (optional)</param>
	/// <returns>InlineResponse20037</returns>
	InlineResponse20037 GetTemplates(string type = null);

	/// <summary>
	///     Retrieve templates
	/// </summary>
	/// <remarks>
	///     Retrieve all templates
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="type">Type of the templates you want to get. (optional)</param>
	/// <returns>ApiResponse of InlineResponse20037</returns>
	ApiResponse<InlineResponse20037> GetTemplatesWithHttpInfo(string type = null);

	/// <summary>
	///     Update an of credit note template
	/// </summary>
	/// <remarks>
	///     Update an existing of credit note template
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="creditNoteId">ID of credit note to update</param>
	/// <param name="body">Change Layout (optional)</param>
	/// <returns>InlineResponse20017</returns>
	InlineResponse20017 UpdateCreditNoteTemplate(int? creditNoteId, ModelChangeLayout body = null);

	/// <summary>
	///     Update an of credit note template
	/// </summary>
	/// <remarks>
	///     Update an existing of credit note template
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="creditNoteId">ID of credit note to update</param>
	/// <param name="body">Change Layout (optional)</param>
	/// <returns>ApiResponse of InlineResponse20017</returns>
	ApiResponse<InlineResponse20017> UpdateCreditNoteTemplateWithHttpInfo(int? creditNoteId,
		ModelChangeLayout body = null);

	/// <summary>
	///     Update an invoice template
	/// </summary>
	/// <remarks>
	///     Update an existing invoice template
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to update</param>
	/// <param name="body">Change Layout (optional)</param>
	/// <returns>InlineResponse20017</returns>
	InlineResponse20017 UpdateInvoiceTemplate(int? invoiceId, ModelChangeLayout body = null);

	/// <summary>
	///     Update an invoice template
	/// </summary>
	/// <remarks>
	///     Update an existing invoice template
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to update</param>
	/// <param name="body">Change Layout (optional)</param>
	/// <returns>ApiResponse of InlineResponse20017</returns>
	ApiResponse<InlineResponse20017> UpdateInvoiceTemplateWithHttpInfo(int? invoiceId, ModelChangeLayout body = null);

	/// <summary>
	///     Update an order template
	/// </summary>
	/// <remarks>
	///     Update an existing order template
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to update</param>
	/// <param name="body">Change Layout (optional)</param>
	/// <returns>InlineResponse20017</returns>
	InlineResponse20017 UpdateOrderTemplate(int? orderId, ModelChangeLayout body = null);

	/// <summary>
	///     Update an order template
	/// </summary>
	/// <remarks>
	///     Update an existing order template
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to update</param>
	/// <param name="body">Change Layout (optional)</param>
	/// <returns>ApiResponse of InlineResponse20017</returns>
	ApiResponse<InlineResponse20017> UpdateOrderTemplateWithHttpInfo(int? orderId, ModelChangeLayout body = null);

	#endregion Synchronous Operations

	#region Asynchronous Operations

	/// <summary>
	///     Retrieve letterpapers
	/// </summary>
	/// <remarks>
	///     Retrieve all letterpapers with Thumb
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of InlineResponse20015</returns>
	Task<InlineResponse20015> GetLetterpapersWithThumbAsync();

	/// <summary>
	///     Retrieve letterpapers
	/// </summary>
	/// <remarks>
	///     Retrieve all letterpapers with Thumb
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ApiResponse (InlineResponse20015)</returns>
	Task<ApiResponse<InlineResponse20015>> GetLetterpapersWithThumbAsyncWithHttpInfo();

	/// <summary>
	///     Retrieve templates
	/// </summary>
	/// <remarks>
	///     Retrieve all templates
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="type">Type of the templates you want to get. (optional)</param>
	/// <returns>Task of InlineResponse20037</returns>
	Task<InlineResponse20037> GetTemplatesAsync(string type = null);

	/// <summary>
	///     Retrieve templates
	/// </summary>
	/// <remarks>
	///     Retrieve all templates
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="type">Type of the templates you want to get. (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse20037)</returns>
	Task<ApiResponse<InlineResponse20037>> GetTemplatesAsyncWithHttpInfo(string type = null);

	/// <summary>
	///     Update an of credit note template
	/// </summary>
	/// <remarks>
	///     Update an existing of credit note template
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="creditNoteId">ID of credit note to update</param>
	/// <param name="body">Change Layout (optional)</param>
	/// <returns>Task of InlineResponse20017</returns>
	Task<InlineResponse20017> UpdateCreditNoteTemplateAsync(int? creditNoteId, ModelChangeLayout body = null);

	/// <summary>
	///     Update an of credit note template
	/// </summary>
	/// <remarks>
	///     Update an existing of credit note template
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="creditNoteId">ID of credit note to update</param>
	/// <param name="body">Change Layout (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse20017)</returns>
	Task<ApiResponse<InlineResponse20017>> UpdateCreditNoteTemplateAsyncWithHttpInfo(int? creditNoteId,
		ModelChangeLayout body = null);

	/// <summary>
	///     Update an invoice template
	/// </summary>
	/// <remarks>
	///     Update an existing invoice template
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to update</param>
	/// <param name="body">Change Layout (optional)</param>
	/// <returns>Task of InlineResponse20017</returns>
	Task<InlineResponse20017> UpdateInvoiceTemplateAsync(int? invoiceId, ModelChangeLayout body = null);

	/// <summary>
	///     Update an invoice template
	/// </summary>
	/// <remarks>
	///     Update an existing invoice template
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to update</param>
	/// <param name="body">Change Layout (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse20017)</returns>
	Task<ApiResponse<InlineResponse20017>> UpdateInvoiceTemplateAsyncWithHttpInfo(int? invoiceId,
		ModelChangeLayout body = null);

	/// <summary>
	///     Update an order template
	/// </summary>
	/// <remarks>
	///     Update an existing order template
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to update</param>
	/// <param name="body">Change Layout (optional)</param>
	/// <returns>Task of InlineResponse20017</returns>
	Task<InlineResponse20017> UpdateOrderTemplateAsync(int? orderId, ModelChangeLayout body = null);

	/// <summary>
	///     Update an order template
	/// </summary>
	/// <remarks>
	///     Update an existing order template
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to update</param>
	/// <param name="body">Change Layout (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse20017)</returns>
	Task<ApiResponse<InlineResponse20017>> UpdateOrderTemplateAsyncWithHttpInfo(int? orderId,
		ModelChangeLayout body = null);

	#endregion Asynchronous Operations
}