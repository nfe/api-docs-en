/// <summary>
/// Pessoas Juridicas
/// </summary>
[Authorize]
[RoutePrefix("v1/companies/{company_id}/legalpeople")]
public class LegalPeopleController
{
    /// <summary>
    /// Listar as pessoas jurídicas ativas
    /// </summary>
    /// <param name="company_id">ID da empresa</param>
    /// <returns>Todas as pessoas jurídicas</returns>
    /// <response code="200">Sucesso na requisição</response>
    /// <response code="400">API Key da empresa não é valida</response>
    [Route("")]
    [HttpGet]
    [ResponseType(typeof(LegalPersonResource))]
    public async Task<IHttpActionResult> Get(string company_id)
    { }

    /// <summary>
    /// Obter os detalhes de uma pessoa jurídica
    /// </summary>
    /// <param name="company_id">ID da empresa</param>
    /// <param name="id">ID da pessoa juridica</param>
    /// <returns>Todas os detalhes da pessoa jurídica</returns>
    /// <response code="200">Sucesso na requisição</response>
    /// <response code="400">API Key da empresa não é valida</response>
    [Route("{id}")]
    [HttpGet]
    [ResponseType(typeof(LegalPersonSingleResource))]
    public async Task<IHttpActionResult> Get(string company_id, string id)
    { }

    /// <summary>
    /// Criar uma pessoa jurídica
    /// </summary>
    /// <param name="company_id">ID da empresa</param>
    /// <param name="item">Dados da pessoa jurídica</param>
    /// <returns>Todas os detalhes da pessoa jurídica</returns>
    /// <response code="200">Sucesso na criação da pessoa jurídica</response>
    /// <response code="400">API Key da empresa não é valida</response>
    /// <response code="400">Algum parametro informado não é válido</response>
    [Route("")]
    [HttpPost]
    [ResponseType(typeof(LegalPersonSingleResource))]
    public async Task<IHttpActionResult> Post(string company_id, LegalPersonResource item)
    { }

    /// <summary>
    /// Atualizar uma pessoa jurídica
    /// </summary>
    /// <param name="company_id">ID da empresa</param>
    /// <param name="id">ID da pessoa jurídica</param>
    /// <param name="item">Dados da pessoa jurídica</param>
    /// <returns>Todos os detalhes de uma pessoa jurídica</returns>
    /// <response code="200">Sucesso na atualização da pessoa jurídica</response>
    /// <response code="400">API Key da empresa não é valida</response>
    /// <response code="400">Algum parametro informado não é válido</response>
    [Route("{id}")]
    [HttpPut]
    [ResponseType(typeof(LegalPersonSingleResource))]
    public async Task<IHttpActionResult> Put(string company_id, string id, LegalPersonResource item)
    { }

    /// <summary>
    /// Excluir uma pessoa jurídica
    /// </summary>
    /// <param name="company_id">ID da empresa</param>
    /// <param name="id">ID da pessoa jurídica</param>
    /// <returns>Todos os detalhes de uma pessoa jurídica</returns>
    /// <response code="200">Sucesso na remoção da pessoa jurídica</response>
    /// <response code="400">API Key da empresa não é valida</response>
    /// <response code="400">Algum parametro informado não é válido</response>
    /// <response code="404">Pessoa jurídica não foi encontrada</response>
    [Route("{id}")]
    [HttpDelete]
    public async Task<IHttpActionResult> Delete(string company_id, string id)
    { }
}