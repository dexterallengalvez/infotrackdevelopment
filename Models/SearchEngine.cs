using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoTrackDevelopmentProject.Models
{
    /// <summary>
    /// Class which represents Search Engines in the Table Storage
    /// </summary>
    public class SearchEngine : ITableEntity
    {
        /// <summary>
        /// Default property - Groups the records in the Azure Table Storage
        /// </summary>
        public string PartitionKey { get; set; }

        /// <summary>
        /// Default Property - Used to identify a particular record in the table storage
        /// </summary>
        public string RowKey { get; set; }

        /// <summary>
        /// The Search Engine Host
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// The name of the Search Engine
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The HTML tag name which contains the site link
        /// This is used in the scraping process
        /// </summary>
        public string LinkTag { get; set; }

        #region Default Properties and methods from ITableEntity

        /// <summary>
        /// Date and Time that the data was inserted or updated in the Table Storage
        /// </summary>
        public DateTimeOffset Timestamp { get; set; }
        
        /// <summary>
        /// ETag to track concurrency for updates
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// Read the entity properties
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="operationContext"></param>
        public void ReadEntity(IDictionary<string, EntityProperty> properties, OperationContext operationContext)
        {
            TableEntity.ReadUserObject(this, properties, operationContext);
        }

        /// <summary>
        /// Update the entity properties
        /// </summary>
        /// <param name="operationContext"></param>
        /// <returns></returns>
        public IDictionary<string, EntityProperty> WriteEntity(OperationContext operationContext)
        {
            return TableEntity.WriteUserObject(this, operationContext);
        }
        #endregion
    }
}
