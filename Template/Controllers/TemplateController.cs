using Microsoft.AspNetCore.Mvc;
using Template.Model.Models.CommandModel;
using Template.Service.IServices;

namespace Library.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemplateController : ControllerBase
    {
        private readonly ITemplateService _templateService;

        public TemplateController(ITemplateService templateService)
        {
            _templateService = templateService;
        }

        /// <summary>
        /// Create Template text.
        /// </summary>
        /// <param name="createTemplateRequest"></param>
        [HttpPost]
        [ProducesResponseType(typeof(TemplateResponse), 201)]
        public async Task<IActionResult> Create(CreateTemplateRequest createTemplateRequest)
        {
            var result = await _templateService.CreateTemplate(createTemplateRequest);
            return CreatedAtAction("GetAll", result);
        }

        /// <summary>        /// Updates info about Template text.
        /// </summary>
        /// <param name="editTemplateRequest"></param>        
        [HttpPut]
        [ProducesResponseType(typeof(TemplateResponse), 200)]
        public async Task<IActionResult> Update(EditTemplateRequest editTemplateRequest)
            => Ok(await _templateService.UpdateTemplate(editTemplateRequest));


        /// <summary>
        /// Gets current Template text by given Id.
        /// </summary>
        /// <param name="id"></param>
        [HttpGet]
        [Route("GetTemplateById/{id}")]
        [ProducesResponseType(typeof(TemplateResponse), 200)]
        public async Task<IActionResult> GetById(Guid id)
          => Ok(await _templateService.GetTemplateById(id));

        /// <summary>
        /// Gets list of Template text.
        /// </summary>
        [HttpGet]
        [Route("GetAllTemplates")]
        [ProducesResponseType(typeof(TemplateResponse), 200)]
        public async Task<IActionResult> GetAll()
            => Ok(await _templateService.GetAllTemplates());

        /// <summary>
        /// Deletes Template text.
        /// </summary>
        /// <param name="deleteTemplateRequest"></param>
        [HttpDelete]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Delete(DeleteTemplateRequest deleteTemplateRequest)
        {
            await _templateService.DeleteTemplate(deleteTemplateRequest);
            return NoContent();
        }
    }
}

