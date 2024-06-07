﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuickServe.Application.DTOs.IngredientTypeTemplateSteps.Request;
using QuickServe.Application.DTOs.ProductTemplates.Request;
using QuickServe.Application.Interfaces.IngredientTypeTemplateSteps;
using QuickServe.Application.Wrappers;
using System;
using System.Threading.Tasks;

namespace QuickServe.WebApi.Controllers.v1
{
    public class IngredientTypeTemplateStepsController : BaseApiController
    {
        private readonly IIngredientTypeTemplateStepService _service;
        public IngredientTypeTemplateStepsController(IIngredientTypeTemplateStepService service)
        {
            _service = service;
        }
        [HttpGet("all")]
        public async Task<BaseResult> GetAll([FromQuery] GetAllTemplateRequest model)
            => await _service.GetAll(model);

        [HttpGet("{id}")]
        public async Task<BaseResult> GetTemplateById(long id)
            => await _service.GetById(new GetTemplateByIdRequest { TemplateStepId = id });

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Brand_Manager")]
        public async Task<BaseResult> CreateTemplate(CreateTemplateRequest request)
            => await _service.CreateTempalte(request);

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Brand_Manager")]
        public async Task<BaseResult> UpdateTemplate(CreateTemplateRequest request)
            => await _service.UpdateTempalte(request);

        [HttpPut("updateStatus")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Brand_Manager")]
        public async Task<BaseResult> UpdateTemplateStatus(UpdateTemplateStatusRequest request)
            => await _service.UpdateTemplateStatus(request);

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Brand_Manager")]
        public async Task<BaseResult> DeleteTemplate(long id)
            => await _service.DeleteTemplate(new DeleteTemplateRequest { TemplateStepId = id });
    }
}
