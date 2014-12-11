/// <summary>
/// Pessoas Físicas
/// </summary>
[Authorize]
[RoutePrefix("v1/companies/{company_id}/naturalpeople")]
public class NaturalPeopleController
{
    /// <summary>
    /// Listar as pessoas físicas ativas
    /// </summary>
    /// <param name="company_id">ID da empresa</param>
    /// <returns>Todas as pessoas físicas</returns>
    /// <response code="200">Sucesso na requisição</response>
    /// <response code="400">API Key da empresa não é valida</response>
    [Route("")]
    [HttpGet]
    [ResponseType(typeof(NaturalPersonCollectionResource))]
    public async Task<IHttpActionResult> Get(string company_id)
    { }

    /// <summary>
    /// Obter os detalhes de uma pessoa física
    /// </summary>
    /// <param name="company_id">ID da empresa</param>
    /// <param name="id">ID da pessoa física</param>
    /// <returns>Todas os detalhes da pessoa física</returns>
    /// <response code="200">Sucesso na requisição</response>
    /// <response code="400">API Key da empresa não é valida</response>
    [Route("{id}")]
    [HttpGet]
    [ResponseType(typeof(NaturalPersonResource))]
    public async Task<IHttpActionResult> Get(string company_id, string id)
    { }

    /// <summary>
    /// Criar uma pessoa física
    /// </summary>
    /// <param name="company_id">ID da empresa</param>
    /// <param name="item">Dados da pessoa física</param>
    /// <returns>Todas os detalhes da pessoa física</returns>
    /// <response code="200">Sucesso na criação da pessoa física</response>
    /// <response code="400">API Key da empresa não é valida</response>
    /// <response code="400">Algum parametro informado não é válido</response>
    [Route("")]
    [HttpPost]
    [ResponseType(typeof(NaturalPersonSingleResource))]
    public async Task<IHttpActionResult> Post(string company_id, NaturalPersonResource item)
    { }

    /// <summary>
    /// Atualizar uma pessoa física
    /// </summary>
    /// <param name="company_id">ID da empresa</param>
    /// <param name="id">ID da pessoa física</param>
    /// <param name="item">Dados da pessoa física</param>
    /// <returns>Todos os detalhes de uma pessoa física</returns>
    /// <response code="200">Sucesso na atualização da pessoa física</response>
    /// <response code="400">API Key da empresa não é valida</response>
    /// <response code="400">Algum parametro informado não é válido</response>
    [Route("{id}")]
    [HttpPut]
    [ResponseType(typeof(NaturalPersonSingleResource))]
    public async Task<IHttpActionResult> Put(string company_id, string id, NaturalPersonResource item)
    { }

    /// <summary>
    /// Excluir uma pessoa física
    /// </summary>
    /// <param name="company_id">ID da empresa</param>
    /// <param name="id">ID da pessoa física</param>
    /// <returns>Todos os detalhes de uma pessoa física</returns>
    /// <response code="200">Sucesso na remoção da pessoa física</response>
    /// <response code="400">API Key da empresa não é valida</response>
    /// <response code="400">Algum parametro informado não é válido</response>
    /// <response code="404">Pessoa física não foi encontrada</response>
    [Route("{id}")]
    [HttpDelete]
    public async Task<IHttpActionResult> Delete(string company_id, string id)
    { }
}