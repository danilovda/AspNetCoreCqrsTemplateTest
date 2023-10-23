using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json.Linq;
using _apiTemplate_.Contracts._entityTemplate_;
using _apiTemplate_.FunctionalTests.Extensions;
using _apiTemplate_.FunctionalTests.Fixture;
using _apiTemplate_.FunctionalTests.TestUtils;
using System.Net.Http.Json;

namespace _apiTemplate_.FunctionalTests.Tests._entityTemplate_sEndpoint;

[Collection("Database collection")]
public class _entityTemplate_sEndpointCreateTests
{
    private readonly DatabaseFixture _fixture;
    public _entityTemplate_sEndpointCreateTests(DatabaseFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task Create_entityTemplate__Returns_entityTemplate_()
    {
        IDbContextTransaction? transaction = null;
        try
        {
            //Arrange
            var dbContext = _fixture.DbContext;

            transaction = dbContext.Database.BeginTransaction();

            _entityTemplate_CreateRequest _entityTemplate_Request = new(
                FirstName: Utils.CreateString(),
                LastName: Utils.CreateString(),
                MiddleName: Utils.CreateString());

            //Act
            var response = await _fixture.HttpClient
                .PostAsJsonAsync("/api/v1/_entityTemplate_s", _entityTemplate_Request);

            //Assert
            Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);

            var _entityTemplate_Respons = await response.ReadContentAs<_entityTemplate_Response>();

            Assert.NotNull(_entityTemplate_Respons);
            Assert.Equal(_entityTemplate_Request.FirstName, _entityTemplate_Respons.FirstName);
            Assert.Equal(_entityTemplate_Request.LastName, _entityTemplate_Respons.LastName);
            Assert.Equal(_entityTemplate_Request.MiddleName, _entityTemplate_Respons.MiddleName);

            var _entityTemplate_Db = dbContext._entityTemplate_s.Single(p => p.Id == _entityTemplate_Respons.Id);

            Assert.NotEqual(0, _entityTemplate_Respons.Id);
            Assert.Equal(_entityTemplate_Request.FirstName, _entityTemplate_Db.FirstName);
            Assert.Equal(_entityTemplate_Request.LastName, _entityTemplate_Db.LastName);
            Assert.Equal(_entityTemplate_Request.MiddleName, _entityTemplate_Db.MiddleName);
        }
        finally
        {
            transaction?.Rollback();
        }
    }

    [Fact]
    public async Task Create_entityTemplate__ModelIsNotValid()
    {
        IDbContextTransaction? transaction = null;
        try
        {
            //Arrange
            var dbContext = _fixture.DbContext;

            transaction = dbContext.Database.BeginTransaction();

            _entityTemplate_CreateRequest _entityTemplate_Request = new(
                FirstName: "",
                LastName: "",
                MiddleName: "");

            //Act
            var response = await _fixture.HttpClient
                .PostAsJsonAsync("/api/v1/_entityTemplate_s", _entityTemplate_Request);

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
