using SevDesk.Extensions.ClientApi.Client;
using SevDesk.Extensions.ClientApi.Model;

namespace SevDesk.Extensions.ClientApi.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface ICheckAccountTransactionApi : IApiAccessor
{
	#region Synchronous Operations

	/// <summary>
	///     Create a new transaction
	/// </summary>
	/// <remarks>
	///     Creates a new transaction on a check account.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">
	///     Creation data. Please be aware, that you need to provide at least all required parameter
	///     of the CheckAccountTransaction model! (optional)
	/// </param>
	/// <returns>InlineResponse2004</returns>
	InlineResponse2004 CreateTransaction(ModelCheckAccountTransaction body = null);

	/// <summary>
	///     Create a new transaction
	/// </summary>
	/// <remarks>
	///     Creates a new transaction on a check account.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">
	///     Creation data. Please be aware, that you need to provide at least all required parameter
	///     of the CheckAccountTransaction model! (optional)
	/// </param>
	/// <returns>ApiResponse of InlineResponse2004</returns>
	ApiResponse<InlineResponse2004> CreateTransactionWithHttpInfo(ModelCheckAccountTransaction body = null);

	/// <summary>
	///     Deletes a check account transaction
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountTransactionId">Id of check account transaction to delete</param>
	/// <returns>InlineResponse2003</returns>
	InlineResponse2003 DeleteCheckAccountTransaction(int? checkAccountTransactionId);

	/// <summary>
	///     Deletes a check account transaction
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountTransactionId">Id of check account transaction to delete</param>
	/// <returns>ApiResponse of InlineResponse2003</returns>
	ApiResponse<InlineResponse2003> DeleteCheckAccountTransactionWithHttpInfo(int? checkAccountTransactionId);

	/// <summary>
	///     Find check account transaction by ID
	/// </summary>
	/// <remarks>
	///     Retrieve an existing check account transaction
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountTransactionId">ID of check account transaction</param>
	/// <returns>InlineResponse2004</returns>
	InlineResponse2004 GetCheckAccountTransactionById(int? checkAccountTransactionId);

	/// <summary>
	///     Find check account transaction by ID
	/// </summary>
	/// <remarks>
	///     Retrieve an existing check account transaction
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountTransactionId">ID of check account transaction</param>
	/// <returns>ApiResponse of InlineResponse2004</returns>
	ApiResponse<InlineResponse2004> GetCheckAccountTransactionByIdWithHttpInfo(int? checkAccountTransactionId);

	/// <summary>
	///     Retrieve transactions
	/// </summary>
	/// <remarks>
	///     Retrieve all transactions depending on the filters defined in the query.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountId">
	///     Retrieve all transactions on this check account. Must be provided with
	///     checkAccount[objectName] (optional)
	/// </param>
	/// <param name="checkAccountObjectName">
	///     Only required if checkAccount[id] was provided. &#x27;CheckAccount&#x27; should be
	///     used as value. (optional)
	/// </param>
	/// <param name="isBooked">Only retrieve booked transactions (optional)</param>
	/// <param name="paymtPurpose">Only retrieve transactions with this payment purpose (optional)</param>
	/// <param name="startDate">Only retrieve transactions from this date on (optional)</param>
	/// <param name="endDate">Only retrieve transactions up to this date (optional)</param>
	/// <param name="payeePayerName">Only retrieve transactions with this payee / payer (optional)</param>
	/// <param name="onlyCredit">Only retrieve credit transactions (optional)</param>
	/// <param name="onlyDebit">Only retrieve debit transactions (optional)</param>
	/// <returns>InlineResponse2004</returns>
	InlineResponse2004 GetTransactions(int? checkAccountId = null, string checkAccountObjectName = null,
		bool? isBooked = null, string paymtPurpose = null, DateTime? startDate = null, DateTime? endDate = null,
		string payeePayerName = null, bool? onlyCredit = null, bool? onlyDebit = null);

	/// <summary>
	///     Retrieve transactions
	/// </summary>
	/// <remarks>
	///     Retrieve all transactions depending on the filters defined in the query.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountId">
	///     Retrieve all transactions on this check account. Must be provided with
	///     checkAccount[objectName] (optional)
	/// </param>
	/// <param name="checkAccountObjectName">
	///     Only required if checkAccount[id] was provided. &#x27;CheckAccount&#x27; should be
	///     used as value. (optional)
	/// </param>
	/// <param name="isBooked">Only retrieve booked transactions (optional)</param>
	/// <param name="paymtPurpose">Only retrieve transactions with this payment purpose (optional)</param>
	/// <param name="startDate">Only retrieve transactions from this date on (optional)</param>
	/// <param name="endDate">Only retrieve transactions up to this date (optional)</param>
	/// <param name="payeePayerName">Only retrieve transactions with this payee / payer (optional)</param>
	/// <param name="onlyCredit">Only retrieve credit transactions (optional)</param>
	/// <param name="onlyDebit">Only retrieve debit transactions (optional)</param>
	/// <returns>ApiResponse of InlineResponse2004</returns>
	ApiResponse<InlineResponse2004> GetTransactionsWithHttpInfo(int? checkAccountId = null,
		string checkAccountObjectName = null, bool? isBooked = null, string paymtPurpose = null,
		DateTime? startDate = null, DateTime? endDate = null, string payeePayerName = null, bool? onlyCredit = null,
		bool? onlyDebit = null);

	/// <summary>
	///     Update an existing check account transaction
	/// </summary>
	/// <remarks>
	///     Update a check account transaction
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountTransactionId">ID of check account to update transaction</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>InlineResponse2004</returns>
	InlineResponse2004 UpdateCheckAccountTransaction(int? checkAccountTransactionId,
		ModelCheckAccountTransactionUpdate body = null);

	/// <summary>
	///     Update an existing check account transaction
	/// </summary>
	/// <remarks>
	///     Update a check account transaction
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountTransactionId">ID of check account to update transaction</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>ApiResponse of InlineResponse2004</returns>
	ApiResponse<InlineResponse2004> UpdateCheckAccountTransactionWithHttpInfo(int? checkAccountTransactionId,
		ModelCheckAccountTransactionUpdate body = null);

	#endregion Synchronous Operations

	#region Asynchronous Operations

	/// <summary>
	///     Create a new transaction
	/// </summary>
	/// <remarks>
	///     Creates a new transaction on a check account.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">
	///     Creation data. Please be aware, that you need to provide at least all required parameter
	///     of the CheckAccountTransaction model! (optional)
	/// </param>
	/// <returns>Task of InlineResponse2004</returns>
	Task<InlineResponse2004> CreateTransactionAsync(ModelCheckAccountTransaction body = null);

	/// <summary>
	///     Create a new transaction
	/// </summary>
	/// <remarks>
	///     Creates a new transaction on a check account.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">
	///     Creation data. Please be aware, that you need to provide at least all required parameter
	///     of the CheckAccountTransaction model! (optional)
	/// </param>
	/// <returns>Task of ApiResponse (InlineResponse2004)</returns>
	Task<ApiResponse<InlineResponse2004>> CreateTransactionAsyncWithHttpInfo(ModelCheckAccountTransaction body = null);

	/// <summary>
	///     Deletes a check account transaction
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountTransactionId">Id of check account transaction to delete</param>
	/// <returns>Task of InlineResponse2003</returns>
	Task<InlineResponse2003> DeleteCheckAccountTransactionAsync(int? checkAccountTransactionId);

	/// <summary>
	///     Deletes a check account transaction
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountTransactionId">Id of check account transaction to delete</param>
	/// <returns>Task of ApiResponse (InlineResponse2003)</returns>
	Task<ApiResponse<InlineResponse2003>>
		DeleteCheckAccountTransactionAsyncWithHttpInfo(int? checkAccountTransactionId);

	/// <summary>
	///     Find check account transaction by ID
	/// </summary>
	/// <remarks>
	///     Retrieve an existing check account transaction
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountTransactionId">ID of check account transaction</param>
	/// <returns>Task of InlineResponse2004</returns>
	Task<InlineResponse2004> GetCheckAccountTransactionByIdAsync(int? checkAccountTransactionId);

	/// <summary>
	///     Find check account transaction by ID
	/// </summary>
	/// <remarks>
	///     Retrieve an existing check account transaction
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountTransactionId">ID of check account transaction</param>
	/// <returns>Task of ApiResponse (InlineResponse2004)</returns>
	Task<ApiResponse<InlineResponse2004>> GetCheckAccountTransactionByIdAsyncWithHttpInfo(
		int? checkAccountTransactionId);

	/// <summary>
	///     Retrieve transactions
	/// </summary>
	/// <remarks>
	///     Retrieve all transactions depending on the filters defined in the query.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountId">
	///     Retrieve all transactions on this check account. Must be provided with
	///     checkAccount[objectName] (optional)
	/// </param>
	/// <param name="checkAccountObjectName">
	///     Only required if checkAccount[id] was provided. &#x27;CheckAccount&#x27; should be
	///     used as value. (optional)
	/// </param>
	/// <param name="isBooked">Only retrieve booked transactions (optional)</param>
	/// <param name="paymtPurpose">Only retrieve transactions with this payment purpose (optional)</param>
	/// <param name="startDate">Only retrieve transactions from this date on (optional)</param>
	/// <param name="endDate">Only retrieve transactions up to this date (optional)</param>
	/// <param name="payeePayerName">Only retrieve transactions with this payee / payer (optional)</param>
	/// <param name="onlyCredit">Only retrieve credit transactions (optional)</param>
	/// <param name="onlyDebit">Only retrieve debit transactions (optional)</param>
	/// <returns>Task of InlineResponse2004</returns>
	Task<InlineResponse2004> GetTransactionsAsync(int? checkAccountId = null, string checkAccountObjectName = null,
		bool? isBooked = null, string paymtPurpose = null, DateTime? startDate = null, DateTime? endDate = null,
		string payeePayerName = null, bool? onlyCredit = null, bool? onlyDebit = null);

	/// <summary>
	///     Retrieve transactions
	/// </summary>
	/// <remarks>
	///     Retrieve all transactions depending on the filters defined in the query.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountId">
	///     Retrieve all transactions on this check account. Must be provided with
	///     checkAccount[objectName] (optional)
	/// </param>
	/// <param name="checkAccountObjectName">
	///     Only required if checkAccount[id] was provided. &#x27;CheckAccount&#x27; should be
	///     used as value. (optional)
	/// </param>
	/// <param name="isBooked">Only retrieve booked transactions (optional)</param>
	/// <param name="paymtPurpose">Only retrieve transactions with this payment purpose (optional)</param>
	/// <param name="startDate">Only retrieve transactions from this date on (optional)</param>
	/// <param name="endDate">Only retrieve transactions up to this date (optional)</param>
	/// <param name="payeePayerName">Only retrieve transactions with this payee / payer (optional)</param>
	/// <param name="onlyCredit">Only retrieve credit transactions (optional)</param>
	/// <param name="onlyDebit">Only retrieve debit transactions (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse2004)</returns>
	Task<ApiResponse<InlineResponse2004>> GetTransactionsAsyncWithHttpInfo(int? checkAccountId = null,
		string checkAccountObjectName = null, bool? isBooked = null, string paymtPurpose = null,
		DateTime? startDate = null, DateTime? endDate = null, string payeePayerName = null, bool? onlyCredit = null,
		bool? onlyDebit = null);

	/// <summary>
	///     Update an existing check account transaction
	/// </summary>
	/// <remarks>
	///     Update a check account transaction
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountTransactionId">ID of check account to update transaction</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>Task of InlineResponse2004</returns>
	Task<InlineResponse2004> UpdateCheckAccountTransactionAsync(int? checkAccountTransactionId,
		ModelCheckAccountTransactionUpdate body = null);

	/// <summary>
	///     Update an existing check account transaction
	/// </summary>
	/// <remarks>
	///     Update a check account transaction
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountTransactionId">ID of check account to update transaction</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse2004)</returns>
	Task<ApiResponse<InlineResponse2004>> UpdateCheckAccountTransactionAsyncWithHttpInfo(int? checkAccountTransactionId,
		ModelCheckAccountTransactionUpdate body = null);

	#endregion Asynchronous Operations
}