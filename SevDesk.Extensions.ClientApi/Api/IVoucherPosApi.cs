using SevDesk.Extensions.ClientApi.Client;
using SevDesk.Extensions.ClientApi.Model;

namespace SevDesk.Extensions.ClientApi.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IVoucherPosApi : IApiAccessor
{
	#region Synchronous Operations

	/// <summary>
	///     Retrieve voucher positions
	/// </summary>
	/// <remarks>
	///     Retrieve all voucher positions depending on the filters defined in the query.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="voucherId">
	///     Retrieve all vouchers positions belonging to this voucher. Must be provided with
	///     voucher[objectName] (optional)
	/// </param>
	/// <param name="voucherObjectName">
	///     Only required if voucher[id] was provided. &#x27;Voucher&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <returns>GetVoucherPositionsResponse</returns>
	GetVoucherPositionsResponse GetVoucherPositions(int? voucherId = null, string voucherObjectName = null);

	/// <summary>
	///     Retrieve voucher positions
	/// </summary>
	/// <remarks>
	///     Retrieve all voucher positions depending on the filters defined in the query.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="voucherId">
	///     Retrieve all vouchers positions belonging to this voucher. Must be provided with
	///     voucher[objectName] (optional)
	/// </param>
	/// <param name="voucherObjectName">
	///     Only required if voucher[id] was provided. &#x27;Voucher&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <returns>ApiResponse of GetVoucherPositionsResponse</returns>
	ApiResponse<GetVoucherPositionsResponse> GetVoucherPositionsWithHttpInfo(int? voucherId = null,
		string voucherObjectName = null);

	#endregion Synchronous Operations

	#region Asynchronous Operations

	/// <summary>
	///     Retrieve voucher positions
	/// </summary>
	/// <remarks>
	///     Retrieve all voucher positions depending on the filters defined in the query.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="voucherId">
	///     Retrieve all vouchers positions belonging to this voucher. Must be provided with
	///     voucher[objectName] (optional)
	/// </param>
	/// <param name="voucherObjectName">
	///     Only required if voucher[id] was provided. &#x27;Voucher&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <returns>Task of GetVoucherPositionsResponse</returns>
	Task<GetVoucherPositionsResponse> GetVoucherPositionsAsync(int? voucherId = null, string voucherObjectName = null);

	/// <summary>
	///     Retrieve voucher positions
	/// </summary>
	/// <remarks>
	///     Retrieve all voucher positions depending on the filters defined in the query.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="voucherId">
	///     Retrieve all vouchers positions belonging to this voucher. Must be provided with
	///     voucher[objectName] (optional)
	/// </param>
	/// <param name="voucherObjectName">
	///     Only required if voucher[id] was provided. &#x27;Voucher&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <returns>Task of ApiResponse (GetVoucherPositionsResponse)</returns>
	Task<ApiResponse<GetVoucherPositionsResponse>> GetVoucherPositionsAsyncWithHttpInfo(int? voucherId = null,
		string voucherObjectName = null);

	#endregion Asynchronous Operations
}