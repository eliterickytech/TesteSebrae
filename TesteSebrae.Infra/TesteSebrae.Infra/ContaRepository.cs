using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using TesteSebrae.Domain.Entities;
using TesteSebrae.Domain.Interfaces;

namespace TesteSebrae.Infra
{
    public class ContaRepository : IContaRepository
    {
        public readonly IConfiguration _configuration;
        public string connectionString;
        public ContaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetSection("ConnectionStrings:Sebrae").Value;
        }

        public const string _QueryInsert = @"
            INSERT INTO TbConta(Conta) VALUES (@Conta)
            SELECT @@IDENTITY AS Id            
        ";

        public const string _QueryUpdate = @"
            UPDATE TbConta Set Conta = @Conta WHERE Id = @Id
        ";

        public const string _QueryDelete = @"
            DELETE FROM TbConta WHERE Id = @Id
        ";

        public const string _QuerySelect = @"
            SELECT Id, Conta, DataCriacao FROM TbConta
        ";

        public async Task<int> InsertContaAsync(string conta)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@Conta", conta, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return Convert.ToInt32( await connection.ExecuteScalarAsync(_QueryInsert, parameters, commandType: System.Data.CommandType.Text));
            }
        }

        public async Task<IEnumerable<ContaModel>> SelectContaAsync()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return await connection.QueryAsync<ContaModel>(_QuerySelect, commandType: System.Data.CommandType.Text);
            }
        }

        public async Task<bool> UpdateContaAsync(string conta, int id)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@Conta", conta, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var result = await connection.ExecuteAsync(_QueryUpdate, parameters, commandType: System.Data.CommandType.Text);

                return result >= 1 ? true : false;
            }
        }

        public async Task<bool> DeleteContaAsync(int id)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@Id", id, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var result = await connection.ExecuteAsync(_QueryDelete, parameters, commandType: System.Data.CommandType.Text);
                return result >= 1 ? true : false;

            }
        }

    }
}
