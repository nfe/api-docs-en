/// <summary>
/// Webhooks da conta
/// </summary>
[Authorize]
[RoutePrefix("v1/hooks")]
public class WebhooksController
{
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
    { }

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
    { }

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
    { }

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
    { }

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
    { }
}