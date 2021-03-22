using Hahn.ApplicationProcess.February2021.Domain.DataValidators;
using Hahn.ApplicationProcess.February2021.Domain.Dtos;
using Hahn.ApplicationProcess.February2021.Domain.Implementations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace Hahn.ApplicationProcess.February2021.Web.Controllers.General
{
    public class AssetController : BaseAPIController
    {
        private IAssetProvider _assetProvider;
        public AssetController(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        [HttpGet("GetAssetById/{id}")]
        public IActionResult GetAssetById(int id)
        {
            var data = _assetProvider.GetAssetById(id);
            return Ok(data);
        }
        [HttpGet("GetAllAssets")]
        public async Task<IActionResult> GetAllAssets()
        {
            var data = await _assetProvider.GetAllAsync();
            return Ok(data);
        }
        [HttpPost("AddAsset")]
        public IActionResult AddAsset(SaveAssetDto asset)
        {
            var validator = new AssetValidator();
            var result = validator.Validate(asset);
            if(result.IsValid)
            {
                var data = _assetProvider.SaveAsset(asset);
                var absoluteUri = string.Concat(
                        Request.Scheme,
                        "://",
                        Request.Host.ToUriComponent(),
                        Request.PathBase.ToUriComponent(),
                        $"/api/Asset/GetAssetById/{data.Id}");
                return Created(new Uri(absoluteUri), absoluteUri);
            }
            else
            {
                List<string> errorMessages = new List<string>();
                foreach(var item in result.Errors)
                    errorMessages.Add(item.ErrorMessage);
                return BadRequest(errorMessages);
            }
        }
        [HttpPut("EditAsset/{id}")]
        public IActionResult EditAsset(int id, [FromBody]SaveAssetDto asset)
        {
            var validator = new AssetValidator();
            var result = validator.Validate(asset);
            if (result.IsValid)
            {
                try
                {
                    var editedData = _assetProvider.UpdateAsset(id, asset);
                    var absoluteUri = string.Concat(
                       Request.Scheme,
                       "://",
                       Request.Host.ToUriComponent(),
                       Request.PathBase.ToUriComponent(),
                       $"/api/Asset/GetAssetById/{id}");
                    return Created(new Uri(absoluteUri), absoluteUri);
                }
                catch(Exception exc)
                {
                    return BadRequest(exc.Message);
                }
                
            }
            else
            {
                List<string> errorMessages = new List<string>();
                foreach (var item in result.Errors)
                    errorMessages.Add(item.ErrorMessage);
                return BadRequest(errorMessages);
            }
        }
        [HttpDelete("DeleteAsset/{id}")]
        public IActionResult DeleteAsset(int id)
        {
            try
            {
                try
                {
                    _assetProvider.DeleteAsset(id);
                }
                catch(Exception exc)
                {
                    return BadRequest(exc.Message);
                }
                return Ok();
            }
            catch (Exception exc)
            {
                return BadRequest($"{exc.Message}, {exc.InnerException}");
            }
        }
    }
}
