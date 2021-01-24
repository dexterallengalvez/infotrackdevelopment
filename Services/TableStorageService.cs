using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Table;

namespace InfoTrackDevelopmentProject.Services
{
    /// <summary>
    /// Service class for Azure Table Storage
    /// </summary>
    public class TableStorageService
    {
        protected CloudTableClient tableClient;
        protected CloudStorageAccount cloudStorageAccount;

        /// <summary>
        /// Default constructor for TableStorageService
        /// </summary>
        /// <param name="accountName">The account name of the Azure Storage Account</param>
        /// <param name="key">The Access Key of the Azure Storage Account </param>
        public TableStorageService(string accountName, string key)
        {
            if (String.IsNullOrEmpty(accountName) || String.IsNullOrEmpty(key)) 
                throw new Exception("Invalid parameters. Cannot create table storage service");
            cloudStorageAccount = new CloudStorageAccount(new StorageCredentials(accountName, key), true);
            tableClient = cloudStorageAccount.CreateCloudTableClient();

        }

        /// <summary>
        /// Hide the parameter-less constructor
        /// </summary>
        private TableStorageService() { }
    }
}
