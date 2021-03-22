using AutoMapper;
using Hahn.ApplicationProcess.February2021.Data.Core.Data;
using Hahn.ApplicationProcess.February2021.Data.Core.UnitOfWork;
using Hahn.ApplicationProcess.February2021.Data.Implementations.UnitOfWork;
using Hahn.ApplicationProcess.February2021.Data.Persistence;
using Hahn.ApplicationProcess.February2021.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Domain.Implementations
{
    public class AssetProvider : IAssetProvider
    {
        private DataContext _dataContext;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public AssetProvider(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public IUnitOfWork UnitOfWork
        {
            get
            {
                if(_unitOfWork == null)
                {
                    _unitOfWork = new UnitOfWork(_dataContext);
                }
                return _unitOfWork;
            }
        }

        public void DeleteAsset(int assetId)
        {
            UnitOfWork.Assets.RemoveById(assetId);
            UnitOfWork.Complete();
        }

        public async Task<IEnumerable<Asset>> GetAllAsync()
        {
            var data = await UnitOfWork.Assets.GetAllAsync();
            UnitOfWork.Complete();
            return data;
        }

        public Asset GetAssetById(int assetId)
        {
            var asset = UnitOfWork.Assets.Get(assetId);
            UnitOfWork.Complete();
            return asset;
        }

        public Asset SaveAsset(SaveAssetDto saveAssetDto)
        {
            Asset asset = _mapper.Map<Asset>(saveAssetDto);
            var added = UnitOfWork.Assets.Add(asset);
            UnitOfWork.Complete();
            return added;
        }

        public int UpdateAsset(int id, SaveAssetDto asset)
        {
            Asset editableAsset = _mapper.Map<Asset>(asset);
            editableAsset.Id = id;
            UnitOfWork.Assets.Edit(editableAsset);
            UnitOfWork.Complete();
            return editableAsset.Id;
        }
    }
}
