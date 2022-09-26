using DatabaseHomework.DbProvider;
using DatabaseHomework.Models;

namespace DatabaseHomework.Repository;

public class CountryRepository : ICountryRepository
{
    private readonly IDapperDbProvider _dapperDbProvider;

    private const string SelectCountrySqlStatement = @"SELECT * FROM country WHERE CountryId = @Id LIMIT 1";
    private const string SelectAllCountriesSqlStatement = @"SELECT * FROM country LIMIT 50";

    public CountryRepository(IDapperDbProvider dapperDbProvider)
    {
        _dapperDbProvider = dapperDbProvider;
    }

    public async Task<Country> GetCountry(int id)
    {
        using var connection = _dapperDbProvider.GetConnection();

        return await _dapperDbProvider.QueryFirstOrDefaultAsync<Country>(connection, SelectCountrySqlStatement, new { Id = id });
    }

    public async Task<IEnumerable<Country>> GetAllCountries()
    {
        using var connection = _dapperDbProvider.GetConnection();

        return await _dapperDbProvider.QueryAsync<Country>(connection, SelectAllCountriesSqlStatement);
    }

    public async Task AddCountry(Country country)
    {
        string InsertCountrySqlStatement = $"INSERT INTO public.country(countryname, continent, currency) VALUES ('{country.CountryName}', '{country.Continent}', '{country.Currency}');";
    
        using var connection = _dapperDbProvider.GetConnection();

        await _dapperDbProvider.ExecuteAsync(connection, InsertCountrySqlStatement);
    }

    public async Task<Country> UpdateCountry(Country country)
    {
        string UpdateCountrySqlStatement = $"UPDATE country SET countryname = '{country.CountryName}', continent = '{country.Continent}', currency = '{country.Currency}' WHERE CountryId = {country.CountryId}";

        using var connection = _dapperDbProvider.GetConnection();

        return await _dapperDbProvider.QueryFirstOrDefaultAsync<Country>(connection, UpdateCountrySqlStatement);
    }

    public async Task<Country> DeleteCountry(int id)
    {
        string DeleteCountrySqlStatement = $"DELETE FROM public.country WHERE countryid = {id};";
        using var connection = _dapperDbProvider.GetConnection();
        await _dapperDbProvider.QueryFirstOrDefaultAsync<Country>(connection, DeleteCountrySqlStatement);
        return await _dapperDbProvider.QueryFirstOrDefaultAsync<Country>(connection, SelectCountrySqlStatement, new { Id = id });
    }
}