/* 
 * sevDesk API
 *
 * <b>Contact:</b> To contact our support click <a href='https://landing.sevdesk.de/service-support-center-technik'>here</a><br><br>   # General information  Welcome to our API!<br>  sevDesk offers you the possibility of retrieving data using an interface, namely the sevDesk API, and making changes without having to use the web UI. The sevDesk interface is a REST-Full API. All sevDesk data and functions that are used in the web UI can also be controlled through the API.   # Cross-Origin Resource Sharing  This API features Cross-Origin Resource Sharing (CORS).<br>  It enables cross-domain communication from the browser.<br>  All responses have a wildcard same-origin which makes them completely public and accessible to everyone, including any code on any site.    # Embedding resources  When retrieving resources by using this API, you might encounter nested resources in the resources you requested.<br>  For example, an invoice always contains a contact, of which you can see the ID and the object name.<br>  This API gives you the possibility to embed these resources completely into the resources you originally requested.<br>  Taking our invoice example, this would mean, that you would not only see the ID and object name of a contact, but rather the complete contact resource.    To embed resources, all you need to do is to add the query parameter 'embed' to your GET request.<br>  As values, you can provide the name of the nested resource.<br>  Multiple nested resources are also possible by providing multiple names, separated by a comma.    # Authentication and Authorization  The sevDesk API uses a token authentication to authorize calls. For this purpose every sevDesk administrator has one API token, which is a <b>hexadecimal string</b> containing <b>32 characters</b>. The following clip shows where you can find the API token if this is your first time with our API.<br><br> <video src='OpenAPI/img/findingTheApiToken.mp4' controls width='640' height='360'> Ihr Browser kann dieses Video nicht wiedergeben.<br/> Dieses Video zeigt wie sie Ihr sevDesk API Token finden. </video> <br> The token will be needed in every request that you want to send and needs to be attached to the request url as a <b>Query Parameter</b><br> or provided as a value of an <b>Authorization Header</b>.<br> For security reasons, we suggest putting the API Token in the Authorization Header and not in the query string.<br> However, in the request examples in this documentation, we will keep it in the query string, as it is easier for you to copy them and try them yourself.<br> The following url is an example that shows where your token needs to be placed as a query parameter.<br> In this case, we used some random API token. <ul> <li><span>ht</span>tps://my.sevdesk.de/api/v1/Contact?token=<span style='color:red'>b7794de0085f5cd00560f160f290af38</span></li> </ul> The next example shows the token in the Authorization Header. <ul> <li>\"Authorization\" :<span style='color:red'>\"b7794de0085f5cd00560f160f290af38\"</span></li> </ul> The api tokens have an infinite lifetime and, in other words, exist as long as the sevDesk user exists.<br> For this reason, the user should <b>NEVER</b> be deleted.<br> If really necessary, it is advisable to save the api token as we will <b>NOT</b> be able to retrieve it afterwards!<br> It is also possible to generate a new API token, for example, if you want to prevent the usage of your sevDesk account by other people who got your current API token.<br> To achieve this, you just need to click on the \"generate new\" symbol to the right of your token and confirm it with your password.  # API News  To never miss API news and updates again, subscribe to our <b>free API newsletter</b> and get all relevant information to keep your sevDesk software running smoothly. To subscribe, simply click <a href = 'https://landing.sevdesk.de/api-newsletter'><b>here</b></a> and confirm the email address to which we may send all updates relevant to you.  # API Requests  In our case, REST API requests need to be build by combining the following components. <table> <tr> <th><b>Component</b></th> <th><b>Description</b></th> </tr> <tr> <td>HTTP-Methods</td> <td> <ul> <li>GET (retrieve a resource)</li> <li>POST (create a resource)</li> <li>PUT (update a resource)</li> <li>DELETE (delete a resource)</li> </ul> </td> </tr> <tr> <td>URL of the API</td> <td><span style='color: #2aa198'>ht</span><span style='color: #2aa198'>tps://my.sevdesk.de/api/v1</span></td> </tr> <tr> <td>URI of the resource</td> <td>The resource to query.<br>For example contacts in sevDesk:<br><br> <span style='color:red'>/Contact</span><br><br> Which will result in the following complete URL:<br><br> <span style='color: #2aa198'>ht</span><span style='color: #2aa198'>tps://my.sevdesk.de/api/v1</span><span style='color:red'>/Contact</span> </td> </tr> <tr> <td>Query parameters</td> <td>Are attached by using the connectives <b>?</b> and <b>&</b> in the URL.<br></td> </tr> <tr> <td>Request headers</td> <td>Typical request headers are for example:<br> <div> <br> <ul> <li>Content-type</li> <li>Authorization</li> <li>Accept-Encoding</li> <li>User-Agent</li> <li>...</li> </ul> </div> </td> </tr> <tr> <td>Request body</td> <td>Mostly required in POST and PUT requests.<br> Often the request body contains json, in our case, it also accepts url-encoded data. </td> </tr> </table><br> <span style='color:red'>Note</span>: please pass a meaningful entry at the header \"User-Agent\". If the \"User-Agent\" is set meaningfully, we can offer better support in case of queries from customers.<br> An example how such a \"User-Agent\" can look like: \"Integration-name by abc\". <br><br> This is a sample request for retrieving existing contacts in sevDesk using curl:<br><br> <img src='OpenAPI/img/GETRequest.PNG' alt='Get Request' height='150'><br><br> As you can see, the request contains all the components mentioned above.<br> It's HTTP method is GET, it has a correct endpoint (<span style='color: #2aa198'>ht</span><span style='color: #2aa198'>tps://my.sevdesk.de/api/v1</span><span style='color:red'>/Contact</span>), query parameters like <b>token</b> and additional <b>header</b> information!<br><br> <b>Query Parameters</b><br><br> As you might have seen in the sample request above, there are several other parameters besides \"token\", located in the url.<br> Those are mostly optional but prove to be very useful for a lot of requests as they can limit, extend, sort or filter the data you will get as a response.<br><br> These are the three most used query parameter for the sevDesk API. <table> <tr> <th><b>Parameter</b></th> <th><b>Description</b></th> </tr> <tr> <td>limit</td> <td>Limits the number of entries that are returned.<br> Most useful in GET requests which will most likely deliver big sets of data like country or currency lists.<br> In this case, you can bypass the default limitation on returned entries by providing a high number. </td> </tr> <tr> <td>offset</td> <td>Specifies a certain offset for the data that will be returned.<br> As an example, you can specify \"offset=2\" if you want all entries except for the first two.</td> </tr> <tr> <td>embed</td> <td>Will extend some of the returned data.<br> A brief example can be found below.</td> </tr> </table> This is an example for the usage of the embed parameter.<br> The following first request will return all company contact entries in sevDesk up to a limit of 100 without any additional information and no offset.<br><br> <img src='OpenAPI/img/ContactQueryWithoutEmbed.PNG' width='900' height='850'><br><br> Now have a look at the category attribute located in the response.<br> Naturally, it just contains the id and the object name of the object but no further information.<br> We will now use the parameter embed with the value \"category\".<br><br> <img src='OpenAPI/img/ContactQueryWithEmbed.PNG' width='900' height='850'><br><br> As you can see, the category object is now extended and shows all the attributes and their corresponding values.<br><br> There are lot of other query parameters that can be used to filter the returned data for objects that match a certain pattern, however, those will not be mentioned here and instead can be found at the detail documentation of the most used API endpoints like contact, invoice or voucher.<br><br> <b>Request Headers</b><br><br> The HTTP request (response) headers allow the client as well as the server to pass additional information with the request.<br> They transfer the parameters and arguments which are important for transmitting data over HTTP.<br> Three headers which are useful / necessary when using the sevDesk API are \"Authorization, \"Accept\" and \"Content-type\".<br> Underneath is a brief description of why and how they should be used.<br><br> <b>Authorization</b><br><br> Can be used if you want to provide your API token in the header instead of having it in the url. <ul> <li>Authorization:<span style='color:red'>yourApiToken</span></li> </ul> <b>Accept</b><br><br> Specifies the format of the response.<br> Required for operations with a response body. <ul> <li>Accept:application/<span style='color:red'>format</span> </li> </ul> In our case, <code><span style='color:red'>format</span></code> could be replaced with <code>json</code> or <code>xml</code><br><br> <b>Content-type</b><br><br> Specifies which format is used in the request.<br> Is required for operations with a request body. <ul> <li>Content-type:application/<span style='color:red'>format</span></li> </ul> In our case,<code><span style='color:red'>format</span></code>could be replaced with <code>json</code> or <code>x-www-form-urlencoded</code> <br><br><b>API Responses</b><br><br> HTTP status codes<br> When calling the sevDesk API it is very likely that you will get a HTTP status code in the response.<br> Some API calls will also return JSON response bodies which will contain information about the resource.<br> Each status code which is returned will either be a <b>success</b> code or an <b>error</b> code.<br><br> Success codes <table> <tr> <th><b>Status code</b></th> <th><b>Description</b></th> </tr> <tr> <td><code>200 OK</code></td> <td>The request was successful</td> </tr> <tr> <td><code>201 Created</code></td> <td>Most likely to be found in the response of a <b>POST</b> request.<br> This code indicates that the desired resource was successfully created.</td> </tr> </table> <br>Error codes <table> <tr> <th><b>Status code</b></th> <th><b>Description</b></th> </tr> <tr> <td><code>400 Bad request</code></td> <td>The request you sent is most likely syntactically incorrect.<br> You should check if the parameters in the request body or the url are correct.</td> </tr> <tr> <td><code>401 Unauthorized</code></td> <td>The authentication failed.<br> Most likely caused by a missing or wrong API token.</td> </tr> <tr> <td><code>403 Forbidden</code></td> <td>You do not have the permission the access the resource which is requested.</td> </tr> <tr> <td><code>404 Not found</code></td> <td>The resource you specified does not exist.</td> </tr> <tr> <td><code>500 Internal server error</code></td> <td>An internal server error has occurred.<br> Normally this means that something went wrong on our side.<br> However, sometimes this error will appear if we missed to catch an error which is normally a 400 status code! </td> </tr> </table>  # Your First Request  After reading the introduction to our API, you should now be able to make your first call.<br> For testing our API, we would always recommend to create a trial account for sevDesk to prevent unwanted changes to your main account.<br> A trial account will be in the highest tariff (materials management), so every sevDesk function can be tested! <br><br>To start testing we would recommend one of the following tools: <ul> <li><a href='https://www.getpostman.com/'>Postman</a></li> <li><a href='https://curl.haxx.se/download.html'>cURL</a></li> </ul> This example will illustrate your first request, which is creating a new Contact in sevDesk.<br> <ol> <li>Download <a href='https://www.getpostman.com/'><b>Postman</b></a> for your desired system and start the application</li> <li>Enter <span><b>ht</span>tps://my.sevdesk.de/api/v1/Contact</b> as the url</li> <li>Use the connective <b>?</b> to append <b>token=</b> to the end of the url, or create an authorization header. Insert your API token as the value</li> <li>For this test, select <b>POST</b> as the HTTP method</li> <li>Go to <b>Headers</b> and enter the key-value pair <b>Content-type</b> + <b>application/x-www-form-urlencoded</b><br> As an alternative, you can just go to <b>Body</b> and select <b>x-www-form-urlencoded</b></li> <li>Now go to <b>Body</b> (if you are not there yet) and enter the key-value pairs as shown in the following picture<br><br> <img src='OpenAPI/img/FirstRequestPostman.PNG' width='900'><br><br></li> <li>Click on <b>Send</b>. Your response should now look like this:<br><br> <img src='OpenAPI/img/FirstRequestResponse.PNG' width='900'></li> </ol> As you can see, a successful response in this case returns a JSON-formatted response body containing the contact you just created.<br> For keeping it simple, this was only a minimal example of creating a contact.<br> There are however numerous combinations of parameters that you can provide which add information to your contact.
 *
 * OpenAPI spec version: 2.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SevDesk.Extensions.ClientApi.Model;

/// <summary>
///     Voucher model
/// </summary>
[DataContract]
public class ModelVoucherUpdate : IEquatable<ModelVoucherUpdate>, IValidatableObject
{
	/// <summary>
	///     Defines if your voucher is a credit (C) or debit (D)
	/// </summary>
	/// <value>Defines if your voucher is a credit (C) or debit (D)</value>
	[JsonConverter(typeof(StringEnumConverter))]
	public enum CreditDebitEnum
	{
		/// <summary>
		///     Enum C for value: C
		/// </summary>
		[EnumMember(Value = "C")] C = 1,

		/// <summary>
		///     Enum D for value: D
		/// </summary>
		[EnumMember(Value = "D")] D = 2
	}

	/// <summary>
	///     Please have a look in       &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/Types-and-status-of-vouchers
	///     &#x27;&gt;status of vouchers&lt;/a&gt;      to see what the different status codes mean
	/// </summary>
	/// <value>
	///     Please have a look in       &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/Types-and-status-of-vouchers
	///     &#x27;&gt;status of vouchers&lt;/a&gt;      to see what the different status codes mean
	/// </value>
	[JsonConverter(typeof(StringEnumConverter))]
	public enum StatusEnum
	{
		/// <summary>
		///     Enum _50 for value: 50
		/// </summary>
		[EnumMember(Value = "50")] _50 = 1,

		/// <summary>
		///     Enum _100 for value: 100
		/// </summary>
		[EnumMember(Value = "100")] _100 = 2,

		/// <summary>
		///     Enum _1000 for value: 1000
		/// </summary>
		[EnumMember(Value = "1000")] _1000 = 3
	}

	/// <summary>
	///     Type of the voucher. For more information on the different types, check       &lt;a href&#x3D;&#x27;
	///     https://api.sevdesk.de/#section/Types-and-status-of-vouchers&#x27;&gt;this&lt;/a&gt;
	/// </summary>
	/// <value>
	///     Type of the voucher. For more information on the different types, check       &lt;a href&#x3D;&#x27;
	///     https://api.sevdesk.de/#section/Types-and-status-of-vouchers&#x27;&gt;this&lt;/a&gt;
	/// </value>
	[JsonConverter(typeof(StringEnumConverter))]
	public enum VoucherTypeEnum
	{
		/// <summary>
		///     Enum VOU for value: VOU
		/// </summary>
		[EnumMember(Value = "VOU")] VOU = 1,

		/// <summary>
		///     Enum RV for value: RV
		/// </summary>
		[EnumMember(Value = "RV")] RV = 2
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="ModelVoucherUpdate" /> class.
	/// </summary>
	/// <param name="voucherDate">Needs to be provided as timestamp or dd.mm.yyyy.</param>
	/// <param name="supplier">supplier.</param>
	/// <param name="supplierName">
	///     The supplier name.&lt;br&gt;       The value you provide here will determine what supplier
	///     name is shown for the voucher in case you did not provide a supplier..
	/// </param>
	/// <param name="description">The description of the voucher. Essentially the voucher number..</param>
	/// <param name="payDate">Needs to be timestamp or dd.mm.yyyy.</param>
	/// <param name="status">
	///     Please have a look in       &lt;a href&#x3D;&#x27;
	///     https://api.sevdesk.de/#section/Types-and-status-of-vouchers&#x27;&gt;status of vouchers&lt;/a&gt;      to see what
	///     the different status codes mean.
	/// </param>
	/// <param name="taxType">
	///     Tax type of the voucher. There are four tax types: 1. default - Umsatzsteuer ausweisen 2. eu -
	///     Steuerfreie innergemeinschaftliche Lieferung (Europäische Union) 3. noteu - Steuerschuldnerschaft des
	///     Leistungsempfängers (außerhalb EU, z. B. Schweiz) 4. custom - Using custom tax set 5. ss - Not subject to VAT
	///     according to §19 1 UStG Tax rates are heavily connected to the tax type used..
	/// </param>
	/// <param name="creditDebit">Defines if your voucher is a credit (C) or debit (D).</param>
	/// <param name="voucherType">
	///     Type of the voucher. For more information on the different types, check       &lt;a href
	///     &#x3D;&#x27;https://api.sevdesk.de/#section/Types-and-status-of-vouchers&#x27;&gt;this&lt;/a&gt;  .
	/// </param>
	/// <param name="currency">
	///     specifies which currency the voucher should have. Attention: If the currency differs from the
	///     default currency stored in the account, then either the \&quot;propertyForeignCurrencyDeadline\&quot; or \&quot;
	///     propertyExchangeRate\&quot; parameter must be specified. If both parameters are specified, then the \&quot;
	///     propertyForeignCurrencyDeadline\&quot; parameter is preferred.
	/// </param>
	/// <param name="propertyForeignCurrencyDeadline">
	///     Defines the exchange rate day and and then the exchange rate is set from
	///     sevDesk. Needs to be provided as timestamp or dd.mm.yyyy.
	/// </param>
	/// <param name="propertyExchangeRate">Defines the exchange rate.</param>
	/// <param name="taxSet">taxSet.</param>
	/// <param name="paymentDeadline">Payment deadline of the voucher..</param>
	/// <param name="deliveryDate">Needs to be provided as timestamp or dd.mm.yyyy.</param>
	/// <param name="deliveryDateUntil">Needs to be provided as timestamp or dd.mm.yyyy.</param>
	/// <param name="document">document.</param>
	/// <param name="costCentre">costCentre.</param>
	public ModelVoucherUpdate(DateTime? voucherDate = default,
		ModelVoucherUpdateSupplier supplier = default,
		string supplierName = default, string description = default,
		DateTime? payDate = default, StatusEnum? status = default,
		string taxType = default, CreditDebitEnum? creditDebit = default,
		VoucherTypeEnum? voucherType = default, string currency = default,
		DateTime? propertyForeignCurrencyDeadline = default,
		float? propertyExchangeRate = default,
		ModelVoucherUpdateTaxSet taxSet = default,
		DateTime? paymentDeadline = default, DateTime? deliveryDate = default,
		DateTime? deliveryDateUntil = default,
		ModelVoucherUpdateDocument document = default,
		ModelVoucherUpdateCostCentre costCentre = default)
	{
		VoucherDate = voucherDate;
		Supplier = supplier;
		SupplierName = supplierName;
		Description = description;
		PayDate = payDate;
		Status = status;
		TaxType = taxType;
		CreditDebit = creditDebit;
		VoucherType = voucherType;
		Currency = currency;
		PropertyForeignCurrencyDeadline = propertyForeignCurrencyDeadline;
		PropertyExchangeRate = propertyExchangeRate;
		TaxSet = taxSet;
		PaymentDeadline = paymentDeadline;
		DeliveryDate = deliveryDate;
		DeliveryDateUntil = deliveryDateUntil;
		Document = document;
		CostCentre = costCentre;
	}

	/// <summary>
	///     Please have a look in       &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/Types-and-status-of-vouchers
	///     &#x27;&gt;status of vouchers&lt;/a&gt;      to see what the different status codes mean
	/// </summary>
	/// <value>
	///     Please have a look in       &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/Types-and-status-of-vouchers
	///     &#x27;&gt;status of vouchers&lt;/a&gt;      to see what the different status codes mean
	/// </value>
	[DataMember(Name = "status", EmitDefaultValue = false)]
	public StatusEnum? Status { get; set; }

	/// <summary>
	///     Defines if your voucher is a credit (C) or debit (D)
	/// </summary>
	/// <value>Defines if your voucher is a credit (C) or debit (D)</value>
	[DataMember(Name = "creditDebit", EmitDefaultValue = false)]
	public CreditDebitEnum? CreditDebit { get; set; }

	/// <summary>
	///     Type of the voucher. For more information on the different types, check       &lt;a href&#x3D;&#x27;
	///     https://api.sevdesk.de/#section/Types-and-status-of-vouchers&#x27;&gt;this&lt;/a&gt;
	/// </summary>
	/// <value>
	///     Type of the voucher. For more information on the different types, check       &lt;a href&#x3D;&#x27;
	///     https://api.sevdesk.de/#section/Types-and-status-of-vouchers&#x27;&gt;this&lt;/a&gt;
	/// </value>
	[DataMember(Name = "voucherType", EmitDefaultValue = false)]
	public VoucherTypeEnum? VoucherType { get; set; }

	/// <summary>
	///     Needs to be provided as timestamp or dd.mm.yyyy
	/// </summary>
	/// <value>Needs to be provided as timestamp or dd.mm.yyyy</value>
	[DataMember(Name = "voucherDate", EmitDefaultValue = false)]
	public DateTime? VoucherDate { get; set; }

	/// <summary>
	///     Gets or Sets Supplier
	/// </summary>
	[DataMember(Name = "supplier", EmitDefaultValue = false)]
	public ModelVoucherUpdateSupplier Supplier { get; set; }

	/// <summary>
	///     The supplier name.&lt;br&gt;       The value you provide here will determine what supplier name is shown for the
	///     voucher in case you did not provide a supplier.
	/// </summary>
	/// <value>
	///     The supplier name.&lt;br&gt;       The value you provide here will determine what supplier name is shown for the
	///     voucher in case you did not provide a supplier.
	/// </value>
	[DataMember(Name = "supplierName", EmitDefaultValue = false)]
	public string SupplierName { get; set; }

	/// <summary>
	///     The description of the voucher. Essentially the voucher number.
	/// </summary>
	/// <value>The description of the voucher. Essentially the voucher number.</value>
	[DataMember(Name = "description", EmitDefaultValue = false)]
	public string Description { get; set; }

	/// <summary>
	///     Needs to be timestamp or dd.mm.yyyy
	/// </summary>
	/// <value>Needs to be timestamp or dd.mm.yyyy</value>
	[DataMember(Name = "payDate", EmitDefaultValue = false)]
	public DateTime? PayDate { get; set; }


	/// <summary>
	///     Amount which has already been paid for this voucher by the customer
	/// </summary>
	/// <value>Amount which has already been paid for this voucher by the customer</value>
	[DataMember(Name = "paidAmount", EmitDefaultValue = false)]
	public float? PaidAmount { get; private set; }

	/// <summary>
	///     Tax type of the voucher. There are four tax types: 1. default - Umsatzsteuer ausweisen 2. eu - Steuerfreie
	///     innergemeinschaftliche Lieferung (Europäische Union) 3. noteu - Steuerschuldnerschaft des Leistungsempfängers
	///     (außerhalb EU, z. B. Schweiz) 4. custom - Using custom tax set 5. ss - Not subject to VAT according to §19 1 UStG
	///     Tax rates are heavily connected to the tax type used.
	/// </summary>
	/// <value>
	///     Tax type of the voucher. There are four tax types: 1. default - Umsatzsteuer ausweisen 2. eu - Steuerfreie
	///     innergemeinschaftliche Lieferung (Europäische Union) 3. noteu - Steuerschuldnerschaft des Leistungsempfängers
	///     (außerhalb EU, z. B. Schweiz) 4. custom - Using custom tax set 5. ss - Not subject to VAT according to §19 1 UStG
	///     Tax rates are heavily connected to the tax type used.
	/// </value>
	[DataMember(Name = "taxType", EmitDefaultValue = false)]
	public string TaxType { get; set; }


	/// <summary>
	///     specifies which currency the voucher should have. Attention: If the currency differs from the default currency
	///     stored in the account, then either the \&quot;propertyForeignCurrencyDeadline\&quot; or \&quot;
	///     propertyExchangeRate\&quot; parameter must be specified. If both parameters are specified, then the \&quot;
	///     propertyForeignCurrencyDeadline\&quot; parameter is preferred
	/// </summary>
	/// <value>
	///     specifies which currency the voucher should have. Attention: If the currency differs from the default currency
	///     stored in the account, then either the \&quot;propertyForeignCurrencyDeadline\&quot; or \&quot;
	///     propertyExchangeRate\&quot; parameter must be specified. If both parameters are specified, then the \&quot;
	///     propertyForeignCurrencyDeadline\&quot; parameter is preferred
	/// </value>
	[DataMember(Name = "currency", EmitDefaultValue = false)]
	public string Currency { get; set; }

	/// <summary>
	///     Defines the exchange rate day and and then the exchange rate is set from sevDesk. Needs to be provided as timestamp
	///     or dd.mm.yyyy
	/// </summary>
	/// <value>
	///     Defines the exchange rate day and and then the exchange rate is set from sevDesk. Needs to be provided as
	///     timestamp or dd.mm.yyyy
	/// </value>
	[DataMember(Name = "propertyForeignCurrencyDeadline", EmitDefaultValue = false)]
	public DateTime? PropertyForeignCurrencyDeadline { get; set; }

	/// <summary>
	///     Defines the exchange rate
	/// </summary>
	/// <value>Defines the exchange rate</value>
	[DataMember(Name = "propertyExchangeRate", EmitDefaultValue = false)]
	public float? PropertyExchangeRate { get; set; }

	/// <summary>
	///     Gets or Sets TaxSet
	/// </summary>
	[DataMember(Name = "taxSet", EmitDefaultValue = false)]
	public ModelVoucherUpdateTaxSet TaxSet { get; set; }

	/// <summary>
	///     Payment deadline of the voucher.
	/// </summary>
	/// <value>Payment deadline of the voucher.</value>
	[DataMember(Name = "paymentDeadline", EmitDefaultValue = false)]
	public DateTime? PaymentDeadline { get; set; }

	/// <summary>
	///     Needs to be provided as timestamp or dd.mm.yyyy
	/// </summary>
	/// <value>Needs to be provided as timestamp or dd.mm.yyyy</value>
	[DataMember(Name = "deliveryDate", EmitDefaultValue = false)]
	public DateTime? DeliveryDate { get; set; }

	/// <summary>
	///     Needs to be provided as timestamp or dd.mm.yyyy
	/// </summary>
	/// <value>Needs to be provided as timestamp or dd.mm.yyyy</value>
	[DataMember(Name = "deliveryDateUntil", EmitDefaultValue = false)]
	public DateTime? DeliveryDateUntil { get; set; }

	/// <summary>
	///     Gets or Sets Document
	/// </summary>
	[DataMember(Name = "document", EmitDefaultValue = false)]
	public ModelVoucherUpdateDocument Document { get; set; }

	/// <summary>
	///     Gets or Sets CostCentreResponse
	/// </summary>
	[DataMember(Name = "costCentre", EmitDefaultValue = false)]
	public ModelVoucherUpdateCostCentre CostCentre { get; set; }

	/// <summary>
	///     Returns true if ModelVoucherUpdate instances are equal
	/// </summary>
	/// <param name="input">Instance of ModelVoucherUpdate to be compared</param>
	/// <returns>Boolean</returns>
	public bool Equals(ModelVoucherUpdate input)
	{
		if (input == null)
			return false;

		return
			(
				VoucherDate == input.VoucherDate ||
				(VoucherDate != null &&
				 VoucherDate.Equals(input.VoucherDate))
			) &&
			(
				Supplier == input.Supplier ||
				(Supplier != null &&
				 Supplier.Equals(input.Supplier))
			) &&
			(
				SupplierName == input.SupplierName ||
				(SupplierName != null &&
				 SupplierName.Equals(input.SupplierName))
			) &&
			(
				Description == input.Description ||
				(Description != null &&
				 Description.Equals(input.Description))
			) &&
			(
				PayDate == input.PayDate ||
				(PayDate != null &&
				 PayDate.Equals(input.PayDate))
			) &&
			(
				Status == input.Status ||
				(Status != null &&
				 Status.Equals(input.Status))
			) &&
			(
				PaidAmount == input.PaidAmount ||
				(PaidAmount != null &&
				 PaidAmount.Equals(input.PaidAmount))
			) &&
			(
				TaxType == input.TaxType ||
				(TaxType != null &&
				 TaxType.Equals(input.TaxType))
			) &&
			(
				CreditDebit == input.CreditDebit ||
				(CreditDebit != null &&
				 CreditDebit.Equals(input.CreditDebit))
			) &&
			(
				VoucherType == input.VoucherType ||
				(VoucherType != null &&
				 VoucherType.Equals(input.VoucherType))
			) &&
			(
				Currency == input.Currency ||
				(Currency != null &&
				 Currency.Equals(input.Currency))
			) &&
			(
				PropertyForeignCurrencyDeadline == input.PropertyForeignCurrencyDeadline ||
				(PropertyForeignCurrencyDeadline != null &&
				 PropertyForeignCurrencyDeadline.Equals(input.PropertyForeignCurrencyDeadline))
			) &&
			(
				PropertyExchangeRate == input.PropertyExchangeRate ||
				(PropertyExchangeRate != null &&
				 PropertyExchangeRate.Equals(input.PropertyExchangeRate))
			) &&
			(
				TaxSet == input.TaxSet ||
				(TaxSet != null &&
				 TaxSet.Equals(input.TaxSet))
			) &&
			(
				PaymentDeadline == input.PaymentDeadline ||
				(PaymentDeadline != null &&
				 PaymentDeadline.Equals(input.PaymentDeadline))
			) &&
			(
				DeliveryDate == input.DeliveryDate ||
				(DeliveryDate != null &&
				 DeliveryDate.Equals(input.DeliveryDate))
			) &&
			(
				DeliveryDateUntil == input.DeliveryDateUntil ||
				(DeliveryDateUntil != null &&
				 DeliveryDateUntil.Equals(input.DeliveryDateUntil))
			) &&
			(
				Document == input.Document ||
				(Document != null &&
				 Document.Equals(input.Document))
			) &&
			(
				CostCentre == input.CostCentre ||
				(CostCentre != null &&
				 CostCentre.Equals(input.CostCentre))
			);
	}

	/// <summary>
	///     To validate all properties of the instance
	/// </summary>
	/// <param name="validationContext">Validation context</param>
	/// <returns>Validation Result</returns>
	IEnumerable<ValidationResult> IValidatableObject.Validate(
		ValidationContext validationContext)
	{
		yield break;
	}

	/// <summary>
	///     Returns the string presentation of the object
	/// </summary>
	/// <returns>String presentation of the object</returns>
	public override string ToString()
	{
		var sb = new StringBuilder();
		sb.Append("class ModelVoucherUpdate {\n");
		sb.Append("  VoucherDate: ").Append(VoucherDate).Append("\n");
		sb.Append("  Supplier: ").Append(Supplier).Append("\n");
		sb.Append("  SupplierName: ").Append(SupplierName).Append("\n");
		sb.Append("  Description: ").Append(Description).Append("\n");
		sb.Append("  PayDate: ").Append(PayDate).Append("\n");
		sb.Append("  Status: ").Append(Status).Append("\n");
		sb.Append("  PaidAmount: ").Append(PaidAmount).Append("\n");
		sb.Append("  TaxType: ").Append(TaxType).Append("\n");
		sb.Append("  CreditDebit: ").Append(CreditDebit).Append("\n");
		sb.Append("  VoucherType: ").Append(VoucherType).Append("\n");
		sb.Append("  Currency: ").Append(Currency).Append("\n");
		sb.Append("  PropertyForeignCurrencyDeadline: ").Append(PropertyForeignCurrencyDeadline).Append("\n");
		sb.Append("  PropertyExchangeRate: ").Append(PropertyExchangeRate).Append("\n");
		sb.Append("  TaxSet: ").Append(TaxSet).Append("\n");
		sb.Append("  PaymentDeadline: ").Append(PaymentDeadline).Append("\n");
		sb.Append("  DeliveryDate: ").Append(DeliveryDate).Append("\n");
		sb.Append("  DeliveryDateUntil: ").Append(DeliveryDateUntil).Append("\n");
		sb.Append("  Document: ").Append(Document).Append("\n");
		sb.Append("  CostCentreResponse: ").Append(CostCentre).Append("\n");
		sb.Append("}\n");
		return sb.ToString();
	}

	/// <summary>
	///     Returns the JSON string presentation of the object
	/// </summary>
	/// <returns>JSON string presentation of the object</returns>
	public virtual string ToJson()
	{
		return JsonConvert.SerializeObject(this, Formatting.Indented);
	}

	/// <summary>
	///     Returns true if objects are equal
	/// </summary>
	/// <param name="input">Object to be compared</param>
	/// <returns>Boolean</returns>
	public override bool Equals(object input)
	{
		return Equals(input as ModelVoucherUpdate);
	}

	/// <summary>
	///     Gets the hash code
	/// </summary>
	/// <returns>Hash code</returns>
	public override int GetHashCode()
	{
		unchecked // Overflow is fine, just wrap
		{
			var hashCode = 41;
			if (VoucherDate != null)
				hashCode = hashCode * 59 + VoucherDate.GetHashCode();
			if (Supplier != null)
				hashCode = hashCode * 59 + Supplier.GetHashCode();
			if (SupplierName != null)
				hashCode = hashCode * 59 + SupplierName.GetHashCode();
			if (Description != null)
				hashCode = hashCode * 59 + Description.GetHashCode();
			if (PayDate != null)
				hashCode = hashCode * 59 + PayDate.GetHashCode();
			if (Status != null)
				hashCode = hashCode * 59 + Status.GetHashCode();
			if (PaidAmount != null)
				hashCode = hashCode * 59 + PaidAmount.GetHashCode();
			if (TaxType != null)
				hashCode = hashCode * 59 + TaxType.GetHashCode();
			if (CreditDebit != null)
				hashCode = hashCode * 59 + CreditDebit.GetHashCode();
			if (VoucherType != null)
				hashCode = hashCode * 59 + VoucherType.GetHashCode();
			if (Currency != null)
				hashCode = hashCode * 59 + Currency.GetHashCode();
			if (PropertyForeignCurrencyDeadline != null)
				hashCode = hashCode * 59 + PropertyForeignCurrencyDeadline.GetHashCode();
			if (PropertyExchangeRate != null)
				hashCode = hashCode * 59 + PropertyExchangeRate.GetHashCode();
			if (TaxSet != null)
				hashCode = hashCode * 59 + TaxSet.GetHashCode();
			if (PaymentDeadline != null)
				hashCode = hashCode * 59 + PaymentDeadline.GetHashCode();
			if (DeliveryDate != null)
				hashCode = hashCode * 59 + DeliveryDate.GetHashCode();
			if (DeliveryDateUntil != null)
				hashCode = hashCode * 59 + DeliveryDateUntil.GetHashCode();
			if (Document != null)
				hashCode = hashCode * 59 + Document.GetHashCode();
			if (CostCentre != null)
				hashCode = hashCode * 59 + CostCentre.GetHashCode();
			return hashCode;
		}
	}
}