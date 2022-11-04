/* 
 * sevDesk API
 *
 * <b>Contact:</b> To contact our support click <a href='https://landing.sevdesk.de/service-support-center-technik'>here</a><br><br>   # General information  Welcome to our API!<br>  sevDesk offers you the possibility of retrieving data using an interface, namely the sevDesk API, and making changes without having to use the web UI. The sevDesk interface is a REST-Full API. All sevDesk data and functions that are used in the web UI can also be controlled through the API.   # Cross-Origin Resource Sharing  This API features Cross-Origin Resource Sharing (CORS).<br>  It enables cross-domain communication from the browser.<br>  All responses have a wildcard same-origin which makes them completely public and accessible to everyone, including any code on any site.    # Embedding resources  When retrieving resources by using this API, you might encounter nested resources in the resources you requested.<br>  For example, an invoice always contains a contact, of which you can see the ID and the object name.<br>  This API gives you the possibility to embed these resources completely into the resources you originally requested.<br>  Taking our invoice example, this would mean, that you would not only see the ID and object name of a contact, but rather the complete contact resource.    To embed resources, all you need to do is to add the query parameter 'embed' to your GET request.<br>  As values, you can provide the name of the nested resource.<br>  Multiple nested resources are also possible by providing multiple names, separated by a comma.    # Authentication and Authorization  The sevDesk API uses a token authentication to authorize calls. For this purpose every sevDesk administrator has one API token, which is a <b>hexadecimal string</b> containing <b>32 characters</b>. The following clip shows where you can find the API token if this is your first time with our API.<br><br> <video src='OpenAPI/img/findingTheApiToken.mp4' controls width='640' height='360'> Ihr Browser kann dieses Video nicht wiedergeben.<br/> Dieses Video zeigt wie sie Ihr sevDesk API Token finden. </video> <br> The token will be needed in every request that you want to send and needs to be attached to the request url as a <b>Query Parameter</b><br> or provided as a value of an <b>Authorization Header</b>.<br> For security reasons, we suggest putting the API Token in the Authorization Header and not in the query string.<br> However, in the request examples in this documentation, we will keep it in the query string, as it is easier for you to copy them and try them yourself.<br> The following url is an example that shows where your token needs to be placed as a query parameter.<br> In this case, we used some random API token. <ul> <li><span>ht</span>tps://my.sevdesk.de/api/v1/Contact?token=<span style='color:red'>b7794de0085f5cd00560f160f290af38</span></li> </ul> The next example shows the token in the Authorization Header. <ul> <li>\"Authorization\" :<span style='color:red'>\"b7794de0085f5cd00560f160f290af38\"</span></li> </ul> The api tokens have an infinite lifetime and, in other words, exist as long as the sevDesk user exists.<br> For this reason, the user should <b>NEVER</b> be deleted.<br> If really necessary, it is advisable to save the api token as we will <b>NOT</b> be able to retrieve it afterwards!<br> It is also possible to generate a new API token, for example, if you want to prevent the usage of your sevDesk account by other people who got your current API token.<br> To achieve this, you just need to click on the \"generate new\" symbol to the right of your token and confirm it with your password.  # API News  To never miss API news and updates again, subscribe to our <b>free API newsletter</b> and get all relevant information to keep your sevDesk software running smoothly. To subscribe, simply click <a href = 'https://landing.sevdesk.de/api-newsletter'><b>here</b></a> and confirm the email address to which we may send all updates relevant to you.  # API Requests  In our case, REST API requests need to be build by combining the following components. <table> <tr> <th><b>Component</b></th> <th><b>Description</b></th> </tr> <tr> <td>HTTP-Methods</td> <td> <ul> <li>GET (retrieve a resource)</li> <li>POST (create a resource)</li> <li>PUT (update a resource)</li> <li>DELETE (delete a resource)</li> </ul> </td> </tr> <tr> <td>URL of the API</td> <td><span style='color: #2aa198'>ht</span><span style='color: #2aa198'>tps://my.sevdesk.de/api/v1</span></td> </tr> <tr> <td>URI of the resource</td> <td>The resource to query.<br>For example contacts in sevDesk:<br><br> <span style='color:red'>/Contact</span><br><br> Which will result in the following complete URL:<br><br> <span style='color: #2aa198'>ht</span><span style='color: #2aa198'>tps://my.sevdesk.de/api/v1</span><span style='color:red'>/Contact</span> </td> </tr> <tr> <td>Query parameters</td> <td>Are attached by using the connectives <b>?</b> and <b>&</b> in the URL.<br></td> </tr> <tr> <td>Request headers</td> <td>Typical request headers are for example:<br> <div> <br> <ul> <li>Content-type</li> <li>Authorization</li> <li>Accept-Encoding</li> <li>User-Agent</li> <li>...</li> </ul> </div> </td> </tr> <tr> <td>Request body</td> <td>Mostly required in POST and PUT requests.<br> Often the request body contains json, in our case, it also accepts url-encoded data. </td> </tr> </table><br> <span style='color:red'>Note</span>: please pass a meaningful entry at the header \"User-Agent\". If the \"User-Agent\" is set meaningfully, we can offer better support in case of queries from customers.<br> An example how such a \"User-Agent\" can look like: \"Integration-name by abc\". <br><br> This is a sample request for retrieving existing contacts in sevDesk using curl:<br><br> <img src='OpenAPI/img/GETRequest.PNG' alt='Get Request' height='150'><br><br> As you can see, the request contains all the components mentioned above.<br> It's HTTP method is GET, it has a correct endpoint (<span style='color: #2aa198'>ht</span><span style='color: #2aa198'>tps://my.sevdesk.de/api/v1</span><span style='color:red'>/Contact</span>), query parameters like <b>token</b> and additional <b>header</b> information!<br><br> <b>Query Parameters</b><br><br> As you might have seen in the sample request above, there are several other parameters besides \"token\", located in the url.<br> Those are mostly optional but prove to be very useful for a lot of requests as they can limit, extend, sort or filter the data you will get as a response.<br><br> These are the three most used query parameter for the sevDesk API. <table> <tr> <th><b>Parameter</b></th> <th><b>Description</b></th> </tr> <tr> <td>limit</td> <td>Limits the number of entries that are returned.<br> Most useful in GET requests which will most likely deliver big sets of data like country or currency lists.<br> In this case, you can bypass the default limitation on returned entries by providing a high number. </td> </tr> <tr> <td>offset</td> <td>Specifies a certain offset for the data that will be returned.<br> As an example, you can specify \"offset=2\" if you want all entries except for the first two.</td> </tr> <tr> <td>embed</td> <td>Will extend some of the returned data.<br> A brief example can be found below.</td> </tr> </table> This is an example for the usage of the embed parameter.<br> The following first request will return all company contact entries in sevDesk up to a limit of 100 without any additional information and no offset.<br><br> <img src='OpenAPI/img/ContactQueryWithoutEmbed.PNG' width='900' height='850'><br><br> Now have a look at the category attribute located in the response.<br> Naturally, it just contains the id and the object name of the object but no further information.<br> We will now use the parameter embed with the value \"category\".<br><br> <img src='OpenAPI/img/ContactQueryWithEmbed.PNG' width='900' height='850'><br><br> As you can see, the category object is now extended and shows all the attributes and their corresponding values.<br><br> There are lot of other query parameters that can be used to filter the returned data for objects that match a certain pattern, however, those will not be mentioned here and instead can be found at the detail documentation of the most used API endpoints like contact, invoice or voucher.<br><br> <b>Request Headers</b><br><br> The HTTP request (response) headers allow the client as well as the server to pass additional information with the request.<br> They transfer the parameters and arguments which are important for transmitting data over HTTP.<br> Three headers which are useful / necessary when using the sevDesk API are \"Authorization, \"Accept\" and \"Content-type\".<br> Underneath is a brief description of why and how they should be used.<br><br> <b>Authorization</b><br><br> Can be used if you want to provide your API token in the header instead of having it in the url. <ul> <li>Authorization:<span style='color:red'>yourApiToken</span></li> </ul> <b>Accept</b><br><br> Specifies the format of the response.<br> Required for operations with a response body. <ul> <li>Accept:application/<span style='color:red'>format</span> </li> </ul> In our case, <code><span style='color:red'>format</span></code> could be replaced with <code>json</code> or <code>xml</code><br><br> <b>Content-type</b><br><br> Specifies which format is used in the request.<br> Is required for operations with a request body. <ul> <li>Content-type:application/<span style='color:red'>format</span></li> </ul> In our case,<code><span style='color:red'>format</span></code>could be replaced with <code>json</code> or <code>x-www-form-urlencoded</code> <br><br><b>API Responses</b><br><br> HTTP status codes<br> When calling the sevDesk API it is very likely that you will get a HTTP status code in the response.<br> Some API calls will also return JSON response bodies which will contain information about the resource.<br> Each status code which is returned will either be a <b>success</b> code or an <b>error</b> code.<br><br> Success codes <table> <tr> <th><b>Status code</b></th> <th><b>Description</b></th> </tr> <tr> <td><code>200 OK</code></td> <td>The request was successful</td> </tr> <tr> <td><code>201 Created</code></td> <td>Most likely to be found in the response of a <b>POST</b> request.<br> This code indicates that the desired resource was successfully created.</td> </tr> </table> <br>Error codes <table> <tr> <th><b>Status code</b></th> <th><b>Description</b></th> </tr> <tr> <td><code>400 Bad request</code></td> <td>The request you sent is most likely syntactically incorrect.<br> You should check if the parameters in the request body or the url are correct.</td> </tr> <tr> <td><code>401 Unauthorized</code></td> <td>The authentication failed.<br> Most likely caused by a missing or wrong API token.</td> </tr> <tr> <td><code>403 Forbidden</code></td> <td>You do not have the permission the access the resource which is requested.</td> </tr> <tr> <td><code>404 Not found</code></td> <td>The resource you specified does not exist.</td> </tr> <tr> <td><code>500 Internal server error</code></td> <td>An internal server error has occurred.<br> Normally this means that something went wrong on our side.<br> However, sometimes this error will appear if we missed to catch an error which is normally a 400 status code! </td> </tr> </table>  # Your First Request  After reading the introduction to our API, you should now be able to make your first call.<br> For testing our API, we would always recommend to create a trial account for sevDesk to prevent unwanted changes to your main account.<br> A trial account will be in the highest tariff (materials management), so every sevDesk function can be tested! <br><br>To start testing we would recommend one of the following tools: <ul> <li><a href='https://www.getpostman.com/'>Postman</a></li> <li><a href='https://curl.haxx.se/download.html'>cURL</a></li> </ul> This example will illustrate your first request, which is creating a new Contact in sevDesk.<br> <ol> <li>Download <a href='https://www.getpostman.com/'><b>Postman</b></a> for your desired system and start the application</li> <li>Enter <span><b>ht</span>tps://my.sevdesk.de/api/v1/Contact</b> as the url</li> <li>Use the connective <b>?</b> to append <b>token=</b> to the end of the url, or create an authorization header. Insert your API token as the value</li> <li>For this test, select <b>POST</b> as the HTTP method</li> <li>Go to <b>Headers</b> and enter the key-value pair <b>Content-type</b> + <b>application/x-www-form-urlencoded</b><br> As an alternative, you can just go to <b>Body</b> and select <b>x-www-form-urlencoded</b></li> <li>Now go to <b>Body</b> (if you are not there yet) and enter the key-value pairs as shown in the following picture<br><br> <img src='OpenAPI/img/FirstRequestPostman.PNG' width='900'><br><br></li> <li>Click on <b>Send</b>. Your response should now look like this:<br><br> <img src='OpenAPI/img/FirstRequestResponse.PNG' width='900'></li> </ol> As you can see, a successful response in this case returns a JSON-formatted response body containing the contact you just created.<br> For keeping it simple, this was only a minimal example of creating a contact.<br> There are however numerous combinations of parameters that you can provide which add information to your contact.
 *
 * OpenAPI spec version: 2.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System.Collections;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;

namespace SevDesk.Extensions.ClientApi.Client;

/// <summary>
///     API client is mainly responsible for making the HTTP call to the API backend.
/// </summary>
public partial class ApiClient
{
    /// <summary>
    ///     Gets or sets the default API client for making HTTP calls.
    /// </summary>
    /// <value>The default API client.</value>
    [Obsolete("ApiClient.Default is deprecated, please use 'Configuration.Default.ApiClient' instead.")]
	public static ApiClient Default;

	private readonly JsonSerializerSettings serializerSettings = new()
	{
		ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
		Converters = new List<JsonConverter>
		{
			new StringEnumConverter(),
			new BooleanJsonConverter()
		}
	};

    /// <summary>
    ///     Initializes a new instance of the <see cref="ApiClient" /> class
    ///     with default configuration.
    /// </summary>
    public ApiClient()
	{
		Configuration = Client.Configuration.Default;
		RestClient = new RestClient("https://my.sevdesk.de/api/v1");
	}

    /// <summary>
    ///     Initializes a new instance of the <see cref="ApiClient" /> class
    ///     with default base path (https://my.sevdesk.de/api/v1).
    /// </summary>
    /// <param name="config">An instance of Configuration.</param>
    public ApiClient(Configuration config)
	{
		Configuration = config ?? Client.Configuration.Default;

		RestClient = new RestClient(Configuration.BasePath);
	}

    /// <summary>
    ///     Initializes a new instance of the <see cref="ApiClient" /> class
    ///     with default configuration.
    /// </summary>
    /// <param name="basePath">The base path.</param>
    public ApiClient(string basePath = "https://my.sevdesk.de/api/v1")
	{
		if (string.IsNullOrEmpty(basePath))
			throw new ArgumentException("basePath cannot be empty");

		RestClient = new RestClient(basePath);
		Configuration = Client.Configuration.Default;
	}

    /// <summary>
    ///     Gets or sets an instance of the IReadableConfiguration.
    /// </summary>
    /// <value>An instance of the IReadableConfiguration.</value>
    /// <remarks>
    ///     <see cref="IReadableConfiguration" /> helps us to avoid modifying possibly global
    ///     configuration values from within a given client. It does not guarantee thread-safety
    ///     of the <see cref="Configuration" /> instance in any way.
    /// </remarks>
    public IReadableConfiguration Configuration { get; set; }

    /// <summary>
    ///     Gets or sets the RestClient.
    /// </summary>
    /// <value>An instance of the RestClient</value>
    public RestClient RestClient { get; set; }

    /// <summary>
    ///     Allows for extending request processing for <see cref="ApiClient" /> generated code.
    /// </summary>
    /// <param name="request">The RestSharp request object</param>
    partial void InterceptRequest(IRestRequest request);

    /// <summary>
    ///     Allows for extending response processing for <see cref="ApiClient" /> generated code.
    /// </summary>
    /// <param name="request">The RestSharp request object</param>
    /// <param name="response">The RestSharp response object</param>
    partial void InterceptResponse(IRestRequest request, IRestResponse response);

	// Creates and sets up a RestRequest prior to a call.
	private RestRequest PrepareRequest(
		string path, Method method, List<KeyValuePair<string, string>> queryParams, object postBody,
		Dictionary<string, string> headerParams, Dictionary<string, string> formParams,
		Dictionary<string, FileParameter> fileParams, Dictionary<string, string> pathParams,
		string contentType)
	{
		var request = new RestRequest(path, method);

		// add path parameter, if any
		foreach (var param in pathParams)
			request.AddParameter(param.Key, param.Value, ParameterType.UrlSegment);

		// add header parameter, if any
		foreach (var param in headerParams)
			request.AddHeader(param.Key, param.Value);

		// add query parameter, if any
		foreach (var param in queryParams)
			request.AddQueryParameter(param.Key, param.Value);

		// add form parameter, if any
		foreach (var param in formParams)
			request.AddParameter(param.Key, param.Value);

		// add file parameter, if any
		foreach (var param in fileParams)
			request.AddFile(param.Value.Name, param.Value.Writer, param.Value.FileName, param.Value.ContentType);

		if (postBody != null) // http body (model or byte[]) parameter
			request.AddParameter(contentType, postBody, ParameterType.RequestBody);

		return request;
	}

    /// <summary>
    ///     Makes the HTTP request (Sync).
    /// </summary>
    /// <param name="path">URL path.</param>
    /// <param name="method">HTTP method.</param>
    /// <param name="queryParams">Query parameters.</param>
    /// <param name="postBody">HTTP body (POST request).</param>
    /// <param name="headerParams">Header parameters.</param>
    /// <param name="formParams">Form parameters.</param>
    /// <param name="fileParams">File parameters.</param>
    /// <param name="pathParams">Path parameters.</param>
    /// <param name="contentType">Content Type of the request</param>
    /// <returns>Object</returns>
    public object CallApi(
		string path, Method method, List<KeyValuePair<string, string>> queryParams, object postBody,
		Dictionary<string, string> headerParams, Dictionary<string, string> formParams,
		Dictionary<string, FileParameter> fileParams, Dictionary<string, string> pathParams,
		string contentType)
	{
		var request = PrepareRequest(
			path, method, queryParams, postBody, headerParams, formParams, fileParams,
			pathParams, contentType);

		// set timeout

		RestClient.Timeout = Configuration.Timeout;
		// set user agent
		RestClient.UserAgent = Configuration.UserAgent;

		InterceptRequest(request);
		var response = RestClient.Execute(request);
		InterceptResponse(request, response);

		return response;
	}

    /// <summary>
    ///     Makes the asynchronous HTTP request.
    /// </summary>
    /// <param name="path">URL path.</param>
    /// <param name="method">HTTP method.</param>
    /// <param name="queryParams">Query parameters.</param>
    /// <param name="postBody">HTTP body (POST request).</param>
    /// <param name="headerParams">Header parameters.</param>
    /// <param name="formParams">Form parameters.</param>
    /// <param name="fileParams">File parameters.</param>
    /// <param name="pathParams">Path parameters.</param>
    /// <param name="contentType">Content type.</param>
    /// <returns>The Task instance.</returns>
    public async Task<object> CallApiAsync(
		string path, Method method, List<KeyValuePair<string, string>> queryParams, object postBody,
		Dictionary<string, string> headerParams, Dictionary<string, string> formParams,
		Dictionary<string, FileParameter> fileParams, Dictionary<string, string> pathParams,
		string contentType)
	{
		var request = PrepareRequest(
			path, method, queryParams, postBody, headerParams, formParams, fileParams,
			pathParams, contentType);
		InterceptRequest(request);
		var response = await RestClient.ExecuteTaskAsync(request);
		InterceptResponse(request, response);
		return response;
	}

    /// <summary>
    ///     Escape string (url-encoded).
    /// </summary>
    /// <param name="str">String to be escaped.</param>
    /// <returns>Escaped string.</returns>
    public string EscapeString(string str)
	{
		return UrlEncode(str);
	}

    /// <summary>
    ///     Create FileParameter based on Stream.
    /// </summary>
    /// <param name="name">Parameter name.</param>
    /// <param name="stream">Input stream.</param>
    /// <returns>FileParameter.</returns>
    public FileParameter ParameterToFile(string name, Stream stream)
	{
		if (stream is FileStream)
			return FileParameter.Create(name, ReadAsBytes(stream), Path.GetFileName(((FileStream)stream).Name));
		return FileParameter.Create(name, ReadAsBytes(stream), "no_file_name_provided");
	}

	public FileParameter ParameterToFile(string name, byte[] stream)
	{
		return FileParameter.Create(name, stream, "no_file_name_provided");
	}

    /// <summary>
    ///     If parameter is DateTime, output in a formatted string (default ISO 8601), customizable with
    ///     Configuration.DateTime.
    ///     If parameter is a list, join the list with ",".
    ///     Otherwise just return the string.
    /// </summary>
    /// <param name="obj">The parameter (header, path, query, form).</param>
    /// <returns>Formatted string.</returns>
    public string ParameterToString(object obj)
	{
		if (obj is DateTime)
			// Return a formatted date string - Can be customized with Configuration.DateTimeFormat
			// Defaults to an ISO 8601, using the known as a Round-trip date/time pattern ("o")
			// https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx#Anchor_8
			// For example: 2009-06-15T13:45:30.0000000
			return ((DateTime)obj).ToString(Configuration.DateTimeFormat);

		if (obj is DateTimeOffset)
			// Return a formatted date string - Can be customized with Configuration.DateTimeFormat
			// Defaults to an ISO 8601, using the known as a Round-trip date/time pattern ("o")
			// https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx#Anchor_8
			// For example: 2009-06-15T13:45:30.0000000
			return ((DateTimeOffset)obj).ToString(Configuration.DateTimeFormat);

		if (obj is IList)
		{
			var flattenedString = new StringBuilder();
			foreach (var param in (IList)obj)
			{
				if (flattenedString.Length > 0)
					flattenedString.Append(",");
				flattenedString.Append(param);
			}

			return flattenedString.ToString();
		}

		return Convert.ToString(obj);
	}

    /// <summary>
    ///     Deserialize the JSON string into a proper object.
    /// </summary>
    /// <param name="response">The HTTP response.</param>
    /// <param name="type">Object type.</param>
    /// <returns>Object representation of the JSON string.</returns>
    public object Deserialize(IRestResponse response, Type type)
	{
		IList<Parameter> headers = response.Headers;
		if (type == typeof(byte[])) // return byte array
			return response.RawBytes;

		// TODO: ? if (type.IsAssignableFrom(typeof(Stream)))
		if (type == typeof(Stream))
		{
			if (headers != null)
			{
				var filePath = string.IsNullOrEmpty(Configuration.TempFolderPath)
					? Path.GetTempPath()
					: Configuration.TempFolderPath;
				var regex = new Regex(@"Content-Disposition=.*filename=['""]?([^'""\s]+)['""]?$");
				foreach (var header in headers)
				{
					var match = regex.Match(header.ToString());
					if (match.Success)
					{
						var fileName = filePath +
						               SanitizeFilename(match.Groups[1].Value.Replace("\"", "").Replace("'", ""));
						File.WriteAllBytes(fileName, response.RawBytes);
						return new FileStream(fileName, FileMode.Open);
					}
				}
			}

			var stream = new MemoryStream(response.RawBytes);
			return stream;
		}

		if (type.Name.StartsWith("System.Nullable`1[[System.DateTime")) // return a datetime object
			return DateTime.Parse(response.Content, null, DateTimeStyles.RoundtripKind);

		if (type == typeof(string) || type.Name.StartsWith("System.Nullable")) // return primitive type
			return ConvertType(response.Content, type);

		// at this point, it must be a model (json)
		try
		{
			return JsonConvert.DeserializeObject(response.Content, type, serializerSettings);
		}
		catch (Exception e)
		{
			throw new ApiException(500, e.Message);
		}
	}

    /// <summary>
    ///     Serialize an input (model) into JSON string
    /// </summary>
    /// <param name="obj">Object.</param>
    /// <returns>JSON string.</returns>
    public string Serialize(object obj)
	{
		try
		{
			return obj != null ? JsonConvert.SerializeObject(obj) : null;
		}
		catch (Exception e)
		{
			throw new ApiException(500, e.Message);
		}
	}

    /// <summary>
    ///     Check if the given MIME is a JSON MIME.
    ///     JSON MIME examples:
    ///     application/json
    ///     application/json; charset=UTF8
    ///     APPLICATION/JSON
    ///     application/vnd.company+json
    /// </summary>
    /// <param name="mime">MIME</param>
    /// <returns>Returns True if MIME type is json.</returns>
    public bool IsJsonMime(string mime)
	{
		var jsonRegex = new Regex("(?i)^(application/json|[^;/ \t]+/[^;/ \t]+[+]json)[ \t]*(;.*)?$");
		return mime != null && (jsonRegex.IsMatch(mime) || mime.Equals("application/json-patch+json"));
	}

    /// <summary>
    ///     Select the Content-Type header's value from the given content-type array:
    ///     if JSON type exists in the given array, use it;
    ///     otherwise use the first one defined in 'consumes'
    /// </summary>
    /// <param name="contentTypes">The Content-Type array to select from.</param>
    /// <returns>The Content-Type header to use.</returns>
    public string SelectHeaderContentType(string[] contentTypes)
	{
		if (contentTypes.Length == 0)
			return "application/json";

		foreach (var contentType in contentTypes)
			if (IsJsonMime(contentType.ToLower()))
				return contentType;

		return contentTypes[0]; // use the first content type specified in 'consumes'
	}

    /// <summary>
    ///     Select the Accept header's value from the given accepts array:
    ///     if JSON exists in the given array, use it;
    ///     otherwise use all of them (joining into a string)
    /// </summary>
    /// <param name="accepts">The accepts array to select from.</param>
    /// <returns>The Accept header to use.</returns>
    public string SelectHeaderAccept(string[] accepts)
	{
		if (accepts.Length == 0)
			return null;

		if (accepts.Contains("application/json", StringComparer.OrdinalIgnoreCase))
			return "application/json";

		return string.Join(",", accepts);
	}

    /// <summary>
    ///     Encode string in base64 format.
    /// </summary>
    /// <param name="text">String to be encoded.</param>
    /// <returns>Encoded string.</returns>
    public static string Base64Encode(string text)
	{
		return Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
	}

    /// <summary>
    ///     Dynamically cast the object into target type.
    /// </summary>
    /// <param name="fromObject">Object to be casted</param>
    /// <param name="toObject">Target type</param>
    /// <returns>Casted object</returns>
    public static dynamic ConvertType(dynamic fromObject, Type toObject)
	{
		return Convert.ChangeType(fromObject, toObject);
	}

    /// <summary>
    ///     Convert stream to byte array
    /// </summary>
    /// <param name="inputStream">Input stream to be converted</param>
    /// <returns>Byte array</returns>
    public static byte[] ReadAsBytes(Stream inputStream)
	{
		var buf = new byte[16 * 1024];
		using (var ms = new MemoryStream())
		{
			int count;
			while ((count = inputStream.Read(buf, 0, buf.Length)) > 0) ms.Write(buf, 0, count);
			return ms.ToArray();
		}
	}

    /// <summary>
    ///     URL encode a string
    ///     Credit/Ref: https://github.com/restsharp/RestSharp/blob/master/RestSharp/Extensions/StringExtensions.cs#L50
    /// </summary>
    /// <param name="input">String to be URL encoded</param>
    /// <returns>Byte array</returns>
    public static string UrlEncode(string input)
	{
		const int maxLength = 32766;

		if (input == null) throw new ArgumentNullException("input");

		if (input.Length <= maxLength) return Uri.EscapeDataString(input);

		var sb = new StringBuilder(input.Length * 2);
		var index = 0;

		while (index < input.Length)
		{
			var length = Math.Min(input.Length - index, maxLength);
			var subString = input.Substring(index, length);

			sb.Append(Uri.EscapeDataString(subString));
			index += subString.Length;
		}

		return sb.ToString();
	}

    /// <summary>
    ///     Sanitize filename by removing the path
    /// </summary>
    /// <param name="filename">Filename</param>
    /// <returns>Filename</returns>
    public static string SanitizeFilename(string filename)
	{
		var match = Regex.Match(filename, @".*[/\\](.*)$");

		if (match.Success)
			return match.Groups[1].Value;
		return filename;
	}

    /// <summary>
    ///     Convert params to key/value pairs.
    ///     Use collectionFormat to properly format lists and collections.
    /// </summary>
    /// <param name="name">Key name.</param>
    /// <param name="value">Value object.</param>
    /// <returns>A list of KeyValuePairs</returns>
    public IEnumerable<KeyValuePair<string, string>> ParameterToKeyValuePairs(string collectionFormat, string name,
		object value)
	{
		var parameters = new List<KeyValuePair<string, string>>();

		if (IsCollection(value) && collectionFormat == "multi")
		{
			var valueCollection = value as IEnumerable;
			parameters.AddRange(from object item in valueCollection
				select new KeyValuePair<string, string>(name, ParameterToString(item)));
		}
		else
		{
			parameters.Add(new KeyValuePair<string, string>(name, ParameterToString(value)));
		}

		return parameters;
	}

    /// <summary>
    ///     Check if generic object is a collection.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>True if object is a collection type</returns>
    private static bool IsCollection(object value)
	{
		return value is IList || value is ICollection;
	}
}