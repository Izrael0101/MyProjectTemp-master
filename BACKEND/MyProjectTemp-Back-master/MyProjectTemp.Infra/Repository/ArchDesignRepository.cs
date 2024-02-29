using Dapper;
using Microsoft.Extensions.Configuration;
using MyProjectTemp.App.Interfaces;
using MyProjectTemp.Core.Entities;
using System.Data;
using System.Data.SqlClient;

namespace MyProjectTemp.Infra.Repository
{
    public class ArchDesignRepository : IArchDesignRepository
    {
        private readonly IConfiguration configuration;

        public ArchDesignRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IReadOnlyList<ArchDesign>> GetAllAsync()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                var result = await connection.QueryAsync<ArchDesign>("ListArchDesign", commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<ArchDesign> GetByIdAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ArchDesignID", id, DbType.Int32);
                var result = await connection.QuerySingleOrDefaultAsync<ArchDesign>("SelectArchDesignByID", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<string> AddAsync(ArchDesign entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Description", entity.Description, DbType.String);
                var result = await connection.ExecuteAsync("AddArchDesign", parameters, commandType: CommandType.StoredProcedure);
                return result.ToString();
            }
        }

        public async Task<string> UpdateAsync(ArchDesign entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ArchDesignID", entity.ArchDesignID, DbType.Int32);
                parameters.Add("@Description", entity.Description, DbType.String);
                var result = await connection.ExecuteAsync("UpdateArchDesign", parameters, commandType: CommandType.StoredProcedure);
                return result.ToString();
            }
        }

        public async Task<string> DeleteAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ArchDesignID", id, DbType.Int32);
                var result = await connection.ExecuteAsync("DeleteArchDesign", parameters, commandType: CommandType.StoredProcedure);
                return result.ToString();
            }
        }

        // Método adicional para ilustrar el uso de una consulta SQL directa
        public async Task<IReadOnlyList<ArchDesign>> GetByDescriptionAsync(string description)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                // Consulta SQL directa con parámetros
                var query = "SELECT * FROM ArchDesign WHERE Description LIKE @DescriptionPattern";
                var parameters = new { DescriptionPattern = $"%{description}%" };

                var result = await connection.QueryAsync<ArchDesign>(query, parameters);
                return result.ToList();
            }
        }
    }
}