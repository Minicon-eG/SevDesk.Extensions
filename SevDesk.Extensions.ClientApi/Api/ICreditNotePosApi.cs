using SevDesk.Extensions.ClientApi.Client;
using SevDesk.Extensions.ClientApi.Model;

namespace SevDesk.Extensions.ClientApi.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface ICreditNotePosApi : IApiAccessor
{
	#region Synchronous Operations

	/// <summary>
	///     Retrieve creditNote positions
	/// </summary>
	/// <remarks>
	///     Retrieve all creditNote positions depending on the filters defined in the query.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="creditNoteId">
	///     Retrieve all creditNote positions belonging to this creditNote. Must be provided with
	///     creditNote[objectName] (optional)
	/// </param>
	/// <param name="creditNoteObjectName">
	///     Only required if creditNote[id] was provided. &#x27;creditNote&#x27; should be used
	///     as value. (optional)
	/// </param>
	/// <returns>InlineResponse20033</returns>
	InlineResponse20033 GetcreditNotePositions(int? creditNoteId = null, string creditNoteObjectName = null);

	/// <summary>
	///     Retrieve creditNote positions
	/// </summary>
	/// <remarks>
	///     Retrieve all creditNote positions depending on the filters defined in the query.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="creditNoteId">
	///     Retrieve all creditNote positions belonging to this creditNote. Must be provided with
	///     creditNote[objectName] (optional)
	/// </param>
	/// <param name="creditNoteObjectName">
	///     Only required if creditNote[id] was provided. &#x27;creditNote&#x27; should be used
	///     as value. (optional)
	/// </param>
	/// <returns>ApiResponse of InlineResponse20033</returns>
	ApiResponse<InlineResponse20033> GetcreditNotePositionsWithHttpInfo(int? creditNoteId = null,
		string creditNoteObjectName = null);

	#endregion Synchronous Operations

	#region Asynchronous Operations

	/// <summary>
	///     Retrieve creditNote positions
	/// </summary>
	/// <remarks>
	///     Retrieve all creditNote positions depending on the filters defined in the query.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="creditNoteId">
	///     Retrieve all creditNote positions belonging to this creditNote. Must be provided with
	///     creditNote[objectName] (optional)
	/// </param>
	/// <param name="creditNoteObjectName">
	///     Only required if creditNote[id] was provided. &#x27;creditNote&#x27; should be used
	///     as value. (optional)
	/// </param>
	/// <returns>Task of InlineResponse20033</returns>
	Task<InlineResponse20033> GetcreditNotePositionsAsync(int? creditNoteId = null, string creditNoteObjectName = null);

	/// <summary>
	///     Retrieve creditNote positions
	/// </summary>
	/// <remarks>
	///     Retrieve all creditNote positions depending on the filters defined in the query.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="creditNoteId">
	///     Retrieve all creditNote positions belonging to this creditNote. Must be provided with
	///     creditNote[objectName] (optional)
	/// </param>
	/// <param name="creditNoteObjectName">
	///     Only required if creditNote[id] was provided. &#x27;creditNote&#x27; should be used
	///     as value. (optional)
	/// </param>
	/// <returns>Task of ApiResponse (InlineResponse20033)</returns>
	Task<ApiResponse<InlineResponse20033>> GetcreditNotePositionsAsyncWithHttpInfo(int? creditNoteId = null,
		string creditNoteObjectName = null);

	#endregion Asynchronous Operations
}