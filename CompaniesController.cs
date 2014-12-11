using Conube.Domain;
using Conube.Infrastructure;
using Fepin.Foundation;
using Fepin.Persistence;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Conube.App.Api.Frontend.Controllers
{
    /// <summary>
    /// Empresas
    /// </summary>
    [Authorize]
    [RoutePrefix("v1/companies")]
    public class CompaniesController : BaseAccountController
    {
        private readonly CompanyApplicationService _service;
        private readonly ICertificateService _certificateService;

        /// <summary>
        /// Construtor padrão
        /// </summary>
        /// <param name="contaRepository">Repositório de acesso as Empresas</param>
        /// <param name="empresaService">Serviço base para acesso as empresas</param>
        /// <param name="certificateService">Serviço de certificado</param>
        public CompaniesController(
            IRepository<Account> contaRepository,
            CompanyApplicationService empresaService,
            ICertificateService certificateService)
            : base(contaRepository)
        {
            _service = empresaService;
            _certificateService = certificateService;
        }

        /// <summary>
        /// Listar as empresas ativas de uma conta
        /// </summary>
        /// <returns>Todas as empresas</returns>
        /// <response code="200">Sucesso na requisição</response>
        /// <response code="400">API Key da conta não é valida</response>
        [Route("")]
        [HttpGet]
        [ResponseType(typeof(CompanyCollectionResource))]
        public async Task<IHttpActionResult> Get()
        {
            var account = this.ApiKey;
            if (account == null || account.Description.IndexOf("api.nfe.io") < 0)
                return BadRequest("account api key is not valid");

            var account_id = account.ParentId;

            return ResponseResult(await _service.All(account_id));
        }

        /// <summary>
        /// Obter os detalhes de uma empresa
        /// </summary>
        /// <param name="company_id_or_tax_number">ID da empresa ou Inscrição Federal (CNPJ)</param>
        /// <returns>Todas os detalhes da empresa</returns>
        /// <response code="200">Sucesso na requisição</response>
        /// <response code="400">API Key da conta não é valida</response>
        [Route("{company_id_or_tax_number}")]
        [HttpGet]
        [ResponseType(typeof(CompanySingleResource))]
        public async Task<IHttpActionResult> Get(string company_id_or_tax_number)
        {
            var account = this.ApiKey;
            if (account == null || account.Description.IndexOf("api.nfe.io") < 0)
                return BadRequest("account api key is not valid");

            var account_id = account.ParentId;

            var result = default(Result<CompanySingleResource>);

            if (Cnpj.Validate(company_id_or_tax_number))
            {
                result = await _service.One(account_id, long.Parse(company_id_or_tax_number.RemoveNonNumeric()));
            }
            else
            {
                result = await _service.One(account_id, company_id_or_tax_number);
            }

            return ResponseResult(result);
        }

        /// <summary>
        /// Criar uma empresa
        /// </summary>
        /// <param name="item">Dados da empresa</param>
        /// <returns>Todas os detalhes da empresa</returns>
        /// <response code="201">Sucesso na criação da empresa</response>
        /// <response code="400">API Key da conta não é valida</response>
        /// <response code="409">Já existe uma empresa com o CNPJ informado</response>
        [Route("")]
        [HttpPost]
        [ResponseType(typeof(CompanySingleResource))]
        public async Task<IHttpActionResult> Post(CompanyResource item)
        {
            var account = this.ApiKey;
            if (account == null || account.Description.IndexOf("api.nfe.io") < 0)
                return BadRequest("account api key is not valid");

            var account_id = account.ParentId;

            var result = await _service.Create(account_id, item);

            if (result.Status == ResultStatusCode.OK)
            {
                return Created(string.Format("/v1/companies/{0}", result.ValueAsSuccess.Companies.Id), result.ValueAsSuccess);
            }

            return ResponseResult(result);
        }

        /// <summary>
        /// Atualizar uma empresa
        /// </summary>
        /// <param name="company_id">ID da empresa</param>
        /// <param name="item">Dados da empresa</param>
        /// <returns>Todos os detalhes de uma empresa</returns>
        /// <response code="200">Sucesso na atualização da empresa</response>
        /// <response code="400">API Key da conta não é valida</response>
        /// <response code="400">Algum parametro informado não é válido</response>
        [Route("{company_id}")]
        [HttpPut]
        [ResponseType(typeof(CompanySingleResource))]
        public async Task<IHttpActionResult> Put(string company_id, CompanyResource item)
        {
            var account = this.ApiKey;
            if (account == null || account.Description.IndexOf("api.nfe.io") < 0)
                return BadRequest("account api key is not valid");

            var account_id = account.ParentId;

            return ResponseResult(await _service.Save(account_id, company_id, item));
        }

        /// <summary>
        /// Excluir uma empresa
        /// </summary>
        /// <param name="company_id">ID da empresa</param>
        /// <returns>Todos os detalhes de uma empresa</returns>
        /// <response code="200">Sucesso na remoção da empresa</response>
        /// <response code="400">API Key da conta não é valida</response>
        /// <response code="400">Algum parametro informado não é válido</response>
        /// <response code="404">empresa não foi encontrada</response>
        [Route("{company_id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(string company_id)
        {
            var account = this.ApiKey;
            if (account == null || account.Description.IndexOf("api.nfe.io") < 0)
                return BadRequest("account api key is not valid");

            var account_id = account.ParentId;

            return ResponseResult(await _service.Delete(account_id, company_id));
        }

        /// <summary>
        /// Upload do certificado digital da empresa usando o codificação multipart/form-data.
        /// </summary>
        /// <param name="company_id">ID da empresa</param>
        /// <returns>Todos os detalhes de uma empresa</returns>
        /// <response code="200">Sucesso na atualização da empresa</response>
        /// <response code="400">API Key da conta não é valida</response>
        /// <response code="400">Algum parametro informado não é válido</response>
        /// <response code="404">Empresa não foi encontrada</response>
        /// <response code="415">Nenhum arquivo foi encontrado na requisição</response>
        [Route("{company_id}/certificate")]
        [HttpPost]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> Post(string company_id)
        {
            var account = this.ApiKey;
            if (account == null || account.Description.IndexOf("api.nfe.io") < 0)
                return BadRequest("account api key is not valid");

            var account_id = account.ParentId;

            if (Request.Content.IsMimeMultipartContent() == false)
                return StatusCode(HttpStatusCode.UnsupportedMediaType);

            var provider = await Request.Content.ReadAsMultipartAsync(new MultipartFormDataStreamProvider(Path.GetTempPath()));
            var files = provider.FileData;
            if (files.Any() == false)
                return BadRequest("certificate file not found");

            var filePath = files.First().LocalFileName;
            var password = provider.FormData["password"];

            return ResponseResult(await _service.SaveCertificate(_certificateService, account_id, company_id, filePath, password));
        }
    }
}