using SevDesk.Extensions.ClientApi.Client;
using SevDesk.Extensions.ClientApi.Model;

namespace SevDesk.Extensions.ClientApi.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IReportApi : IApiAccessor
{
	#region Synchronous Operations

	/// <summary>
	///     Export contact list
	/// </summary>
	/// <remarks>
	///     Export contact list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="sevQuery"></param>
	/// <param name="download"> (optional)</param>
	/// <returns>Object</returns>
	object ReportContact(SevQuery7 sevQuery, bool? download = null);

	/// <summary>
	///     Export contact list
	/// </summary>
	/// <remarks>
	///     Export contact list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="sevQuery"></param>
	/// <param name="download"> (optional)</param>
	/// <returns>ApiResponse of Object</returns>
	ApiResponse<object> ReportContactWithHttpInfo(SevQuery7 sevQuery, bool? download = null);

	/// <summary>
	///     Export invoice list
	/// </summary>
	/// <remarks>
	///     Export invoice list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="sevQuery"></param>
	/// <param name="download"> (optional)</param>
	/// <returns>Object</returns>
	object ReportInvoice(SevQuery2 sevQuery, bool? download = null);

	/// <summary>
	///     Export invoice list
	/// </summary>
	/// <remarks>
	///     Export invoice list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="sevQuery"></param>
	/// <param name="download"> (optional)</param>
	/// <returns>ApiResponse of Object</returns>
	ApiResponse<object> ReportInvoiceWithHttpInfo(SevQuery2 sevQuery, bool? download = null);

	/// <summary>
	///     Export order list
	/// </summary>
	/// <remarks>
	///     Export order list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="sevQuery"></param>
	/// <param name="download"> (optional)</param>
	/// <returns>Object</returns>
	object ReportOrder(SevQuery3 sevQuery, bool? download = null);

	/// <summary>
	///     Export order list
	/// </summary>
	/// <remarks>
	///     Export order list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="sevQuery"></param>
	/// <param name="download"> (optional)</param>
	/// <returns>ApiResponse of Object</returns>
	ApiResponse<object> ReportOrderWithHttpInfo(SevQuery3 sevQuery, bool? download = null);

	/// <summary>
	///     Export voucher list
	/// </summary>
	/// <remarks>
	///     Export voucher list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="sevQuery"></param>
	/// <param name="download"> (optional)</param>
	/// <returns>Object</returns>
	object ReportVoucher(SevQuery5 sevQuery, bool? download = null);

	/// <summary>
	///     Export voucher list
	/// </summary>
	/// <remarks>
	///     Export voucher list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="sevQuery"></param>
	/// <param name="download"> (optional)</param>
	/// <returns>ApiResponse of Object</returns>
	ApiResponse<object> ReportVoucherWithHttpInfo(SevQuery5 sevQuery, bool? download = null);

	#endregion Synchronous Operations

	#region Asynchronous Operations

	/// <summary>
	///     Export contact list
	/// </summary>
	/// <remarks>
	///     Export contact list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="sevQuery"></param>
	/// <param name="download"> (optional)</param>
	/// <returns>Task of Object</returns>
	Task<object> ReportContactAsync(SevQuery7 sevQuery, bool? download = null);

	/// <summary>
	///     Export contact list
	/// </summary>
	/// <remarks>
	///     Export contact list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="sevQuery"></param>
	/// <param name="download"> (optional)</param>
	/// <returns>Task of ApiResponse (Object)</returns>
	Task<ApiResponse<object>> ReportContactAsyncWithHttpInfo(SevQuery7 sevQuery, bool? download = null);

	/// <summary>
	///     Export invoice list
	/// </summary>
	/// <remarks>
	///     Export invoice list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="sevQuery"></param>
	/// <param name="download"> (optional)</param>
	/// <returns>Task of Object</returns>
	Task<object> ReportInvoiceAsync(SevQuery2 sevQuery, bool? download = null);

	/// <summary>
	///     Export invoice list
	/// </summary>
	/// <remarks>
	///     Export invoice list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="sevQuery"></param>
	/// <param name="download"> (optional)</param>
	/// <returns>Task of ApiResponse (Object)</returns>
	Task<ApiResponse<object>> ReportInvoiceAsyncWithHttpInfo(SevQuery2 sevQuery, bool? download = null);

	/// <summary>
	///     Export order list
	/// </summary>
	/// <remarks>
	///     Export order list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="sevQuery"></param>
	/// <param name="download"> (optional)</param>
	/// <returns>Task of Object</returns>
	Task<object> ReportOrderAsync(SevQuery3 sevQuery, bool? download = null);

	/// <summary>
	///     Export order list
	/// </summary>
	/// <remarks>
	///     Export order list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="sevQuery"></param>
	/// <param name="download"> (optional)</param>
	/// <returns>Task of ApiResponse (Object)</returns>
	Task<ApiResponse<object>> ReportOrderAsyncWithHttpInfo(SevQuery3 sevQuery, bool? download = null);

	/// <summary>
	///     Export voucher list
	/// </summary>
	/// <remarks>
	///     Export voucher list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="sevQuery"></param>
	/// <param name="download"> (optional)</param>
	/// <returns>Task of Object</returns>
	Task<object> ReportVoucherAsync(SevQuery5 sevQuery, bool? download = null);

	/// <summary>
	///     Export voucher list
	/// </summary>
	/// <remarks>
	///     Export voucher list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="sevQuery"></param>
	/// <param name="download"> (optional)</param>
	/// <returns>Task of ApiResponse (Object)</returns>
	Task<ApiResponse<object>> ReportVoucherAsyncWithHttpInfo(SevQuery5 sevQuery, bool? download = null);

	#endregion Asynchronous Operations
}