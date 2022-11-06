/* 
 * sevDesk API
 *
 * <b>Contact:</b> To contact our support click <a href='https://landing.sevdesk.de/service-support-center-technik'>here</a><br><br>   # General information  Welcome to our API!<br>  sevDesk offers you the possibility of retrieving data using an interface, namely the sevDesk API, and making changes without having to use the web UI. The sevDesk interface is a REST-Full API. All sevDesk data and functions that are used in the web UI can also be controlled through the API.   # Cross-Origin Resource Sharing  This API features Cross-Origin Resource Sharing (CORS).<br>  It enables cross-domain communication from the browser.<br>  All responses have a wildcard same-origin which makes them completely public and accessible to everyone, including any code on any site.    # Embedding resources  When retrieving resources by using this API, you might encounter nested resources in the resources you requested.<br>  For example, an invoice always contains a contact, of which you can see the ID and the object name.<br>  This API gives you the possibility to embed these resources completely into the resources you originally requested.<br>  Taking our invoice example, this would mean, that you would not only see the ID and object name of a contact, but rather the complete contact resource.    To embed resources, all you need to do is to add the query parameter 'embed' to your GET request.<br>  As values, you can provide the name of the nested resource.<br>  Multiple nested resources are also possible by providing multiple names, separated by a comma.    # Authentication and Authorization  The sevDesk API uses a token authentication to authorize calls. For this purpose every sevDesk administrator has one API token, which is a <b>hexadecimal string</b> containing <b>32 characters</b>. The following clip shows where you can find the API token if this is your first time with our API.<br><br> <video src='OpenAPI/img/findingTheApiToken.mp4' controls width='640' height='360'> Ihr Browser kann dieses Video nicht wiedergeben.<br/> Dieses Video zeigt wie sie Ihr sevDesk API Token finden. </video> <br> The token will be needed in every request that you want to send and needs to be attached to the request url as a <b>Query Parameter</b><br> or provided as a value of an <b>Authorization Header</b>.<br> For security reasons, we suggest putting the API Token in the Authorization Header and not in the query string.<br> However, in the request examples in this documentation, we will keep it in the query string, as it is easier for you to copy them and try them yourself.<br> The following url is an example that shows where your token needs to be placed as a query parameter.<br> In this case, we used some random API token. <ul> <li><span>ht</span>tps://my.sevdesk.de/api/v1/Contact?token=<span style='color:red'>b7794de0085f5cd00560f160f290af38</span></li> </ul> The next example shows the token in the Authorization Header. <ul> <li>\"Authorization\" :<span style='color:red'>\"b7794de0085f5cd00560f160f290af38\"</span></li> </ul> The api tokens have an infinite lifetime and, in other words, exist as long as the sevDesk user exists.<br> For this reason, the user should <b>NEVER</b> be deleted.<br> If really necessary, it is advisable to save the api token as we will <b>NOT</b> be able to retrieve it afterwards!<br> It is also possible to generate a new API token, for example, if you want to prevent the usage of your sevDesk account by other people who got your current API token.<br> To achieve this, you just need to click on the \"generate new\" symbol to the right of your token and confirm it with your password.  # API News  To never miss API news and updates again, subscribe to our <b>free API newsletter</b> and get all relevant information to keep your sevDesk software running smoothly. To subscribe, simply click <a href = 'https://landing.sevdesk.de/api-newsletter'><b>here</b></a> and confirm the email address to which we may send all updates relevant to you.  # API Requests  In our case, REST API requests need to be build by combining the following components. <table> <tr> <th><b>Component</b></th> <th><b>Description</b></th> </tr> <tr> <td>HTTP-Methods</td> <td> <ul> <li>GET (retrieve a resource)</li> <li>POST (create a resource)</li> <li>PUT (update a resource)</li> <li>DELETE (delete a resource)</li> </ul> </td> </tr> <tr> <td>URL of the API</td> <td><span style='color: #2aa198'>ht</span><span style='color: #2aa198'>tps://my.sevdesk.de/api/v1</span></td> </tr> <tr> <td>URI of the resource</td> <td>The resource to query.<br>For example contacts in sevDesk:<br><br> <span style='color:red'>/Contact</span><br><br> Which will result in the following complete URL:<br><br> <span style='color: #2aa198'>ht</span><span style='color: #2aa198'>tps://my.sevdesk.de/api/v1</span><span style='color:red'>/Contact</span> </td> </tr> <tr> <td>Query parameters</td> <td>Are attached by using the connectives <b>?</b> and <b>&</b> in the URL.<br></td> </tr> <tr> <td>Request headers</td> <td>Typical request headers are for example:<br> <div> <br> <ul> <li>Content-type</li> <li>Authorization</li> <li>Accept-Encoding</li> <li>User-Agent</li> <li>...</li> </ul> </div> </td> </tr> <tr> <td>Request body</td> <td>Mostly required in POST and PUT requests.<br> Often the request body contains json, in our case, it also accepts url-encoded data. </td> </tr> </table><br> <span style='color:red'>Note</span>: please pass a meaningful entry at the header \"User-Agent\". If the \"User-Agent\" is set meaningfully, we can offer better support in case of queries from customers.<br> An example how such a \"User-Agent\" can look like: \"Integration-name by abc\". <br><br> This is a sample request for retrieving existing contacts in sevDesk using curl:<br><br> <img src='OpenAPI/img/GETRequest.PNG' alt='Get Request' height='150'><br><br> As you can see, the request contains all the components mentioned above.<br> It's HTTP method is GET, it has a correct endpoint (<span style='color: #2aa198'>ht</span><span style='color: #2aa198'>tps://my.sevdesk.de/api/v1</span><span style='color:red'>/Contact</span>), query parameters like <b>token</b> and additional <b>header</b> information!<br><br> <b>Query Parameters</b><br><br> As you might have seen in the sample request above, there are several other parameters besides \"token\", located in the url.<br> Those are mostly optional but prove to be very useful for a lot of requests as they can limit, extend, sort or filter the data you will get as a response.<br><br> These are the three most used query parameter for the sevDesk API. <table> <tr> <th><b>Parameter</b></th> <th><b>Description</b></th> </tr> <tr> <td>limit</td> <td>Limits the number of entries that are returned.<br> Most useful in GET requests which will most likely deliver big sets of data like country or currency lists.<br> In this case, you can bypass the default limitation on returned entries by providing a high number. </td> </tr> <tr> <td>offset</td> <td>Specifies a certain offset for the data that will be returned.<br> As an example, you can specify \"offset=2\" if you want all entries except for the first two.</td> </tr> <tr> <td>embed</td> <td>Will extend some of the returned data.<br> A brief example can be found below.</td> </tr> </table> This is an example for the usage of the embed parameter.<br> The following first request will return all company contact entries in sevDesk up to a limit of 100 without any additional information and no offset.<br><br> <img src='OpenAPI/img/ContactQueryWithoutEmbed.PNG' width='900' height='850'><br><br> Now have a look at the category attribute located in the response.<br> Naturally, it just contains the id and the object name of the object but no further information.<br> We will now use the parameter embed with the value \"category\".<br><br> <img src='OpenAPI/img/ContactQueryWithEmbed.PNG' width='900' height='850'><br><br> As you can see, the category object is now extended and shows all the attributes and their corresponding values.<br><br> There are lot of other query parameters that can be used to filter the returned data for objects that match a certain pattern, however, those will not be mentioned here and instead can be found at the detail documentation of the most used API endpoints like contact, invoice or voucher.<br><br> <b>Request Headers</b><br><br> The HTTP request (response) headers allow the client as well as the server to pass additional information with the request.<br> They transfer the parameters and arguments which are important for transmitting data over HTTP.<br> Three headers which are useful / necessary when using the sevDesk API are \"Authorization, \"Accept\" and \"Content-type\".<br> Underneath is a brief description of why and how they should be used.<br><br> <b>Authorization</b><br><br> Can be used if you want to provide your API token in the header instead of having it in the url. <ul> <li>Authorization:<span style='color:red'>yourApiToken</span></li> </ul> <b>Accept</b><br><br> Specifies the format of the response.<br> Required for operations with a response body. <ul> <li>Accept:application/<span style='color:red'>format</span> </li> </ul> In our case, <code><span style='color:red'>format</span></code> could be replaced with <code>json</code> or <code>xml</code><br><br> <b>Content-type</b><br><br> Specifies which format is used in the request.<br> Is required for operations with a request body. <ul> <li>Content-type:application/<span style='color:red'>format</span></li> </ul> In our case,<code><span style='color:red'>format</span></code>could be replaced with <code>json</code> or <code>x-www-form-urlencoded</code> <br><br><b>API Responses</b><br><br> HTTP status codes<br> When calling the sevDesk API it is very likely that you will get a HTTP status code in the response.<br> Some API calls will also return JSON response bodies which will contain information about the resource.<br> Each status code which is returned will either be a <b>success</b> code or an <b>error</b> code.<br><br> Success codes <table> <tr> <th><b>Status code</b></th> <th><b>Description</b></th> </tr> <tr> <td><code>200 OK</code></td> <td>The request was successful</td> </tr> <tr> <td><code>201 Created</code></td> <td>Most likely to be found in the response of a <b>POST</b> request.<br> This code indicates that the desired resource was successfully created.</td> </tr> </table> <br>Error codes <table> <tr> <th><b>Status code</b></th> <th><b>Description</b></th> </tr> <tr> <td><code>400 Bad request</code></td> <td>The request you sent is most likely syntactically incorrect.<br> You should check if the parameters in the request body or the url are correct.</td> </tr> <tr> <td><code>401 Unauthorized</code></td> <td>The authentication failed.<br> Most likely caused by a missing or wrong API token.</td> </tr> <tr> <td><code>403 Forbidden</code></td> <td>You do not have the permission the access the resource which is requested.</td> </tr> <tr> <td><code>404 Not found</code></td> <td>The resource you specified does not exist.</td> </tr> <tr> <td><code>500 Internal server error</code></td> <td>An internal server error has occurred.<br> Normally this means that something went wrong on our side.<br> However, sometimes this error will appear if we missed to catch an error which is normally a 400 status code! </td> </tr> </table>  # Your First Request  After reading the introduction to our API, you should now be able to make your first call.<br> For testing our API, we would always recommend to create a trial account for sevDesk to prevent unwanted changes to your main account.<br> A trial account will be in the highest tariff (materials management), so every sevDesk function can be tested! <br><br>To start testing we would recommend one of the following tools: <ul> <li><a href='https://www.getpostman.com/'>Postman</a></li> <li><a href='https://curl.haxx.se/download.html'>cURL</a></li> </ul> This example will illustrate your first request, which is creating a new Contact in sevDesk.<br> <ol> <li>Download <a href='https://www.getpostman.com/'><b>Postman</b></a> for your desired system and start the application</li> <li>Enter <span><b>ht</span>tps://my.sevdesk.de/api/v1/Contact</b> as the url</li> <li>Use the connective <b>?</b> to append <b>token=</b> to the end of the url, or create an authorization header. Insert your API token as the value</li> <li>For this test, select <b>POST</b> as the HTTP method</li> <li>Go to <b>Headers</b> and enter the key-value pair <b>Content-type</b> + <b>application/x-www-form-urlencoded</b><br> As an alternative, you can just go to <b>Body</b> and select <b>x-www-form-urlencoded</b></li> <li>Now go to <b>Body</b> (if you are not there yet) and enter the key-value pairs as shown in the following picture<br><br> <img src='OpenAPI/img/FirstRequestPostman.PNG' width='900'><br><br></li> <li>Click on <b>Send</b>. Your response should now look like this:<br><br> <img src='OpenAPI/img/FirstRequestResponse.PNG' width='900'></li> </ol> As you can see, a successful response in this case returns a JSON-formatted response body containing the contact you just created.<br> For keeping it simple, this was only a minimal example of creating a contact.<br> There are however numerous combinations of parameters that you can provide which add information to your contact.
 *
 * OpenAPI spec version: 2.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System.Collections.ObjectModel;
using RestSharp;
using SevDesk.Extensions.ClientApi.Client;
using SevDesk.Extensions.ClientApi.Model;

namespace SevDesk.Extensions.ClientApi.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public class InvoiceApi : IInvoiceApi
{
	private ExceptionFactory _exceptionFactory = (name, response) => null;

	/// <summary>
	///     Initializes a new instance of the <see cref="InvoiceApi" /> class.
	/// </summary>
	/// <returns></returns>
	public InvoiceApi(string basePath)
	{
		Configuration = new Configuration { BasePath = basePath };

		ExceptionFactory = Configuration.DefaultExceptionFactory;
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="InvoiceApi" /> class
	/// </summary>
	/// <returns></returns>
	public InvoiceApi()
	{
		Configuration = Configuration.Default;

		ExceptionFactory = Configuration.DefaultExceptionFactory;
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="InvoiceApi" /> class
	///     using Configuration object
	/// </summary>
	/// <param name="configuration">An instance of Configuration</param>
	/// <returns></returns>
	public InvoiceApi(Configuration configuration = null)
	{
		if (configuration == null) // use the default one in Configuration
			Configuration = Configuration.Default;
		else
			Configuration = configuration;

		ExceptionFactory = Configuration.DefaultExceptionFactory;
	}

	/// <summary>
	///     Gets the base path of the API client.
	/// </summary>
	/// <value>The base path</value>
	public string GetBasePath()
	{
		return Configuration.ApiClient.RestClient.BaseUrl.ToString();
	}

	/// <summary>
	///     Gets or sets the configuration object
	/// </summary>
	/// <value>An instance of the Configuration</value>
	public Configuration Configuration { get; set; }

	/// <summary>
	///     Provides a factory method hook for the creation of exceptions.
	/// </summary>
	public ExceptionFactory ExceptionFactory
	{
		get
		{
			if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
				throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
			return _exceptionFactory;
		}
		set => _exceptionFactory = value;
	}

	/// <summary>
	///     Book an invoice Booking the invoice with a transaction is probably the most important part in the bookkeeping
	///     process.&lt;br&gt; There are several ways on correctly booking an invoice, all by using the same endpoint.&lt;br
	///     &gt; for more information look &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/How-to-book-an-invoice&#x27;
	///     &gt;here&lt;/a&gt;.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to book</param>
	/// <param name="body">Booking data (optional)</param>
	/// <returns>InlineResponse2008</returns>
	public InlineResponse2008 BookInvoice(int? invoiceId, InvoiceIdBookAmountBody body = null)
	{
		var localVarResponse = BookInvoiceWithHttpInfo(invoiceId, body);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Book an invoice Booking the invoice with a transaction is probably the most important part in the bookkeeping
	///     process.&lt;br&gt; There are several ways on correctly booking an invoice, all by using the same endpoint.&lt;br
	///     &gt; for more information look &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/How-to-book-an-invoice&#x27;
	///     &gt;here&lt;/a&gt;.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to book</param>
	/// <param name="body">Booking data (optional)</param>
	/// <returns>ApiResponse of InlineResponse2008</returns>
	public ApiResponse<InlineResponse2008> BookInvoiceWithHttpInfo(int? invoiceId, InvoiceIdBookAmountBody body = null)
	{
		// verify the required parameter 'invoiceId' is set
		if (invoiceId == null)
			throw new ApiException(400, "Missing required parameter 'invoiceId' when calling InvoiceApi->BookInvoice");

		var localVarPath = "/Invoice/{invoiceId}/bookAmount";
		var localVarPathParams = new Dictionary<string, string>();
		var localVarQueryParams = new List<KeyValuePair<string, string>>();
		var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
		var localVarFormParams = new Dictionary<string, string>();
		var localVarFileParams = new Dictionary<string, FileParameter>();
		object localVarPostBody = null;

		// to determine the Content-Type header
		string[] localVarHttpContentTypes =
		{
			"application/json"
		};
		var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

		// to determine the Accept header
		string[] localVarHttpHeaderAccepts =
		{
			"application/json"
		};
		var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
		if (localVarHttpHeaderAccept != null)
			localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

		if (invoiceId != null)
			localVarPathParams.Add("invoiceId", Configuration.ApiClient.ParameterToString(invoiceId)); // path parameter
		if (body != null && body.GetType() != typeof(byte[]))
			localVarPostBody = Configuration.ApiClient.Serialize(body); // http body (model) parameter
		else
			localVarPostBody = body; // byte array
		// authentication (api_key) required
		if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
			localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");

		// make the HTTP request
		var localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
			Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
			localVarFileParams,
			localVarPathParams, localVarHttpContentType);

		var localVarStatusCode = (int)localVarResponse.StatusCode;

		if (ExceptionFactory != null)
		{
			var exception = ExceptionFactory("BookInvoice", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse2008>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse2008)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2008)));
	}

	/// <summary>
	///     Book an invoice Booking the invoice with a transaction is probably the most important part in the bookkeeping
	///     process.&lt;br&gt; There are several ways on correctly booking an invoice, all by using the same endpoint.&lt;br
	///     &gt; for more information look &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/How-to-book-an-invoice&#x27;
	///     &gt;here&lt;/a&gt;.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to book</param>
	/// <param name="body">Booking data (optional)</param>
	/// <returns>Task of InlineResponse2008</returns>
	public async Task<InlineResponse2008> BookInvoiceAsync(int? invoiceId, InvoiceIdBookAmountBody body = null)
	{
		var localVarResponse = await BookInvoiceAsyncWithHttpInfo(invoiceId, body);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Book an invoice Booking the invoice with a transaction is probably the most important part in the bookkeeping
	///     process.&lt;br&gt; There are several ways on correctly booking an invoice, all by using the same endpoint.&lt;br
	///     &gt; for more information look &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/How-to-book-an-invoice&#x27;
	///     &gt;here&lt;/a&gt;.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to book</param>
	/// <param name="body">Booking data (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse2008)</returns>
	public async Task<ApiResponse<InlineResponse2008>> BookInvoiceAsyncWithHttpInfo(int? invoiceId,
		InvoiceIdBookAmountBody body = null)
	{
		// verify the required parameter 'invoiceId' is set
		if (invoiceId == null)
			throw new ApiException(400, "Missing required parameter 'invoiceId' when calling InvoiceApi->BookInvoice");

		var localVarPath = "/Invoice/{invoiceId}/bookAmount";
		var localVarPathParams = new Dictionary<string, string>();
		var localVarQueryParams = new List<KeyValuePair<string, string>>();
		var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
		var localVarFormParams = new Dictionary<string, string>();
		var localVarFileParams = new Dictionary<string, FileParameter>();
		object localVarPostBody = null;

		// to determine the Content-Type header
		string[] localVarHttpContentTypes =
		{
			"application/json"
		};
		var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

		// to determine the Accept header
		string[] localVarHttpHeaderAccepts =
		{
			"application/json"
		};
		var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
		if (localVarHttpHeaderAccept != null)
			localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

		if (invoiceId != null)
			localVarPathParams.Add("invoiceId", Configuration.ApiClient.ParameterToString(invoiceId)); // path parameter
		if (body != null && body.GetType() != typeof(byte[]))
			localVarPostBody = Configuration.ApiClient.Serialize(body); // http body (model) parameter
		else
			localVarPostBody = body; // byte array
		// authentication (api_key) required
		if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
			localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");

		// make the HTTP request
		var localVarResponse = (IRestResponse)await Configuration.ApiClient.CallApiAsync(localVarPath,
			Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
			localVarFileParams,
			localVarPathParams, localVarHttpContentType);

		var localVarStatusCode = (int)localVarResponse.StatusCode;

		if (ExceptionFactory != null)
		{
			var exception = ExceptionFactory("BookInvoice", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse2008>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse2008)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2008)));
	}

	/// <summary>
	///     Cancel an invoice / Create cancellation invoice This endpoint will cancel the specified invoice therefor creating a
	///     cancellation invoice.&lt;br&gt;       The cancellation invoice will be automatically paid and the source invoices
	///     status will change to &#x27;cancelled&#x27;.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to be cancelled</param>
	/// <returns>GetInvoicesResponse</returns>
	public GetInvoicesResponse CancelInvoice(int? invoiceId)
	{
		var localVarResponse = CancelInvoiceWithHttpInfo(invoiceId);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Cancel an invoice / Create cancellation invoice This endpoint will cancel the specified invoice therefor creating a
	///     cancellation invoice.&lt;br&gt;       The cancellation invoice will be automatically paid and the source invoices
	///     status will change to &#x27;cancelled&#x27;.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to be cancelled</param>
	/// <returns>ApiResponse of GetInvoicesResponse</returns>
	public ApiResponse<GetInvoicesResponse> CancelInvoiceWithHttpInfo(int? invoiceId)
	{
		// verify the required parameter 'invoiceId' is set
		if (invoiceId == null)
			throw new ApiException(400,
				"Missing required parameter 'invoiceId' when calling InvoiceApi->CancelInvoice");

		var localVarPath = "/Invoice/{invoiceId}/cancelInvoice";
		var localVarPathParams = new Dictionary<string, string>();
		var localVarQueryParams = new List<KeyValuePair<string, string>>();
		var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
		var localVarFormParams = new Dictionary<string, string>();
		var localVarFileParams = new Dictionary<string, FileParameter>();
		object localVarPostBody = null;

		// to determine the Content-Type header
		string[] localVarHttpContentTypes =
		{
		};
		var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

		// to determine the Accept header
		string[] localVarHttpHeaderAccepts =
		{
			"application/json"
		};
		var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
		if (localVarHttpHeaderAccept != null)
			localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

		if (invoiceId != null)
			localVarPathParams.Add("invoiceId", Configuration.ApiClient.ParameterToString(invoiceId)); // path parameter
		// authentication (api_key) required
		if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
			localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");

		// make the HTTP request
		var localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
			Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
			localVarFileParams,
			localVarPathParams, localVarHttpContentType);

		var localVarStatusCode = (int)localVarResponse.StatusCode;

		if (ExceptionFactory != null)
		{
			var exception = ExceptionFactory("CancelInvoice", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<GetInvoicesResponse>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(GetInvoicesResponse)Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetInvoicesResponse)));
	}

	/// <summary>
	///     Cancel an invoice / Create cancellation invoice This endpoint will cancel the specified invoice therefor creating a
	///     cancellation invoice.&lt;br&gt;       The cancellation invoice will be automatically paid and the source invoices
	///     status will change to &#x27;cancelled&#x27;.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to be cancelled</param>
	/// <returns>Task of GetInvoicesResponse</returns>
	public async Task<GetInvoicesResponse> CancelInvoiceAsync(int? invoiceId)
	{
		var localVarResponse = await CancelInvoiceAsyncWithHttpInfo(invoiceId);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Cancel an invoice / Create cancellation invoice This endpoint will cancel the specified invoice therefor creating a
	///     cancellation invoice.&lt;br&gt;       The cancellation invoice will be automatically paid and the source invoices
	///     status will change to &#x27;cancelled&#x27;.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to be cancelled</param>
	/// <returns>Task of ApiResponse (GetInvoicesResponse)</returns>
	public async Task<ApiResponse<GetInvoicesResponse>> CancelInvoiceAsyncWithHttpInfo(int? invoiceId)
	{
		// verify the required parameter 'invoiceId' is set
		if (invoiceId == null)
			throw new ApiException(400,
				"Missing required parameter 'invoiceId' when calling InvoiceApi->CancelInvoice");

		var localVarPath = "/Invoice/{invoiceId}/cancelInvoice";
		var localVarPathParams = new Dictionary<string, string>();
		var localVarQueryParams = new List<KeyValuePair<string, string>>();
		var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
		var localVarFormParams = new Dictionary<string, string>();
		var localVarFileParams = new Dictionary<string, FileParameter>();
		object localVarPostBody = null;

		// to determine the Content-Type header
		string[] localVarHttpContentTypes =
		{
		};
		var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

		// to determine the Accept header
		string[] localVarHttpHeaderAccepts =
		{
			"application/json"
		};
		var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
		if (localVarHttpHeaderAccept != null)
			localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

		if (invoiceId != null)
			localVarPathParams.Add("invoiceId", Configuration.ApiClient.ParameterToString(invoiceId)); // path parameter
		// authentication (api_key) required
		if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
			localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");

		// make the HTTP request
		var localVarResponse = (IRestResponse)await Configuration.ApiClient.CallApiAsync(localVarPath,
			Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
			localVarFileParams,
			localVarPathParams, localVarHttpContentType);

		var localVarStatusCode = (int)localVarResponse.StatusCode;

		if (ExceptionFactory != null)
		{
			var exception = ExceptionFactory("CancelInvoice", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<GetInvoicesResponse>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(GetInvoicesResponse)Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetInvoicesResponse)));
	}

	/// <summary>
	///     Create a new invoice This endpoint offers you the following functionality.       &lt;ul&gt;          &lt;li&gt;
	///     Create invoices together with positions and discounts&lt;/li&gt;          &lt;li&gt;Delete positions while adding
	///     new ones&lt;/li&gt;          &lt;li&gt;Delete or add discounts, or both at the same time&lt;/li&gt;          &lt;li
	///     &gt;Automatically fill the address of the supplied contact into the invoice address&lt;/li&gt;       &lt;/ul&gt;
	///     To make your own request sample slimmer, you can omit all parameters which are not required and nullable.
	///     However, for a valid and logical bookkeeping document, you will also need some of them to ensure that all the
	///     necessary data is in the invoice.&lt;br&gt;&lt;br&gt; The list of parameters starts with the invoice array.&lt;br
	///     &gt; This array contains all required attributes for a complete invoice.&lt;br&gt; Most of the attributes are
	///     covered in the invoice attribute list, there are only two parameters standing out, namely &lt;b&gt;mapAll&lt;/b&gt;
	///     and &lt;b&gt;objectName&lt;/b&gt;.&lt;br&gt; These are just needed for our system and you always need to provide
	///     them.&lt;br&gt;&lt;br&gt; The list of parameters then continues with the invoice position array.&lt;br&gt; With
	///     this array you have the possibility to add multiple positions at once.&lt;br&gt; In the example it only contains
	///     one position, again together with the parameters &lt;b&gt;mapAll&lt;/b&gt; and &lt;b&gt;objectName&lt;/b&gt;,
	///     however, you can add more invoice positions by extending the array.&lt;br&gt; So if you wanted to add another
	///     position, you would add the same list of parameters with an incremented array index of \&quot;1\&quot; instead of \
	///     &quot;0\&quot;.&lt;br&gt;&lt;br&gt; The list ends with the four parameters invoicePosDelete, discountSave,
	///     discountDelete and takeDefaultAddress.&lt;br&gt; They only play a minor role if you only want to create an invoice
	///     but we will shortly explain what they can do.&lt;br&gt; With invoicePosDelete you have to option to delete invoice
	///     positions as this request can also be used to update invoices.&lt;br&gt; With discountSave you can add discounts to
	///     your invoice.&lt;br&gt; With discountDelete you can delete discounts from your invoice.&lt;br&gt; With
	///     takeDefaultAddress you can specify that the first address of the contact you are using for the invoice is taken for
	///     the invoice address attribute automatically, so you don&#x27;t need to provide the address yourself.&lt;br&gt; If
	///     you want to know more about these parameters, for example if you want to use this request to update invoices, feel
	///     free to contact our support.&lt;br&gt;&lt;br&gt; Finally, after covering all parameters, they only important
	///     information left, is that the order of the last four attributes always needs to be kept.&lt;br&gt; You will also
	///     always need to provide all of them, as otherwise the request won&#x27;t work properly.&lt;br&gt;&lt;br&gt; &lt;b
	///     &gt;Warning\&quot;:\&quot;&lt;/b&gt; You can not create a regular invoice with the &lt;b&gt;deliveryDate&lt;/b&gt;
	///     being later than the &lt;b&gt;invoiceDate&lt;/b&gt;.&lt;br&gt; To do that you will need to create a so called &lt;b
	///     &gt;Abschlagsrechnung&lt;/b&gt; by setting the &lt;b&gt;invoiceType&lt;/b&gt; parameter to &lt;b&gt;AR&lt;/b&gt;.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">
	///     Creation data. Please be aware, that you need to provide at least all required parameter of the
	///     invoice model! (optional)
	/// </param>
	/// <returns>SaveInvoiceResponse</returns>
	public SaveInvoiceResponse CreateInvoiceByFactory(SaveInvoice body = null)
	{
		var localVarResponse = CreateInvoiceByFactoryWithHttpInfo(body);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Create a new invoice This endpoint offers you the following functionality.       &lt;ul&gt;          &lt;li&gt;
	///     Create invoices together with positions and discounts&lt;/li&gt;          &lt;li&gt;Delete positions while adding
	///     new ones&lt;/li&gt;          &lt;li&gt;Delete or add discounts, or both at the same time&lt;/li&gt;          &lt;li
	///     &gt;Automatically fill the address of the supplied contact into the invoice address&lt;/li&gt;       &lt;/ul&gt;
	///     To make your own request sample slimmer, you can omit all parameters which are not required and nullable.
	///     However, for a valid and logical bookkeeping document, you will also need some of them to ensure that all the
	///     necessary data is in the invoice.&lt;br&gt;&lt;br&gt; The list of parameters starts with the invoice array.&lt;br
	///     &gt; This array contains all required attributes for a complete invoice.&lt;br&gt; Most of the attributes are
	///     covered in the invoice attribute list, there are only two parameters standing out, namely &lt;b&gt;mapAll&lt;/b&gt;
	///     and &lt;b&gt;objectName&lt;/b&gt;.&lt;br&gt; These are just needed for our system and you always need to provide
	///     them.&lt;br&gt;&lt;br&gt; The list of parameters then continues with the invoice position array.&lt;br&gt; With
	///     this array you have the possibility to add multiple positions at once.&lt;br&gt; In the example it only contains
	///     one position, again together with the parameters &lt;b&gt;mapAll&lt;/b&gt; and &lt;b&gt;objectName&lt;/b&gt;,
	///     however, you can add more invoice positions by extending the array.&lt;br&gt; So if you wanted to add another
	///     position, you would add the same list of parameters with an incremented array index of \&quot;1\&quot; instead of \
	///     &quot;0\&quot;.&lt;br&gt;&lt;br&gt; The list ends with the four parameters invoicePosDelete, discountSave,
	///     discountDelete and takeDefaultAddress.&lt;br&gt; They only play a minor role if you only want to create an invoice
	///     but we will shortly explain what they can do.&lt;br&gt; With invoicePosDelete you have to option to delete invoice
	///     positions as this request can also be used to update invoices.&lt;br&gt; With discountSave you can add discounts to
	///     your invoice.&lt;br&gt; With discountDelete you can delete discounts from your invoice.&lt;br&gt; With
	///     takeDefaultAddress you can specify that the first address of the contact you are using for the invoice is taken for
	///     the invoice address attribute automatically, so you don&#x27;t need to provide the address yourself.&lt;br&gt; If
	///     you want to know more about these parameters, for example if you want to use this request to update invoices, feel
	///     free to contact our support.&lt;br&gt;&lt;br&gt; Finally, after covering all parameters, they only important
	///     information left, is that the order of the last four attributes always needs to be kept.&lt;br&gt; You will also
	///     always need to provide all of them, as otherwise the request won&#x27;t work properly.&lt;br&gt;&lt;br&gt; &lt;b
	///     &gt;Warning\&quot;:\&quot;&lt;/b&gt; You can not create a regular invoice with the &lt;b&gt;deliveryDate&lt;/b&gt;
	///     being later than the &lt;b&gt;invoiceDate&lt;/b&gt;.&lt;br&gt; To do that you will need to create a so called &lt;b
	///     &gt;Abschlagsrechnung&lt;/b&gt; by setting the &lt;b&gt;invoiceType&lt;/b&gt; parameter to &lt;b&gt;AR&lt;/b&gt;.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">
	///     Creation data. Please be aware, that you need to provide at least all required parameterof the
	///     invoice model! (optional)
	/// </param>
	/// <returns>ApiResponse of SaveInvoiceResponse</returns>
	public ApiResponse<SaveInvoiceResponse> CreateInvoiceByFactoryWithHttpInfo(SaveInvoice body = null)
	{
		var localVarPath = "/Invoice/Factory/saveInvoice";
		var localVarPathParams = new Dictionary<string, string>();
		var localVarQueryParams = new List<KeyValuePair<string, string>>();
		var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
		var localVarFormParams = new Dictionary<string, string>();
		var localVarFileParams = new Dictionary<string, FileParameter>();
		object localVarPostBody = null;

		// to determine the Content-Type header
		string[] localVarHttpContentTypes =
		{
			"application/json"
		};
		var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

		// to determine the Accept header
		string[] localVarHttpHeaderAccepts =
		{
			"application/json"
		};
		var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
		if (localVarHttpHeaderAccept != null)
			localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

		if (body != null && body.GetType() != typeof(byte[]))
			localVarPostBody = Configuration.ApiClient.Serialize(body); // http body (model) parameter
		else
			localVarPostBody = body; // byte array
		// authentication (api_key) required
		if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
			localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");

		// make the HTTP request
		var localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
			Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
			localVarFileParams,
			localVarPathParams, localVarHttpContentType);

		var localVarStatusCode = (int)localVarResponse.StatusCode;

		if (ExceptionFactory != null)
		{
			var exception = ExceptionFactory("CreateInvoiceByFactory", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<SaveInvoiceResponse>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(SaveInvoiceResponse)Configuration.ApiClient.Deserialize(localVarResponse, typeof(SaveInvoiceResponse)));
	}

	/// <summary>
	///     Create a new invoice This endpoint offers you the following functionality.       &lt;ul&gt;          &lt;li&gt;
	///     Create invoices together with positions and discounts&lt;/li&gt;          &lt;li&gt;Delete positions while adding
	///     new ones&lt;/li&gt;          &lt;li&gt;Delete or add discounts, or both at the same time&lt;/li&gt;          &lt;li
	///     &gt;Automatically fill the address of the supplied contact into the invoice address&lt;/li&gt;       &lt;/ul&gt;
	///     To make your own request sample slimmer, you can omit all parameters which are not required and nullable.
	///     However, for a valid and logical bookkeeping document, you will also need some of them to ensure that all the
	///     necessary data is in the invoice.&lt;br&gt;&lt;br&gt; The list of parameters starts with the invoice array.&lt;br
	///     &gt; This array contains all required attributes for a complete invoice.&lt;br&gt; Most of the attributes are
	///     covered in the invoice attribute list, there are only two parameters standing out, namely &lt;b&gt;mapAll&lt;/b&gt;
	///     and &lt;b&gt;objectName&lt;/b&gt;.&lt;br&gt; These are just needed for our system and you always need to provide
	///     them.&lt;br&gt;&lt;br&gt; The list of parameters then continues with the invoice position array.&lt;br&gt; With
	///     this array you have the possibility to add multiple positions at once.&lt;br&gt; In the example it only contains
	///     one position, again together with the parameters &lt;b&gt;mapAll&lt;/b&gt; and &lt;b&gt;objectName&lt;/b&gt;,
	///     however, you can add more invoice positions by extending the array.&lt;br&gt; So if you wanted to add another
	///     position, you would add the same list of parameters with an incremented array index of \&quot;1\&quot; instead of \
	///     &quot;0\&quot;.&lt;br&gt;&lt;br&gt; The list ends with the four parameters invoicePosDelete, discountSave,
	///     discountDelete and takeDefaultAddress.&lt;br&gt; They only play a minor role if you only want to create an invoice
	///     but we will shortly explain what they can do.&lt;br&gt; With invoicePosDelete you have to option to delete invoice
	///     positions as this request can also be used to update invoices.&lt;br&gt; With discountSave you can add discounts to
	///     your invoice.&lt;br&gt; With discountDelete you can delete discounts from your invoice.&lt;br&gt; With
	///     takeDefaultAddress you can specify that the first address of the contact you are using for the invoice is taken for
	///     the invoice address attribute automatically, so you don&#x27;t need to provide the address yourself.&lt;br&gt; If
	///     you want to know more about these parameters, for example if you want to use this request to update invoices, feel
	///     free to contact our support.&lt;br&gt;&lt;br&gt; Finally, after covering all parameters, they only important
	///     information left, is that the order of the last four attributes always needs to be kept.&lt;br&gt; You will also
	///     always need to provide all of them, as otherwise the request won&#x27;t work properly.&lt;br&gt;&lt;br&gt; &lt;b
	///     &gt;Warning\&quot;:\&quot;&lt;/b&gt; You can not create a regular invoice with the &lt;b&gt;deliveryDate&lt;/b&gt;
	///     being later than the &lt;b&gt;invoiceDate&lt;/b&gt;.&lt;br&gt; To do that you will need to create a so called &lt;b
	///     &gt;Abschlagsrechnung&lt;/b&gt; by setting the &lt;b&gt;invoiceType&lt;/b&gt; parameter to &lt;b&gt;AR&lt;/b&gt;.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">
	///     Creation data. Please be aware, that you need to provide at least all required parameter
	///     of the invoice model! (optional)
	/// </param>
	/// <returns>Task of SaveInvoiceResponse</returns>
	public async Task<SaveInvoiceResponse> CreateInvoiceByFactoryAsync(SaveInvoice body = null)
	{
		var localVarResponse = await CreateInvoiceByFactoryAsyncWithHttpInfo(body);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Create a new invoice This endpoint offers you the following functionality.       &lt;ul&gt;          &lt;li&gt;
	///     Create invoices together with positions and discounts&lt;/li&gt;          &lt;li&gt;Delete positions while adding
	///     new ones&lt;/li&gt;          &lt;li&gt;Delete or add discounts, or both at the same time&lt;/li&gt;          &lt;li
	///     &gt;Automatically fill the address of the supplied contact into the invoice address&lt;/li&gt;       &lt;/ul&gt;
	///     To make your own request sample slimmer, you can omit all parameters which are not required and nullable.
	///     However, for a valid and logical bookkeeping document, you will also need some of them to ensure that all the
	///     necessary data is in the invoice.&lt;br&gt;&lt;br&gt; The list of parameters starts with the invoice array.&lt;br
	///     &gt; This array contains all required attributes for a complete invoice.&lt;br&gt; Most of the attributes are
	///     covered in the invoice attribute list, there are only two parameters standing out, namely &lt;b&gt;mapAll&lt;/b&gt;
	///     and &lt;b&gt;objectName&lt;/b&gt;.&lt;br&gt; These are just needed for our system and you always need to provide
	///     them.&lt;br&gt;&lt;br&gt; The list of parameters then continues with the invoice position array.&lt;br&gt; With
	///     this array you have the possibility to add multiple positions at once.&lt;br&gt; In the example it only contains
	///     one position, again together with the parameters &lt;b&gt;mapAll&lt;/b&gt; and &lt;b&gt;objectName&lt;/b&gt;,
	///     however, you can add more invoice positions by extending the array.&lt;br&gt; So if you wanted to add another
	///     position, you would add the same list of parameters with an incremented array index of \&quot;1\&quot; instead of \
	///     &quot;0\&quot;.&lt;br&gt;&lt;br&gt; The list ends with the four parameters invoicePosDelete, discountSave,
	///     discountDelete and takeDefaultAddress.&lt;br&gt; They only play a minor role if you only want to create an invoice
	///     but we will shortly explain what they can do.&lt;br&gt; With invoicePosDelete you have to option to delete invoice
	///     positions as this request can also be used to update invoices.&lt;br&gt; With discountSave you can add discounts to
	///     your invoice.&lt;br&gt; With discountDelete you can delete discounts from your invoice.&lt;br&gt; With
	///     takeDefaultAddress you can specify that the first address of the contact you are using for the invoice is taken for
	///     the invoice address attribute automatically, so you don&#x27;t need to provide the address yourself.&lt;br&gt; If
	///     you want to know more about these parameters, for example if you want to use this request to update invoices, feel
	///     free to contact our support.&lt;br&gt;&lt;br&gt; Finally, after covering all parameters, they only important
	///     information left, is that the order of the last four attributes always needs to be kept.&lt;br&gt; You will also
	///     always need to provide all of them, as otherwise the request won&#x27;t work properly.&lt;br&gt;&lt;br&gt; &lt;b
	///     &gt;Warning\&quot;:\&quot;&lt;/b&gt; You can not create a regular invoice with the &lt;b&gt;deliveryDate&lt;/b&gt;
	///     being later than the &lt;b&gt;invoiceDate&lt;/b&gt;.&lt;br&gt; To do that you will need to create a so called &lt;b
	///     &gt;Abschlagsrechnung&lt;/b&gt; by setting the &lt;b&gt;invoiceType&lt;/b&gt; parameter to &lt;b&gt;AR&lt;/b&gt;.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">
	///     Creation data. Please be aware, that you need to provide at least all required parameter
	///     of the invoice model! (optional)
	/// </param>
	/// <returns>Task of ApiResponse (SaveInvoiceResponse)</returns>
	public async Task<ApiResponse<SaveInvoiceResponse>> CreateInvoiceByFactoryAsyncWithHttpInfo(SaveInvoice body = null)
	{
		var localVarPath = "/Invoice/Factory/saveInvoice";
		var localVarPathParams = new Dictionary<string, string>();
		var localVarQueryParams = new List<KeyValuePair<string, string>>();
		var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
		var localVarFormParams = new Dictionary<string, string>();
		var localVarFileParams = new Dictionary<string, FileParameter>();
		object localVarPostBody = null;

		// to determine the Content-Type header
		string[] localVarHttpContentTypes =
		{
			"application/json"
		};
		var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

		// to determine the Accept header
		string[] localVarHttpHeaderAccepts =
		{
			"application/json"
		};
		var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
		if (localVarHttpHeaderAccept != null)
			localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

		if (body != null && body.GetType() != typeof(byte[]))
			localVarPostBody = Configuration.ApiClient.Serialize(body); // http body (model) parameter
		else
			localVarPostBody = body; // byte array
		// authentication (api_key) required
		if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
			localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");

		// make the HTTP request
		var localVarResponse = (IRestResponse)await Configuration.ApiClient.CallApiAsync(localVarPath,
			Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
			localVarFileParams,
			localVarPathParams, localVarHttpContentType);

		var localVarStatusCode = (int)localVarResponse.StatusCode;

		if (ExceptionFactory != null)
		{
			var exception = ExceptionFactory("CreateInvoiceByFactory", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<SaveInvoiceResponse>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(SaveInvoiceResponse)Configuration.ApiClient.Deserialize(localVarResponse, typeof(SaveInvoiceResponse)));
	}

	/// <summary>
	///     Create invoice from order Create an invoice from an order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">the id of the invoice</param>
	/// <param name="invoiceObjectName">Model name, which is &#x27;Invoice&#x27;</param>
	/// <param name="body">Create invoice (optional)</param>
	/// <returns>GetInvoicesResponse</returns>
	public GetInvoicesResponse CreateInvoiceFromOrder(int? invoiceId, string invoiceObjectName,
		ModelCreateInvoiceFromOrder body = null)
	{
		var localVarResponse = CreateInvoiceFromOrderWithHttpInfo(invoiceId, invoiceObjectName, body);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Create invoice from order Create an invoice from an order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">the id of the invoice</param>
	/// <param name="invoiceObjectName">Model name, which is &#x27;Invoice&#x27;</param>
	/// <param name="body">Create invoice (optional)</param>
	/// <returns>ApiResponse of GetInvoicesResponse</returns>
	public ApiResponse<GetInvoicesResponse> CreateInvoiceFromOrderWithHttpInfo(int? invoiceId, string invoiceObjectName,
		ModelCreateInvoiceFromOrder body = null)
	{
		// verify the required parameter 'invoiceId' is set
		if (invoiceId == null)
			throw new ApiException(400,
				"Missing required parameter 'invoiceId' when calling InvoiceApi->CreateInvoiceFromOrder");
		// verify the required parameter 'invoiceObjectName' is set
		if (invoiceObjectName == null)
			throw new ApiException(400,
				"Missing required parameter 'invoiceObjectName' when calling InvoiceApi->CreateInvoiceFromOrder");

		var localVarPath = "/Invoice/Factory/createInvoiceFromOrder";
		var localVarPathParams = new Dictionary<string, string>();
		var localVarQueryParams = new List<KeyValuePair<string, string>>();
		var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
		var localVarFormParams = new Dictionary<string, string>();
		var localVarFileParams = new Dictionary<string, FileParameter>();
		object localVarPostBody = null;

		// to determine the Content-Type header
		string[] localVarHttpContentTypes =
		{
			"application/json"
		};
		var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

		// to determine the Accept header
		string[] localVarHttpHeaderAccepts =
		{
			"application/json"
		};
		var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
		if (localVarHttpHeaderAccept != null)
			localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

		if (invoiceId != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "invoice[id]", invoiceId)); // query parameter
		if (invoiceObjectName != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "invoice[objectName]",
					invoiceObjectName)); // query parameter
		if (body != null && body.GetType() != typeof(byte[]))
			localVarPostBody = Configuration.ApiClient.Serialize(body); // http body (model) parameter
		else
			localVarPostBody = body; // byte array
		// authentication (api_key) required
		if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
			localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");

		// make the HTTP request
		var localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
			Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
			localVarFileParams,
			localVarPathParams, localVarHttpContentType);

		var localVarStatusCode = (int)localVarResponse.StatusCode;

		if (ExceptionFactory != null)
		{
			var exception = ExceptionFactory("CreateInvoiceFromOrder", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<GetInvoicesResponse>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(GetInvoicesResponse)Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetInvoicesResponse)));
	}

	/// <summary>
	///     Create invoice from order Create an invoice from an order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">the id of the invoice</param>
	/// <param name="invoiceObjectName">Model name, which is &#x27;Invoice&#x27;</param>
	/// <param name="body">Create invoice (optional)</param>
	/// <returns>Task of GetInvoicesResponse</returns>
	public async Task<GetInvoicesResponse> CreateInvoiceFromOrderAsync(int? invoiceId, string invoiceObjectName,
		ModelCreateInvoiceFromOrder body = null)
	{
		var localVarResponse = await CreateInvoiceFromOrderAsyncWithHttpInfo(invoiceId, invoiceObjectName, body);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Create invoice from order Create an invoice from an order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">the id of the invoice</param>
	/// <param name="invoiceObjectName">Model name, which is &#x27;Invoice&#x27;</param>
	/// <param name="body">Create invoice (optional)</param>
	/// <returns>Task of ApiResponse (GetInvoicesResponse)</returns>
	public async Task<ApiResponse<GetInvoicesResponse>> CreateInvoiceFromOrderAsyncWithHttpInfo(int? invoiceId,
		string invoiceObjectName, ModelCreateInvoiceFromOrder body = null)
	{
		// verify the required parameter 'invoiceId' is set
		if (invoiceId == null)
			throw new ApiException(400,
				"Missing required parameter 'invoiceId' when calling InvoiceApi->CreateInvoiceFromOrder");
		// verify the required parameter 'invoiceObjectName' is set
		if (invoiceObjectName == null)
			throw new ApiException(400,
				"Missing required parameter 'invoiceObjectName' when calling InvoiceApi->CreateInvoiceFromOrder");

		var localVarPath = "/Invoice/Factory/createInvoiceFromOrder";
		var localVarPathParams = new Dictionary<string, string>();
		var localVarQueryParams = new List<KeyValuePair<string, string>>();
		var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
		var localVarFormParams = new Dictionary<string, string>();
		var localVarFileParams = new Dictionary<string, FileParameter>();
		object localVarPostBody = null;

		// to determine the Content-Type header
		string[] localVarHttpContentTypes =
		{
			"application/json"
		};
		var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

		// to determine the Accept header
		string[] localVarHttpHeaderAccepts =
		{
			"application/json"
		};
		var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
		if (localVarHttpHeaderAccept != null)
			localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

		if (invoiceId != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "invoice[id]", invoiceId)); // query parameter
		if (invoiceObjectName != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "invoice[objectName]",
					invoiceObjectName)); // query parameter
		if (body != null && body.GetType() != typeof(byte[]))
			localVarPostBody = Configuration.ApiClient.Serialize(body); // http body (model) parameter
		else
			localVarPostBody = body; // byte array
		// authentication (api_key) required
		if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
			localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");

		// make the HTTP request
		var localVarResponse = (IRestResponse)await Configuration.ApiClient.CallApiAsync(localVarPath,
			Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
			localVarFileParams,
			localVarPathParams, localVarHttpContentType);

		var localVarStatusCode = (int)localVarResponse.StatusCode;

		if (ExceptionFactory != null)
		{
			var exception = ExceptionFactory("CreateInvoiceFromOrder", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<GetInvoicesResponse>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(GetInvoicesResponse)Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetInvoicesResponse)));
	}

	/// <summary>
	///     Create invoice reminder Create an reminder from an invoice
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">the id of the invoice</param>
	/// <param name="invoiceObjectName">Model name, which is &#x27;Invoice&#x27;</param>
	/// <param name="body">Create invoice (optional)</param>
	/// <returns>GetInvoicesResponse</returns>
	public GetInvoicesResponse CreateInvoiceReminder(int? invoiceId, string invoiceObjectName,
		FactoryCreateInvoiceReminderBody body = null)
	{
		var localVarResponse = CreateInvoiceReminderWithHttpInfo(invoiceId, invoiceObjectName, body);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Create invoice reminder Create an reminder from an invoice
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">the id of the invoice</param>
	/// <param name="invoiceObjectName">Model name, which is &#x27;Invoice&#x27;</param>
	/// <param name="body">Create invoice (optional)</param>
	/// <returns>ApiResponse of GetInvoicesResponse</returns>
	public ApiResponse<GetInvoicesResponse> CreateInvoiceReminderWithHttpInfo(int? invoiceId, string invoiceObjectName,
		FactoryCreateInvoiceReminderBody body = null)
	{
		// verify the required parameter 'invoiceId' is set
		if (invoiceId == null)
			throw new ApiException(400,
				"Missing required parameter 'invoiceId' when calling InvoiceApi->CreateInvoiceReminder");
		// verify the required parameter 'invoiceObjectName' is set
		if (invoiceObjectName == null)
			throw new ApiException(400,
				"Missing required parameter 'invoiceObjectName' when calling InvoiceApi->CreateInvoiceReminder");

		var localVarPath = "/Invoice/Factory/createInvoiceReminder";
		var localVarPathParams = new Dictionary<string, string>();
		var localVarQueryParams = new List<KeyValuePair<string, string>>();
		var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
		var localVarFormParams = new Dictionary<string, string>();
		var localVarFileParams = new Dictionary<string, FileParameter>();
		object localVarPostBody = null;

		// to determine the Content-Type header
		string[] localVarHttpContentTypes =
		{
			"application/json"
		};
		var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

		// to determine the Accept header
		string[] localVarHttpHeaderAccepts =
		{
			"application/json"
		};
		var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
		if (localVarHttpHeaderAccept != null)
			localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

		if (invoiceId != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "invoice[id]", invoiceId)); // query parameter
		if (invoiceObjectName != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "invoice[objectName]",
					invoiceObjectName)); // query parameter
		if (body != null && body.GetType() != typeof(byte[]))
			localVarPostBody = Configuration.ApiClient.Serialize(body); // http body (model) parameter
		else
			localVarPostBody = body; // byte array
		// authentication (api_key) required
		if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
			localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");

		// make the HTTP request
		var localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
			Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
			localVarFileParams,
			localVarPathParams, localVarHttpContentType);

		var localVarStatusCode = (int)localVarResponse.StatusCode;

		if (ExceptionFactory != null)
		{
			var exception = ExceptionFactory("CreateInvoiceReminder", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<GetInvoicesResponse>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(GetInvoicesResponse)Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetInvoicesResponse)));
	}

	/// <summary>
	///     Create invoice reminder Create an reminder from an invoice
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">the id of the invoice</param>
	/// <param name="invoiceObjectName">Model name, which is &#x27;Invoice&#x27;</param>
	/// <param name="body">Create invoice (optional)</param>
	/// <returns>Task of GetInvoicesResponse</returns>
	public async Task<GetInvoicesResponse> CreateInvoiceReminderAsync(int? invoiceId, string invoiceObjectName,
		FactoryCreateInvoiceReminderBody body = null)
	{
		var localVarResponse = await CreateInvoiceReminderAsyncWithHttpInfo(invoiceId, invoiceObjectName, body);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Create invoice reminder Create an reminder from an invoice
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">the id of the invoice</param>
	/// <param name="invoiceObjectName">Model name, which is &#x27;Invoice&#x27;</param>
	/// <param name="body">Create invoice (optional)</param>
	/// <returns>Task of ApiResponse (GetInvoicesResponse)</returns>
	public async Task<ApiResponse<GetInvoicesResponse>> CreateInvoiceReminderAsyncWithHttpInfo(int? invoiceId,
		string invoiceObjectName, FactoryCreateInvoiceReminderBody body = null)
	{
		// verify the required parameter 'invoiceId' is set
		if (invoiceId == null)
			throw new ApiException(400,
				"Missing required parameter 'invoiceId' when calling InvoiceApi->CreateInvoiceReminder");
		// verify the required parameter 'invoiceObjectName' is set
		if (invoiceObjectName == null)
			throw new ApiException(400,
				"Missing required parameter 'invoiceObjectName' when calling InvoiceApi->CreateInvoiceReminder");

		var localVarPath = "/Invoice/Factory/createInvoiceReminder";
		var localVarPathParams = new Dictionary<string, string>();
		var localVarQueryParams = new List<KeyValuePair<string, string>>();
		var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
		var localVarFormParams = new Dictionary<string, string>();
		var localVarFileParams = new Dictionary<string, FileParameter>();
		object localVarPostBody = null;

		// to determine the Content-Type header
		string[] localVarHttpContentTypes =
		{
			"application/json"
		};
		var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

		// to determine the Accept header
		string[] localVarHttpHeaderAccepts =
		{
			"application/json"
		};
		var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
		if (localVarHttpHeaderAccept != null)
			localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

		if (invoiceId != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "invoice[id]", invoiceId)); // query parameter
		if (invoiceObjectName != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "invoice[objectName]",
					invoiceObjectName)); // query parameter
		if (body != null && body.GetType() != typeof(byte[]))
			localVarPostBody = Configuration.ApiClient.Serialize(body); // http body (model) parameter
		else
			localVarPostBody = body; // byte array
		// authentication (api_key) required
		if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
			localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");

		// make the HTTP request
		var localVarResponse = (IRestResponse)await Configuration.ApiClient.CallApiAsync(localVarPath,
			Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
			localVarFileParams,
			localVarPathParams, localVarHttpContentType);

		var localVarStatusCode = (int)localVarResponse.StatusCode;

		if (ExceptionFactory != null)
		{
			var exception = ExceptionFactory("CreateInvoiceReminder", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<GetInvoicesResponse>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(GetInvoicesResponse)Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetInvoicesResponse)));
	}

	/// <summary>
	///     Find invoice by ID Returns a single invoice
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to return</param>
	/// <returns>GetInvoicesResponse</returns>
	public GetInvoicesResponse GetInvoiceById(int? invoiceId)
	{
		var localVarResponse = GetInvoiceByIdWithHttpInfo(invoiceId);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Find invoice by ID Returns a single invoice
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to return</param>
	/// <returns>ApiResponse of GetInvoicesResponse</returns>
	public ApiResponse<GetInvoicesResponse> GetInvoiceByIdWithHttpInfo(int? invoiceId)
	{
		// verify the required parameter 'invoiceId' is set
		if (invoiceId == null)
			throw new ApiException(400,
				"Missing required parameter 'invoiceId' when calling InvoiceApi->GetInvoiceById");

		var localVarPath = "/Invoice/{invoiceId}";
		var localVarPathParams = new Dictionary<string, string>();
		var localVarQueryParams = new List<KeyValuePair<string, string>>();
		var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
		var localVarFormParams = new Dictionary<string, string>();
		var localVarFileParams = new Dictionary<string, FileParameter>();
		object localVarPostBody = null;

		// to determine the Content-Type header
		string[] localVarHttpContentTypes =
		{
		};
		var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

		// to determine the Accept header
		string[] localVarHttpHeaderAccepts =
		{
			"application/json"
		};
		var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
		if (localVarHttpHeaderAccept != null)
			localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

		if (invoiceId != null)
			localVarPathParams.Add("invoiceId", Configuration.ApiClient.ParameterToString(invoiceId)); // path parameter
		// authentication (api_key) required
		if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
			localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");

		// make the HTTP request
		var localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
			Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
			localVarFileParams,
			localVarPathParams, localVarHttpContentType);

		var localVarStatusCode = (int)localVarResponse.StatusCode;

		if (ExceptionFactory != null)
		{
			var exception = ExceptionFactory("GetInvoiceById", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<GetInvoicesResponse>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(GetInvoicesResponse)Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetInvoicesResponse)));
	}

	/// <summary>
	///     Find invoice by ID Returns a single invoice
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to return</param>
	/// <returns>Task of GetInvoicesResponse</returns>
	public async Task<GetInvoicesResponse> GetInvoiceByIdAsync(int? invoiceId)
	{
		var localVarResponse = await GetInvoiceByIdAsyncWithHttpInfo(invoiceId);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Find invoice by ID Returns a single invoice
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to return</param>
	/// <returns>Task of ApiResponse (GetInvoicesResponse)</returns>
	public async Task<ApiResponse<GetInvoicesResponse>> GetInvoiceByIdAsyncWithHttpInfo(int? invoiceId)
	{
		// verify the required parameter 'invoiceId' is set
		if (invoiceId == null)
			throw new ApiException(400,
				"Missing required parameter 'invoiceId' when calling InvoiceApi->GetInvoiceById");

		var localVarPath = "/Invoice/{invoiceId}";
		var localVarPathParams = new Dictionary<string, string>();
		var localVarQueryParams = new List<KeyValuePair<string, string>>();
		var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
		var localVarFormParams = new Dictionary<string, string>();
		var localVarFileParams = new Dictionary<string, FileParameter>();
		object localVarPostBody = null;

		// to determine the Content-Type header
		string[] localVarHttpContentTypes =
		{
		};
		var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

		// to determine the Accept header
		string[] localVarHttpHeaderAccepts =
		{
			"application/json"
		};
		var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
		if (localVarHttpHeaderAccept != null)
			localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

		if (invoiceId != null)
			localVarPathParams.Add("invoiceId", Configuration.ApiClient.ParameterToString(invoiceId)); // path parameter
		// authentication (api_key) required
		if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
			localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");

		// make the HTTP request
		var localVarResponse = (IRestResponse)await Configuration.ApiClient.CallApiAsync(localVarPath,
			Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
			localVarFileParams,
			localVarPathParams, localVarHttpContentType);

		var localVarStatusCode = (int)localVarResponse.StatusCode;

		if (ExceptionFactory != null)
		{
			var exception = ExceptionFactory("GetInvoiceById", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<GetInvoicesResponse>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(GetInvoicesResponse)Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetInvoicesResponse)));
	}

	/// <summary>
	///     Find invoice positions Returns all positions of an invoice
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to return the positions</param>
	/// <param name="limit">limits the number of entries returned (optional)</param>
	/// <param name="offset">set the index where the returned entries start (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>InlineResponse20022</returns>
	public InlineResponse20022 GetInvoicePositionsById(int? invoiceId, int? limit = null, int? offset = null,
		List<string> embed = null)
	{
		var localVarResponse = GetInvoicePositionsByIdWithHttpInfo(invoiceId, limit, offset, embed);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Find invoice positions Returns all positions of an invoice
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to return the positions</param>
	/// <param name="limit">limits the number of entries returned (optional)</param>
	/// <param name="offset">set the index where the returned entries start (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>ApiResponse of InlineResponse20022</returns>
	public ApiResponse<InlineResponse20022> GetInvoicePositionsByIdWithHttpInfo(int? invoiceId, int? limit = null,
		int? offset = null, List<string> embed = null)
	{
		// verify the required parameter 'invoiceId' is set
		if (invoiceId == null)
			throw new ApiException(400,
				"Missing required parameter 'invoiceId' when calling InvoiceApi->GetInvoicePositionsById");

		var localVarPath = "/Invoice/{invoiceId}/getPositions";
		var localVarPathParams = new Dictionary<string, string>();
		var localVarQueryParams = new List<KeyValuePair<string, string>>();
		var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
		var localVarFormParams = new Dictionary<string, string>();
		var localVarFileParams = new Dictionary<string, FileParameter>();
		object localVarPostBody = null;

		// to determine the Content-Type header
		string[] localVarHttpContentTypes =
		{
		};
		var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

		// to determine the Accept header
		string[] localVarHttpHeaderAccepts =
		{
			"application/json"
		};
		var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
		if (localVarHttpHeaderAccept != null)
			localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

		if (invoiceId != null)
			localVarPathParams.Add("invoiceId", Configuration.ApiClient.ParameterToString(invoiceId)); // path parameter
		if (limit != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "limit", limit)); // query parameter
		if (offset != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "offset", offset)); // query parameter
		if (embed != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("multi", "embed", embed)); // query parameter
		// authentication (api_key) required
		if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
			localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");

		// make the HTTP request
		var localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
			Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
			localVarFileParams,
			localVarPathParams, localVarHttpContentType);

		var localVarStatusCode = (int)localVarResponse.StatusCode;

		if (ExceptionFactory != null)
		{
			var exception = ExceptionFactory("GetInvoicePositionsById", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse20022>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse20022)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse20022)));
	}

	/// <summary>
	///     Find invoice positions Returns all positions of an invoice
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to return the positions</param>
	/// <param name="limit">limits the number of entries returned (optional)</param>
	/// <param name="offset">set the index where the returned entries start (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>Task of InlineResponse20022</returns>
	public async Task<InlineResponse20022> GetInvoicePositionsByIdAsync(int? invoiceId, int? limit = null,
		int? offset = null, List<string> embed = null)
	{
		var localVarResponse = await GetInvoicePositionsByIdAsyncWithHttpInfo(invoiceId, limit, offset, embed);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Find invoice positions Returns all positions of an invoice
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to return the positions</param>
	/// <param name="limit">limits the number of entries returned (optional)</param>
	/// <param name="offset">set the index where the returned entries start (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>Task of ApiResponse (InlineResponse20022)</returns>
	public async Task<ApiResponse<InlineResponse20022>> GetInvoicePositionsByIdAsyncWithHttpInfo(int? invoiceId,
		int? limit = null, int? offset = null, List<string> embed = null)
	{
		// verify the required parameter 'invoiceId' is set
		if (invoiceId == null)
			throw new ApiException(400,
				"Missing required parameter 'invoiceId' when calling InvoiceApi->GetInvoicePositionsById");

		var localVarPath = "/Invoice/{invoiceId}/getPositions";
		var localVarPathParams = new Dictionary<string, string>();
		var localVarQueryParams = new List<KeyValuePair<string, string>>();
		var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
		var localVarFormParams = new Dictionary<string, string>();
		var localVarFileParams = new Dictionary<string, FileParameter>();
		object localVarPostBody = null;

		// to determine the Content-Type header
		string[] localVarHttpContentTypes =
		{
		};
		var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

		// to determine the Accept header
		string[] localVarHttpHeaderAccepts =
		{
			"application/json"
		};
		var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
		if (localVarHttpHeaderAccept != null)
			localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

		if (invoiceId != null)
			localVarPathParams.Add("invoiceId", Configuration.ApiClient.ParameterToString(invoiceId)); // path parameter
		if (limit != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "limit", limit)); // query parameter
		if (offset != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "offset", offset)); // query parameter
		if (embed != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("multi", "embed", embed)); // query parameter
		// authentication (api_key) required
		if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
			localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");

		// make the HTTP request
		var localVarResponse = (IRestResponse)await Configuration.ApiClient.CallApiAsync(localVarPath,
			Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
			localVarFileParams,
			localVarPathParams, localVarHttpContentType);

		var localVarStatusCode = (int)localVarResponse.StatusCode;

		if (ExceptionFactory != null)
		{
			var exception = ExceptionFactory("GetInvoicePositionsById", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse20022>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse20022)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse20022)));
	}

	/// <summary>
	///     Retrieve invoices There are a multitude of parameter which can be used to filter. A few of them are attached but
	///     for a complete list please check out &lt;a href&#x3D;&#x27;
	///     https://api.sevdesk.de/#section/How-to-filter-for-certain-invoices&#x27;&gt;this&lt;/a&gt; list
	/// </summary>
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
	public GetInvoicesResponse GetInvoices(decimal? status = null, string invoiceNumber = null, int? startDate = null,
		int? endDate = null, int? contactId = null, string contactObjectName = null)
	{
		var localVarResponse =
			GetInvoicesWithHttpInfo(status, invoiceNumber, startDate, endDate, contactId, contactObjectName);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Retrieve invoices There are a multitude of parameter which can be used to filter. A few of them are attached but
	///     for a complete list please check out &lt;a href&#x3D;&#x27;
	///     https://api.sevdesk.de/#section/How-to-filter-for-certain-invoices&#x27;&gt;this&lt;/a&gt; list
	/// </summary>
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
	public ApiResponse<GetInvoicesResponse> GetInvoicesWithHttpInfo(decimal? status = null, string invoiceNumber = null,
		int? startDate = null, int? endDate = null, int? contactId = null, string contactObjectName = null)
	{
		var localVarPath = "/Invoice";
		var localVarPathParams = new Dictionary<string, string>();
		var localVarQueryParams = new List<KeyValuePair<string, string>>();
		var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
		var localVarFormParams = new Dictionary<string, string>();
		var localVarFileParams = new Dictionary<string, FileParameter>();
		object localVarPostBody = null;

		// to determine the Content-Type header
		string[] localVarHttpContentTypes =
		{
		};
		var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

		// to determine the Accept header
		string[] localVarHttpHeaderAccepts =
		{
			"application/json"
		};
		var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
		if (localVarHttpHeaderAccept != null)
			localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

		if (status != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "status", status)); // query parameter
		if (invoiceNumber != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "invoiceNumber",
					invoiceNumber)); // query parameter
		if (startDate != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "startDate", startDate)); // query parameter
		if (endDate != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "endDate", endDate)); // query parameter
		if (contactId != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "contact[id]", contactId)); // query parameter
		if (contactObjectName != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "contact[objectName]",
					contactObjectName)); // query parameter
		// authentication (api_key) required
		if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
			localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");

		// make the HTTP request
		var localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
			Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
			localVarFileParams,
			localVarPathParams, localVarHttpContentType);

		var localVarStatusCode = (int)localVarResponse.StatusCode;

		if (ExceptionFactory != null)
		{
			var exception = ExceptionFactory("GetInvoices", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<GetInvoicesResponse>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(GetInvoicesResponse)Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetInvoicesResponse)));
	}

	/// <summary>
	///     Retrieve invoices There are a multitude of parameter which can be used to filter. A few of them are attached but
	///     for a complete list please check out &lt;a href&#x3D;&#x27;
	///     https://api.sevdesk.de/#section/How-to-filter-for-certain-invoices&#x27;&gt;this&lt;/a&gt; list
	/// </summary>
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
	public async Task<GetInvoicesResponse> GetInvoicesAsync(decimal? status = null, string invoiceNumber = null,
		int? startDate = null, int? endDate = null, int? contactId = null, string contactObjectName = null)
	{
		var localVarResponse =
			await GetInvoicesAsyncWithHttpInfo(status, invoiceNumber, startDate, endDate, contactId, contactObjectName);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Retrieve invoices There are a multitude of parameter which can be used to filter. A few of them are attached but
	///     for a complete list please check out &lt;a href&#x3D;&#x27;
	///     https://api.sevdesk.de/#section/How-to-filter-for-certain-invoices&#x27;&gt;this&lt;/a&gt; list
	/// </summary>
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
	public async Task<ApiResponse<GetInvoicesResponse>> GetInvoicesAsyncWithHttpInfo(decimal? status = null,
		string invoiceNumber = null, int? startDate = null, int? endDate = null, int? contactId = null,
		string contactObjectName = null)
	{
		var localVarPath = "/Invoice";
		var localVarPathParams = new Dictionary<string, string>();
		var localVarQueryParams = new List<KeyValuePair<string, string>>();
		var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
		var localVarFormParams = new Dictionary<string, string>();
		var localVarFileParams = new Dictionary<string, FileParameter>();
		object localVarPostBody = null;

		// to determine the Content-Type header
		string[] localVarHttpContentTypes =
		{
		};
		var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

		// to determine the Accept header
		string[] localVarHttpHeaderAccepts =
		{
			"application/json"
		};
		var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
		if (localVarHttpHeaderAccept != null)
			localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

		if (status != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "status", status)); // query parameter
		if (invoiceNumber != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "invoiceNumber",
					invoiceNumber)); // query parameter
		if (startDate != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "startDate", startDate)); // query parameter
		if (endDate != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "endDate", endDate)); // query parameter
		if (contactId != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "contact[id]", contactId)); // query parameter
		if (contactObjectName != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "contact[objectName]",
					contactObjectName)); // query parameter
		// authentication (api_key) required
		if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
			localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");

		// make the HTTP request
		var localVarResponse = (IRestResponse)await Configuration.ApiClient.CallApiAsync(localVarPath,
			Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
			localVarFileParams,
			localVarPathParams, localVarHttpContentType);

		var localVarStatusCode = (int)localVarResponse.StatusCode;

		if (ExceptionFactory != null)
		{
			var exception = ExceptionFactory("GetInvoices", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<GetInvoicesResponse>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(GetInvoicesResponse)Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetInvoicesResponse)));
	}

	/// <summary>
	///     Check if an invoice is already partially paid Returns &#x27;true&#x27; if the given invoice is partially paid -
	///     &#x27;false&#x27; if it is not.      Invoices which are completely paid are regarded as not partially paid.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to return</param>
	/// <returns>InlineResponse20011</returns>
	public InlineResponse20011 GetIsInvoicePartiallyPaid(int? invoiceId)
	{
		var localVarResponse = GetIsInvoicePartiallyPaidWithHttpInfo(invoiceId);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Check if an invoice is already partially paid Returns &#x27;true&#x27; if the given invoice is partially paid -
	///     &#x27;false&#x27; if it is not.      Invoices which are completely paid are regarded as not partially paid.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to return</param>
	/// <returns>ApiResponse of InlineResponse20011</returns>
	public ApiResponse<InlineResponse20011> GetIsInvoicePartiallyPaidWithHttpInfo(int? invoiceId)
	{
		// verify the required parameter 'invoiceId' is set
		if (invoiceId == null)
			throw new ApiException(400,
				"Missing required parameter 'invoiceId' when calling InvoiceApi->GetIsInvoicePartiallyPaid");

		var localVarPath = "/Invoice/{invoiceId}/getIsPartiallyPaid";
		var localVarPathParams = new Dictionary<string, string>();
		var localVarQueryParams = new List<KeyValuePair<string, string>>();
		var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
		var localVarFormParams = new Dictionary<string, string>();
		var localVarFileParams = new Dictionary<string, FileParameter>();
		object localVarPostBody = null;

		// to determine the Content-Type header
		string[] localVarHttpContentTypes =
		{
		};
		var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

		// to determine the Accept header
		string[] localVarHttpHeaderAccepts =
		{
			"application/json"
		};
		var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
		if (localVarHttpHeaderAccept != null)
			localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

		if (invoiceId != null)
			localVarPathParams.Add("invoiceId", Configuration.ApiClient.ParameterToString(invoiceId)); // path parameter
		// authentication (api_key) required
		if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
			localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");

		// make the HTTP request
		var localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
			Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
			localVarFileParams,
			localVarPathParams, localVarHttpContentType);

		var localVarStatusCode = (int)localVarResponse.StatusCode;

		if (ExceptionFactory != null)
		{
			var exception = ExceptionFactory("GetIsInvoicePartiallyPaid", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse20011>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse20011)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse20011)));
	}

	/// <summary>
	///     Check if an invoice is already partially paid Returns &#x27;true&#x27; if the given invoice is partially paid -
	///     &#x27;false&#x27; if it is not.      Invoices which are completely paid are regarded as not partially paid.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to return</param>
	/// <returns>Task of InlineResponse20011</returns>
	public async Task<InlineResponse20011> GetIsInvoicePartiallyPaidAsync(int? invoiceId)
	{
		var localVarResponse = await GetIsInvoicePartiallyPaidAsyncWithHttpInfo(invoiceId);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Check if an invoice is already partially paid Returns &#x27;true&#x27; if the given invoice is partially paid -
	///     &#x27;false&#x27; if it is not.      Invoices which are completely paid are regarded as not partially paid.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to return</param>
	/// <returns>Task of ApiResponse (InlineResponse20011)</returns>
	public async Task<ApiResponse<InlineResponse20011>> GetIsInvoicePartiallyPaidAsyncWithHttpInfo(int? invoiceId)
	{
		// verify the required parameter 'invoiceId' is set
		if (invoiceId == null)
			throw new ApiException(400,
				"Missing required parameter 'invoiceId' when calling InvoiceApi->GetIsInvoicePartiallyPaid");

		var localVarPath = "/Invoice/{invoiceId}/getIsPartiallyPaid";
		var localVarPathParams = new Dictionary<string, string>();
		var localVarQueryParams = new List<KeyValuePair<string, string>>();
		var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
		var localVarFormParams = new Dictionary<string, string>();
		var localVarFileParams = new Dictionary<string, FileParameter>();
		object localVarPostBody = null;

		// to determine the Content-Type header
		string[] localVarHttpContentTypes =
		{
		};
		var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

		// to determine the Accept header
		string[] localVarHttpHeaderAccepts =
		{
			"application/json"
		};
		var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
		if (localVarHttpHeaderAccept != null)
			localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

		if (invoiceId != null)
			localVarPathParams.Add("invoiceId", Configuration.ApiClient.ParameterToString(invoiceId)); // path parameter
		// authentication (api_key) required
		if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
			localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");

		// make the HTTP request
		var localVarResponse = (IRestResponse)await Configuration.ApiClient.CallApiAsync(localVarPath,
			Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
			localVarFileParams,
			localVarPathParams, localVarHttpContentType);

		var localVarStatusCode = (int)localVarResponse.StatusCode;

		if (ExceptionFactory != null)
		{
			var exception = ExceptionFactory("GetIsInvoicePartiallyPaid", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse20011>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse20011)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse20011)));
	}

	/// <summary>
	///     Retrieve pdf document of an invoice Retrieves the pdf document of an invoice with additional metadata.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice from which you want the pdf</param>
	/// <param name="download">If u want to download the pdf of the invoice. (optional)</param>
	/// <param name="preventSendBy">Defines if u want to send the invoice. (optional)</param>
	/// <returns>CreditNoteGetPdfResponse</returns>
	public CreditNoteGetPdfResponse InvoiceGetPdf(int? invoiceId, bool? download = null, bool? preventSendBy = null)
	{
		var localVarResponse = InvoiceGetPdfWithHttpInfo(invoiceId, download, preventSendBy);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Retrieve pdf document of an invoice Retrieves the pdf document of an invoice with additional metadata.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice from which you want the pdf</param>
	/// <param name="download">If u want to download the pdf of the invoice. (optional)</param>
	/// <param name="preventSendBy">Defines if u want to send the invoice. (optional)</param>
	/// <returns>ApiResponse of CreditNoteGetPdfResponse</returns>
	public ApiResponse<CreditNoteGetPdfResponse> InvoiceGetPdfWithHttpInfo(int? invoiceId, bool? download = null,
		bool? preventSendBy = null)
	{
		// verify the required parameter 'invoiceId' is set
		if (invoiceId == null)
			throw new ApiException(400,
				"Missing required parameter 'invoiceId' when calling InvoiceApi->InvoiceGetPdf");

		var localVarPath = "/Invoice/{invoiceId}/getPdf";
		var localVarPathParams = new Dictionary<string, string>();
		var localVarQueryParams = new List<KeyValuePair<string, string>>();
		var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
		var localVarFormParams = new Dictionary<string, string>();
		var localVarFileParams = new Dictionary<string, FileParameter>();
		object localVarPostBody = null;

		// to determine the Content-Type header
		string[] localVarHttpContentTypes =
		{
		};
		var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

		// to determine the Accept header
		string[] localVarHttpHeaderAccepts =
		{
			"application/json"
		};
		var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
		if (localVarHttpHeaderAccept != null)
			localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

		if (invoiceId != null)
			localVarPathParams.Add("invoiceId", Configuration.ApiClient.ParameterToString(invoiceId)); // path parameter
		if (download != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "download", download)); // query parameter
		if (preventSendBy != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "preventSendBy",
					preventSendBy)); // query parameter
		// authentication (api_key) required
		if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
			localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");

		// make the HTTP request
		var localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
			Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
			localVarFileParams,
			localVarPathParams, localVarHttpContentType);

		var localVarStatusCode = (int)localVarResponse.StatusCode;

		if (ExceptionFactory != null)
		{
			var exception = ExceptionFactory("InvoiceGetPdf", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<CreditNoteGetPdfResponse>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(CreditNoteGetPdfResponse)Configuration.ApiClient.Deserialize(localVarResponse,
				typeof(CreditNoteGetPdfResponse)));
	}

	/// <summary>
	///     Retrieve pdf document of an invoice Retrieves the pdf document of an invoice with additional metadata.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice from which you want the pdf</param>
	/// <param name="download">If u want to download the pdf of the invoice. (optional)</param>
	/// <param name="preventSendBy">Defines if u want to send the invoice. (optional)</param>
	/// <returns>Task of CreditNoteGetPdfResponse</returns>
	public async Task<CreditNoteGetPdfResponse> InvoiceGetPdfAsync(int? invoiceId, bool? download = null,
		bool? preventSendBy = null)
	{
		var localVarResponse = await InvoiceGetPdfAsyncWithHttpInfo(invoiceId, download, preventSendBy);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Retrieve pdf document of an invoice Retrieves the pdf document of an invoice with additional metadata.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice from which you want the pdf</param>
	/// <param name="download">If u want to download the pdf of the invoice. (optional)</param>
	/// <param name="preventSendBy">Defines if u want to send the invoice. (optional)</param>
	/// <returns>Task of ApiResponse (CreditNoteGetPdfResponse)</returns>
	public async Task<ApiResponse<CreditNoteGetPdfResponse>> InvoiceGetPdfAsyncWithHttpInfo(int? invoiceId,
		bool? download = null, bool? preventSendBy = null)
	{
		// verify the required parameter 'invoiceId' is set
		if (invoiceId == null)
			throw new ApiException(400,
				"Missing required parameter 'invoiceId' when calling InvoiceApi->InvoiceGetPdf");

		var localVarPath = "/Invoice/{invoiceId}/getPdf";
		var localVarPathParams = new Dictionary<string, string>();
		var localVarQueryParams = new List<KeyValuePair<string, string>>();
		var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
		var localVarFormParams = new Dictionary<string, string>();
		var localVarFileParams = new Dictionary<string, FileParameter>();
		object localVarPostBody = null;

		// to determine the Content-Type header
		string[] localVarHttpContentTypes =
		{
		};
		var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

		// to determine the Accept header
		string[] localVarHttpHeaderAccepts =
		{
			"application/json"
		};
		var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
		if (localVarHttpHeaderAccept != null)
			localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

		if (invoiceId != null)
			localVarPathParams.Add("invoiceId", Configuration.ApiClient.ParameterToString(invoiceId)); // path parameter
		if (download != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "download", download)); // query parameter
		if (preventSendBy != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "preventSendBy",
					preventSendBy)); // query parameter
		// authentication (api_key) required
		if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
			localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");

		// make the HTTP request
		var localVarResponse = (IRestResponse)await Configuration.ApiClient.CallApiAsync(localVarPath,
			Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
			localVarFileParams,
			localVarPathParams, localVarHttpContentType);

		var localVarStatusCode = (int)localVarResponse.StatusCode;

		if (ExceptionFactory != null)
		{
			var exception = ExceptionFactory("InvoiceGetPdf", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<CreditNoteGetPdfResponse>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(CreditNoteGetPdfResponse)Configuration.ApiClient.Deserialize(localVarResponse,
				typeof(CreditNoteGetPdfResponse)));
	}

	/// <summary>
	///     Render the pdf document of an invoice Using this endpoint you can render the pdf document of an invoice.&lt;br&gt;
	///     Use cases for this are the retrieval of the pdf location or the forceful re-render of a already sent invoice.&lt;br
	///     &gt;       Please be aware that changing an invoice after it has been sent to a customer is not an allowed
	///     bookkeeping process.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to render</param>
	/// <param name="body">Define if the document should be forcefully re-rendered. (optional)</param>
	/// <returns>InlineResponse2011</returns>
	public InlineResponse2011 InvoiceRender(int? invoiceId, InvoiceIdRenderBody body = null)
	{
		var localVarResponse = InvoiceRenderWithHttpInfo(invoiceId, body);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Render the pdf document of an invoice Using this endpoint you can render the pdf document of an invoice.&lt;br&gt;
	///     Use cases for this are the retrieval of the pdf location or the forceful re-render of a already sent invoice.&lt;br
	///     &gt;       Please be aware that changing an invoice after it has been sent to a customer is not an allowed
	///     bookkeeping process.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to render</param>
	/// <param name="body">Define if the document should be forcefully re-rendered. (optional)</param>
	/// <returns>ApiResponse of InlineResponse2011</returns>
	public ApiResponse<InlineResponse2011> InvoiceRenderWithHttpInfo(int? invoiceId, InvoiceIdRenderBody body = null)
	{
		// verify the required parameter 'invoiceId' is set
		if (invoiceId == null)
			throw new ApiException(400,
				"Missing required parameter 'invoiceId' when calling InvoiceApi->InvoiceRender");

		var localVarPath = "/Invoice/{invoiceId}/render";
		var localVarPathParams = new Dictionary<string, string>();
		var localVarQueryParams = new List<KeyValuePair<string, string>>();
		var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
		var localVarFormParams = new Dictionary<string, string>();
		var localVarFileParams = new Dictionary<string, FileParameter>();
		object localVarPostBody = null;

		// to determine the Content-Type header
		string[] localVarHttpContentTypes =
		{
			"application/json"
		};
		var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

		// to determine the Accept header
		string[] localVarHttpHeaderAccepts =
		{
			"application/json"
		};
		var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
		if (localVarHttpHeaderAccept != null)
			localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

		if (invoiceId != null)
			localVarPathParams.Add("invoiceId", Configuration.ApiClient.ParameterToString(invoiceId)); // path parameter
		if (body != null && body.GetType() != typeof(byte[]))
			localVarPostBody = Configuration.ApiClient.Serialize(body); // http body (model) parameter
		else
			localVarPostBody = body; // byte array
		// authentication (api_key) required
		if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
			localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");

		// make the HTTP request
		var localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
			Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
			localVarFileParams,
			localVarPathParams, localVarHttpContentType);

		var localVarStatusCode = (int)localVarResponse.StatusCode;

		if (ExceptionFactory != null)
		{
			var exception = ExceptionFactory("InvoiceRender", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse2011>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse2011)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2011)));
	}

	/// <summary>
	///     Render the pdf document of an invoice Using this endpoint you can render the pdf document of an invoice.&lt;br&gt;
	///     Use cases for this are the retrieval of the pdf location or the forceful re-render of a already sent invoice.&lt;br
	///     &gt;       Please be aware that changing an invoice after it has been sent to a customer is not an allowed
	///     bookkeeping process.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to render</param>
	/// <param name="body">Define if the document should be forcefully re-rendered. (optional)</param>
	/// <returns>Task of InlineResponse2011</returns>
	public async Task<InlineResponse2011> InvoiceRenderAsync(int? invoiceId, InvoiceIdRenderBody body = null)
	{
		var localVarResponse = await InvoiceRenderAsyncWithHttpInfo(invoiceId, body);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Render the pdf document of an invoice Using this endpoint you can render the pdf document of an invoice.&lt;br&gt;
	///     Use cases for this are the retrieval of the pdf location or the forceful re-render of a already sent invoice.&lt;br
	///     &gt;       Please be aware that changing an invoice after it has been sent to a customer is not an allowed
	///     bookkeeping process.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to render</param>
	/// <param name="body">Define if the document should be forcefully re-rendered. (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse2011)</returns>
	public async Task<ApiResponse<InlineResponse2011>> InvoiceRenderAsyncWithHttpInfo(int? invoiceId,
		InvoiceIdRenderBody body = null)
	{
		// verify the required parameter 'invoiceId' is set
		if (invoiceId == null)
			throw new ApiException(400,
				"Missing required parameter 'invoiceId' when calling InvoiceApi->InvoiceRender");

		var localVarPath = "/Invoice/{invoiceId}/render";
		var localVarPathParams = new Dictionary<string, string>();
		var localVarQueryParams = new List<KeyValuePair<string, string>>();
		var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
		var localVarFormParams = new Dictionary<string, string>();
		var localVarFileParams = new Dictionary<string, FileParameter>();
		object localVarPostBody = null;

		// to determine the Content-Type header
		string[] localVarHttpContentTypes =
		{
			"application/json"
		};
		var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

		// to determine the Accept header
		string[] localVarHttpHeaderAccepts =
		{
			"application/json"
		};
		var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
		if (localVarHttpHeaderAccept != null)
			localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

		if (invoiceId != null)
			localVarPathParams.Add("invoiceId", Configuration.ApiClient.ParameterToString(invoiceId)); // path parameter
		if (body != null && body.GetType() != typeof(byte[]))
			localVarPostBody = Configuration.ApiClient.Serialize(body); // http body (model) parameter
		else
			localVarPostBody = body; // byte array
		// authentication (api_key) required
		if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
			localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");

		// make the HTTP request
		var localVarResponse = (IRestResponse)await Configuration.ApiClient.CallApiAsync(localVarPath,
			Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
			localVarFileParams,
			localVarPathParams, localVarHttpContentType);

		var localVarStatusCode = (int)localVarResponse.StatusCode;

		if (ExceptionFactory != null)
		{
			var exception = ExceptionFactory("InvoiceRender", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse2011>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse2011)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2011)));
	}

	/// <summary>
	///     Mark invoice as sent Marks an invoice as sent by a chosen send type.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to mark as sent</param>
	/// <param name="body">Specify the send type (optional)</param>
	/// <returns>InlineResponse20029</returns>
	public InlineResponse20029 InvoiceSendBy(int? invoiceId, InvoiceIdSendByBody body = null)
	{
		var localVarResponse = InvoiceSendByWithHttpInfo(invoiceId, body);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Mark invoice as sent Marks an invoice as sent by a chosen send type.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to mark as sent</param>
	/// <param name="body">Specify the send type (optional)</param>
	/// <returns>ApiResponse of InlineResponse20029</returns>
	public ApiResponse<InlineResponse20029> InvoiceSendByWithHttpInfo(int? invoiceId, InvoiceIdSendByBody body = null)
	{
		// verify the required parameter 'invoiceId' is set
		if (invoiceId == null)
			throw new ApiException(400,
				"Missing required parameter 'invoiceId' when calling InvoiceApi->InvoiceSendBy");

		var localVarPath = "/Invoice/{invoiceId}/sendBy";
		var localVarPathParams = new Dictionary<string, string>();
		var localVarQueryParams = new List<KeyValuePair<string, string>>();
		var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
		var localVarFormParams = new Dictionary<string, string>();
		var localVarFileParams = new Dictionary<string, FileParameter>();
		object localVarPostBody = null;

		// to determine the Content-Type header
		string[] localVarHttpContentTypes =
		{
			"application/json"
		};
		var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

		// to determine the Accept header
		string[] localVarHttpHeaderAccepts =
		{
			"application/json"
		};
		var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
		if (localVarHttpHeaderAccept != null)
			localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

		if (invoiceId != null)
			localVarPathParams.Add("invoiceId", Configuration.ApiClient.ParameterToString(invoiceId)); // path parameter
		if (body != null && body.GetType() != typeof(byte[]))
			localVarPostBody = Configuration.ApiClient.Serialize(body); // http body (model) parameter
		else
			localVarPostBody = body; // byte array
		// authentication (api_key) required
		if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
			localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");

		// make the HTTP request
		var localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
			Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
			localVarFileParams,
			localVarPathParams, localVarHttpContentType);

		var localVarStatusCode = (int)localVarResponse.StatusCode;

		if (ExceptionFactory != null)
		{
			var exception = ExceptionFactory("InvoiceSendBy", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse20029>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse20029)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse20029)));
	}

	/// <summary>
	///     Mark invoice as sent Marks an invoice as sent by a chosen send type.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to mark as sent</param>
	/// <param name="body">Specify the send type (optional)</param>
	/// <returns>Task of InlineResponse20029</returns>
	public async Task<InlineResponse20029> InvoiceSendByAsync(int? invoiceId, InvoiceIdSendByBody body = null)
	{
		var localVarResponse = await InvoiceSendByAsyncWithHttpInfo(invoiceId, body);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Mark invoice as sent Marks an invoice as sent by a chosen send type.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to mark as sent</param>
	/// <param name="body">Specify the send type (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse20029)</returns>
	public async Task<ApiResponse<InlineResponse20029>> InvoiceSendByAsyncWithHttpInfo(int? invoiceId,
		InvoiceIdSendByBody body = null)
	{
		// verify the required parameter 'invoiceId' is set
		if (invoiceId == null)
			throw new ApiException(400,
				"Missing required parameter 'invoiceId' when calling InvoiceApi->InvoiceSendBy");

		var localVarPath = "/Invoice/{invoiceId}/sendBy";
		var localVarPathParams = new Dictionary<string, string>();
		var localVarQueryParams = new List<KeyValuePair<string, string>>();
		var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
		var localVarFormParams = new Dictionary<string, string>();
		var localVarFileParams = new Dictionary<string, FileParameter>();
		object localVarPostBody = null;

		// to determine the Content-Type header
		string[] localVarHttpContentTypes =
		{
			"application/json"
		};
		var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

		// to determine the Accept header
		string[] localVarHttpHeaderAccepts =
		{
			"application/json"
		};
		var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
		if (localVarHttpHeaderAccept != null)
			localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

		if (invoiceId != null)
			localVarPathParams.Add("invoiceId", Configuration.ApiClient.ParameterToString(invoiceId)); // path parameter
		if (body != null && body.GetType() != typeof(byte[]))
			localVarPostBody = Configuration.ApiClient.Serialize(body); // http body (model) parameter
		else
			localVarPostBody = body; // byte array
		// authentication (api_key) required
		if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
			localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");

		// make the HTTP request
		var localVarResponse = (IRestResponse)await Configuration.ApiClient.CallApiAsync(localVarPath,
			Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
			localVarFileParams,
			localVarPathParams, localVarHttpContentType);

		var localVarStatusCode = (int)localVarResponse.StatusCode;

		if (ExceptionFactory != null)
		{
			var exception = ExceptionFactory("InvoiceSendBy", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse20029>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse20029)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse20029)));
	}

	/// <summary>
	///     Send invoice via email This endpoint sends the specified invoice to a customer via email.&lt;br&gt;      This will
	///     automatically mark the invoice as sent.&lt;br&gt;      Please note, that in production an invoice is not allowed to
	///     be changed after this happened!
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to be sent via email</param>
	/// <param name="body">Mail data (optional)</param>
	/// <returns>InlineResponse201</returns>
	public InlineResponse201 SendInvoiceViaEMail(int? invoiceId, InvoiceIdSendViaEmailBody body = null)
	{
		var localVarResponse = SendInvoiceViaEMailWithHttpInfo(invoiceId, body);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Send invoice via email This endpoint sends the specified invoice to a customer via email.&lt;br&gt;      This will
	///     automatically mark the invoice as sent.&lt;br&gt;      Please note, that in production an invoice is not allowed to
	///     be changed after this happened!
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to be sent via email</param>
	/// <param name="body">Mail data (optional)</param>
	/// <returns>ApiResponse of InlineResponse201</returns>
	public ApiResponse<InlineResponse201> SendInvoiceViaEMailWithHttpInfo(int? invoiceId,
		InvoiceIdSendViaEmailBody body = null)
	{
		// verify the required parameter 'invoiceId' is set
		if (invoiceId == null)
			throw new ApiException(400,
				"Missing required parameter 'invoiceId' when calling InvoiceApi->SendInvoiceViaEMail");

		var localVarPath = "/Invoice/{invoiceId}/sendViaEmail";
		var localVarPathParams = new Dictionary<string, string>();
		var localVarQueryParams = new List<KeyValuePair<string, string>>();
		var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
		var localVarFormParams = new Dictionary<string, string>();
		var localVarFileParams = new Dictionary<string, FileParameter>();
		object localVarPostBody = null;

		// to determine the Content-Type header
		string[] localVarHttpContentTypes =
		{
			"application/json"
		};
		var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

		// to determine the Accept header
		string[] localVarHttpHeaderAccepts =
		{
			"application/json"
		};
		var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
		if (localVarHttpHeaderAccept != null)
			localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

		if (invoiceId != null)
			localVarPathParams.Add("invoiceId", Configuration.ApiClient.ParameterToString(invoiceId)); // path parameter
		if (body != null && body.GetType() != typeof(byte[]))
			localVarPostBody = Configuration.ApiClient.Serialize(body); // http body (model) parameter
		else
			localVarPostBody = body; // byte array
		// authentication (api_key) required
		if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
			localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");

		// make the HTTP request
		var localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
			Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
			localVarFileParams,
			localVarPathParams, localVarHttpContentType);

		var localVarStatusCode = (int)localVarResponse.StatusCode;

		if (ExceptionFactory != null)
		{
			var exception = ExceptionFactory("SendInvoiceViaEMail", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse201>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse201)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse201)));
	}

	/// <summary>
	///     Send invoice via email This endpoint sends the specified invoice to a customer via email.&lt;br&gt;      This will
	///     automatically mark the invoice as sent.&lt;br&gt;      Please note, that in production an invoice is not allowed to
	///     be changed after this happened!
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to be sent via email</param>
	/// <param name="body">Mail data (optional)</param>
	/// <returns>Task of InlineResponse201</returns>
	public async Task<InlineResponse201> SendInvoiceViaEMailAsync(int? invoiceId, InvoiceIdSendViaEmailBody body = null)
	{
		var localVarResponse = await SendInvoiceViaEMailAsyncWithHttpInfo(invoiceId, body);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Send invoice via email This endpoint sends the specified invoice to a customer via email.&lt;br&gt;      This will
	///     automatically mark the invoice as sent.&lt;br&gt;      Please note, that in production an invoice is not allowed to
	///     be changed after this happened!
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to be sent via email</param>
	/// <param name="body">Mail data (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse201)</returns>
	public async Task<ApiResponse<InlineResponse201>> SendInvoiceViaEMailAsyncWithHttpInfo(int? invoiceId,
		InvoiceIdSendViaEmailBody body = null)
	{
		// verify the required parameter 'invoiceId' is set
		if (invoiceId == null)
			throw new ApiException(400,
				"Missing required parameter 'invoiceId' when calling InvoiceApi->SendInvoiceViaEMail");

		var localVarPath = "/Invoice/{invoiceId}/sendViaEmail";
		var localVarPathParams = new Dictionary<string, string>();
		var localVarQueryParams = new List<KeyValuePair<string, string>>();
		var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
		var localVarFormParams = new Dictionary<string, string>();
		var localVarFileParams = new Dictionary<string, FileParameter>();
		object localVarPostBody = null;

		// to determine the Content-Type header
		string[] localVarHttpContentTypes =
		{
			"application/json"
		};
		var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

		// to determine the Accept header
		string[] localVarHttpHeaderAccepts =
		{
			"application/json"
		};
		var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
		if (localVarHttpHeaderAccept != null)
			localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

		if (invoiceId != null)
			localVarPathParams.Add("invoiceId", Configuration.ApiClient.ParameterToString(invoiceId)); // path parameter
		if (body != null && body.GetType() != typeof(byte[]))
			localVarPostBody = Configuration.ApiClient.Serialize(body); // http body (model) parameter
		else
			localVarPostBody = body; // byte array
		// authentication (api_key) required
		if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
			localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");

		// make the HTTP request
		var localVarResponse = (IRestResponse)await Configuration.ApiClient.CallApiAsync(localVarPath,
			Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
			localVarFileParams,
			localVarPathParams, localVarHttpContentType);

		var localVarStatusCode = (int)localVarResponse.StatusCode;

		if (ExceptionFactory != null)
		{
			var exception = ExceptionFactory("SendInvoiceViaEMail", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse201>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse201)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse201)));
	}

	/// <summary>
	///     Sets the base path of the API client.
	/// </summary>
	/// <value>The base path</value>
	[Obsolete(
		"SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
	public void SetBasePath(string basePath)
	{
		// do nothing
	}

	/// <summary>
	///     Gets the default header.
	/// </summary>
	/// <returns>Dictionary of HTTP header</returns>
	[Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
	public IDictionary<string, string> DefaultHeader()
	{
		return new ReadOnlyDictionary<string, string>(Configuration.DefaultHeader);
	}

	/// <summary>
	///     Add default header.
	/// </summary>
	/// <param name="key">Header field name.</param>
	/// <param name="value">Header field value.</param>
	/// <returns></returns>
	[Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
	public void AddDefaultHeader(string key, string value)
	{
		Configuration.AddDefaultHeader(key, value);
	}
}