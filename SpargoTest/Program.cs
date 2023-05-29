using Newtonsoft.Json;
using Refit;
using SpargoTest;

TokenStorage storage = new TokenStorage();
var apiClient = RestService.For<IApiClient>("http://f3bus.test.pharmadata.ru");

var getUserDepartmentsResponse = apiClient.GetUserDepartmentsAsync(storage.GetToken());
if (getUserDepartmentsResponse.Result.IsSuccessStatusCode is false)
    throw new Exception($"Error: {getUserDepartmentsResponse.Result.Error}");

var department = getUserDepartmentsResponse.Result.Content
                    .ToList()
                    .Where(d => d.IsActivated is true)
                    .Select(d => d.Department)
                    .FirstOrDefault();
if (department is null)
    throw new Exception("No departments was found for current user");

var getGoodsResponse = apiClient.GetGoodsAsync(storage.GetToken(), department.Id);
if (getGoodsResponse.Result.IsSuccessStatusCode is false)
    throw new Exception($"Error: {getGoodsResponse.Result.Error}");

if (getGoodsResponse.Result.Content is null)
    throw new Exception("No goods was found for current department");

string filePath = "result.txt";
File.WriteAllText(filePath, JsonConvert.SerializeObject(getGoodsResponse.Result.Content));

Console.WriteLine($"Data successfully saved to file: {filePath}");