using Refit;
using SpargoTest.ApiClient.Models.Response;

namespace SpargoTest;

public interface IApiClient
{
    public const string AuthorizationBearer = "Authorization";

    [Post("/User/auth/{role}")]
    Task<ApiResponse<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string role);

    [Get("/User/departments")]
    Task<ApiResponse<IEnumerable<GetUserDepartmentsResponse>>> GetUserDepartmentsAsync([Header(AuthorizationBearer)] string token);

    [Get("/Goods/{departmentId}")]
    Task<ApiResponse<IEnumerable<GetGoodsResponse>>> GetGoodsAsync([Header(AuthorizationBearer)] string token, string departmentId);
}