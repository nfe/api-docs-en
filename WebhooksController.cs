using Conube.Domain;
using Conube.Infrastructure;
using Fepin.Persistence;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Conube.App.Api.Frontend.Controllers
{
    /// <summary>
    /// Webhooks da conta
    /// </summary>
    [Authorize]
    [RoutePrefix("v1/hooks")]
    public class WebhooksController : BaseAccountController
    {
        private readonly AccountApplicationService _service;

        /// <summary>
        /// Construtor padrão
        /// </summary>
        /// <param name="accountRepository">Repositório de acesso as Empresas</param>
        /// <param name="accountService">Serviço base para acesso as empresas</param>
        public WebhooksController(
            IRepository<Account> accountRepository,
            AccountApplicationService accountService)
            : base(accountRepository)
        {
            _service = accountService;
        }

        /// <summary>
        /// Listar os webhooks da conta
        /// </summary>
        /// <returns>Todas os webhooks</returns>
        /// <response code="200">Sucesso na requisição</response>
        /// <response code="400">API Key da empresa não é valida</response>
        [Route("")]
        [HttpGet]
        [ResponseType(typeof(WebhookCollectionResource))]
        public async Task<IHttpActionResult> Get()
        {
            var account = this.ApiKey;
            if (account == null || account.Description.IndexOf("api.nfe.io") < 0)
                return BadRequest("account api key is not valid");

            return ResponseResult(await _service.AllWebhooks(account.ParentId));
        }

        /// <summary>
        /// Obter os detalhes de um webhook da conta
        /// </summary>
        /// <param name="hook_id">ID do webhook</param>
        /// <returns>Todos os detalhes do webhook</returns>
        /// <response code="200">Sucesso na atualização do webhook</response>
        /// <response code="400">API Key da conta não é valida</response>
        /// <response code="400">Algum parametro informado não é válido</response>
        /// <response code="404">Webhook não foi encontrada</response>
        [Route("{hook_id}")]
        [HttpGet]
        [ResponseType(typeof(WebhookSingleResource))]
        public async Task<IHttpActionResult> Get(long hook_id)
        {
            var account = this.ApiKey;
            if (account == null || account.Description.IndexOf("api.nfe.io") < 0)
                return BadRequest("account api key is not valid");

            return ResponseResult(await _service.OneWebhook(account.ParentId, hook_id));
        }

        /// <summary>
        /// Criar um webhook da conta
        /// </summary>
        /// <param name="item">Dados do webhook</param>
        /// <returns>Todas os detalhes do webhook</returns>
        /// <response code="200">Sucesso na criação do webhook</response>
        /// <response code="400">API Key da conta não é valida</response>
        /// <response code="400">Algum parametro informado não é válido</response>
        /// <response code="409">Webhook duplicado</response>
        [Route("")]
        [HttpPost]
        [ResponseType(typeof(WebhookSingleResource))]
        public async Task<IHttpActionResult> Post(WebhookResource item)
        {
            var account = this.ApiKey;
            if (account == null || account.Description.IndexOf("api.nfe.io") < 0)
                return BadRequest("account api key is not valid");

            var result = await _service.CreateWebhoook(account.ParentId, item);

            if (result.Status == ResultStatusCode.OK)
            {
                return CreatedAtRoute("WebhooksDefaultApi", new { controller = "webhooks", id = result.ValueAsSuccess.Hooks.Id }, result.ValueAsSuccess);
            }

            return ResponseResult(result);
        }

        /// <summary>
        /// Atualizar um webhook da conta
        /// </summary>
        /// <param name="hook_id">ID do webhook</param>
        /// <param name="item">Dados do webhook</param>
        /// <returns>Todos os detalhes do webhook</returns>
        /// <response code="200">Sucesso na atualização do webhook</response>
        /// <response code="400">API Key da conta não é valida</response>
        /// <response code="400">Algum parametro informado não é válido</response>
        /// <response code="404">Webhook ou Conta não foi encontrada</response>
        [Route("{hook_id}")]
        [HttpPut]
        [ResponseType(typeof(WebhookSingleResource))]
        public async Task<IHttpActionResult> Put(long hook_id, WebhookResource item)
        {
            var account = this.ApiKey;
            if (account == null || account.Description.IndexOf("api.nfe.io") < 0)
                return BadRequest("account api key is not valid");

            return ResponseResult(await _service.UpdateWebhook(account.ParentId, hook_id, item));
        }

        /// <summary>
        /// Excluir um webhook da conta
        /// </summary>
        /// <param name="hook_id">ID do webhook</param>
        /// <response code="200">Sucesso na remoção do webhook</response>
        /// <response code="400">API Key da conta não é valida</response>
        /// <response code="400">Algum parametro informado não é válido</response>
        /// <response code="404">Webhook ou Conta não foi encontrada</response>
        [Route("{hook_id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(long hook_id)
        {
            var account = this.ApiKey;
            if (account == null || account.Description.IndexOf("api.nfe.io") < 0)
                return BadRequest("account api key is not valid");

            return ResponseResult(await _service.DeleteWebhook(account.ParentId, hook_id));
        }
    }
}