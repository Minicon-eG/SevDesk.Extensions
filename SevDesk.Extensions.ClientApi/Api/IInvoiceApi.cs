using SevDesk.Extensions.ClientApi.Client;
using SevDesk.Extensions.ClientApi.Model;

namespace SevDesk.Extensions.ClientApi.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IInvoiceApi : IApiAccessor
{
	#region Synchronous Operations

	/// <summary>
	///     Book an invoice
	/// </summary>
	/// <remarks>
	///     Booking the invoice with a transaction is probably the most important part in the bookkeeping process.&lt;br&gt;
	///     There are several ways on correctly booking an invoice, all by using the same endpoint.&lt;br&gt; for more
	///     information look &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/How-to-book-an-invoice&#x27;&gt;here&lt;/a
	///     &gt;.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to book</param>
	/// <param name="body">Booking data (optional)</param>
	/// <returns>InlineResponse2008</returns>
	InlineResponse2008 BookInvoice(int? invoiceId, InvoiceIdBookAmountBody body = null);

	/// <summary>
	///     Book an invoice
	/// </summary>
	/// <remarks>
	///     Booking the invoice with a transaction is probably the most important part in the bookkeeping process.&lt;br&gt;
	///     There are several ways on correctly booking an invoice, all by using the same endpoint.&lt;br&gt; for more
	///     information look &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/How-to-book-an-invoice&#x27;&gt;here&lt;/a
	///     &gt;.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to book</param>
	/// <param name="body">Booking data (optional)</param>
	/// <returns>ApiResponse of InlineResponse2008</returns>
	ApiResponse<InlineResponse2008> BookInvoiceWithHttpInfo(int? invoiceId, InvoiceIdBookAmountBody body = null);

	/// <summary>
	///     Cancel an invoice / Create cancellation invoice
	/// </summary>
	/// <remarks>
	///     This endpoint will cancel the specified invoice therefor creating a cancellation invoice.&lt;br&gt;       The
	///     cancellation invoice will be automatically paid and the source invoices status will change to &#x27;cancelled&#x27;
	///     .
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to be cancelled</param>
	/// <returns>GetInvoicesResponse</returns>
	GetInvoicesResponse CancelInvoice(int? invoiceId);

	/// <summary>
	///     Cancel an invoice / Create cancellation invoice
	/// </summary>
	/// <remarks>
	///     This endpoint will cancel the specified invoice therefor creating a cancellation invoice.&lt;br&gt;       The
	///     cancellation invoice will be automatically paid and the source invoices status will change to &#x27;cancelled&#x27;
	///     .
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to be cancelled</param>
	/// <returns>ApiResponse of GetInvoicesResponse</returns>
	ApiResponse<GetInvoicesResponse> CancelInvoiceWithHttpInfo(int? invoiceId);

	/// <summary>
	///     Create a new invoice
	/// </summary>
	/// <remarks>
	///     This endpoint offers you the following functionality.       &lt;ul&gt;          &lt;li&gt;Create invoices together
	///     with positions and discounts&lt;/li&gt;          &lt;li&gt;Delete positions while adding new ones&lt;/li&gt;
	///     &lt;li&gt;Delete or add discounts, or both at the same time&lt;/li&gt;          &lt;li&gt;Automatically fill the
	///     address of the supplied contact into the invoice address&lt;/li&gt;       &lt;/ul&gt;       To make your own
	///     request sample slimmer, you can omit all parameters which are not required and nullable.       However, for a valid
	///     and logical bookkeeping document, you will also need some of them to ensure that all the necessary data is in the
	///     invoice.&lt;br&gt;&lt;br&gt; The list of parameters starts with the invoice array.&lt;br&gt; This array contains
	///     all required attributes for a complete invoice.&lt;br&gt; Most of the attributes are covered in the invoice
	///     attribute list, there are only two parameters standing out, namely &lt;b&gt;mapAll&lt;/b&gt; and &lt;b&gt;
	///     objectName&lt;/b&gt;.&lt;br&gt; These are just needed for our system and you always need to provide them.&lt;br&gt;
	///     &lt;br&gt; The list of parameters then continues with the invoice position array.&lt;br&gt; With this array you
	///     have the possibility to add multiple positions at once.&lt;br&gt; In the example it only contains one position,
	///     again together with the parameters &lt;b&gt;mapAll&lt;/b&gt; and &lt;b&gt;objectName&lt;/b&gt;, however, you can
	///     add more invoice positions by extending the array.&lt;br&gt; So if you wanted to add another position, you would
	///     add the same list of parameters with an incremented array index of \&quot;1\&quot; instead of \&quot;0\&quot;.&lt;
	///     br&gt;&lt;br&gt; The list ends with the four parameters invoicePosDelete, discountSave, discountDelete and
	///     takeDefaultAddress.&lt;br&gt; They only play a minor role if you only want to create an invoice but we will shortly
	///     explain what they can do.&lt;br&gt; With invoicePosDelete you have to option to delete invoice positions as this
	///     request can also be used to update invoices.&lt;br&gt; With discountSave you can add discounts to your invoice.&lt;
	///     br&gt; With discountDelete you can delete discounts from your invoice.&lt;br&gt; With takeDefaultAddress you can
	///     specify that the first address of the contact you are using for the invoice is taken for the invoice address
	///     attribute automatically, so you don&#x27;t need to provide the address yourself.&lt;br&gt; If you want to know more
	///     about these parameters, for example if you want to use this request to update invoices, feel free to contact our
	///     support.&lt;br&gt;&lt;br&gt; Finally, after covering all parameters, they only important information left, is that
	///     the order of the last four attributes always needs to be kept.&lt;br&gt; You will also always need to provide all
	///     of them, as otherwise the request won&#x27;t work properly.&lt;br&gt;&lt;br&gt; &lt;b&gt;Warning\&quot;:\&quot;&lt;
	///     /b&gt; You can not create a regular invoice with the &lt;b&gt;deliveryDate&lt;/b&gt; being later than the &lt;b&gt;
	///     invoiceDate&lt;/b&gt;.&lt;br&gt; To do that you will need to create a so called &lt;b&gt;Abschlagsrechnung&lt;/b
	///     &gt; by setting the &lt;b&gt;invoiceType&lt;/b&gt; parameter to &lt;b&gt;AR&lt;/b&gt;.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">
	///     Creation data. Please be aware, that you need to provide at least all required parameter
	///     of the invoice model! (optional)
	/// </param>
	/// <returns>SaveInvoiceResponse</returns>
	SaveInvoiceResponse CreateInvoiceByFactory(SaveInvoice body = null);

	/// <summary>
	///     Create a new invoice
	/// </summary>
	/// <remarks>
	///     This endpoint offers you the following functionality.       &lt;ul&gt;          &lt;li&gt;Create invoices together
	///     with positions and discounts&lt;/li&gt;          &lt;li&gt;Delete positions while adding new ones&lt;/li&gt;
	///     &lt;li&gt;Delete or add discounts, or both at the same time&lt;/li&gt;          &lt;li&gt;Automatically fill the
	///     address of the supplied contact into the invoice address&lt;/li&gt;       &lt;/ul&gt;       To make your own
	///     request sample slimmer, you can omit all parameters which are not required and nullable.       However, for a valid
	///     and logical bookkeeping document, you will also need some of them to ensure that all the necessary data is in the
	///     invoice.&lt;br&gt;&lt;br&gt; The list of parameters starts with the invoice array.&lt;br&gt; This array contains
	///     all required attributes for a complete invoice.&lt;br&gt; Most of the attributes are covered in the invoice
	///     attribute list, there are only two parameters standing out, namely &lt;b&gt;mapAll&lt;/b&gt; and &lt;b&gt;
	///     objectName&lt;/b&gt;.&lt;br&gt; These are just needed for our system and you always need to provide them.&lt;br&gt;
	///     &lt;br&gt; The list of parameters then continues with the invoice position array.&lt;br&gt; With this array you
	///     have the possibility to add multiple positions at once.&lt;br&gt; In the example it only contains one position,
	///     again together with the parameters &lt;b&gt;mapAll&lt;/b&gt; and &lt;b&gt;objectName&lt;/b&gt;, however, you can
	///     add more invoice positions by extending the array.&lt;br&gt; So if you wanted to add another position, you would
	///     add the same list of parameters with an incremented array index of \&quot;1\&quot; instead of \&quot;0\&quot;.&lt;
	///     br&gt;&lt;br&gt; The list ends with the four parameters invoicePosDelete, discountSave, discountDelete and
	///     takeDefaultAddress.&lt;br&gt; They only play a minor role if you only want to create an invoice but we will shortly
	///     explain what they can do.&lt;br&gt; With invoicePosDelete you have to option to delete invoice positions as this
	///     request can also be used to update invoices.&lt;br&gt; With discountSave you can add discounts to your invoice.&lt;
	///     br&gt; With discountDelete you can delete discounts from your invoice.&lt;br&gt; With takeDefaultAddress you can
	///     specify that the first address of the contact you are using for the invoice is taken for the invoice address
	///     attribute automatically, so you don&#x27;t need to provide the address yourself.&lt;br&gt; If you want to know more
	///     about these parameters, for example if you want to use this request to update invoices, feel free to contact our
	///     support.&lt;br&gt;&lt;br&gt; Finally, after covering all parameters, they only important information left, is that
	///     the order of the last four attributes always needs to be kept.&lt;br&gt; You will also always need to provide all
	///     of them, as otherwise the request won&#x27;t work properly.&lt;br&gt;&lt;br&gt; &lt;b&gt;Warning\&quot;:\&quot;&lt;
	///     /b&gt; You can not create a regular invoice with the &lt;b&gt;deliveryDate&lt;/b&gt; being later than the &lt;b&gt;
	///     invoiceDate&lt;/b&gt;.&lt;br&gt; To do that you will need to create a so called &lt;b&gt;Abschlagsrechnung&lt;/b
	///     &gt; by setting the &lt;b&gt;invoiceType&lt;/b&gt; parameter to &lt;b&gt;AR&lt;/b&gt;.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">
	///     Creation data. Please be aware, that you need to provide at least all required parameter
	///     of the invoice model! (optional)
	/// </param>
	/// <returns>ApiResponse of SaveInvoiceResponse</returns>
	ApiResponse<SaveInvoiceResponse> CreateInvoiceByFactoryWithHttpInfo(SaveInvoice body = null);

	/// <summary>
	///     Create invoice from order
	/// </summary>
	/// <remarks>
	///     Create an invoice from an order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">the id of the invoice</param>
	/// <param name="invoiceObjectName">Model name, which is &#x27;Invoice&#x27;</param>
	/// <param name="body">Create invoice (optional)</param>
	/// <returns>GetInvoicesResponse</returns>
	GetInvoicesResponse CreateInvoiceFromOrder(int? invoiceId, string invoiceObjectName,
		ModelCreateInvoiceFromOrder body = null);

	/// <summary>
	///     Create invoice from order
	/// </summary>
	/// <remarks>
	///     Create an invoice from an order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">the id of the invoice</param>
	/// <param name="invoiceObjectName">Model name, which is &#x27;Invoice&#x27;</param>
	/// <param name="body">Create invoice (optional)</param>
	/// <returns>ApiResponse of GetInvoicesResponse</returns>
	ApiResponse<GetInvoicesResponse> CreateInvoiceFromOrderWithHttpInfo(int? invoiceId, string invoiceObjectName,
		ModelCreateInvoiceFromOrder body = null);

	/// <summary>
	///     Create invoice reminder
	/// </summary>
	/// <remarks>
	///     Create an reminder from an invoice
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">the id of the invoice</param>
	/// <param name="invoiceObjectName">Model name, which is &#x27;Invoice&#x27;</param>
	/// <param name="body">Create invoice (optional)</param>
	/// <returns>GetInvoicesResponse</returns>
	GetInvoicesResponse CreateInvoiceReminder(int? invoiceId, string invoiceObjectName,
		FactoryCreateInvoiceReminderBody body = null);

	/// <summary>
	///     Create invoice reminder
	/// </summary>
	/// <remarks>
	///     Create an reminder from an invoice
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">the id of the invoice</param>
	/// <param name="invoiceObjectName">Model name, which is &#x27;Invoice&#x27;</param>
	/// <param name="body">Create invoice (optional)</param>
	/// <returns>ApiResponse of GetInvoicesResponse</returns>
	ApiResponse<GetInvoicesResponse> CreateInvoiceReminderWithHttpInfo(int? invoiceId, string invoiceObjectName,
		FactoryCreateInvoiceReminderBody body = null);

	/// <summary>
	///     Find invoice by ID
	/// </summary>
	/// <remarks>
	///     Returns a single invoice
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to return</param>
	/// <returns>GetInvoicesResponse</returns>
	GetInvoicesResponse GetInvoiceById(int? invoiceId);

	/// <summary>
	///     Find invoice by ID
	/// </summary>
	/// <remarks>
	///     Returns a single invoice
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to return</param>
	/// <returns>ApiResponse of GetInvoicesResponse</returns>
	ApiResponse<GetInvoicesResponse> GetInvoiceByIdWithHttpInfo(int? invoiceId);

	/// <summary>
	///     Find invoice positions
	/// </summary>
	/// <remarks>
	///     Returns all positions of an invoice
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to return the positions</param>
	/// <param name="limit">limits the number of entries returned (optional)</param>
	/// <param name="offset">set the index where the returned entries start (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>InlineResponse20022</returns>
	InlineResponse20022 GetInvoicePositionsById(int? invoiceId, int? limit = null, int? offset = null,
		List<string> embed = null);

	/// <summary>
	///     Find invoice positions
	/// </summary>
	/// <remarks>
	///     Returns all positions of an invoice
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to return the positions</param>
	/// <param name="limit">limits the number of entries returned (optional)</param>
	/// <param name="offset">set the index where the returned entries start (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>ApiResponse of InlineResponse20022</returns>
	ApiResponse<InlineResponse20022> GetInvoicePositionsByIdWithHttpInfo(int? invoiceId, int? limit = null,
		int? offset = null, List<string> embed = null);

	/// <summary>
	///     Retrieve invoices
	/// </summary>
	/// <remarks>
	///     There are a multitude of parameter which can be used to filter. A few of them are attached but       for a complete
	///     list please check out &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/How-to-filter-for-certain-invoices
	///     &#x27;&gt;this&lt;/a&gt; list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="status">Status of the invoices (optional)</param>
	/// <param name="invoiceNumber">Retrieve all invoices with this invoice number (optional)</param>
	/// <param name="startDate">Retrieve all invoices with a date equal or higher (optional)</param>
	/// <param name="endDate">Retrieve all invoices with a date equal or lower (optional)</param>
	/// <param name="contactId">Retrieve all invoices with this contact. Must be provided with contact[objectName] (optional)</param>
	/// <param name="contactObjectName">
	///     Only required if contact[id] was provided. &#x27;Contact&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <returns>GetInvoicesResponse</returns>
	GetInvoicesResponse GetInvoices(decimal? status = null, string invoiceNumber = null, int? startDate = null,
		int? endDate = null, int? contactId = null, string contactObjectName = null);

	/// <summary>
	///     Retrieve invoices
	/// </summary>
	/// <remarks>
	///     There are a multitude of parameter which can be used to filter. A few of them are attached but       for a complete
	///     list please check out &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/How-to-filter-for-certain-invoices
	///     &#x27;&gt;this&lt;/a&gt; list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="status">Status of the invoices (optional)</param>
	/// <param name="invoiceNumber">Retrieve all invoices with this invoice number (optional)</param>
	/// <param name="startDate">Retrieve all invoices with a date equal or higher (optional)</param>
	/// <param name="endDate">Retrieve all invoices with a date equal or lower (optional)</param>
	/// <param name="contactId">Retrieve all invoices with this contact. Must be provided with contact[objectName] (optional)</param>
	/// <param name="contactObjectName">
	///     Only required if contact[id] was provided. &#x27;Contact&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <returns>ApiResponse of GetInvoicesResponse</returns>
	ApiResponse<GetInvoicesResponse> GetInvoicesWithHttpInfo(decimal? status = null, string invoiceNumber = null,
		int? startDate = null, int? endDate = null, int? contactId = null, string contactObjectName = null);

	/// <summary>
	///     Check if an invoice is already partially paid
	/// </summary>
	/// <remarks>
	///     Returns &#x27;true&#x27; if the given invoice is partially paid - &#x27;false&#x27; if it is not.      Invoices
	///     which are completely paid are regarded as not partially paid.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to return</param>
	/// <returns>InlineResponse20011</returns>
	InlineResponse20011 GetIsInvoicePartiallyPaid(int? invoiceId);

	/// <summary>
	///     Check if an invoice is already partially paid
	/// </summary>
	/// <remarks>
	///     Returns &#x27;true&#x27; if the given invoice is partially paid - &#x27;false&#x27; if it is not.      Invoices
	///     which are completely paid are regarded as not partially paid.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to return</param>
	/// <returns>ApiResponse of InlineResponse20011</returns>
	ApiResponse<InlineResponse20011> GetIsInvoicePartiallyPaidWithHttpInfo(int? invoiceId);

	/// <summary>
	///     Retrieve pdf document of an invoice
	/// </summary>
	/// <remarks>
	///     Retrieves the pdf document of an invoice with additional metadata.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice from which you want the pdf</param>
	/// <param name="download">If u want to download the pdf of the invoice. (optional)</param>
	/// <param name="preventSendBy">Defines if u want to send the invoice. (optional)</param>
	/// <returns>CreditNoteGetPdfResponse</returns>
	CreditNoteGetPdfResponse InvoiceGetPdf(int? invoiceId, bool? download = null, bool? preventSendBy = null);

	/// <summary>
	///     Retrieve pdf document of an invoice
	/// </summary>
	/// <remarks>
	///     Retrieves the pdf document of an invoice with additional metadata.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice from which you want the pdf</param>
	/// <param name="download">If u want to download the pdf of the invoice. (optional)</param>
	/// <param name="preventSendBy">Defines if u want to send the invoice. (optional)</param>
	/// <returns>ApiResponse of CreditNoteGetPdfResponse</returns>
	ApiResponse<CreditNoteGetPdfResponse> InvoiceGetPdfWithHttpInfo(int? invoiceId, bool? download = null,
		bool? preventSendBy = null);

	/// <summary>
	///     Render the pdf document of an invoice
	/// </summary>
	/// <remarks>
	///     Using this endpoint you can render the pdf document of an invoice.&lt;br&gt;       Use cases for this are the
	///     retrieval of the pdf location or the forceful re-render of a already sent invoice.&lt;br&gt;       Please be aware
	///     that changing an invoice after it has been sent to a customer is not an allowed bookkeeping process.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to render</param>
	/// <param name="body">Define if the document should be forcefully re-rendered. (optional)</param>
	/// <returns>InlineResponse2011</returns>
	InlineResponse2011 InvoiceRender(int? invoiceId, InvoiceIdRenderBody body = null);

	/// <summary>
	///     Render the pdf document of an invoice
	/// </summary>
	/// <remarks>
	///     Using this endpoint you can render the pdf document of an invoice.&lt;br&gt;       Use cases for this are the
	///     retrieval of the pdf location or the forceful re-render of a already sent invoice.&lt;br&gt;       Please be aware
	///     that changing an invoice after it has been sent to a customer is not an allowed bookkeeping process.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to render</param>
	/// <param name="body">Define if the document should be forcefully re-rendered. (optional)</param>
	/// <returns>ApiResponse of InlineResponse2011</returns>
	ApiResponse<InlineResponse2011> InvoiceRenderWithHttpInfo(int? invoiceId, InvoiceIdRenderBody body = null);

	/// <summary>
	///     Mark invoice as sent
	/// </summary>
	/// <remarks>
	///     Marks an invoice as sent by a chosen send type.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to mark as sent</param>
	/// <param name="body">Specify the send type (optional)</param>
	/// <returns>InlineResponse20029</returns>
	InlineResponse20029 InvoiceSendBy(int? invoiceId, InvoiceIdSendByBody body = null);

	/// <summary>
	///     Mark invoice as sent
	/// </summary>
	/// <remarks>
	///     Marks an invoice as sent by a chosen send type.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to mark as sent</param>
	/// <param name="body">Specify the send type (optional)</param>
	/// <returns>ApiResponse of InlineResponse20029</returns>
	ApiResponse<InlineResponse20029> InvoiceSendByWithHttpInfo(int? invoiceId, InvoiceIdSendByBody body = null);

	/// <summary>
	///     Send invoice via email
	/// </summary>
	/// <remarks>
	///     This endpoint sends the specified invoice to a customer via email.&lt;br&gt;      This will automatically mark the
	///     invoice as sent.&lt;br&gt;      Please note, that in production an invoice is not allowed to be changed after this
	///     happened!
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to be sent via email</param>
	/// <param name="body">Mail data (optional)</param>
	/// <returns>InlineResponse201</returns>
	InlineResponse201 SendInvoiceViaEMail(int? invoiceId, InvoiceIdSendViaEmailBody body = null);

	/// <summary>
	///     Send invoice via email
	/// </summary>
	/// <remarks>
	///     This endpoint sends the specified invoice to a customer via email.&lt;br&gt;      This will automatically mark the
	///     invoice as sent.&lt;br&gt;      Please note, that in production an invoice is not allowed to be changed after this
	///     happened!
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to be sent via email</param>
	/// <param name="body">Mail data (optional)</param>
	/// <returns>ApiResponse of InlineResponse201</returns>
	ApiResponse<InlineResponse201> SendInvoiceViaEMailWithHttpInfo(int? invoiceId,
		InvoiceIdSendViaEmailBody body = null);

	#endregion Synchronous Operations

	#region Asynchronous Operations

	/// <summary>
	///     Book an invoice
	/// </summary>
	/// <remarks>
	///     Booking the invoice with a transaction is probably the most important part in the bookkeeping process.&lt;br&gt;
	///     There are several ways on correctly booking an invoice, all by using the same endpoint.&lt;br&gt; for more
	///     information look &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/How-to-book-an-invoice&#x27;&gt;here&lt;/a
	///     &gt;.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to book</param>
	/// <param name="body">Booking data (optional)</param>
	/// <returns>Task of InlineResponse2008</returns>
	Task<InlineResponse2008> BookInvoiceAsync(int? invoiceId, InvoiceIdBookAmountBody body = null);

	/// <summary>
	///     Book an invoice
	/// </summary>
	/// <remarks>
	///     Booking the invoice with a transaction is probably the most important part in the bookkeeping process.&lt;br&gt;
	///     There are several ways on correctly booking an invoice, all by using the same endpoint.&lt;br&gt; for more
	///     information look &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/How-to-book-an-invoice&#x27;&gt;here&lt;/a
	///     &gt;.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to book</param>
	/// <param name="body">Booking data (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse2008)</returns>
	Task<ApiResponse<InlineResponse2008>> BookInvoiceAsyncWithHttpInfo(int? invoiceId,
		InvoiceIdBookAmountBody body = null);

	/// <summary>
	///     Cancel an invoice / Create cancellation invoice
	/// </summary>
	/// <remarks>
	///     This endpoint will cancel the specified invoice therefor creating a cancellation invoice.&lt;br&gt;       The
	///     cancellation invoice will be automatically paid and the source invoices status will change to &#x27;cancelled&#x27;
	///     .
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to be cancelled</param>
	/// <returns>Task of GetInvoicesResponse</returns>
	Task<GetInvoicesResponse> CancelInvoiceAsync(int? invoiceId);

	/// <summary>
	///     Cancel an invoice / Create cancellation invoice
	/// </summary>
	/// <remarks>
	///     This endpoint will cancel the specified invoice therefor creating a cancellation invoice.&lt;br&gt;       The
	///     cancellation invoice will be automatically paid and the source invoices status will change to &#x27;cancelled&#x27;
	///     .
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to be cancelled</param>
	/// <returns>Task of ApiResponse (GetInvoicesResponse)</returns>
	Task<ApiResponse<GetInvoicesResponse>> CancelInvoiceAsyncWithHttpInfo(int? invoiceId);

	/// <summary>
	///     Create a new invoice
	/// </summary>
	/// <remarks>
	///     This endpoint offers you the following functionality.       &lt;ul&gt;          &lt;li&gt;Create invoices together
	///     with positions and discounts&lt;/li&gt;          &lt;li&gt;Delete positions while adding new ones&lt;/li&gt;
	///     &lt;li&gt;Delete or add discounts, or both at the same time&lt;/li&gt;          &lt;li&gt;Automatically fill the
	///     address of the supplied contact into the invoice address&lt;/li&gt;       &lt;/ul&gt;       To make your own
	///     request sample slimmer, you can omit all parameters which are not required and nullable.       However, for a valid
	///     and logical bookkeeping document, you will also need some of them to ensure that all the necessary data is in the
	///     invoice.&lt;br&gt;&lt;br&gt; The list of parameters starts with the invoice array.&lt;br&gt; This array contains
	///     all required attributes for a complete invoice.&lt;br&gt; Most of the attributes are covered in the invoice
	///     attribute list, there are only two parameters standing out, namely &lt;b&gt;mapAll&lt;/b&gt; and &lt;b&gt;
	///     objectName&lt;/b&gt;.&lt;br&gt; These are just needed for our system and you always need to provide them.&lt;br&gt;
	///     &lt;br&gt; The list of parameters then continues with the invoice position array.&lt;br&gt; With this array you
	///     have the possibility to add multiple positions at once.&lt;br&gt; In the example it only contains one position,
	///     again together with the parameters &lt;b&gt;mapAll&lt;/b&gt; and &lt;b&gt;objectName&lt;/b&gt;, however, you can
	///     add more invoice positions by extending the array.&lt;br&gt; So if you wanted to add another position, you would
	///     add the same list of parameters with an incremented array index of \&quot;1\&quot; instead of \&quot;0\&quot;.&lt;
	///     br&gt;&lt;br&gt; The list ends with the four parameters invoicePosDelete, discountSave, discountDelete and
	///     takeDefaultAddress.&lt;br&gt; They only play a minor role if you only want to create an invoice but we will shortly
	///     explain what they can do.&lt;br&gt; With invoicePosDelete you have to option to delete invoice positions as this
	///     request can also be used to update invoices.&lt;br&gt; With discountSave you can add discounts to your invoice.&lt;
	///     br&gt; With discountDelete you can delete discounts from your invoice.&lt;br&gt; With takeDefaultAddress you can
	///     specify that the first address of the contact you are using for the invoice is taken for the invoice address
	///     attribute automatically, so you don&#x27;t need to provide the address yourself.&lt;br&gt; If you want to know more
	///     about these parameters, for example if you want to use this request to update invoices, feel free to contact our
	///     support.&lt;br&gt;&lt;br&gt; Finally, after covering all parameters, they only important information left, is that
	///     the order of the last four attributes always needs to be kept.&lt;br&gt; You will also always need to provide all
	///     of them, as otherwise the request won&#x27;t work properly.&lt;br&gt;&lt;br&gt; &lt;b&gt;Warning\&quot;:\&quot;&lt;
	///     /b&gt; You can not create a regular invoice with the &lt;b&gt;deliveryDate&lt;/b&gt; being later than the &lt;b&gt;
	///     invoiceDate&lt;/b&gt;.&lt;br&gt; To do that you will need to create a so called &lt;b&gt;Abschlagsrechnung&lt;/b
	///     &gt; by setting the &lt;b&gt;invoiceType&lt;/b&gt; parameter to &lt;b&gt;AR&lt;/b&gt;.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">
	///     Creation data. Please be aware, that you need to provide at least all required parameter
	///     of the invoice model! (optional)
	/// </param>
	/// <returns>Task of SaveInvoiceResponse</returns>
	Task<SaveInvoiceResponse> CreateInvoiceByFactoryAsync(SaveInvoice body = null);

	/// <summary>
	///     Create a new invoice
	/// </summary>
	/// <remarks>
	///     This endpoint offers you the following functionality.       &lt;ul&gt;          &lt;li&gt;Create invoices together
	///     with positions and discounts&lt;/li&gt;          &lt;li&gt;Delete positions while adding new ones&lt;/li&gt;
	///     &lt;li&gt;Delete or add discounts, or both at the same time&lt;/li&gt;          &lt;li&gt;Automatically fill the
	///     address of the supplied contact into the invoice address&lt;/li&gt;       &lt;/ul&gt;       To make your own
	///     request sample slimmer, you can omit all parameters which are not required and nullable.       However, for a valid
	///     and logical bookkeeping document, you will also need some of them to ensure that all the necessary data is in the
	///     invoice.&lt;br&gt;&lt;br&gt; The list of parameters starts with the invoice array.&lt;br&gt; This array contains
	///     all required attributes for a complete invoice.&lt;br&gt; Most of the attributes are covered in the invoice
	///     attribute list, there are only two parameters standing out, namely &lt;b&gt;mapAll&lt;/b&gt; and &lt;b&gt;
	///     objectName&lt;/b&gt;.&lt;br&gt; These are just needed for our system and you always need to provide them.&lt;br&gt;
	///     &lt;br&gt; The list of parameters then continues with the invoice position array.&lt;br&gt; With this array you
	///     have the possibility to add multiple positions at once.&lt;br&gt; In the example it only contains one position,
	///     again together with the parameters &lt;b&gt;mapAll&lt;/b&gt; and &lt;b&gt;objectName&lt;/b&gt;, however, you can
	///     add more invoice positions by extending the array.&lt;br&gt; So if you wanted to add another position, you would
	///     add the same list of parameters with an incremented array index of \&quot;1\&quot; instead of \&quot;0\&quot;.&lt;
	///     br&gt;&lt;br&gt; The list ends with the four parameters invoicePosDelete, discountSave, discountDelete and
	///     takeDefaultAddress.&lt;br&gt; They only play a minor role if you only want to create an invoice but we will shortly
	///     explain what they can do.&lt;br&gt; With invoicePosDelete you have to option to delete invoice positions as this
	///     request can also be used to update invoices.&lt;br&gt; With discountSave you can add discounts to your invoice.&lt;
	///     br&gt; With discountDelete you can delete discounts from your invoice.&lt;br&gt; With takeDefaultAddress you can
	///     specify that the first address of the contact you are using for the invoice is taken for the invoice address
	///     attribute automatically, so you don&#x27;t need to provide the address yourself.&lt;br&gt; If you want to know more
	///     about these parameters, for example if you want to use this request to update invoices, feel free to contact our
	///     support.&lt;br&gt;&lt;br&gt; Finally, after covering all parameters, they only important information left, is that
	///     the order of the last four attributes always needs to be kept.&lt;br&gt; You will also always need to provide all
	///     of them, as otherwise the request won&#x27;t work properly.&lt;br&gt;&lt;br&gt; &lt;b&gt;Warning\&quot;:\&quot;&lt;
	///     /b&gt; You can not create a regular invoice with the &lt;b&gt;deliveryDate&lt;/b&gt; being later than the &lt;b&gt;
	///     invoiceDate&lt;/b&gt;.&lt;br&gt; To do that you will need to create a so called &lt;b&gt;Abschlagsrechnung&lt;/b
	///     &gt; by setting the &lt;b&gt;invoiceType&lt;/b&gt; parameter to &lt;b&gt;AR&lt;/b&gt;.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">
	///     Creation data. Please be aware, that you need to provide at least all required parameter
	///     of the invoice model! (optional)
	/// </param>
	/// <returns>Task of ApiResponse (SaveInvoiceResponse)</returns>
	Task<ApiResponse<SaveInvoiceResponse>> CreateInvoiceByFactoryAsyncWithHttpInfo(SaveInvoice body = null);

	/// <summary>
	///     Create invoice from order
	/// </summary>
	/// <remarks>
	///     Create an invoice from an order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">the id of the invoice</param>
	/// <param name="invoiceObjectName">Model name, which is &#x27;Invoice&#x27;</param>
	/// <param name="body">Create invoice (optional)</param>
	/// <returns>Task of GetInvoicesResponse</returns>
	Task<GetInvoicesResponse> CreateInvoiceFromOrderAsync(int? invoiceId, string invoiceObjectName,
		ModelCreateInvoiceFromOrder body = null);

	/// <summary>
	///     Create invoice from order
	/// </summary>
	/// <remarks>
	///     Create an invoice from an order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">the id of the invoice</param>
	/// <param name="invoiceObjectName">Model name, which is &#x27;Invoice&#x27;</param>
	/// <param name="body">Create invoice (optional)</param>
	/// <returns>Task of ApiResponse (GetInvoicesResponse)</returns>
	Task<ApiResponse<GetInvoicesResponse>> CreateInvoiceFromOrderAsyncWithHttpInfo(int? invoiceId,
		string invoiceObjectName, ModelCreateInvoiceFromOrder body = null);

	/// <summary>
	///     Create invoice reminder
	/// </summary>
	/// <remarks>
	///     Create an reminder from an invoice
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">the id of the invoice</param>
	/// <param name="invoiceObjectName">Model name, which is &#x27;Invoice&#x27;</param>
	/// <param name="body">Create invoice (optional)</param>
	/// <returns>Task of GetInvoicesResponse</returns>
	Task<GetInvoicesResponse> CreateInvoiceReminderAsync(int? invoiceId, string invoiceObjectName,
		FactoryCreateInvoiceReminderBody body = null);

	/// <summary>
	///     Create invoice reminder
	/// </summary>
	/// <remarks>
	///     Create an reminder from an invoice
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">the id of the invoice</param>
	/// <param name="invoiceObjectName">Model name, which is &#x27;Invoice&#x27;</param>
	/// <param name="body">Create invoice (optional)</param>
	/// <returns>Task of ApiResponse (GetInvoicesResponse)</returns>
	Task<ApiResponse<GetInvoicesResponse>> CreateInvoiceReminderAsyncWithHttpInfo(int? invoiceId,
		string invoiceObjectName, FactoryCreateInvoiceReminderBody body = null);

	/// <summary>
	///     Find invoice by ID
	/// </summary>
	/// <remarks>
	///     Returns a single invoice
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to return</param>
	/// <returns>Task of GetInvoicesResponse</returns>
	Task<GetInvoicesResponse> GetInvoiceByIdAsync(int? invoiceId);

	/// <summary>
	///     Find invoice by ID
	/// </summary>
	/// <remarks>
	///     Returns a single invoice
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to return</param>
	/// <returns>Task of ApiResponse (GetInvoicesResponse)</returns>
	Task<ApiResponse<GetInvoicesResponse>> GetInvoiceByIdAsyncWithHttpInfo(int? invoiceId);

	/// <summary>
	///     Find invoice positions
	/// </summary>
	/// <remarks>
	///     Returns all positions of an invoice
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to return the positions</param>
	/// <param name="limit">limits the number of entries returned (optional)</param>
	/// <param name="offset">set the index where the returned entries start (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>Task of InlineResponse20022</returns>
	Task<InlineResponse20022> GetInvoicePositionsByIdAsync(int? invoiceId, int? limit = null, int? offset = null,
		List<string> embed = null);

	/// <summary>
	///     Find invoice positions
	/// </summary>
	/// <remarks>
	///     Returns all positions of an invoice
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to return the positions</param>
	/// <param name="limit">limits the number of entries returned (optional)</param>
	/// <param name="offset">set the index where the returned entries start (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>Task of ApiResponse (InlineResponse20022)</returns>
	Task<ApiResponse<InlineResponse20022>> GetInvoicePositionsByIdAsyncWithHttpInfo(int? invoiceId, int? limit = null,
		int? offset = null, List<string> embed = null);

	/// <summary>
	///     Retrieve invoices
	/// </summary>
	/// <remarks>
	///     There are a multitude of parameter which can be used to filter. A few of them are attached but       for a complete
	///     list please check out &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/How-to-filter-for-certain-invoices
	///     &#x27;&gt;this&lt;/a&gt; list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="status">Status of the invoices (optional)</param>
	/// <param name="invoiceNumber">Retrieve all invoices with this invoice number (optional)</param>
	/// <param name="startDate">Retrieve all invoices with a date equal or higher (optional)</param>
	/// <param name="endDate">Retrieve all invoices with a date equal or lower (optional)</param>
	/// <param name="contactId">Retrieve all invoices with this contact. Must be provided with contact[objectName] (optional)</param>
	/// <param name="contactObjectName">
	///     Only required if contact[id] was provided. &#x27;Contact&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <returns>Task of GetInvoicesResponse</returns>
	Task<GetInvoicesResponse> GetInvoicesAsync(decimal? status = null, string invoiceNumber = null,
		int? startDate = null, int? endDate = null, int? contactId = null, string contactObjectName = null);

	/// <summary>
	///     Retrieve invoices
	/// </summary>
	/// <remarks>
	///     There are a multitude of parameter which can be used to filter. A few of them are attached but       for a complete
	///     list please check out &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/How-to-filter-for-certain-invoices
	///     &#x27;&gt;this&lt;/a&gt; list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="status">Status of the invoices (optional)</param>
	/// <param name="invoiceNumber">Retrieve all invoices with this invoice number (optional)</param>
	/// <param name="startDate">Retrieve all invoices with a date equal or higher (optional)</param>
	/// <param name="endDate">Retrieve all invoices with a date equal or lower (optional)</param>
	/// <param name="contactId">Retrieve all invoices with this contact. Must be provided with contact[objectName] (optional)</param>
	/// <param name="contactObjectName">
	///     Only required if contact[id] was provided. &#x27;Contact&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <returns>Task of ApiResponse (GetInvoicesResponse)</returns>
	Task<ApiResponse<GetInvoicesResponse>> GetInvoicesAsyncWithHttpInfo(decimal? status = null,
		string invoiceNumber = null, int? startDate = null, int? endDate = null, int? contactId = null,
		string contactObjectName = null);

	/// <summary>
	///     Check if an invoice is already partially paid
	/// </summary>
	/// <remarks>
	///     Returns &#x27;true&#x27; if the given invoice is partially paid - &#x27;false&#x27; if it is not.      Invoices
	///     which are completely paid are regarded as not partially paid.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to return</param>
	/// <returns>Task of InlineResponse20011</returns>
	Task<InlineResponse20011> GetIsInvoicePartiallyPaidAsync(int? invoiceId);

	/// <summary>
	///     Check if an invoice is already partially paid
	/// </summary>
	/// <remarks>
	///     Returns &#x27;true&#x27; if the given invoice is partially paid - &#x27;false&#x27; if it is not.      Invoices
	///     which are completely paid are regarded as not partially paid.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to return</param>
	/// <returns>Task of ApiResponse (InlineResponse20011)</returns>
	Task<ApiResponse<InlineResponse20011>> GetIsInvoicePartiallyPaidAsyncWithHttpInfo(int? invoiceId);

	/// <summary>
	///     Retrieve pdf document of an invoice
	/// </summary>
	/// <remarks>
	///     Retrieves the pdf document of an invoice with additional metadata.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice from which you want the pdf</param>
	/// <param name="download">If u want to download the pdf of the invoice. (optional)</param>
	/// <param name="preventSendBy">Defines if u want to send the invoice. (optional)</param>
	/// <returns>Task of CreditNoteGetPdfResponse</returns>
	Task<CreditNoteGetPdfResponse>
		InvoiceGetPdfAsync(int? invoiceId, bool? download = null, bool? preventSendBy = null);

	/// <summary>
	///     Retrieve pdf document of an invoice
	/// </summary>
	/// <remarks>
	///     Retrieves the pdf document of an invoice with additional metadata.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice from which you want the pdf</param>
	/// <param name="download">If u want to download the pdf of the invoice. (optional)</param>
	/// <param name="preventSendBy">Defines if u want to send the invoice. (optional)</param>
	/// <returns>Task of ApiResponse (CreditNoteGetPdfResponse)</returns>
	Task<ApiResponse<CreditNoteGetPdfResponse>> InvoiceGetPdfAsyncWithHttpInfo(int? invoiceId, bool? download = null,
		bool? preventSendBy = null);

	/// <summary>
	///     Render the pdf document of an invoice
	/// </summary>
	/// <remarks>
	///     Using this endpoint you can render the pdf document of an invoice.&lt;br&gt;       Use cases for this are the
	///     retrieval of the pdf location or the forceful re-render of a already sent invoice.&lt;br&gt;       Please be aware
	///     that changing an invoice after it has been sent to a customer is not an allowed bookkeeping process.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to render</param>
	/// <param name="body">Define if the document should be forcefully re-rendered. (optional)</param>
	/// <returns>Task of InlineResponse2011</returns>
	Task<InlineResponse2011> InvoiceRenderAsync(int? invoiceId, InvoiceIdRenderBody body = null);

	/// <summary>
	///     Render the pdf document of an invoice
	/// </summary>
	/// <remarks>
	///     Using this endpoint you can render the pdf document of an invoice.&lt;br&gt;       Use cases for this are the
	///     retrieval of the pdf location or the forceful re-render of a already sent invoice.&lt;br&gt;       Please be aware
	///     that changing an invoice after it has been sent to a customer is not an allowed bookkeeping process.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to render</param>
	/// <param name="body">Define if the document should be forcefully re-rendered. (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse2011)</returns>
	Task<ApiResponse<InlineResponse2011>> InvoiceRenderAsyncWithHttpInfo(int? invoiceId,
		InvoiceIdRenderBody body = null);

	/// <summary>
	///     Mark invoice as sent
	/// </summary>
	/// <remarks>
	///     Marks an invoice as sent by a chosen send type.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to mark as sent</param>
	/// <param name="body">Specify the send type (optional)</param>
	/// <returns>Task of InlineResponse20029</returns>
	Task<InlineResponse20029> InvoiceSendByAsync(int? invoiceId, InvoiceIdSendByBody body = null);

	/// <summary>
	///     Mark invoice as sent
	/// </summary>
	/// <remarks>
	///     Marks an invoice as sent by a chosen send type.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to mark as sent</param>
	/// <param name="body">Specify the send type (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse20029)</returns>
	Task<ApiResponse<InlineResponse20029>> InvoiceSendByAsyncWithHttpInfo(int? invoiceId,
		InvoiceIdSendByBody body = null);

	/// <summary>
	///     Send invoice via email
	/// </summary>
	/// <remarks>
	///     This endpoint sends the specified invoice to a customer via email.&lt;br&gt;      This will automatically mark the
	///     invoice as sent.&lt;br&gt;      Please note, that in production an invoice is not allowed to be changed after this
	///     happened!
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to be sent via email</param>
	/// <param name="body">Mail data (optional)</param>
	/// <returns>Task of InlineResponse201</returns>
	Task<InlineResponse201> SendInvoiceViaEMailAsync(int? invoiceId, InvoiceIdSendViaEmailBody body = null);

	/// <summary>
	///     Send invoice via email
	/// </summary>
	/// <remarks>
	///     This endpoint sends the specified invoice to a customer via email.&lt;br&gt;      This will automatically mark the
	///     invoice as sent.&lt;br&gt;      Please note, that in production an invoice is not allowed to be changed after this
	///     happened!
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to be sent via email</param>
	/// <param name="body">Mail data (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse201)</returns>
	Task<ApiResponse<InlineResponse201>> SendInvoiceViaEMailAsyncWithHttpInfo(int? invoiceId,
		InvoiceIdSendViaEmailBody body = null);

	#endregion Asynchronous Operations
}