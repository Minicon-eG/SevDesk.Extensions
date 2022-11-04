using SevDesk.Extensions.ClientApi.Client;
using SevDesk.Extensions.ClientApi.Model;

namespace SevDesk.Extensions.ClientApi.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IContactFieldApi : IApiAccessor
{
	#region Synchronous Operations

	/// <summary>
	///     Create contact field
	/// </summary>
	/// <remarks>
	///     Create contact field
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body"> (optional)</param>
	/// <returns>InlineResponse20014</returns>
	InlineResponse20014 CreateContactField(ModelContactCustomField body = null);

	/// <summary>
	///     Create contact field
	/// </summary>
	/// <remarks>
	///     Create contact field
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body"> (optional)</param>
	/// <returns>ApiResponse of InlineResponse20014</returns>
	ApiResponse<InlineResponse20014> CreateContactFieldWithHttpInfo(ModelContactCustomField body = null);

	/// <summary>
	///     Create contact field setting
	/// </summary>
	/// <remarks>
	///     Create contact field setting
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body"> (optional)</param>
	/// <returns>InlineResponse2006</returns>
	InlineResponse2006 CreateContactFieldSetting(ModelContactCustomFieldSetting body = null);

	/// <summary>
	///     Create contact field setting
	/// </summary>
	/// <remarks>
	///     Create contact field setting
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body"> (optional)</param>
	/// <returns>ApiResponse of InlineResponse2006</returns>
	ApiResponse<InlineResponse2006> CreateContactFieldSettingWithHttpInfo(ModelContactCustomFieldSetting body = null);

	/// <summary>
	///     delete a contact field
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldId">Id of contact field</param>
	/// <returns>InlineResponse2003</returns>
	InlineResponse2003 DeleteContactCustomFieldId(int? contactCustomFieldId);

	/// <summary>
	///     delete a contact field
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldId">Id of contact field</param>
	/// <returns>ApiResponse of InlineResponse2003</returns>
	ApiResponse<InlineResponse2003> DeleteContactCustomFieldIdWithHttpInfo(int? contactCustomFieldId);

	/// <summary>
	///     Deletes a contact field setting
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldSettingId">Id of contact field to delete</param>
	/// <returns>InlineResponse2003</returns>
	InlineResponse2003 DeleteContactFieldSetting(int? contactCustomFieldSettingId);

	/// <summary>
	///     Deletes a contact field setting
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldSettingId">Id of contact field to delete</param>
	/// <returns>ApiResponse of InlineResponse2003</returns>
	ApiResponse<InlineResponse2003> DeleteContactFieldSettingWithHttpInfo(int? contactCustomFieldSettingId);

	/// <summary>
	///     Find contact field setting by ID
	/// </summary>
	/// <remarks>
	///     Returns a single contact field setting
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldSettingId">ID of contact field to return</param>
	/// <returns>InlineResponse2006</returns>
	InlineResponse2006 GetContactFieldSettingById(int? contactCustomFieldSettingId);

	/// <summary>
	///     Find contact field setting by ID
	/// </summary>
	/// <remarks>
	///     Returns a single contact field setting
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldSettingId">ID of contact field to return</param>
	/// <returns>ApiResponse of InlineResponse2006</returns>
	ApiResponse<InlineResponse2006> GetContactFieldSettingByIdWithHttpInfo(int? contactCustomFieldSettingId);

	/// <summary>
	///     Retrieve contact field settings
	/// </summary>
	/// <remarks>
	///     Retrieve all contact field settings
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>InlineResponse2006</returns>
	InlineResponse2006 GetContactFieldSettings();

	/// <summary>
	///     Retrieve contact field settings
	/// </summary>
	/// <remarks>
	///     Retrieve all contact field settings
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>ApiResponse of InlineResponse2006</returns>
	ApiResponse<InlineResponse2006> GetContactFieldSettingsWithHttpInfo();

	/// <summary>
	///     Retrieve contact fields
	/// </summary>
	/// <remarks>
	///     Retrieve all contact fields
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>InlineResponse20014</returns>
	InlineResponse20014 GetContactFields();

	/// <summary>
	///     Retrieve contact fields
	/// </summary>
	/// <remarks>
	///     Retrieve all contact fields
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>ApiResponse of InlineResponse20014</returns>
	ApiResponse<InlineResponse20014> GetContactFieldsWithHttpInfo();

	/// <summary>
	///     Retrieve contact fields
	/// </summary>
	/// <remarks>
	///     Retrieve all contact fields
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldId">id of the contact field</param>
	/// <returns>InlineResponse20014</returns>
	InlineResponse20014 GetContactFieldsById(decimal? contactCustomFieldId);

	/// <summary>
	///     Retrieve contact fields
	/// </summary>
	/// <remarks>
	///     Retrieve all contact fields
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldId">id of the contact field</param>
	/// <returns>ApiResponse of InlineResponse20014</returns>
	ApiResponse<InlineResponse20014> GetContactFieldsByIdWithHttpInfo(decimal? contactCustomFieldId);

	/// <summary>
	///     Retrieve Placeholders
	/// </summary>
	/// <remarks>
	///     Retrieve all Placeholders
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="objectName">Model name</param>
	/// <param name="subObjectName">Sub model name, required if you have \&quot;Email\&quot; at objectName (optional)</param>
	/// <returns>InlineResponse20028</returns>
	InlineResponse20028 GetPlaceholder(string objectName, string subObjectName = null);

	/// <summary>
	///     Retrieve Placeholders
	/// </summary>
	/// <remarks>
	///     Retrieve all Placeholders
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="objectName">Model name</param>
	/// <param name="subObjectName">Sub model name, required if you have \&quot;Email\&quot; at objectName (optional)</param>
	/// <returns>ApiResponse of InlineResponse20028</returns>
	ApiResponse<InlineResponse20028> GetPlaceholderWithHttpInfo(string objectName, string subObjectName = null);

	/// <summary>
	///     Receive count reference
	/// </summary>
	/// <remarks>
	///     Receive count reference
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldSettingId">ID of contact field you want to get the reference count</param>
	/// <returns>InlineResponse20034</returns>
	InlineResponse20034 GetReferenceCount(int? contactCustomFieldSettingId);

	/// <summary>
	///     Receive count reference
	/// </summary>
	/// <remarks>
	///     Receive count reference
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldSettingId">ID of contact field you want to get the reference count</param>
	/// <returns>ApiResponse of InlineResponse20034</returns>
	ApiResponse<InlineResponse20034> GetReferenceCountWithHttpInfo(int? contactCustomFieldSettingId);

	/// <summary>
	///     Update contact field setting
	/// </summary>
	/// <remarks>
	///     Update an existing contact field  setting
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldSettingId">ID of contact field setting you want to update</param>
	/// <param name="body"> (optional)</param>
	/// <returns>InlineResponse2006</returns>
	InlineResponse2006 UpdateContactFieldSetting(int? contactCustomFieldSettingId,
		ModelContactCustomFieldSettingUpdate body = null);

	/// <summary>
	///     Update contact field setting
	/// </summary>
	/// <remarks>
	///     Update an existing contact field  setting
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldSettingId">ID of contact field setting you want to update</param>
	/// <param name="body"> (optional)</param>
	/// <returns>ApiResponse of InlineResponse2006</returns>
	ApiResponse<InlineResponse2006> UpdateContactFieldSettingWithHttpInfo(int? contactCustomFieldSettingId,
		ModelContactCustomFieldSettingUpdate body = null);

	/// <summary>
	///     Update a contact field
	/// </summary>
	/// <remarks>
	///     Update a contact field
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldId">id of the contact field</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>InlineResponse20014</returns>
	InlineResponse20014 UpdateContactfield(decimal? contactCustomFieldId, ModelContactCustomFieldUpdate body = null);

	/// <summary>
	///     Update a contact field
	/// </summary>
	/// <remarks>
	///     Update a contact field
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldId">id of the contact field</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>ApiResponse of InlineResponse20014</returns>
	ApiResponse<InlineResponse20014> UpdateContactfieldWithHttpInfo(decimal? contactCustomFieldId,
		ModelContactCustomFieldUpdate body = null);

	#endregion Synchronous Operations

	#region Asynchronous Operations

	/// <summary>
	///     Create contact field
	/// </summary>
	/// <remarks>
	///     Create contact field
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body"> (optional)</param>
	/// <returns>Task of InlineResponse20014</returns>
	Task<InlineResponse20014> CreateContactFieldAsync(ModelContactCustomField body = null);

	/// <summary>
	///     Create contact field
	/// </summary>
	/// <remarks>
	///     Create contact field
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body"> (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse20014)</returns>
	Task<ApiResponse<InlineResponse20014>> CreateContactFieldAsyncWithHttpInfo(ModelContactCustomField body = null);

	/// <summary>
	///     Create contact field setting
	/// </summary>
	/// <remarks>
	///     Create contact field setting
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body"> (optional)</param>
	/// <returns>Task of InlineResponse2006</returns>
	Task<InlineResponse2006> CreateContactFieldSettingAsync(ModelContactCustomFieldSetting body = null);

	/// <summary>
	///     Create contact field setting
	/// </summary>
	/// <remarks>
	///     Create contact field setting
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body"> (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse2006)</returns>
	Task<ApiResponse<InlineResponse2006>> CreateContactFieldSettingAsyncWithHttpInfo(
		ModelContactCustomFieldSetting body = null);

	/// <summary>
	///     delete a contact field
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldId">Id of contact field</param>
	/// <returns>Task of InlineResponse2003</returns>
	Task<InlineResponse2003> DeleteContactCustomFieldIdAsync(int? contactCustomFieldId);

	/// <summary>
	///     delete a contact field
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldId">Id of contact field</param>
	/// <returns>Task of ApiResponse (InlineResponse2003)</returns>
	Task<ApiResponse<InlineResponse2003>> DeleteContactCustomFieldIdAsyncWithHttpInfo(int? contactCustomFieldId);

	/// <summary>
	///     Deletes a contact field setting
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldSettingId">Id of contact field to delete</param>
	/// <returns>Task of InlineResponse2003</returns>
	Task<InlineResponse2003> DeleteContactFieldSettingAsync(int? contactCustomFieldSettingId);

	/// <summary>
	///     Deletes a contact field setting
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldSettingId">Id of contact field to delete</param>
	/// <returns>Task of ApiResponse (InlineResponse2003)</returns>
	Task<ApiResponse<InlineResponse2003>> DeleteContactFieldSettingAsyncWithHttpInfo(int? contactCustomFieldSettingId);

	/// <summary>
	///     Find contact field setting by ID
	/// </summary>
	/// <remarks>
	///     Returns a single contact field setting
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldSettingId">ID of contact field to return</param>
	/// <returns>Task of InlineResponse2006</returns>
	Task<InlineResponse2006> GetContactFieldSettingByIdAsync(int? contactCustomFieldSettingId);

	/// <summary>
	///     Find contact field setting by ID
	/// </summary>
	/// <remarks>
	///     Returns a single contact field setting
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldSettingId">ID of contact field to return</param>
	/// <returns>Task of ApiResponse (InlineResponse2006)</returns>
	Task<ApiResponse<InlineResponse2006>> GetContactFieldSettingByIdAsyncWithHttpInfo(int? contactCustomFieldSettingId);

	/// <summary>
	///     Retrieve contact field settings
	/// </summary>
	/// <remarks>
	///     Retrieve all contact field settings
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of InlineResponse2006</returns>
	Task<InlineResponse2006> GetContactFieldSettingsAsync();

	/// <summary>
	///     Retrieve contact field settings
	/// </summary>
	/// <remarks>
	///     Retrieve all contact field settings
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ApiResponse (InlineResponse2006)</returns>
	Task<ApiResponse<InlineResponse2006>> GetContactFieldSettingsAsyncWithHttpInfo();

	/// <summary>
	///     Retrieve contact fields
	/// </summary>
	/// <remarks>
	///     Retrieve all contact fields
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of InlineResponse20014</returns>
	Task<InlineResponse20014> GetContactFieldsAsync();

	/// <summary>
	///     Retrieve contact fields
	/// </summary>
	/// <remarks>
	///     Retrieve all contact fields
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ApiResponse (InlineResponse20014)</returns>
	Task<ApiResponse<InlineResponse20014>> GetContactFieldsAsyncWithHttpInfo();

	/// <summary>
	///     Retrieve contact fields
	/// </summary>
	/// <remarks>
	///     Retrieve all contact fields
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldId">id of the contact field</param>
	/// <returns>Task of InlineResponse20014</returns>
	Task<InlineResponse20014> GetContactFieldsByIdAsync(decimal? contactCustomFieldId);

	/// <summary>
	///     Retrieve contact fields
	/// </summary>
	/// <remarks>
	///     Retrieve all contact fields
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldId">id of the contact field</param>
	/// <returns>Task of ApiResponse (InlineResponse20014)</returns>
	Task<ApiResponse<InlineResponse20014>> GetContactFieldsByIdAsyncWithHttpInfo(decimal? contactCustomFieldId);

	/// <summary>
	///     Retrieve Placeholders
	/// </summary>
	/// <remarks>
	///     Retrieve all Placeholders
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="objectName">Model name</param>
	/// <param name="subObjectName">Sub model name, required if you have \&quot;Email\&quot; at objectName (optional)</param>
	/// <returns>Task of InlineResponse20028</returns>
	Task<InlineResponse20028> GetPlaceholderAsync(string objectName, string subObjectName = null);

	/// <summary>
	///     Retrieve Placeholders
	/// </summary>
	/// <remarks>
	///     Retrieve all Placeholders
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="objectName">Model name</param>
	/// <param name="subObjectName">Sub model name, required if you have \&quot;Email\&quot; at objectName (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse20028)</returns>
	Task<ApiResponse<InlineResponse20028>> GetPlaceholderAsyncWithHttpInfo(string objectName,
		string subObjectName = null);

	/// <summary>
	///     Receive count reference
	/// </summary>
	/// <remarks>
	///     Receive count reference
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldSettingId">ID of contact field you want to get the reference count</param>
	/// <returns>Task of InlineResponse20034</returns>
	Task<InlineResponse20034> GetReferenceCountAsync(int? contactCustomFieldSettingId);

	/// <summary>
	///     Receive count reference
	/// </summary>
	/// <remarks>
	///     Receive count reference
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldSettingId">ID of contact field you want to get the reference count</param>
	/// <returns>Task of ApiResponse (InlineResponse20034)</returns>
	Task<ApiResponse<InlineResponse20034>> GetReferenceCountAsyncWithHttpInfo(int? contactCustomFieldSettingId);

	/// <summary>
	///     Update contact field setting
	/// </summary>
	/// <remarks>
	///     Update an existing contact field  setting
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldSettingId">ID of contact field setting you want to update</param>
	/// <param name="body"> (optional)</param>
	/// <returns>Task of InlineResponse2006</returns>
	Task<InlineResponse2006> UpdateContactFieldSettingAsync(int? contactCustomFieldSettingId,
		ModelContactCustomFieldSettingUpdate body = null);

	/// <summary>
	///     Update contact field setting
	/// </summary>
	/// <remarks>
	///     Update an existing contact field  setting
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldSettingId">ID of contact field setting you want to update</param>
	/// <param name="body"> (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse2006)</returns>
	Task<ApiResponse<InlineResponse2006>> UpdateContactFieldSettingAsyncWithHttpInfo(int? contactCustomFieldSettingId,
		ModelContactCustomFieldSettingUpdate body = null);

	/// <summary>
	///     Update a contact field
	/// </summary>
	/// <remarks>
	///     Update a contact field
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldId">id of the contact field</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>Task of InlineResponse20014</returns>
	Task<InlineResponse20014> UpdateContactfieldAsync(decimal? contactCustomFieldId,
		ModelContactCustomFieldUpdate body = null);

	/// <summary>
	///     Update a contact field
	/// </summary>
	/// <remarks>
	///     Update a contact field
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldId">id of the contact field</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse20014)</returns>
	Task<ApiResponse<InlineResponse20014>> UpdateContactfieldAsyncWithHttpInfo(decimal? contactCustomFieldId,
		ModelContactCustomFieldUpdate body = null);

	#endregion Asynchronous Operations
}