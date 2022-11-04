using SevDesk.Extensions.ClientApi.Client;
using SevDesk.Extensions.ClientApi.Model;

namespace SevDesk.Extensions.ClientApi.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IVoucherApi : IApiAccessor
{
	#region Synchronous Operations

	/// <summary>
	///     Book a voucher
	/// </summary>
	/// <remarks>
	///     Booking the voucher with a transaction is probably the most important part in the bookkeeping process.&lt;br&gt;
	///     There are several ways on correctly booking a voucher, all by using the same endpoint.&lt;br&gt; Conveniently, the
	///     booking process is exactly the same as the process for invoices.&lt;br&gt; For this reason, you can have a look at
	///     it &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/How-to-book-an-invoice&#x27;&gt;here&lt;/a&gt; and all you
	///     need to to is to change \&quot;Invoice\&quot; into \&quot;Voucher\&quot; in the URL.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="voucherId">ID of voucher to book</param>
	/// <param name="body">Booking data (optional)</param>
	/// <returns>InlineResponse200</returns>
	InlineResponse200 BookVoucher(int? voucherId, VoucherIdBookAmountBody body = null);

	/// <summary>
	///     Book a voucher
	/// </summary>
	/// <remarks>
	///     Booking the voucher with a transaction is probably the most important part in the bookkeeping process.&lt;br&gt;
	///     There are several ways on correctly booking a voucher, all by using the same endpoint.&lt;br&gt; Conveniently, the
	///     booking process is exactly the same as the process for invoices.&lt;br&gt; For this reason, you can have a look at
	///     it &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/How-to-book-an-invoice&#x27;&gt;here&lt;/a&gt; and all you
	///     need to to is to change \&quot;Invoice\&quot; into \&quot;Voucher\&quot; in the URL.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="voucherId">ID of voucher to book</param>
	/// <param name="body">Booking data (optional)</param>
	/// <returns>ApiResponse of InlineResponse200</returns>
	ApiResponse<InlineResponse200> BookVoucherWithHttpInfo(int? voucherId, VoucherIdBookAmountBody body = null);

	/// <summary>
	///     Create a new voucher
	/// </summary>
	/// <remarks>
	///     Generally there are two ways to create vouchers.&lt;br&gt; You can create vouchers by either POSTing to the &lt;b
	///     &gt;Voucher&lt;/b&gt; and &lt;b&gt;VoucherPos&lt;/b&gt; endpoints with the necessary parameters (see attribute
	///     lists) or you can use a special endpoint which bundles the requests in one.&lt;br&gt; &lt;br&gt; The list of
	///     parameters starts with the voucher array.&lt;br&gt; This array contains all required attributes for a complete
	///     voucher.&lt;br&gt; Most of the attributes are covered in the voucher attribute list, there are only two parameters
	///     standing out, namely &lt;b&gt;mapAll&lt;/b&gt; and &lt;b&gt;objectName&lt;/b&gt;.&lt;br&gt; These are just needed
	///     for our system and you always need to provide them.&lt;br&gt;&lt;br&gt; The list of parameters then continues with
	///     the voucher position array.&lt;br&gt; With this array you have the possibility to add multiple positions at once.
	///     &lt;br&gt; In the example it only contains one position, again together with the parameters &lt;b&gt;mapAll&lt;/b
	///     &gt; and &lt;b&gt;objectName&lt;/b&gt;, however, you can add more voucher positions by extending the array.&lt;br
	///     &gt; So if you wanted to add another position, you would add the same list of parameters with an
	///     incrementedcomponents/schemas/saveVoucher\&quot; array index of \\\&quot;1\\\&quot; instead of \\\&quot;0\\\&quot;.
	///     &lt;br&gt;&lt;br&gt; The list ends with the two parameters voucherPosDelete and filename.&lt;br&gt; We will shortly
	///     explain what they can do.&lt;br&gt; With voucherPosDelete you have to option to delete voucher positions as this
	///     request can also be used to update vouchers.&lt;br&gt; With filename you can attach a file to the voucher.&lt;br
	///     &gt; For most of our customers this is a really important step, as they need to digitize their receipts.&lt;br&gt;
	///     Finally, after covering all parameters, they only important information left, is that the order of the last two
	///     attributes always needs to be kept.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">
	///     Creation data. Please be aware, that you need to provide at least all required parameter
	///     of the voucher and voucher position model! (optional)
	/// </param>
	/// <returns>SaveVoucherResponse</returns>
	SaveVoucherResponse CreateVoucherByFactory(SaveVoucher body = null);

	/// <summary>
	///     Create a new voucher
	/// </summary>
	/// <remarks>
	///     Generally there are two ways to create vouchers.&lt;br&gt; You can create vouchers by either POSTing to the &lt;b
	///     &gt;Voucher&lt;/b&gt; and &lt;b&gt;VoucherPos&lt;/b&gt; endpoints with the necessary parameters (see attribute
	///     lists) or you can use a special endpoint which bundles the requests in one.&lt;br&gt; &lt;br&gt; The list of
	///     parameters starts with the voucher array.&lt;br&gt; This array contains all required attributes for a complete
	///     voucher.&lt;br&gt; Most of the attributes are covered in the voucher attribute list, there are only two parameters
	///     standing out, namely &lt;b&gt;mapAll&lt;/b&gt; and &lt;b&gt;objectName&lt;/b&gt;.&lt;br&gt; These are just needed
	///     for our system and you always need to provide them.&lt;br&gt;&lt;br&gt; The list of parameters then continues with
	///     the voucher position array.&lt;br&gt; With this array you have the possibility to add multiple positions at once.
	///     &lt;br&gt; In the example it only contains one position, again together with the parameters &lt;b&gt;mapAll&lt;/b
	///     &gt; and &lt;b&gt;objectName&lt;/b&gt;, however, you can add more voucher positions by extending the array.&lt;br
	///     &gt; So if you wanted to add another position, you would add the same list of parameters with an
	///     incrementedcomponents/schemas/saveVoucher\&quot; array index of \\\&quot;1\\\&quot; instead of \\\&quot;0\\\&quot;.
	///     &lt;br&gt;&lt;br&gt; The list ends with the two parameters voucherPosDelete and filename.&lt;br&gt; We will shortly
	///     explain what they can do.&lt;br&gt; With voucherPosDelete you have to option to delete voucher positions as this
	///     request can also be used to update vouchers.&lt;br&gt; With filename you can attach a file to the voucher.&lt;br
	///     &gt; For most of our customers this is a really important step, as they need to digitize their receipts.&lt;br&gt;
	///     Finally, after covering all parameters, they only important information left, is that the order of the last two
	///     attributes always needs to be kept.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">
	///     Creation data. Please be aware, that you need to provide at least all required parameter
	///     of the voucher and voucher position model! (optional)
	/// </param>
	/// <returns>ApiResponse of SaveVoucherResponse</returns>
	ApiResponse<SaveVoucherResponse> CreateVoucherByFactoryWithHttpInfo(SaveVoucher body = null);

	/// <summary>
	///     Find voucher by ID
	/// </summary>
	/// <remarks>
	///     Returns a single voucher
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="voucherId">ID of voucher to return</param>
	/// <returns>GetVoucherResponse</returns>
	GetVoucherResponse GetVoucherById(int? voucherId);

	/// <summary>
	///     Find voucher by ID
	/// </summary>
	/// <remarks>
	///     Returns a single voucher
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="voucherId">ID of voucher to return</param>
	/// <returns>ApiResponse of GetVoucherResponse</returns>
	ApiResponse<GetVoucherResponse> GetVoucherByIdWithHttpInfo(int? voucherId);

	/// <summary>
	///     Retrieve vouchers
	/// </summary>
	/// <remarks>
	///     There are a multitude of parameter which can be used to filter. A few of them are attached but      for a complete
	///     list please check out &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/How-to-filter-for-certain-vouchers
	///     &#x27;&gt;this&lt;/a&gt; list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="status">Status of the vouchers to retrieve. (optional)</param>
	/// <param name="creditDebit">Define if you only want credit or debit vouchers. (optional)</param>
	/// <param name="descriptionLike">Retrieve all vouchers with a description like this. (optional)</param>
	/// <param name="startDate">Retrieve all vouchers with a date equal or higher (optional)</param>
	/// <param name="endDate">Retrieve all vouchers with a date equal or lower (optional)</param>
	/// <param name="contactId">Retrieve all vouchers with this contact. Must be provided with contact[objectName] (optional)</param>
	/// <param name="contactObjectName">
	///     Only required if contact[id] was provided. &#x27;Contact&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <returns>GetVoucherResponse</returns>
	GetVoucherResponse GetVouchers(decimal? status = null, string creditDebit = null, string descriptionLike = null,
		int? startDate = null, int? endDate = null, int? contactId = null, string contactObjectName = null);

	/// <summary>
	///     Retrieve vouchers
	/// </summary>
	/// <remarks>
	///     There are a multitude of parameter which can be used to filter. A few of them are attached but      for a complete
	///     list please check out &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/How-to-filter-for-certain-vouchers
	///     &#x27;&gt;this&lt;/a&gt; list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="status">Status of the vouchers to retrieve. (optional)</param>
	/// <param name="creditDebit">Define if you only want credit or debit vouchers. (optional)</param>
	/// <param name="descriptionLike">Retrieve all vouchers with a description like this. (optional)</param>
	/// <param name="startDate">Retrieve all vouchers with a date equal or higher (optional)</param>
	/// <param name="endDate">Retrieve all vouchers with a date equal or lower (optional)</param>
	/// <param name="contactId">Retrieve all vouchers with this contact. Must be provided with contact[objectName] (optional)</param>
	/// <param name="contactObjectName">
	///     Only required if contact[id] was provided. &#x27;Contact&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <returns>ApiResponse of GetVoucherResponse</returns>
	ApiResponse<GetVoucherResponse> GetVouchersWithHttpInfo(decimal? status = null, string creditDebit = null,
		string descriptionLike = null, int? startDate = null, int? endDate = null, int? contactId = null,
		string contactObjectName = null);

	/// <summary>
	///     Update an existing voucher
	/// </summary>
	/// <remarks>
	///     Update a voucher
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="voucherId">ID of voucher to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>GetVoucherResponse</returns>
	GetVoucherResponse UpdateVoucher(int? voucherId, ModelVoucherUpdate body = null);

	/// <summary>
	///     Update an existing voucher
	/// </summary>
	/// <remarks>
	///     Update a voucher
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="voucherId">ID of voucher to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>ApiResponse of GetVoucherResponse</returns>
	ApiResponse<GetVoucherResponse> UpdateVoucherWithHttpInfo(int? voucherId, ModelVoucherUpdate body = null);

	/// <summary>
	///     Upload voucher file
	/// </summary>
	/// <remarks>
	///     To attach a document to a voucher, you will need to upload it first for later use.&lt;br&gt; To do this, you can
	///     use this request.&lt;br&gt; When you successfully uploaded the file, you will get a sevDesk internal filename in
	///     the response.&lt;br&gt; The filename will be a hash generated from your uploaded file. You will need it in the next
	///     request!&lt;br&gt; After you got the just mentioned filename, you can enter it as a value for the filename
	///     parameter of the saveVoucher request.&lt;br&gt; If you provided all necessary parameters and kept all of them in
	///     the right order, the file will be attached to your voucher.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">File to upload (optional)</param>
	/// <returns>InlineResponse2012</returns>
	InlineResponse2012 VoucherUploadFile(FactoryUploadTempFileBody body = null);

	/// <summary>
	///     Upload voucher file
	/// </summary>
	/// <remarks>
	///     To attach a document to a voucher, you will need to upload it first for later use.&lt;br&gt; To do this, you can
	///     use this request.&lt;br&gt; When you successfully uploaded the file, you will get a sevDesk internal filename in
	///     the response.&lt;br&gt; The filename will be a hash generated from your uploaded file. You will need it in the next
	///     request!&lt;br&gt; After you got the just mentioned filename, you can enter it as a value for the filename
	///     parameter of the saveVoucher request.&lt;br&gt; If you provided all necessary parameters and kept all of them in
	///     the right order, the file will be attached to your voucher.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">File to upload (optional)</param>
	/// <returns>ApiResponse of InlineResponse2012</returns>
	ApiResponse<InlineResponse2012> VoucherUploadFileWithHttpInfo(FactoryUploadTempFileBody body = null);

	#endregion Synchronous Operations

	#region Asynchronous Operations

	/// <summary>
	///     Book a voucher
	/// </summary>
	/// <remarks>
	///     Booking the voucher with a transaction is probably the most important part in the bookkeeping process.&lt;br&gt;
	///     There are several ways on correctly booking a voucher, all by using the same endpoint.&lt;br&gt; Conveniently, the
	///     booking process is exactly the same as the process for invoices.&lt;br&gt; For this reason, you can have a look at
	///     it &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/How-to-book-an-invoice&#x27;&gt;here&lt;/a&gt; and all you
	///     need to to is to change \&quot;Invoice\&quot; into \&quot;Voucher\&quot; in the URL.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="voucherId">ID of voucher to book</param>
	/// <param name="body">Booking data (optional)</param>
	/// <returns>Task of InlineResponse200</returns>
	Task<InlineResponse200> BookVoucherAsync(int? voucherId, VoucherIdBookAmountBody body = null);

	/// <summary>
	///     Book a voucher
	/// </summary>
	/// <remarks>
	///     Booking the voucher with a transaction is probably the most important part in the bookkeeping process.&lt;br&gt;
	///     There are several ways on correctly booking a voucher, all by using the same endpoint.&lt;br&gt; Conveniently, the
	///     booking process is exactly the same as the process for invoices.&lt;br&gt; For this reason, you can have a look at
	///     it &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/How-to-book-an-invoice&#x27;&gt;here&lt;/a&gt; and all you
	///     need to to is to change \&quot;Invoice\&quot; into \&quot;Voucher\&quot; in the URL.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="voucherId">ID of voucher to book</param>
	/// <param name="body">Booking data (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse200)</returns>
	Task<ApiResponse<InlineResponse200>> BookVoucherAsyncWithHttpInfo(int? voucherId,
		VoucherIdBookAmountBody body = null);

	/// <summary>
	///     Create a new voucher
	/// </summary>
	/// <remarks>
	///     Generally there are two ways to create vouchers.&lt;br&gt; You can create vouchers by either POSTing to the &lt;b
	///     &gt;Voucher&lt;/b&gt; and &lt;b&gt;VoucherPos&lt;/b&gt; endpoints with the necessary parameters (see attribute
	///     lists) or you can use a special endpoint which bundles the requests in one.&lt;br&gt; &lt;br&gt; The list of
	///     parameters starts with the voucher array.&lt;br&gt; This array contains all required attributes for a complete
	///     voucher.&lt;br&gt; Most of the attributes are covered in the voucher attribute list, there are only two parameters
	///     standing out, namely &lt;b&gt;mapAll&lt;/b&gt; and &lt;b&gt;objectName&lt;/b&gt;.&lt;br&gt; These are just needed
	///     for our system and you always need to provide them.&lt;br&gt;&lt;br&gt; The list of parameters then continues with
	///     the voucher position array.&lt;br&gt; With this array you have the possibility to add multiple positions at once.
	///     &lt;br&gt; In the example it only contains one position, again together with the parameters &lt;b&gt;mapAll&lt;/b
	///     &gt; and &lt;b&gt;objectName&lt;/b&gt;, however, you can add more voucher positions by extending the array.&lt;br
	///     &gt; So if you wanted to add another position, you would add the same list of parameters with an
	///     incrementedcomponents/schemas/saveVoucher\&quot; array index of \\\&quot;1\\\&quot; instead of \\\&quot;0\\\&quot;.
	///     &lt;br&gt;&lt;br&gt; The list ends with the two parameters voucherPosDelete and filename.&lt;br&gt; We will shortly
	///     explain what they can do.&lt;br&gt; With voucherPosDelete you have to option to delete voucher positions as this
	///     request can also be used to update vouchers.&lt;br&gt; With filename you can attach a file to the voucher.&lt;br
	///     &gt; For most of our customers this is a really important step, as they need to digitize their receipts.&lt;br&gt;
	///     Finally, after covering all parameters, they only important information left, is that the order of the last two
	///     attributes always needs to be kept.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">
	///     Creation data. Please be aware, that you need to provide at least all required parameter
	///     of the voucher and voucher position model! (optional)
	/// </param>
	/// <returns>Task of SaveVoucherResponse</returns>
	Task<SaveVoucherResponse> CreateVoucherByFactoryAsync(SaveVoucher body = null);

	/// <summary>
	///     Create a new voucher
	/// </summary>
	/// <remarks>
	///     Generally there are two ways to create vouchers.&lt;br&gt; You can create vouchers by either POSTing to the &lt;b
	///     &gt;Voucher&lt;/b&gt; and &lt;b&gt;VoucherPos&lt;/b&gt; endpoints with the necessary parameters (see attribute
	///     lists) or you can use a special endpoint which bundles the requests in one.&lt;br&gt; &lt;br&gt; The list of
	///     parameters starts with the voucher array.&lt;br&gt; This array contains all required attributes for a complete
	///     voucher.&lt;br&gt; Most of the attributes are covered in the voucher attribute list, there are only two parameters
	///     standing out, namely &lt;b&gt;mapAll&lt;/b&gt; and &lt;b&gt;objectName&lt;/b&gt;.&lt;br&gt; These are just needed
	///     for our system and you always need to provide them.&lt;br&gt;&lt;br&gt; The list of parameters then continues with
	///     the voucher position array.&lt;br&gt; With this array you have the possibility to add multiple positions at once.
	///     &lt;br&gt; In the example it only contains one position, again together with the parameters &lt;b&gt;mapAll&lt;/b
	///     &gt; and &lt;b&gt;objectName&lt;/b&gt;, however, you can add more voucher positions by extending the array.&lt;br
	///     &gt; So if you wanted to add another position, you would add the same list of parameters with an
	///     incrementedcomponents/schemas/saveVoucher\&quot; array index of \\\&quot;1\\\&quot; instead of \\\&quot;0\\\&quot;.
	///     &lt;br&gt;&lt;br&gt; The list ends with the two parameters voucherPosDelete and filename.&lt;br&gt; We will shortly
	///     explain what they can do.&lt;br&gt; With voucherPosDelete you have to option to delete voucher positions as this
	///     request can also be used to update vouchers.&lt;br&gt; With filename you can attach a file to the voucher.&lt;br
	///     &gt; For most of our customers this is a really important step, as they need to digitize their receipts.&lt;br&gt;
	///     Finally, after covering all parameters, they only important information left, is that the order of the last two
	///     attributes always needs to be kept.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">
	///     Creation data. Please be aware, that you need to provide at least all required parameter
	///     of the voucher and voucher position model! (optional)
	/// </param>
	/// <returns>Task of ApiResponse (SaveVoucherResponse)</returns>
	Task<ApiResponse<SaveVoucherResponse>> CreateVoucherByFactoryAsyncWithHttpInfo(SaveVoucher body = null);

	/// <summary>
	///     Find voucher by ID
	/// </summary>
	/// <remarks>
	///     Returns a single voucher
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="voucherId">ID of voucher to return</param>
	/// <returns>Task of GetVoucherResponse</returns>
	Task<GetVoucherResponse> GetVoucherByIdAsync(int? voucherId);

	/// <summary>
	///     Find voucher by ID
	/// </summary>
	/// <remarks>
	///     Returns a single voucher
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="voucherId">ID of voucher to return</param>
	/// <returns>Task of ApiResponse (GetVoucherResponse)</returns>
	Task<ApiResponse<GetVoucherResponse>> GetVoucherByIdAsyncWithHttpInfo(int? voucherId);

	/// <summary>
	///     Retrieve vouchers
	/// </summary>
	/// <remarks>
	///     There are a multitude of parameter which can be used to filter. A few of them are attached but      for a complete
	///     list please check out &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/How-to-filter-for-certain-vouchers
	///     &#x27;&gt;this&lt;/a&gt; list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="status">Status of the vouchers to retrieve. (optional)</param>
	/// <param name="creditDebit">Define if you only want credit or debit vouchers. (optional)</param>
	/// <param name="descriptionLike">Retrieve all vouchers with a description like this. (optional)</param>
	/// <param name="startDate">Retrieve all vouchers with a date equal or higher (optional)</param>
	/// <param name="endDate">Retrieve all vouchers with a date equal or lower (optional)</param>
	/// <param name="contactId">Retrieve all vouchers with this contact. Must be provided with contact[objectName] (optional)</param>
	/// <param name="contactObjectName">
	///     Only required if contact[id] was provided. &#x27;Contact&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <returns>Task of GetVoucherResponse</returns>
	Task<GetVoucherResponse> GetVouchersAsync(decimal? status = null, string creditDebit = null,
		string descriptionLike = null, int? startDate = null, int? endDate = null, int? contactId = null,
		string contactObjectName = null);

	/// <summary>
	///     Retrieve vouchers
	/// </summary>
	/// <remarks>
	///     There are a multitude of parameter which can be used to filter. A few of them are attached but      for a complete
	///     list please check out &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/How-to-filter-for-certain-vouchers
	///     &#x27;&gt;this&lt;/a&gt; list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="status">Status of the vouchers to retrieve. (optional)</param>
	/// <param name="creditDebit">Define if you only want credit or debit vouchers. (optional)</param>
	/// <param name="descriptionLike">Retrieve all vouchers with a description like this. (optional)</param>
	/// <param name="startDate">Retrieve all vouchers with a date equal or higher (optional)</param>
	/// <param name="endDate">Retrieve all vouchers with a date equal or lower (optional)</param>
	/// <param name="contactId">Retrieve all vouchers with this contact. Must be provided with contact[objectName] (optional)</param>
	/// <param name="contactObjectName">
	///     Only required if contact[id] was provided. &#x27;Contact&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <returns>Task of ApiResponse (GetVoucherResponse)</returns>
	Task<ApiResponse<GetVoucherResponse>> GetVouchersAsyncWithHttpInfo(decimal? status = null,
		string creditDebit = null, string descriptionLike = null, int? startDate = null, int? endDate = null,
		int? contactId = null, string contactObjectName = null);

	/// <summary>
	///     Update an existing voucher
	/// </summary>
	/// <remarks>
	///     Update a voucher
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="voucherId">ID of voucher to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>Task of GetVoucherResponse</returns>
	Task<GetSingleVoucherResponse> UpdateVoucherAsync(int? voucherId, ModelVoucherUpdate body = null);

	/// <summary>
	///     Update an existing voucher
	/// </summary>
	/// <remarks>
	///     Update a voucher
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="voucherId">ID of voucher to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>Task of ApiResponse (GetVoucherResponse)</returns>
	Task<ApiResponse<GetSingleVoucherResponse>> UpdateVoucherAsyncWithHttpInfo(int? voucherId,
		ModelVoucherUpdate body = null);

	/// <summary>
	///     Upload voucher file
	/// </summary>
	/// <remarks>
	///     To attach a document to a voucher, you will need to upload it first for later use.&lt;br&gt; To do this, you can
	///     use this request.&lt;br&gt; When you successfully uploaded the file, you will get a sevDesk internal filename in
	///     the response.&lt;br&gt; The filename will be a hash generated from your uploaded file. You will need it in the next
	///     request!&lt;br&gt; After you got the just mentioned filename, you can enter it as a value for the filename
	///     parameter of the saveVoucher request.&lt;br&gt; If you provided all necessary parameters and kept all of them in
	///     the right order, the file will be attached to your voucher.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">File to upload (optional)</param>
	/// <returns>Task of InlineResponse2012</returns>
	Task<InlineResponse2012> VoucherUploadFileAsync(FactoryUploadTempFileBody body = null);

	/// <summary>
	///     Upload voucher file
	/// </summary>
	/// <remarks>
	///     To attach a document to a voucher, you will need to upload it first for later use.&lt;br&gt; To do this, you can
	///     use this request.&lt;br&gt; When you successfully uploaded the file, you will get a sevDesk internal filename in
	///     the response.&lt;br&gt; The filename will be a hash generated from your uploaded file. You will need it in the next
	///     request!&lt;br&gt; After you got the just mentioned filename, you can enter it as a value for the filename
	///     parameter of the saveVoucher request.&lt;br&gt; If you provided all necessary parameters and kept all of them in
	///     the right order, the file will be attached to your voucher.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">File to upload (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse2012)</returns>
	Task<ApiResponse<InlineResponse2012>> VoucherUploadFileAsyncWithHttpInfo(FactoryUploadTempFileBody body = null);

	#endregion Asynchronous Operations
}