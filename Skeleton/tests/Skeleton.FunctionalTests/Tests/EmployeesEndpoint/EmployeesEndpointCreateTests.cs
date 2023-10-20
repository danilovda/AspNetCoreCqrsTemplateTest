using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json.Linq;
using Skeleton.Contracts.Employee;
using Skeleton.FunctionalTests.Extensions;
using Skeleton.FunctionalTests.Fixture;
using Skeleton.FunctionalTests.TestUtils;
using System.Net.Http.Json;

namespace Skeleton.FunctionalTests.Tests.EmployeesEndpoint;

[Collection("Database collection")]
public class EmployeesEndpointCreateTests
{
    private readonly DatabaseFixture _fixture;
    public EmployeesEndpointCreateTests(DatabaseFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task CreateEmployee_ReturnsEmployee()
    {
        IDbContextTransaction? transaction = null;
        try
        {
            //Arrange
            var dbContext = _fixture.DbContext;

            transaction = dbContext.Database.BeginTransaction();

            EmployeeCreateRequest employeeRequest = new(
                FirstName: Utils.CreateString(),
                LastName: Utils.CreateString(),
                MiddleName: Utils.CreateString());

            //Act
            var response = await _fixture.HttpClient
                .PostAsJsonAsync("/api/v1/employees", employeeRequest);

            //Assert
            Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);

            var employeeRespons = await response.ReadContentAs<EmployeeResponse>();

            Assert.NotNull(employeeRespons);
            Assert.Equal(employeeRequest.FirstName, employeeRespons.FirstName);
            Assert.Equal(employeeRequest.LastName, employeeRespons.LastName);
            Assert.Equal(employeeRequest.MiddleName, employeeRespons.MiddleName);

            var employeeDb = dbContext.Employees.Single(p => p.Id == employeeRespons.Id);

            Assert.NotEqual(0, employeeRespons.Id);
            Assert.Equal(employeeRequest.FirstName, employeeDb.FirstName);
            Assert.Equal(employeeRequest.LastName, employeeDb.LastName);
            Assert.Equal(employeeRequest.MiddleName, employeeDb.MiddleName);
        }
        finally
        {
            transaction?.Rollback();
        }
    }

    [Fact]
    public async Task CreateEmployee_ModelIsNotValid()
    {
        IDbContextTransaction? transaction = null;
        try
        {
            //Arrange
            var dbContext = _fixture.DbContext;

            transaction = dbContext.Database.BeginTransaction();

            EmployeeCreateRequest employeeRequest = new(
                FirstName: "",
                LastName: "",
                MiddleName: "");

            //Act
            var response = await _fixture.HttpClient
                .PostAsJsonAsync("/api/v1/employees", employeeRequest);

            //Assert
            Assert.Equal(System.Net.HttpStatusCode.UnprocessableEntity, response.StatusCode);

            dynamic errorsRespons = JObject.Parse(await response.Content.ReadAsStringAsync());

            Assert.EndsWith("must not be empty.", (string)errorsRespons.errors.FirstName[0]);
            Assert.EndsWith("must not be empty.", (string)errorsRespons.errors.LastName[0]);
        }
        finally
        {
            transaction?.Rollback();
        }
    }
}
