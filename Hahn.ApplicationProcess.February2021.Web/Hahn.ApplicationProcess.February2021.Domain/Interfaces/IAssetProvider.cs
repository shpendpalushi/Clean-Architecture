using Hahn.ApplicationProcess.February2021.Data.Core.Data;
using Hahn.ApplicationProcess.February2021.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Domain.Implementations
{
    /// <summary>
    /// Help to Create/Edit/Delete/Read Asset entries from the data layer
    /// </summary>
    public interface IAssetProvider
    {
        /// <summary>
        /// Creates or modifies an asset entry based on the id
        /// </summary>
        /// <param name="saveAssetDto"></param>
        /// <returns></returns>
        Asset SaveAsset(SaveAssetDto saveAssetDto);
        /// <summary>
        /// Deletes an asset Entry
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        void DeleteAsset(int assetId);
        /// <summary>
        /// Get asset from entries based on it's id
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        Asset GetAssetById(int assetId);
        /// <summary>
        /// Updates an existing asset
        /// </summary>
        /// <param name="asset"></param>
        int UpdateAsset(int id, SaveAssetDto asset);
        /// <summary>
        /// Get all the assets
        /// </summary>
        Task<IEnumerable<Asset>> GetAllAsync();
    }
}
