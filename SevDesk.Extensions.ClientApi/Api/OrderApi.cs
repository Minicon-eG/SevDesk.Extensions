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
public class OrderApi : IOrderApi
{
	private ExceptionFactory _exceptionFactory = (name, response) => null;

	/// <summary>
	///     Initializes a new instance of the <see cref="OrderApi" /> class.
	/// </summary>
	/// <returns></returns>
	public OrderApi(string basePath)
	{
		Configuration = new Configuration { BasePath = basePath };

		ExceptionFactory = Configuration.DefaultExceptionFactory;
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="OrderApi" /> class
	/// </summary>
	/// <returns></returns>
	public OrderApi()
	{
		Configuration = Configuration.Default;

		ExceptionFactory = Configuration.DefaultExceptionFactory;
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="OrderApi" /> class
	///     using Configuration object
	/// </summary>
	/// <param name="configuration">An instance of Configuration</param>
	/// <returns></returns>
	public OrderApi(Configuration configuration = null)
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
	///     Create contract note from order Create contract note from order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">the id of the order</param>
	/// <param name="orderObjectName">Model name, which is &#x27;Order&#x27;</param>
	/// <param name="body">Create contract note (optional)</param>
	/// <returns>InlineResponse20010</returns>
	public InlineResponse20010 CreateContractNoteFromOrder(int? orderId, string orderObjectName,
		ModelCreatePackingListFromOrder body = null)
	{
		var localVarResponse = CreateContractNoteFromOrderWithHttpInfo(orderId, orderObjectName, body);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Create contract note from order Create contract note from order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">the id of the order</param>
	/// <param name="orderObjectName">Model name, which is &#x27;Order&#x27;</param>
	/// <param name="body">Create contract note (optional)</param>
	/// <returns>ApiResponse of InlineResponse20010</returns>
	public ApiResponse<InlineResponse20010> CreateContractNoteFromOrderWithHttpInfo(int? orderId,
		string orderObjectName, ModelCreatePackingListFromOrder body = null)
	{
		// verify the required parameter 'orderId' is set
		if (orderId == null)
			throw new ApiException(400,
				"Missing required parameter 'orderId' when calling OrderApi->CreateContractNoteFromOrder");
		// verify the required parameter 'orderObjectName' is set
		if (orderObjectName == null)
			throw new ApiException(400,
				"Missing required parameter 'orderObjectName' when calling OrderApi->CreateContractNoteFromOrder");

		var localVarPath = "/Order/Factory/createContractNoteFromOrder";
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

		if (orderId != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "order[id]", orderId)); // query parameter
		if (orderObjectName != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "order[objectName]",
					orderObjectName)); // query parameter
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
			var exception = ExceptionFactory("CreateContractNoteFromOrder", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse20010>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse20010)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse20010)));
	}

	/// <summary>
	///     Create contract note from order Create contract note from order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">the id of the order</param>
	/// <param name="orderObjectName">Model name, which is &#x27;Order&#x27;</param>
	/// <param name="body">Create contract note (optional)</param>
	/// <returns>Task of InlineResponse20010</returns>
	public async Task<InlineResponse20010> CreateContractNoteFromOrderAsync(int? orderId, string orderObjectName,
		ModelCreatePackingListFromOrder body = null)
	{
		var localVarResponse = await CreateContractNoteFromOrderAsyncWithHttpInfo(orderId, orderObjectName, body);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Create contract note from order Create contract note from order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">the id of the order</param>
	/// <param name="orderObjectName">Model name, which is &#x27;Order&#x27;</param>
	/// <param name="body">Create contract note (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse20010)</returns>
	public async Task<ApiResponse<InlineResponse20010>> CreateContractNoteFromOrderAsyncWithHttpInfo(int? orderId,
		string orderObjectName, ModelCreatePackingListFromOrder body = null)
	{
		// verify the required parameter 'orderId' is set
		if (orderId == null)
			throw new ApiException(400,
				"Missing required parameter 'orderId' when calling OrderApi->CreateContractNoteFromOrder");
		// verify the required parameter 'orderObjectName' is set
		if (orderObjectName == null)
			throw new ApiException(400,
				"Missing required parameter 'orderObjectName' when calling OrderApi->CreateContractNoteFromOrder");

		var localVarPath = "/Order/Factory/createContractNoteFromOrder";
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

		if (orderId != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "order[id]", orderId)); // query parameter
		if (orderObjectName != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "order[objectName]",
					orderObjectName)); // query parameter
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
			var exception = ExceptionFactory("CreateContractNoteFromOrder", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse20010>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse20010)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse20010)));
	}

	/// <summary>
	///     Create a new order Creates an order to which positions can be added later.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">
	///     Creation data. Please be aware, that you need to provide at least all required parameter
	///     of the order model! (optional)
	/// </param>
	/// <returns>SaveOrderResponse</returns>
	public SaveOrderResponse CreateOrder(SaveOrder body = null)
	{
		var localVarResponse = CreateOrderWithHttpInfo(body);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Create a new order Creates an order to which positions can be added later.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">
	///     Creation data. Please be aware, that you need to provide at least all required parameter
	///     of the order model! (optional)
	/// </param>
	/// <returns>ApiResponse of SaveOrderResponse</returns>
	public ApiResponse<SaveOrderResponse> CreateOrderWithHttpInfo(SaveOrder body = null)
	{
		var localVarPath = "/Order/Factory/saveOrder";
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
			var exception = ExceptionFactory("CreateOrder", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<SaveOrderResponse>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(SaveOrderResponse)Configuration.ApiClient.Deserialize(localVarResponse, typeof(SaveOrderResponse)));
	}

	/// <summary>
	///     Create a new order Creates an order to which positions can be added later.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">
	///     Creation data. Please be aware, that you need to provide at least all required parameter
	///     of the order model! (optional)
	/// </param>
	/// <returns>Task of SaveOrderResponse</returns>
	public async Task<SaveOrderResponse> CreateOrderAsync(SaveOrder body = null)
	{
		var localVarResponse = await CreateOrderAsyncWithHttpInfo(body);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Create a new order Creates an order to which positions can be added later.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">
	///     Creation data. Please be aware, that you need to provide at least all required parameter
	///     of the order model! (optional)
	/// </param>
	/// <returns>Task of ApiResponse (SaveOrderResponse)</returns>
	public async Task<ApiResponse<SaveOrderResponse>> CreateOrderAsyncWithHttpInfo(SaveOrder body = null)
	{
		var localVarPath = "/Order/Factory/saveOrder";
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
			var exception = ExceptionFactory("CreateOrder", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<SaveOrderResponse>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(SaveOrderResponse)Configuration.ApiClient.Deserialize(localVarResponse, typeof(SaveOrderResponse)));
	}

	/// <summary>
	///     Create packing list from order Create packing list from order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">the id of the order</param>
	/// <param name="orderObjectName">Model name, which is &#x27;Order&#x27;</param>
	/// <param name="body">Create packing list (optional)</param>
	/// <returns>InlineResponse20010</returns>
	public InlineResponse20010 CreatePackingListFromOrder(int? orderId, string orderObjectName,
		ModelCreatePackingListFromOrder body = null)
	{
		var localVarResponse = CreatePackingListFromOrderWithHttpInfo(orderId, orderObjectName, body);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Create packing list from order Create packing list from order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">the id of the order</param>
	/// <param name="orderObjectName">Model name, which is &#x27;Order&#x27;</param>
	/// <param name="body">Create packing list (optional)</param>
	/// <returns>ApiResponse of InlineResponse20010</returns>
	public ApiResponse<InlineResponse20010> CreatePackingListFromOrderWithHttpInfo(int? orderId, string orderObjectName,
		ModelCreatePackingListFromOrder body = null)
	{
		// verify the required parameter 'orderId' is set
		if (orderId == null)
			throw new ApiException(400,
				"Missing required parameter 'orderId' when calling OrderApi->CreatePackingListFromOrder");
		// verify the required parameter 'orderObjectName' is set
		if (orderObjectName == null)
			throw new ApiException(400,
				"Missing required parameter 'orderObjectName' when calling OrderApi->CreatePackingListFromOrder");

		var localVarPath = "/Order/Factory/createPackingListFromOrder";
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

		if (orderId != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "order[id]", orderId)); // query parameter
		if (orderObjectName != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "order[objectName]",
					orderObjectName)); // query parameter
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
			var exception = ExceptionFactory("CreatePackingListFromOrder", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse20010>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse20010)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse20010)));
	}

	/// <summary>
	///     Create packing list from order Create packing list from order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">the id of the order</param>
	/// <param name="orderObjectName">Model name, which is &#x27;Order&#x27;</param>
	/// <param name="body">Create packing list (optional)</param>
	/// <returns>Task of InlineResponse20010</returns>
	public async Task<InlineResponse20010> CreatePackingListFromOrderAsync(int? orderId, string orderObjectName,
		ModelCreatePackingListFromOrder body = null)
	{
		var localVarResponse = await CreatePackingListFromOrderAsyncWithHttpInfo(orderId, orderObjectName, body);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Create packing list from order Create packing list from order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">the id of the order</param>
	/// <param name="orderObjectName">Model name, which is &#x27;Order&#x27;</param>
	/// <param name="body">Create packing list (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse20010)</returns>
	public async Task<ApiResponse<InlineResponse20010>> CreatePackingListFromOrderAsyncWithHttpInfo(int? orderId,
		string orderObjectName, ModelCreatePackingListFromOrder body = null)
	{
		// verify the required parameter 'orderId' is set
		if (orderId == null)
			throw new ApiException(400,
				"Missing required parameter 'orderId' when calling OrderApi->CreatePackingListFromOrder");
		// verify the required parameter 'orderObjectName' is set
		if (orderObjectName == null)
			throw new ApiException(400,
				"Missing required parameter 'orderObjectName' when calling OrderApi->CreatePackingListFromOrder");

		var localVarPath = "/Order/Factory/createPackingListFromOrder";
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

		if (orderId != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "order[id]", orderId)); // query parameter
		if (orderObjectName != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "order[objectName]",
					orderObjectName)); // query parameter
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
			var exception = ExceptionFactory("CreatePackingListFromOrder", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse20010>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse20010)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse20010)));
	}

	/// <summary>
	///     Deletes an order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">Id of order resource to delete</param>
	/// <returns>InlineResponse2003</returns>
	public InlineResponse2003 DeleteOrder(int? orderId)
	{
		var localVarResponse = DeleteOrderWithHttpInfo(orderId);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Deletes an order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">Id of order resource to delete</param>
	/// <returns>ApiResponse of InlineResponse2003</returns>
	public ApiResponse<InlineResponse2003> DeleteOrderWithHttpInfo(int? orderId)
	{
		// verify the required parameter 'orderId' is set
		if (orderId == null)
			throw new ApiException(400, "Missing required parameter 'orderId' when calling OrderApi->DeleteOrder");

		var localVarPath = "/Order/{orderId}";
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

		if (orderId != null)
			localVarPathParams.Add("orderId", Configuration.ApiClient.ParameterToString(orderId)); // path parameter
		// authentication (api_key) required
		if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
			localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");

		// make the HTTP request
		var localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
			Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
			localVarFileParams,
			localVarPathParams, localVarHttpContentType);

		var localVarStatusCode = (int)localVarResponse.StatusCode;

		if (ExceptionFactory != null)
		{
			var exception = ExceptionFactory("DeleteOrder", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse2003>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse2003)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2003)));
	}

	/// <summary>
	///     Deletes an order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">Id of order resource to delete</param>
	/// <returns>Task of InlineResponse2003</returns>
	public async Task<InlineResponse2003> DeleteOrderAsync(int? orderId)
	{
		var localVarResponse = await DeleteOrderAsyncWithHttpInfo(orderId);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Deletes an order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">Id of order resource to delete</param>
	/// <returns>Task of ApiResponse (InlineResponse2003)</returns>
	public async Task<ApiResponse<InlineResponse2003>> DeleteOrderAsyncWithHttpInfo(int? orderId)
	{
		// verify the required parameter 'orderId' is set
		if (orderId == null)
			throw new ApiException(400, "Missing required parameter 'orderId' when calling OrderApi->DeleteOrder");

		var localVarPath = "/Order/{orderId}";
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

		if (orderId != null)
			localVarPathParams.Add("orderId", Configuration.ApiClient.ParameterToString(orderId)); // path parameter
		// authentication (api_key) required
		if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
			localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");

		// make the HTTP request
		var localVarResponse = (IRestResponse)await Configuration.ApiClient.CallApiAsync(localVarPath,
			Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
			localVarFileParams,
			localVarPathParams, localVarHttpContentType);

		var localVarStatusCode = (int)localVarResponse.StatusCode;

		if (ExceptionFactory != null)
		{
			var exception = ExceptionFactory("DeleteOrder", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse2003>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse2003)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2003)));
	}

	/// <summary>
	///     Find order discounts Returns all discounts of an order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return the positions</param>
	/// <param name="limit">limits the number of entries returned (optional)</param>
	/// <param name="offset">set the index where the returned entries start (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>InlineResponse2009</returns>
	public InlineResponse2009 GetDiscounts(int? orderId, int? limit = null, int? offset = null,
		List<string> embed = null)
	{
		var localVarResponse = GetDiscountsWithHttpInfo(orderId, limit, offset, embed);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Find order discounts Returns all discounts of an order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return the positions</param>
	/// <param name="limit">limits the number of entries returned (optional)</param>
	/// <param name="offset">set the index where the returned entries start (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>ApiResponse of InlineResponse2009</returns>
	public ApiResponse<InlineResponse2009> GetDiscountsWithHttpInfo(int? orderId, int? limit = null, int? offset = null,
		List<string> embed = null)
	{
		// verify the required parameter 'orderId' is set
		if (orderId == null)
			throw new ApiException(400, "Missing required parameter 'orderId' when calling OrderApi->GetDiscounts");

		var localVarPath = "/Order/{orderId}/getDiscounts";
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

		if (orderId != null)
			localVarPathParams.Add("orderId", Configuration.ApiClient.ParameterToString(orderId)); // path parameter
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
			var exception = ExceptionFactory("GetDiscounts", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse2009>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse2009)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2009)));
	}

	/// <summary>
	///     Find order discounts Returns all discounts of an order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return the positions</param>
	/// <param name="limit">limits the number of entries returned (optional)</param>
	/// <param name="offset">set the index where the returned entries start (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>Task of InlineResponse2009</returns>
	public async Task<InlineResponse2009> GetDiscountsAsync(int? orderId, int? limit = null, int? offset = null,
		List<string> embed = null)
	{
		var localVarResponse = await GetDiscountsAsyncWithHttpInfo(orderId, limit, offset, embed);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Find order discounts Returns all discounts of an order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return the positions</param>
	/// <param name="limit">limits the number of entries returned (optional)</param>
	/// <param name="offset">set the index where the returned entries start (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>Task of ApiResponse (InlineResponse2009)</returns>
	public async Task<ApiResponse<InlineResponse2009>> GetDiscountsAsyncWithHttpInfo(int? orderId, int? limit = null,
		int? offset = null, List<string> embed = null)
	{
		// verify the required parameter 'orderId' is set
		if (orderId == null)
			throw new ApiException(400, "Missing required parameter 'orderId' when calling OrderApi->GetDiscounts");

		var localVarPath = "/Order/{orderId}/getDiscounts";
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

		if (orderId != null)
			localVarPathParams.Add("orderId", Configuration.ApiClient.ParameterToString(orderId)); // path parameter
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
			var exception = ExceptionFactory("GetDiscounts", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse2009>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse2009)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2009)));
	}

	/// <summary>
	///     Find order by ID Returns a single order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return</param>
	/// <returns>InlineResponse20010</returns>
	public InlineResponse20010 GetOrderById(int? orderId)
	{
		var localVarResponse = GetOrderByIdWithHttpInfo(orderId);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Find order by ID Returns a single order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return</param>
	/// <returns>ApiResponse of InlineResponse20010</returns>
	public ApiResponse<InlineResponse20010> GetOrderByIdWithHttpInfo(int? orderId)
	{
		// verify the required parameter 'orderId' is set
		if (orderId == null)
			throw new ApiException(400, "Missing required parameter 'orderId' when calling OrderApi->GetOrderById");

		var localVarPath = "/Order/{orderId}";
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

		if (orderId != null)
			localVarPathParams.Add("orderId", Configuration.ApiClient.ParameterToString(orderId)); // path parameter
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
			var exception = ExceptionFactory("GetOrderById", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse20010>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse20010)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse20010)));
	}

	/// <summary>
	///     Find order by ID Returns a single order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return</param>
	/// <returns>Task of InlineResponse20010</returns>
	public async Task<InlineResponse20010> GetOrderByIdAsync(int? orderId)
	{
		var localVarResponse = await GetOrderByIdAsyncWithHttpInfo(orderId);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Find order by ID Returns a single order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return</param>
	/// <returns>Task of ApiResponse (InlineResponse20010)</returns>
	public async Task<ApiResponse<InlineResponse20010>> GetOrderByIdAsyncWithHttpInfo(int? orderId)
	{
		// verify the required parameter 'orderId' is set
		if (orderId == null)
			throw new ApiException(400, "Missing required parameter 'orderId' when calling OrderApi->GetOrderById");

		var localVarPath = "/Order/{orderId}";
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

		if (orderId != null)
			localVarPathParams.Add("orderId", Configuration.ApiClient.ParameterToString(orderId)); // path parameter
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
			var exception = ExceptionFactory("GetOrderById", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse20010>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse20010)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse20010)));
	}

	/// <summary>
	///     Find order positions Returns all positions of an order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return the positions</param>
	/// <param name="limit">limits the number of entries returned (optional)</param>
	/// <param name="offset">set the index where the returned entries start (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>InlineResponse2007</returns>
	public InlineResponse2007 GetOrderPositionsById(int? orderId, int? limit = null, int? offset = null,
		List<string> embed = null)
	{
		var localVarResponse = GetOrderPositionsByIdWithHttpInfo(orderId, limit, offset, embed);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Find order positions Returns all positions of an order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return the positions</param>
	/// <param name="limit">limits the number of entries returned (optional)</param>
	/// <param name="offset">set the index where the returned entries start (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>ApiResponse of InlineResponse2007</returns>
	public ApiResponse<InlineResponse2007> GetOrderPositionsByIdWithHttpInfo(int? orderId, int? limit = null,
		int? offset = null, List<string> embed = null)
	{
		// verify the required parameter 'orderId' is set
		if (orderId == null)
			throw new ApiException(400,
				"Missing required parameter 'orderId' when calling OrderApi->GetOrderPositionsById");

		var localVarPath = "/Order/{orderId}/getPositions";
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

		if (orderId != null)
			localVarPathParams.Add("orderId", Configuration.ApiClient.ParameterToString(orderId)); // path parameter
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
			var exception = ExceptionFactory("GetOrderPositionsById", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse2007>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse2007)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2007)));
	}

	/// <summary>
	///     Find order positions Returns all positions of an order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return the positions</param>
	/// <param name="limit">limits the number of entries returned (optional)</param>
	/// <param name="offset">set the index where the returned entries start (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>Task of InlineResponse2007</returns>
	public async Task<InlineResponse2007> GetOrderPositionsByIdAsync(int? orderId, int? limit = null,
		int? offset = null, List<string> embed = null)
	{
		var localVarResponse = await GetOrderPositionsByIdAsyncWithHttpInfo(orderId, limit, offset, embed);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Find order positions Returns all positions of an order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return the positions</param>
	/// <param name="limit">limits the number of entries returned (optional)</param>
	/// <param name="offset">set the index where the returned entries start (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>Task of ApiResponse (InlineResponse2007)</returns>
	public async Task<ApiResponse<InlineResponse2007>> GetOrderPositionsByIdAsyncWithHttpInfo(int? orderId,
		int? limit = null, int? offset = null, List<string> embed = null)
	{
		// verify the required parameter 'orderId' is set
		if (orderId == null)
			throw new ApiException(400,
				"Missing required parameter 'orderId' when calling OrderApi->GetOrderPositionsById");

		var localVarPath = "/Order/{orderId}/getPositions";
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

		if (orderId != null)
			localVarPathParams.Add("orderId", Configuration.ApiClient.ParameterToString(orderId)); // path parameter
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
			var exception = ExceptionFactory("GetOrderPositionsById", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse2007>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse2007)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2007)));
	}

	/// <summary>
	///     Retrieve orders There are a multitude of parameter which can be used to filter. A few of them are attached but
	///     for a complete list please check out &lt;a href&#x3D;&#x27;
	///     https://api.sevdesk.de/#section/How-to-filter-for-certain-orders&#x27;&gt;this&lt;/a&gt; list
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="status">Status of the order (optional)</param>
	/// <param name="orderNumber">Retrieve all orders with this order number (optional)</param>
	/// <param name="startDate">Retrieve all orders with a date equal or higher (optional)</param>
	/// <param name="endDate">Retrieve all orders with a date equal or lower (optional)</param>
	/// <param name="contactId">Retrieve all orders with this contact. Must be provided with contact[objectName] (optional)</param>
	/// <param name="contactObjectName">
	///     Only required if contact[id] was provided. &#x27;Contact&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <returns>InlineResponse20010</returns>
	public InlineResponse20010 GetOrders(int? status = null, string orderNumber = null, int? startDate = null,
		int? endDate = null, int? contactId = null, string contactObjectName = null)
	{
		var localVarResponse =
			GetOrdersWithHttpInfo(status, orderNumber, startDate, endDate, contactId, contactObjectName);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Retrieve orders There are a multitude of parameter which can be used to filter. A few of them are attached but
	///     for a complete list please check out &lt;a href&#x3D;&#x27;
	///     https://api.sevdesk.de/#section/How-to-filter-for-certain-orders&#x27;&gt;this&lt;/a&gt; list
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="status">Status of the order (optional)</param>
	/// <param name="orderNumber">Retrieve all orders with this order number (optional)</param>
	/// <param name="startDate">Retrieve all orders with a date equal or higher (optional)</param>
	/// <param name="endDate">Retrieve all orders with a date equal or lower (optional)</param>
	/// <param name="contactId">Retrieve all orders with this contact. Must be provided with contact[objectName] (optional)</param>
	/// <param name="contactObjectName">
	///     Only required if contact[id] was provided. &#x27;Contact&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <returns>ApiResponse of InlineResponse20010</returns>
	public ApiResponse<InlineResponse20010> GetOrdersWithHttpInfo(int? status = null, string orderNumber = null,
		int? startDate = null, int? endDate = null, int? contactId = null, string contactObjectName = null)
	{
		var localVarPath = "/Order";
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
		if (orderNumber != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "orderNumber", orderNumber)); // query parameter
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
			var exception = ExceptionFactory("GetOrders", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse20010>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse20010)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse20010)));
	}

	/// <summary>
	///     Retrieve orders There are a multitude of parameter which can be used to filter. A few of them are attached but
	///     for a complete list please check out &lt;a href&#x3D;&#x27;
	///     https://api.sevdesk.de/#section/How-to-filter-for-certain-orders&#x27;&gt;this&lt;/a&gt; list
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="status">Status of the order (optional)</param>
	/// <param name="orderNumber">Retrieve all orders with this order number (optional)</param>
	/// <param name="startDate">Retrieve all orders with a date equal or higher (optional)</param>
	/// <param name="endDate">Retrieve all orders with a date equal or lower (optional)</param>
	/// <param name="contactId">Retrieve all orders with this contact. Must be provided with contact[objectName] (optional)</param>
	/// <param name="contactObjectName">
	///     Only required if contact[id] was provided. &#x27;Contact&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <returns>Task of InlineResponse20010</returns>
	public async Task<InlineResponse20010> GetOrdersAsync(int? status = null, string orderNumber = null,
		int? startDate = null, int? endDate = null, int? contactId = null, string contactObjectName = null)
	{
		var localVarResponse =
			await GetOrdersAsyncWithHttpInfo(status, orderNumber, startDate, endDate, contactId, contactObjectName);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Retrieve orders There are a multitude of parameter which can be used to filter. A few of them are attached but
	///     for a complete list please check out &lt;a href&#x3D;&#x27;
	///     https://api.sevdesk.de/#section/How-to-filter-for-certain-orders&#x27;&gt;this&lt;/a&gt; list
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="status">Status of the order (optional)</param>
	/// <param name="orderNumber">Retrieve all orders with this order number (optional)</param>
	/// <param name="startDate">Retrieve all orders with a date equal or higher (optional)</param>
	/// <param name="endDate">Retrieve all orders with a date equal or lower (optional)</param>
	/// <param name="contactId">Retrieve all orders with this contact. Must be provided with contact[objectName] (optional)</param>
	/// <param name="contactObjectName">
	///     Only required if contact[id] was provided. &#x27;Contact&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <returns>Task of ApiResponse (InlineResponse20010)</returns>
	public async Task<ApiResponse<InlineResponse20010>> GetOrdersAsyncWithHttpInfo(int? status = null,
		string orderNumber = null, int? startDate = null, int? endDate = null, int? contactId = null,
		string contactObjectName = null)
	{
		var localVarPath = "/Order";
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
		if (orderNumber != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "orderNumber", orderNumber)); // query parameter
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
			var exception = ExceptionFactory("GetOrders", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse20010>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse20010)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse20010)));
	}

	/// <summary>
	///     Find related objects Get related objects of a specified order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return the positions</param>
	/// <param name="includeItself">Define if the related objects include the order itself (optional)</param>
	/// <param name="sortByType">Define if you want the related objects sorted by type (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>InlineResponse20038</returns>
	public InlineResponse20038 GetRelatedObjects(int? orderId, bool? includeItself = null, bool? sortByType = null,
		List<string> embed = null)
	{
		var localVarResponse = GetRelatedObjectsWithHttpInfo(orderId, includeItself, sortByType, embed);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Find related objects Get related objects of a specified order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return the positions</param>
	/// <param name="includeItself">Define if the related objects include the order itself (optional)</param>
	/// <param name="sortByType">Define if you want the related objects sorted by type (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>ApiResponse of InlineResponse20038</returns>
	public ApiResponse<InlineResponse20038> GetRelatedObjectsWithHttpInfo(int? orderId, bool? includeItself = null,
		bool? sortByType = null, List<string> embed = null)
	{
		// verify the required parameter 'orderId' is set
		if (orderId == null)
			throw new ApiException(400,
				"Missing required parameter 'orderId' when calling OrderApi->GetRelatedObjects");

		var localVarPath = "/Order/{orderId}/getRelatedObjects";
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

		if (orderId != null)
			localVarPathParams.Add("orderId", Configuration.ApiClient.ParameterToString(orderId)); // path parameter
		if (includeItself != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "includeItself",
					includeItself)); // query parameter
		if (sortByType != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "sortByType", sortByType)); // query parameter
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
			var exception = ExceptionFactory("GetRelatedObjects", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse20038>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse20038)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse20038)));
	}

	/// <summary>
	///     Find related objects Get related objects of a specified order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return the positions</param>
	/// <param name="includeItself">Define if the related objects include the order itself (optional)</param>
	/// <param name="sortByType">Define if you want the related objects sorted by type (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>Task of InlineResponse20038</returns>
	public async Task<InlineResponse20038> GetRelatedObjectsAsync(int? orderId, bool? includeItself = null,
		bool? sortByType = null, List<string> embed = null)
	{
		var localVarResponse = await GetRelatedObjectsAsyncWithHttpInfo(orderId, includeItself, sortByType, embed);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Find related objects Get related objects of a specified order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return the positions</param>
	/// <param name="includeItself">Define if the related objects include the order itself (optional)</param>
	/// <param name="sortByType">Define if you want the related objects sorted by type (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>Task of ApiResponse (InlineResponse20038)</returns>
	public async Task<ApiResponse<InlineResponse20038>> GetRelatedObjectsAsyncWithHttpInfo(int? orderId,
		bool? includeItself = null, bool? sortByType = null, List<string> embed = null)
	{
		// verify the required parameter 'orderId' is set
		if (orderId == null)
			throw new ApiException(400,
				"Missing required parameter 'orderId' when calling OrderApi->GetRelatedObjects");

		var localVarPath = "/Order/{orderId}/getRelatedObjects";
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

		if (orderId != null)
			localVarPathParams.Add("orderId", Configuration.ApiClient.ParameterToString(orderId)); // path parameter
		if (includeItself != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "includeItself",
					includeItself)); // query parameter
		if (sortByType != null)
			localVarQueryParams.AddRange(
				Configuration.ApiClient.ParameterToKeyValuePairs("", "sortByType", sortByType)); // query parameter
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
			var exception = ExceptionFactory("GetRelatedObjects", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse20038>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse20038)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse20038)));
	}

	/// <summary>
	///     Retrieve pdf document of an order Retrieves the pdf document of an order with additional metadata and commit the
	///     order.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order from which you want the pdf</param>
	/// <param name="download">If u want to download the pdf of the order. (optional)</param>
	/// <param name="preventSendBy">Defines if u want to send the order. (optional)</param>
	/// <returns>CreditNoteGetPdfResponse</returns>
	public CreditNoteGetPdfResponse OrderGetPdf(int? orderId, bool? download = null, bool? preventSendBy = null)
	{
		var localVarResponse = OrderGetPdfWithHttpInfo(orderId, download, preventSendBy);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Retrieve pdf document of an order Retrieves the pdf document of an order with additional metadata and commit the
	///     order.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order from which you want the pdf</param>
	/// <param name="download">If u want to download the pdf of the order. (optional)</param>
	/// <param name="preventSendBy">Defines if u want to send the order. (optional)</param>
	/// <returns>ApiResponse of CreditNoteGetPdfResponse</returns>
	public ApiResponse<CreditNoteGetPdfResponse> OrderGetPdfWithHttpInfo(int? orderId, bool? download = null,
		bool? preventSendBy = null)
	{
		// verify the required parameter 'orderId' is set
		if (orderId == null)
			throw new ApiException(400, "Missing required parameter 'orderId' when calling OrderApi->OrderGetPdf");

		var localVarPath = "/Order/{orderId}/getPdf";
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

		if (orderId != null)
			localVarPathParams.Add("orderId", Configuration.ApiClient.ParameterToString(orderId)); // path parameter
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
			var exception = ExceptionFactory("OrderGetPdf", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<CreditNoteGetPdfResponse>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(CreditNoteGetPdfResponse)Configuration.ApiClient.Deserialize(localVarResponse,
				typeof(CreditNoteGetPdfResponse)));
	}

	/// <summary>
	///     Retrieve pdf document of an order Retrieves the pdf document of an order with additional metadata and commit the
	///     order.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order from which you want the pdf</param>
	/// <param name="download">If u want to download the pdf of the order. (optional)</param>
	/// <param name="preventSendBy">Defines if u want to send the order. (optional)</param>
	/// <returns>Task of CreditNoteGetPdfResponse</returns>
	public async Task<CreditNoteGetPdfResponse> OrderGetPdfAsync(int? orderId, bool? download = null,
		bool? preventSendBy = null)
	{
		var localVarResponse = await OrderGetPdfAsyncWithHttpInfo(orderId, download, preventSendBy);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Retrieve pdf document of an order Retrieves the pdf document of an order with additional metadata and commit the
	///     order.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order from which you want the pdf</param>
	/// <param name="download">If u want to download the pdf of the order. (optional)</param>
	/// <param name="preventSendBy">Defines if u want to send the order. (optional)</param>
	/// <returns>Task of ApiResponse (CreditNoteGetPdfResponse)</returns>
	public async Task<ApiResponse<CreditNoteGetPdfResponse>> OrderGetPdfAsyncWithHttpInfo(int? orderId,
		bool? download = null, bool? preventSendBy = null)
	{
		// verify the required parameter 'orderId' is set
		if (orderId == null)
			throw new ApiException(400, "Missing required parameter 'orderId' when calling OrderApi->OrderGetPdf");

		var localVarPath = "/Order/{orderId}/getPdf";
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

		if (orderId != null)
			localVarPathParams.Add("orderId", Configuration.ApiClient.ParameterToString(orderId)); // path parameter
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
			var exception = ExceptionFactory("OrderGetPdf", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<CreditNoteGetPdfResponse>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(CreditNoteGetPdfResponse)Configuration.ApiClient.Deserialize(localVarResponse,
				typeof(CreditNoteGetPdfResponse)));
	}

	/// <summary>
	///     Mark order as sent Marks an order as sent by a chosen send type.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to mark as sent</param>
	/// <param name="body">Specify the send type (optional)</param>
	/// <returns>InlineResponse20027</returns>
	public InlineResponse20027 OrderSendBy(int? orderId, OrderIdSendByBody body = null)
	{
		var localVarResponse = OrderSendByWithHttpInfo(orderId, body);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Mark order as sent Marks an order as sent by a chosen send type.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to mark as sent</param>
	/// <param name="body">Specify the send type (optional)</param>
	/// <returns>ApiResponse of InlineResponse20027</returns>
	public ApiResponse<InlineResponse20027> OrderSendByWithHttpInfo(int? orderId, OrderIdSendByBody body = null)
	{
		// verify the required parameter 'orderId' is set
		if (orderId == null)
			throw new ApiException(400, "Missing required parameter 'orderId' when calling OrderApi->OrderSendBy");

		var localVarPath = "/Order/{orderId}/sendBy";
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

		if (orderId != null)
			localVarPathParams.Add("orderId", Configuration.ApiClient.ParameterToString(orderId)); // path parameter
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
			var exception = ExceptionFactory("OrderSendBy", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse20027>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse20027)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse20027)));
	}

	/// <summary>
	///     Mark order as sent Marks an order as sent by a chosen send type.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to mark as sent</param>
	/// <param name="body">Specify the send type (optional)</param>
	/// <returns>Task of InlineResponse20027</returns>
	public async Task<InlineResponse20027> OrderSendByAsync(int? orderId, OrderIdSendByBody body = null)
	{
		var localVarResponse = await OrderSendByAsyncWithHttpInfo(orderId, body);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Mark order as sent Marks an order as sent by a chosen send type.
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to mark as sent</param>
	/// <param name="body">Specify the send type (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse20027)</returns>
	public async Task<ApiResponse<InlineResponse20027>> OrderSendByAsyncWithHttpInfo(int? orderId,
		OrderIdSendByBody body = null)
	{
		// verify the required parameter 'orderId' is set
		if (orderId == null)
			throw new ApiException(400, "Missing required parameter 'orderId' when calling OrderApi->OrderSendBy");

		var localVarPath = "/Order/{orderId}/sendBy";
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

		if (orderId != null)
			localVarPathParams.Add("orderId", Configuration.ApiClient.ParameterToString(orderId)); // path parameter
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
			var exception = ExceptionFactory("OrderSendBy", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse20027>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse20027)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse20027)));
	}

	/// <summary>
	///     Send order via email This endpoint sends the specified order to a customer via email.&lt;br&gt;      This will
	///     automatically mark the order as sent.&lt;br&gt;      Please note, that in production an order is not allowed to be
	///     changed after this happened!
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to be sent via email</param>
	/// <param name="body">Mail data (optional)</param>
	/// <returns>InlineResponse2013</returns>
	public InlineResponse2013 SendorderViaEMail(int? orderId, OrderIdSendViaEmailBody body = null)
	{
		var localVarResponse = SendorderViaEMailWithHttpInfo(orderId, body);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Send order via email This endpoint sends the specified order to a customer via email.&lt;br&gt;      This will
	///     automatically mark the order as sent.&lt;br&gt;      Please note, that in production an order is not allowed to be
	///     changed after this happened!
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to be sent via email</param>
	/// <param name="body">Mail data (optional)</param>
	/// <returns>ApiResponse of InlineResponse2013</returns>
	public ApiResponse<InlineResponse2013> SendorderViaEMailWithHttpInfo(int? orderId,
		OrderIdSendViaEmailBody body = null)
	{
		// verify the required parameter 'orderId' is set
		if (orderId == null)
			throw new ApiException(400,
				"Missing required parameter 'orderId' when calling OrderApi->SendorderViaEMail");

		var localVarPath = "/Order/{orderId}/sendViaEmail";
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

		if (orderId != null)
			localVarPathParams.Add("orderId", Configuration.ApiClient.ParameterToString(orderId)); // path parameter
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
			var exception = ExceptionFactory("SendorderViaEMail", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse2013>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse2013)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2013)));
	}

	/// <summary>
	///     Send order via email This endpoint sends the specified order to a customer via email.&lt;br&gt;      This will
	///     automatically mark the order as sent.&lt;br&gt;      Please note, that in production an order is not allowed to be
	///     changed after this happened!
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to be sent via email</param>
	/// <param name="body">Mail data (optional)</param>
	/// <returns>Task of InlineResponse2013</returns>
	public async Task<InlineResponse2013> SendorderViaEMailAsync(int? orderId, OrderIdSendViaEmailBody body = null)
	{
		var localVarResponse = await SendorderViaEMailAsyncWithHttpInfo(orderId, body);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Send order via email This endpoint sends the specified order to a customer via email.&lt;br&gt;      This will
	///     automatically mark the order as sent.&lt;br&gt;      Please note, that in production an order is not allowed to be
	///     changed after this happened!
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to be sent via email</param>
	/// <param name="body">Mail data (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse2013)</returns>
	public async Task<ApiResponse<InlineResponse2013>> SendorderViaEMailAsyncWithHttpInfo(int? orderId,
		OrderIdSendViaEmailBody body = null)
	{
		// verify the required parameter 'orderId' is set
		if (orderId == null)
			throw new ApiException(400,
				"Missing required parameter 'orderId' when calling OrderApi->SendorderViaEMail");

		var localVarPath = "/Order/{orderId}/sendViaEmail";
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

		if (orderId != null)
			localVarPathParams.Add("orderId", Configuration.ApiClient.ParameterToString(orderId)); // path parameter
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
			var exception = ExceptionFactory("SendorderViaEMail", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse2013>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse2013)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2013)));
	}

	/// <summary>
	///     Update an existing order Update an order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>InlineResponse20010</returns>
	public InlineResponse20010 UpdateOrder(int? orderId, ModelOrderUpdate body = null)
	{
		var localVarResponse = UpdateOrderWithHttpInfo(orderId, body);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Update an existing order Update an order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>ApiResponse of InlineResponse20010</returns>
	public ApiResponse<InlineResponse20010> UpdateOrderWithHttpInfo(int? orderId, ModelOrderUpdate body = null)
	{
		// verify the required parameter 'orderId' is set
		if (orderId == null)
			throw new ApiException(400, "Missing required parameter 'orderId' when calling OrderApi->UpdateOrder");

		var localVarPath = "/Order/{orderId}";
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

		if (orderId != null)
			localVarPathParams.Add("orderId", Configuration.ApiClient.ParameterToString(orderId)); // path parameter
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
			var exception = ExceptionFactory("UpdateOrder", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse20010>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse20010)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse20010)));
	}

	/// <summary>
	///     Update an existing order Update an order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>Task of InlineResponse20010</returns>
	public async Task<InlineResponse20010> UpdateOrderAsync(int? orderId, ModelOrderUpdate body = null)
	{
		var localVarResponse = await UpdateOrderAsyncWithHttpInfo(orderId, body);
		return localVarResponse.Data;
	}

	/// <summary>
	///     Update an existing order Update an order
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse20010)</returns>
	public async Task<ApiResponse<InlineResponse20010>> UpdateOrderAsyncWithHttpInfo(int? orderId,
		ModelOrderUpdate body = null)
	{
		// verify the required parameter 'orderId' is set
		if (orderId == null)
			throw new ApiException(400, "Missing required parameter 'orderId' when calling OrderApi->UpdateOrder");

		var localVarPath = "/Order/{orderId}";
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

		if (orderId != null)
			localVarPathParams.Add("orderId", Configuration.ApiClient.ParameterToString(orderId)); // path parameter
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
			var exception = ExceptionFactory("UpdateOrder", localVarResponse);
			if (exception != null) throw exception;
		}

		return new ApiResponse<InlineResponse20010>(localVarStatusCode,
			localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
			(InlineResponse20010)Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse20010)));
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