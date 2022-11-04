using SevDesk.Extensions.ClientApi.Client;
using SevDesk.Extensions.ClientApi.Model;

namespace SevDesk.Extensions.ClientApi.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface ITagApi : IApiAccessor
{
	#region Synchronous Operations

	/// <summary>
	///     Create a new tag
	/// </summary>
	/// <remarks>
	///     Create a new tag
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body"> (optional)</param>
	/// <returns>InlineResponse20030</returns>
	InlineResponse20030 CreateTag(FactoryCreateBody body = null);

	/// <summary>
	///     Create a new tag
	/// </summary>
	/// <remarks>
	///     Create a new tag
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body"> (optional)</param>
	/// <returns>ApiResponse of InlineResponse20030</returns>
	ApiResponse<InlineResponse20030> CreateTagWithHttpInfo(FactoryCreateBody body = null);

	/// <summary>
	///     Deletes a tag
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="tagId">Id of tag to delete</param>
	/// <returns>InlineResponse2003</returns>
	InlineResponse2003 DeleteTag(int? tagId);

	/// <summary>
	///     Deletes a tag
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="tagId">Id of tag to delete</param>
	/// <returns>ApiResponse of InlineResponse2003</returns>
	ApiResponse<InlineResponse2003> DeleteTagWithHttpInfo(int? tagId);

	/// <summary>
	///     Find tag by ID
	/// </summary>
	/// <remarks>
	///     Returns a single tag
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="tagId">ID of tag to return</param>
	/// <returns>InlineResponse20019</returns>
	InlineResponse20019 GetTagById(int? tagId);

	/// <summary>
	///     Find tag by ID
	/// </summary>
	/// <remarks>
	///     Returns a single tag
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="tagId">ID of tag to return</param>
	/// <returns>ApiResponse of InlineResponse20019</returns>
	ApiResponse<InlineResponse20019> GetTagByIdWithHttpInfo(int? tagId);

	/// <summary>
	///     Retrieve tag relations
	/// </summary>
	/// <remarks>
	///     Retrieve all tag relations
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>InlineResponse20030</returns>
	InlineResponse20030 GetTagRelations();

	/// <summary>
	///     Retrieve tag relations
	/// </summary>
	/// <remarks>
	///     Retrieve all tag relations
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>ApiResponse of InlineResponse20030</returns>
	ApiResponse<InlineResponse20030> GetTagRelationsWithHttpInfo();

	/// <summary>
	///     Retrieve tags
	/// </summary>
	/// <remarks>
	///     Retrieve all tags
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="id">ID of the Tag (optional)</param>
	/// <param name="name">Name of the Tag (optional)</param>
	/// <returns>InlineResponse20019</returns>
	InlineResponse20019 GetTags(decimal? id = null, string name = null);

	/// <summary>
	///     Retrieve tags
	/// </summary>
	/// <remarks>
	///     Retrieve all tags
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="id">ID of the Tag (optional)</param>
	/// <param name="name">Name of the Tag (optional)</param>
	/// <returns>ApiResponse of InlineResponse20019</returns>
	ApiResponse<InlineResponse20019> GetTagsWithHttpInfo(decimal? id = null, string name = null);

	/// <summary>
	///     Update tag
	/// </summary>
	/// <remarks>
	///     Update an existing tag
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="tagId">ID of tag you want to update</param>
	/// <param name="body"> (optional)</param>
	/// <returns>InlineResponse20019</returns>
	InlineResponse20019 UpdateTag(int? tagId, TagTagIdBody body = null);

	/// <summary>
	///     Update tag
	/// </summary>
	/// <remarks>
	///     Update an existing tag
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="tagId">ID of tag you want to update</param>
	/// <param name="body"> (optional)</param>
	/// <returns>ApiResponse of InlineResponse20019</returns>
	ApiResponse<InlineResponse20019> UpdateTagWithHttpInfo(int? tagId, TagTagIdBody body = null);

	#endregion Synchronous Operations

	#region Asynchronous Operations

	/// <summary>
	///     Create a new tag
	/// </summary>
	/// <remarks>
	///     Create a new tag
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body"> (optional)</param>
	/// <returns>Task of InlineResponse20030</returns>
	Task<InlineResponse20030> CreateTagAsync(FactoryCreateBody body = null);

	/// <summary>
	///     Create a new tag
	/// </summary>
	/// <remarks>
	///     Create a new tag
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body"> (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse20030)</returns>
	Task<ApiResponse<InlineResponse20030>> CreateTagAsyncWithHttpInfo(FactoryCreateBody body = null);

	/// <summary>
	///     Deletes a tag
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="tagId">Id of tag to delete</param>
	/// <returns>Task of InlineResponse2003</returns>
	Task<InlineResponse2003> DeleteTagAsync(int? tagId);

	/// <summary>
	///     Deletes a tag
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="tagId">Id of tag to delete</param>
	/// <returns>Task of ApiResponse (InlineResponse2003)</returns>
	Task<ApiResponse<InlineResponse2003>> DeleteTagAsyncWithHttpInfo(int? tagId);

	/// <summary>
	///     Find tag by ID
	/// </summary>
	/// <remarks>
	///     Returns a single tag
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="tagId">ID of tag to return</param>
	/// <returns>Task of InlineResponse20019</returns>
	Task<InlineResponse20019> GetTagByIdAsync(int? tagId);

	/// <summary>
	///     Find tag by ID
	/// </summary>
	/// <remarks>
	///     Returns a single tag
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="tagId">ID of tag to return</param>
	/// <returns>Task of ApiResponse (InlineResponse20019)</returns>
	Task<ApiResponse<InlineResponse20019>> GetTagByIdAsyncWithHttpInfo(int? tagId);

	/// <summary>
	///     Retrieve tag relations
	/// </summary>
	/// <remarks>
	///     Retrieve all tag relations
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of InlineResponse20030</returns>
	Task<InlineResponse20030> GetTagRelationsAsync();

	/// <summary>
	///     Retrieve tag relations
	/// </summary>
	/// <remarks>
	///     Retrieve all tag relations
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ApiResponse (InlineResponse20030)</returns>
	Task<ApiResponse<InlineResponse20030>> GetTagRelationsAsyncWithHttpInfo();

	/// <summary>
	///     Retrieve tags
	/// </summary>
	/// <remarks>
	///     Retrieve all tags
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="id">ID of the Tag (optional)</param>
	/// <param name="name">Name of the Tag (optional)</param>
	/// <returns>Task of InlineResponse20019</returns>
	Task<InlineResponse20019> GetTagsAsync(decimal? id = null, string name = null);

	/// <summary>
	///     Retrieve tags
	/// </summary>
	/// <remarks>
	///     Retrieve all tags
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="id">ID of the Tag (optional)</param>
	/// <param name="name">Name of the Tag (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse20019)</returns>
	Task<ApiResponse<InlineResponse20019>> GetTagsAsyncWithHttpInfo(decimal? id = null, string name = null);

	/// <summary>
	///     Update tag
	/// </summary>
	/// <remarks>
	///     Update an existing tag
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="tagId">ID of tag you want to update</param>
	/// <param name="body"> (optional)</param>
	/// <returns>Task of InlineResponse20019</returns>
	Task<InlineResponse20019> UpdateTagAsync(int? tagId, TagTagIdBody body = null);

	/// <summary>
	///     Update tag
	/// </summary>
	/// <remarks>
	///     Update an existing tag
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="tagId">ID of tag you want to update</param>
	/// <param name="body"> (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse20019)</returns>
	Task<ApiResponse<InlineResponse20019>> UpdateTagAsyncWithHttpInfo(int? tagId, TagTagIdBody body = null);

	#endregion Asynchronous Operations
}